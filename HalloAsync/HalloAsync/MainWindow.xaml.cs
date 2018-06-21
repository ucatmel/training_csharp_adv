using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;

                Thread.Sleep(50);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    //pb1.Value = i + 1;
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);

                    Thread.Sleep(50);
                }
                btn.Dispatcher.Invoke(() => btn.IsEnabled = true);
            }
            );
        }

        private void StartTaskTS(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            TaskScheduler ts = TaskScheduler.FromCurrentSynchronizationContext();

            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    //pb1.Value = i + 1;
                    Task.Factory.StartNew(() => pb1.Value = i, cts.Token, TaskCreationOptions.None, ts);
                    //Console.WriteLine(i);
                    Thread.Sleep(50);
                    if (cts.IsCancellationRequested)
                    {
                        // cleanup
                        break;
                    }
                }
                Task.Factory.StartNew(() => btn.IsEnabled = true, CancellationToken.None, TaskCreationOptions.None, ts);
            });

        }

        CancellationTokenSource cts = null;
        private void AbortTask(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }

        }

        private async void StartTaskAsync(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            cts = new CancellationTokenSource();
            for (int i = 0; i <= 100; i++)
            {
                pb1.Value = i;

                try
                {
                    await Task.Delay(50, cts.Token);
                }
                catch (TaskCanceledException)
                {

                    MessageBox.Show("Task wurde erfolgreich abgebrochen");
                }


                if (cts.IsCancellationRequested)
                {
                    // cleanup
                    break;
                }

            }
            btn.IsEnabled = true;
        }

        private async void StartAsyncReadDB(object sender, RoutedEventArgs e)
        {
            string conString = "Server=.;Database=Northwind;Trusted_Connection=true;";
            cts = new CancellationTokenSource();
            pb1.IsIndeterminate = true;
            try
            {
                using (var con = new SqlConnection(conString))
                {
                    await con.OpenAsync(cts.Token);

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "Select COUNT(*) FROM Employees; WAITFOR DELAY '00:00:05'";

                        var result = await cmd.ExecuteScalarAsync(cts.Token);
                        MessageBox.Show($"Es sind {result} Employees in der DB");
                    }
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exeception: {ex.Message}");
            }
            pb1.IsIndeterminate = false;
        }

        private async void StartAlt(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            //MessageBox.Show($"Wert von alter, langsamer Methode: {GetWertvonAlterLangsamerFunktion()}");
            MessageBox.Show($"Wert von alter, langsamer Methode: { await GetWertvonAlterLangsamerFunktionAsync(cts.Token)}");

        }


        public long GetWertvonAlterLangsamerFunktion()
        {
            Thread.Sleep(3000);
            return 97392 * DateTime.Now.Millisecond;
        }

        public Task<long> GetWertvonAlterLangsamerFunktionAsync()
        {
            return GetWertvonAlterLangsamerFunktionAsync(CancellationToken.None);
        }
        public Task<long> GetWertvonAlterLangsamerFunktionAsync(CancellationToken ct)
        {
            return Task.Run(() => GetWertvonAlterLangsamerFunktion(),ct);
        }
    }
}
