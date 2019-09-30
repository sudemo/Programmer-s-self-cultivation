using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace regsetting
{
    class Program
    {
        static void Main(string[] args)
        {
            RegHelper rh = new RegHelper();
            rh.ModifyReg();
            Console.ReadKey();
        }
    }
}
