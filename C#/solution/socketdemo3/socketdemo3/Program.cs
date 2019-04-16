using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//导入的命名空间
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {

        static void Main(string[] args)
        {
            //创建一个Socket
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //连接到指定服务器的指定端口
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.connect.aspx
            try
            {
                socket.Connect("localhost", 4530);


                Console.WriteLine("connect to the server");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.Read();
            }
            var buffer = new byte[1024];//设置一个缓冲区，用来保存数据
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.beginreceive.aspx
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) =>
            {
                //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
                var length = socket.EndReceive(ar);
                //读取出来消息内容
                var message = Encoding.Unicode.GetString(buffer, 0, length);
                //显示消息
                Console.WriteLine(message);

            }), null);



        }


    }
}