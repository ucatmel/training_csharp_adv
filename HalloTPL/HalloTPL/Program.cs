using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zaehle();
            //Zaehle();
            //Zaehle();
            //Zaehle();


            //Parallel.Invoke(Zaehle, Zaehle, Zaehle, Zaehle, Zaehle, Zaehle, () => Console.WriteLine("HALLO"));
            //Parallel.For(0, 100000, (i) => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            Task t1 = new Task(() =>
             {
                 Console.WriteLine("T1 gestartet");
                 Thread.Sleep(4000);
                 throw new InvalidOperationException("Muuuh");
                 Console.WriteLine("T1 fertig");
             });

            t1.ContinueWith(t =>
            {
                Console.WriteLine($"Fehler in T1: {t1.Exception.InnerExceptions.First().Message}");
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);

            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 startet Berechnung");
                Thread.Sleep(600);

                Console.WriteLine("T2 Berechnung fertig");
                return 87458189;

            });
            t1.Start();
            t2.Start();

            Task.WhenAll(t1, t2).ContinueWith(t => { Console.WriteLine($"T1 & T2 sind fertig {t2.Result}"); });
            //Console.WriteLine(t2.Result);

            Console.WriteLine("Ende");
            Console.ReadKey();
        }

        private static void Zaehle()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
