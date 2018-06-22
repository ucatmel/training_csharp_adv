using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFord.WetterFrosch5000
{
    public class WetterFrosch : IWetterService
    {

        public int GetTemp()
        {
            return new Random().Next(-10, 40);
        }

        public int GetTemperature(DateTime date)
        {
            return GetTemp() + 5;
        }

        public string GetWeather(DateTime date)
        {
            return "Schön! (sponsored by Binford)";
        }
    }
}
