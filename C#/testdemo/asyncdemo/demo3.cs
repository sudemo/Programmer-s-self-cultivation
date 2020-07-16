using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Delay
{
    class Program
    {/*
        static async Task Main(string[] args)
        {
            Simple ds = new Simple();
            await ds.DoRun();
            Console.Read();
        }
    }
    class Simple
    {
        Stopwatch sw = new Stopwatch();
        public async Task DoRun()
        {
            Console.WriteLine("Caller: Before call");
            await ShowDealyAsync();
            //Task.WaitAll(ShowDealyAsync());
            Console.WriteLine("Caller: After call");
        }

        private async Task ShowDealyAsync()
        {
            sw.Start();
            Console.WriteLine("  Before Delay: {0}", sw.ElapsedMilliseconds);
             await Task.Delay(5000);      //执行到await表达式时，立即返回到调用方法，等待5秒后执行后续部分
            Console.WriteLine(" After Delay : {0} ", sw.ElapsedMilliseconds);//后续部分
        }*/
    }
}