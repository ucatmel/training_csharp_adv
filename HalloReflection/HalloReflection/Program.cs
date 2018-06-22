using Contracts;
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


            Type myCalcType = ass.GetType("Calculator.Calc");
            var calc = Activator.CreateInstance(myCalcType);

            MethodInfo mi = myCalcType.GetRuntimeMethod("Sum",new[] { typeof(int), typeof(int) });


            var result= mi.Invoke(calc, new object[] { 5, 6 });
            Console.WriteLine(result);

            if (result is int i)
                Console.WriteLine($"Jo ist int: {i:000}");

            // -------------------------------- Wetter Service ------------------------------------------
            Console.WriteLine("-------------------------------- Wetter Service ------------------------------------------");

            
            var wetterAss = Assembly.LoadFile(@"C:\Users\ppedv\Source\Repos\training_csharp_adv\BindFord.WetterFrosch5000\BindFord.WetterFrosch5000\bin\Debug\BindFord.WetterFrosch5000.dll");
            // nimm die erstbeste Klasse die IWetterService Implementiert hat.
            var wetterMitInterface = wetterAss.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IWetterService)));

            if (wetterMitInterface != null)
            {
                IWetterService wetter = Activator.CreateInstance(wetterMitInterface) as IWetterService;
                Console.WriteLine(wetter.GetWeather(DateTime.Now));
                Console.WriteLine(wetter.GetTemperature(DateTime.Now));
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
