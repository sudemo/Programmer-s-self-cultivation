using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace PLCCommunicationLibrary.SocketBase
{
    class SocketBase
    {
        public Socket PLCClient; //字段
        private bool ConnectionStatus;

        
        public ReturnStatus<Socket> CreatandConnect(IPEndPoint endpoint,int timeout)//创建并连接socket
        {
            
            PLCClient = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            try
               
            {   
                timeout = 100;
                PLCClient.Connect(endpoint);
                //ReturnStatus<Socket> ReturnStatus = new ReturnStatus();
                //ReturnStatus.CreateSuccessResult
              
                return ReturnStatus.CreatSuccessStatus(PLCClient);
            }
            catch (Exception e)
            {
                PLCClient?.Close();
                //log
                return new ReturnStatus<Socket>(e.Message);
            }           
        }
    }
}
