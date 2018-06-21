using System;
using System.Collections.Generic;
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
    }
}
