using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFord.WetterFrosch5000
{
    public class WetterFrosch
    {

        public int GetTemp()
        {
            return new Random().Next(-10, 40);
        }

    }
}
