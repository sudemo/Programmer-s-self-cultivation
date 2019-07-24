using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Net.Sockets;


namespace PLCCommunicationKit.SocketBaseKit
{

    //暂时，发送接收的返回值不做处理，用原始的数据
    class SocketBase
    {
        public static Socket PLCClient ; //字段
        //private bool ConnectionStatus;


        #region creat socket client
        // ReturnStatus<Socket> CreatandConnect(string ip, int port)//创建并连接socket,此client
        public static bool  initSocketBase(string ip="192.168.0.1", int port=102) //这两个参数后续可以从配置文件读取
        {
             PLCClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //timeout = 100;这里无法设置连接的超时时间，可能会造成该线程卡住20s-40s(在地址错误的时候）
                //PLCClient.ReceiveTimeout = 100;
                PLCClient.Connect(ip, port);
                return true;            
            }
            catch (Exception e)
            {
                PLCClient?.Close();
                //LogHelper.logerror.Error(e);
                Logger.Error("init socket failed " + e.ToString());
                return false;
                //throw;
                //log
                //Console.Write(e.Message);
                //Console.ReadKey();
                //return new ReturnStatus<Socket>(e.Message);
            }
        }
        #endregion
        #region read send
        public static int SocketSend(byte[] arg)
        {
            try
            {
                int ret = PLCClient.Send(arg);
                return ret;
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);               
                return 0;              
            }
            //默认返回的是发送的字节数
            
                
            
            
            
            //return ReturnStatus.CreatSuccessStatus<int>();
        }
        public static byte[] SocketRec()
        {
            byte[] receiveBuffer = new byte[1024];
            try
            {
                PLCClient.ReceiveTimeout = 3000;
                bool aa=PLCClient.Connected;
                    int RecCount = PLCClient.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);
                //Console.WriteLine("{0} is {1}", receiveBuffer, receiveBuffer.Length);
               
                byte[] recMsg = receiveBuffer.Take(RecCount).ToArray();
                //Console.WriteLine();
                    return recMsg;              
            }
            catch (Exception ex)
            {

                LogHelper.Infor("rec error",ex);
                return receiveBuffer;
            }
            
            //Console.Write(Encoding.UTF8.GetString(receiveBuffer));
           
            
        }
        #endregion




        /// <summary>
        /// 是否是长连接的状态
        /// </summary>
        protected bool isPersistentConn = false;         // 是否处于长连接的状态
        /// <summary>
        /// 交互的混合锁
        /// </summary>
        //protected SimpleHybirdLock InteractiveLock;      // 一次正常的交互的互斥锁
        /// <summary>
        /// 当前的socket是否发生了错误
        /// </summary>
        protected bool IsSocketError = false;            // 指示长连接的套接字是否处于错误的状态

       

    }
}
