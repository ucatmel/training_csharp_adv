using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HalloReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 5;

            Type t = zahl.GetType();

            var dings = Activator.CreateInstance(t);

            var ass = Assembly.LoadFile(@"C:\Users\ppedv\Source\Repos\training_csharp_adv\Calculator\Calculator\bin\Debug\Calculator.dll");

            foreach (var item in ass.GetTypes())
            {
                Console.WriteLine(item.FullName);
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
