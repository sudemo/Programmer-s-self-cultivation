using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MTW
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            MTWFile al = new MTWFile("test");
            //al.Write("this is a test");
            Parallel.For(0, 100, x =>
            {
                al.Write(x.ToString());
               // Console.WriteLine(x);
            });
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds);
            Console.ReadKey();
        }

       
    }
}
