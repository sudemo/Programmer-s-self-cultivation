using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;

namespace httpclientdemo3
{
    class Program
    {
         static  void Main(string[] args)
        {
            var sss = db();
            Console.WriteLine(sss.IsCompleted);
            Stopwatch st = new Stopwatch();
            st.Start();
            while (!sss.IsCompleted)
            {
                //Thread.Sleep(100);


                Console.WriteLine(st.ElapsedTicks);
                Console.WriteLine(sss.IsCompleted);
            }
            Console.WriteLine(st.ElapsedTicks);
            Console.WriteLine(sss);
                Console.ReadKey();
        }

        async static Task<string> db()
        {
            string s1 = "http://www.baidu.com/";
            string s2 = "http://www.baidu1.com/";
            HttpClient ht = new HttpClient();
            //Task.Delay(10).Wait();
            var ss = await ht.GetStringAsync(s1);
            //Console.WriteLine(ss);
            return ss;
            //Console.ReadKey();
        }

    }
}
