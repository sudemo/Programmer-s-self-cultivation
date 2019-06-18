using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using logbaseQuene;

namespace demo1 //另写一个日志程序，线程安全，利用队列
{
    class program
    {
        public static void Main()
        {
            Logger.Write("hello");
            //System.Threading.Tasks.Parallel.For(0, 100, x =>
            //    {
            //        Logger.Write(x.ToString());
            //        Console.WriteLine(x);
            //    });
        }
    }
}