using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ss = "0.1123134553456789345678906";
            double sa ;
            double.TryParse(ss, out sa);
            //sa=double.Parse(ss);

        }
    }
}
