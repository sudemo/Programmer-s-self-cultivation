using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class calculator
    {
        public int fact(int num)
        {
            int ret;
            if (num == 1)
                return 1;
            else
                ret = fact(num - 1) * num;
            return ret;
         }


        static void Main(string[] args)
        {
            calculator n = new calculator();
            //qoute method
            //while true
            
                int c = Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("{0}的阶乘是：{1}",c, n.fact(c));
                Console.ReadKey();
        }  
    }
}
