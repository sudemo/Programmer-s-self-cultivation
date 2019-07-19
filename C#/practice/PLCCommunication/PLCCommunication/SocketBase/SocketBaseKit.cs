using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace PLCCommunicationLibrary.SocketBase
{
    class SocketBaseKit
    {
        public Socket PLCClient; //字段
        private bool ConnectionStatus;

        
        public ReturnStatus<Socket> CreatandConnect(string ip, int port)//创建并连接socket,此client
        {
            
            PLCClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            try
               
            {
                //timeout = 100;这里无法设置连接的超时时间，可能会造成该线程卡住20s-40s(在地址错误的时候）
                //PLCClient.ReceiveTimeout = 100;
                PLCClient.Connect(ip,port);
                //Console.WriteLine("ok1{0}",ReturnStatus.CreatSuccessStatus(PLCClient));
                return ReturnStatus.CreatSuccessStatus(PLCClient);
            }
            catch (Exception e)
            {
                PLCClient?.Close();
                //log
                Console.Write(new ReturnStatus<Socket>(e.Message));
                Console.ReadKey();
                return new ReturnStatus<Socket>(e.Message);
            }           
        }

        public ReturnStatus SocketSend(byte[] arg)
        {
            PLCClient.Send(arg);
            return ReturnStatus.CreatSuccessStatus<bool>();
        }
       
        public ReturnStatus SocketRec()
        {
            byte[] receiveBuffer = new byte[1024];
            PLCClient.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
            
            //Console.Write(Encoding.UTF8.GetString(receiveBuffer));
            return ReturnStatus.CreatSuccessStatus<bool>();
        }

    }
}
