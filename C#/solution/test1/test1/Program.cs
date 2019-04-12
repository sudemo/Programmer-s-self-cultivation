using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        
    }

    class gump
    {
        public double Square(ref double x)
        {
            x = x * x;
            return x;
        }
    }
    class TestApp
    {
        public static void Main()
        {
            gump doit = new gump();
            double a = 3;
            double b = 0;
            MessageBox.Show(a.ToString());
            //Console.WriteLine("Before a={0},b={1}", a, b);
            b = doit.Square(ref a);
            //Console.WriteLine("After a={0},b={1}", a, b);
            MessageBox.Show(a.ToString(),"After"); //为什么顺序是反着的呢？
            //.ReadLine();
            //Console.ReadKey();
        }
    }
}
