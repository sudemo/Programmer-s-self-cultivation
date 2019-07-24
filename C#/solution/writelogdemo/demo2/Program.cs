using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;
using logbaseQuene;

namespace demo1 //另写一个日志程序，线程安全，利用队列
{
    class program
    {
        public static void Main()
        {
            //Logger2.Write("hello");
            //try
            //{
            //    string a = "ff";
            //    int b = Convert.ToInt32(a);


            //}
            //catch (Exception ex)
            //{

            //    Logger2.Write(ex.Message);

            //}
            Stopwatch st = new Stopwatch();
            st.Start();
            string mg = "handshake error, plc init failed 在 System.Net.Sockets.Socket.Connect(IPAddress[] addresses, Int32 port)在 System.Net.Sockets.Socket.Connect(String host, Int32 port)在 PLCCommunicationKit.SocketBaseKit.SocketBase.initSocketBase(String ip, Int32 ";
            System.Threading.Tasks.Parallel.For(0, 1000, x =>
                {
                    
                    Logger2.Infor("test"+x.ToString());
                    Logger2.Error(mg + x.ToString());
                    //Console.WriteLine(x);

                });
            st.Stop();
            Console.WriteLine(st.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}