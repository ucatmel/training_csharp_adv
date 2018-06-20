using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloLinq
{
    class DelegateExplanatiob
    {
        public DelegateExplanatiob()
        {
            // Delegate Pointer of Function, with Anonymous Function
            Action meinDeleaction = delegate () { Console.WriteLine("Hello"); };
            Action meinDeleactionAno = () => Console.WriteLine("Hello");

            Action<string> meinDeleactionwithParaAno = (string txt) => { Console.WriteLine(txt); };
            Action<string> meinDeleactionwithParaAno2 = (txt) => Console.WriteLine(txt);


            Func<int, int, long> meinCalcAno = (int a, int b) => { return a + b; };
            Func<int, int, long> meinCalcAno2 = ( a, b) => a + b; 



        }

    }
}
