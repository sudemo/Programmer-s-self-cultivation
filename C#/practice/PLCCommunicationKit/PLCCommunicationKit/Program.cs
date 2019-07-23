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
        static byte[] aaa = new byte[] { 0 };
        static void Main(string[] args)
        {
           // SocketBase.SocketBase sk = new SocketBase.SocketBase();
            //SocketBase sk = new SocketBase();
            //sk.initSocketBase();
            //skd = new Socket();
            //Console.Write("ok");
            //sk.CreatandConnect("172.16.8.204", 102);
            //string ina = Console.ReadLine();
            //Console.ReadKey();
            //string ina = "sas";
            //byte[] by = Encoding.UTF8.GetBytes(ina);
            //Socket soc = null;
            //sk.SocketSend(by);
            //Thread.Sleep(100);
            //Console.WriteLine(sk.SocketRec());
            //Console.ReadKey();
            SiemensS7Net s7 = new SiemensS7Net();
            bool ret;
            //LogHelper.Infor("hello starting siemens");
            //LogHelper.Infor("s");
            LogHelper.Infor("enter init plc");
            ret = s7.init_plc_Connect();
            //LogHelper.Infor("init plc connect successful");
            //Console.Write(ret);
            
            s7.writeByteData(aaa,2,7,8,4);
            //Console.ReadKey();
        }

    }
}
