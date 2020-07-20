using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncdemo2
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Thread.Sleep(1000);
                //int step = 0;
                for (int step = 0 ; step < 3; step++)
                {
                    Console.WriteLine("inside for");
                    switch (step)
                    {
                        case 0:
                            {
                                Console.WriteLine(step);
                            }
                            break;
                        case 1:
                            {
                                Console.WriteLine(step);
                            }
                            continue;
                        case 2:
                            {
                                Console.WriteLine(step);
                            }
                            break;

                    }
                }



            }




            #region MyRegion
            /*new Task(() =>
               {
                   while (true)
                   {
                       Thread.Sleep(100);
                       //bool shutdowncmd = SiemensHelper.Instance.ReadSignal(ref m_TCPIPClient[0], 25, 5, 0x84, 1);
                       bool shutdowncmd = myadd();
                       if (shutdowncmd)
                       {
                           break;
                           //Console.WriteLine("shutdown"); 
                       }
                       Console.WriteLine("shutdown");
                   }
                   Console.WriteLine("hello this is end");
                   //Process.Start("c:/windows/system32/shutdown.exe", "-s -t 10");
               }).Start();*/ 
            #endregion

            //CallWithAsync();
            //Task.Delay(1000);
            //var s=  Greeting("alice");
            //Thread.Sleep(10000);
            Console.WriteLine("last");
            Console.ReadKey();
        }

        public static bool myadd()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
            }
            return false;
        }

        async static Task CallWithAsync()
        {
            string res = await GreetingSomebdAsync("neo");
            Console.WriteLine(res);
            Console.ReadKey();
        }

        static Task<String> GreetingSomebdAsync(string name)
        {
            return Task.Run<string>(()=> { return Greeting(name); } );
        }
        static string Greeting(string name)
        {
            //Task.Delay(1000).Wait();
            //return $"hello,{name}";
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("async  " + name +i);
                Task.Delay(10);
            }
           
            return name;
        }

    }
}
