using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace socketdemo4client
{
    class Program
    {
        Socket client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp); //实例化客户端的socket
        
        public  void sendmsg(byte[] buffer)
        {
            while (true)
            {
                var msg = "recv:" + Console.ReadLine();
                var encodemsg = Encoding.Unicode.GetBytes(msg);
                //var outputBuffer = Encoding.Unicode.GetBytes(message);
                client.Send(encodemsg);
                
            }
        }





        static void Main(string[] args)
        {
        }
    }
}
