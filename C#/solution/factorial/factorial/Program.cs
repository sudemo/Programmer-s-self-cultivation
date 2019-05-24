using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace factorial
{
    class Program
    {
        public static int inta { get; private set; }

        private static long Factorial(int n)
        {
            if (n == 1||n == 0)
                return 1;
            long ret;
            ret = Factorial(n - 1) * n;
            return ret;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            string astr = "hello world";
            string bstr = astr.ToUpperInvariant();
            Console.WriteLine(astr.ToUpper());
            try
            {
                var a = Console.ReadLine();

                int inta = Int32.Parse(a);                                
                Console.WriteLine("not int");
                Console.WriteLine("{0} 的阶乘is {1}", inta, Factorial(inta));
                int ab = 32;
                Console.WriteLine(typeof(int));
                Console.Read();
            }
            catch
            {
                Console.WriteLine("wrong input");
                Console.Read();
            }
        }
    }
}
