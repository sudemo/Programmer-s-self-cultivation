using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    class Program
    {
        private static long Factorial(int n)
        {
            if (n == 1)
                return 1;
            long ret;
            ret = Factorial(n - 1) * n;
            return ret;

        }

        static void Main(string[] args)
        {
           Console.WriteLine( Factorial(12));
            Console.ReadKey();
        }
    }
}
