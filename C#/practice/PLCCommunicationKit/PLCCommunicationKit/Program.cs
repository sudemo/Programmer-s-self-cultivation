using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using PLCCommunicationKit.SocketBaseKit;
using PLCCommunicationKit.Siemens;

namespace PLCCommunicationKit
{
    class Program
    {
        static byte[] aaa = new byte[] { 0x01};
        static void Main(string[] args)
        {
            byte[] readcmdexam = new byte[] { 0x03, 0x00, 0x00, 0x1f, 0x02, 0xf0, 0x80, 0x32, 0x10, 0x00, 0x00, 0x00, 0x1c, 0x00, 0x0e, 0x00 };
            
            SiemensS7Net s7 = new SiemensS7Net();
            bool ret;
            Logger.Infor("enter plc init");
            ret = s7.init_plc_Connect();
            Logger.Infor("init plc ok");
            //s7.writeByteData(aaa, 2, 29, 1, 4);
            //s7.writeByteData(readcmdexam);
            SocketBase.SocketSend(readcmdexam);
            /*SocketBase.initSocketBase();
            byte[] ss = new byte[] { 0x01};
            SocketBase.SocketSend(ss);
            byte[] aa = SocketBase.SocketRec();
            
            //Console.ReadKey();*/

            

            #region 测试
            /* Stopwatch st = new Stopwatch();
               st.Start();
               string ss ="// SocketBase.SocketBase sk = new SocketBase.SocketBase()";


               System.Threading.Tasks.Parallel.For(0, 1000, x =>
               {
                   Logger.Error(ss + x.ToString());
                   Logger.Infor("test" + x.ToString());
                   //Console.WriteLine(x);

               });
               st.Stop();
               Console.WriteLine(st.ElapsedMilliseconds);
               Console.ReadKey();*/
            #endregion
        }

    }
}
