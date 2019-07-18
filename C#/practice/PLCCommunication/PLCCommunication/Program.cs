using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using PLCCommunicationLibrary.SocketBase;

namespace PLCCommunicationLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // SocketBase.SocketBase sk = new SocketBase.SocketBase();
            SocketBaseKit sk = new SocketBaseKit();
            Console.Write("ok");
            sk.CreatandConnect("172.16.8.204",102);
            string ina = Console.ReadLine();
            byte[] by = Encoding.UTF8.GetBytes(ina);
            Socket soc=null;
            sk.socketsend(soc,by);
            Console.ReadKey();
        }
    }
}
