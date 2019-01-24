using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21内求和
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum=0;
            for (int num = 1;num <21;num++)
            {
                if (num % 3 == 0)
                {
                    sum = sum + num;
                }
            }
            //Console.Write("ans={0}",sum);
            Console.WriteLine($"this number is {sum}");
            Console.ReadKey();
                
         }
    }
}
