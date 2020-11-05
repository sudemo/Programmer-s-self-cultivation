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
            //Console.WriteLine("Hello World!");
            //GenerateFibonacci(1000);
            //st.Stop();
            //TimeSpan ts = st.Elapsed;

            //Console.WriteLine($"fk运行时间：{ts.TotalMilliseconds}");
            maopao();
            Console.ReadKey();
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
            string d2 = (DateTime.Now - d1).ToString();
            Console.Write(d2);
            //Console.ReadLine();
        }


    }

}
