using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime time)
        {
            //if (IsWeekday(time))
            //{
            //    return IsWeekdayOpen(time);
            //}
            //return true;
            return IsWeekdayOpen(time);
        }

        bool IsWeekday(DateTime time)
        {
            return time.DayOfWeek.Equals(DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday);

        }
        

        bool IsWeekdayOpen(DateTime time)
        {
           return  time.TimeOfDay >= new TimeSpan(10,30,0) && time.TimeOfDay < new TimeSpan(19,0,0);
        }
    }
}
