using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch st = new Stopwatch();
            //st.Start();
            Stopwatch st = Stopwatch.StartNew();
            //Console.WriteLine("Hello World!"); //20 ticks 48- 27.34
            //GenerateFibonacci(1000);
            //st.Stop();
            //TimeSpan ts = st.Elapsed;


            maopao();
            //st.Stop();
            //TimeSpan ts = st.Elapsed;
            Console.WriteLine(st.Elapsed.TotalMilliseconds);
            //Console.WriteLine($"core运行时间：{ts.TotalMilliseconds} {ts.Ticks}");
            //Console.ReadLine();
        }

        static IEnumerable<int> GenerateFibonacci(int n)
        {
            if (n >= 1) yield return 1;
            int a = 1, b = 0;
            for (int i = 2; i <= n; ++i)
            {
                int t = b;
                b = a;
                a += t;
                yield return a;
            }
        }

        static void maopao()
        {
            var d1 = DateTime.Now;
            List<int> numbers = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(new Random().Next(0, 999999));
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            //var re = DateTime.Now.Ticks - d1.Ticks;
            //Console.WriteLine($"{DateTime.Now.Ticks} 运行  {d1.Ticks} {re}" );
            //string d2 = (DateTime.Now - d1).ToString();
            //Console.WriteLine(d2);
            //Console.ReadLine();
        }
    }

}
