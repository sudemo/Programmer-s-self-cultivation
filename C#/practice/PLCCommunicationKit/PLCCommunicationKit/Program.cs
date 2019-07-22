using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using PLCCommunicationKit.SocketBaseKit;
using PLCCommunicationKit.Siemens;

namespace PLCCommunicationKit
{
    class Program
    {
        static void Main(string[] args)
        {
           // SocketBase.SocketBase sk = new SocketBase.SocketBase();
            SocketBase sk = new SocketBase();
            //skd = new Socket();
            //Console.Write("ok");
            //sk.CreatandConnect("172.16.8.204", 102);
            string ina = Console.ReadLine();
            Console.ReadKey();
            byte[] by = Encoding.UTF8.GetBytes(ina);
            //Socket soc = null;
            sk.SocketSend(by);
            Thread.Sleep(100);
            Console.WriteLine(sk.SocketRec());
            Console.ReadKey();
            //SiemensS7Net s7 = new SiemensS7Net();
            //bool ret;
            //ret = s7.initConnect();
            //Console.Write(ret);
            //Console.ReadKey();
        }

    }
}
