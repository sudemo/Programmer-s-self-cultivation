using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace multithread
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.Name = "main thread";
            Thread th = new Thread(outy);
            th.Name = "th tthread";
            th.Start();
            Thread th2 = new Thread(outz);
            th2.Name = "th2 tthread";
            th2.Start();

            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
                
            }
            Console.ReadKey();
        }

        static void outy()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y"); 
            }
        }
        static void outz()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("z");
            }
        }
    }
}
