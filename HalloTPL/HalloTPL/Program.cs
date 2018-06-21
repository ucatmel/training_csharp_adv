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
                 Thread.Sleep(400);
                 Console.WriteLine("T1 fertig");
             });

            t1.Start();

            Console.WriteLine("Ende");
            Console.ReadKey();
        }

        private static void Zaehle()
        {
            for (var i = 0; i <10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
