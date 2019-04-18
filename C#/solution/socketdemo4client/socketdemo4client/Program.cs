using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace socketdemo4client
{
    class Program
    {
        
        
        public static void recvmsg(object o)
        {
            var client = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer1 = new byte[1024];
                    var recdata = client.Receive(buffer1);
                    if (recdata == 0)
                    {
                        break;
                    }
                    var str = Encoding.UTF8.GetString(buffer1, 0, recdata);
                    Console.WriteLine("recv from serve:{0}",str);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("rec thread {0}",ex.Message);
                    Console.Read();
                }
            }
        }
        public static void sendmsg(object o)
        {
            var client = o as Socket;
            while (true)
            {
                try
                {
                    Console.WriteLine("plz input:");
                    var strinput = Console.ReadLine();
                    var str = Encoding.Unicode.GetBytes(strinput);
                    client.Send(str);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
            }
        }




        static void Main(string[] args)
        {   try
            {
                Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp); //实例化客户端的socket
                //client.SendTimeout = 120;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint port = new IPEndPoint(ip, 49091);
                //client.ReceiveTimeout = 100*2;
                client.Connect(port);
                

                Thread thread = new Thread(recvmsg);
                thread.IsBackground = true;
                thread.Start(client);

                Thread thread2 = new Thread(sendmsg);
                thread.IsBackground = true;
                thread2.Start(client);

               /* while (true)
                {
                    var buffer = Console.ReadLine();
                    var buff = Encoding.UTF8.GetBytes(buffer);
                    var temp = client.Send(buff);
                    Thread.Sleep(10);
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
