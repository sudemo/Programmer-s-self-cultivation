using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//额外导入的两个命名空间
using System.Net.Sockets;
using System.Net;

namespace SocketServer
{
    class Program
    {
        /// <summary>
        /// Socket Server 演示
        /// 作者：陈希章
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //创建一个新的Socket,这里我们使用最常用的基于TCP的Stream Socket（流式套接字）
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //将该socket绑定到主机上面的某个端口
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.bind.aspx
            socket.Bind(new IPEndPoint(IPAddress.Any, 4530));

            //启动监听，并且设置一个最大的队列长度
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.listen(v=VS.100).aspx
            socket.Listen(4);

            //开始接受客户端连接请求
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.beginaccept.aspx
            socket.BeginAccept(new AsyncCallback((ar) =>
            {
                //这就是客户端的Socket实例，我们后续可以将其保存起来
                var client = socket.EndAccept(ar);

                //给客户端发送一个欢迎消息
                client.Send(Encoding.Unicode.GetBytes("Hi there, I accept you request at " + DateTime.Now.ToString()));
            }), null);


            Console.WriteLine("Server is ready!");
            Console.Read();
        }
    }
}
