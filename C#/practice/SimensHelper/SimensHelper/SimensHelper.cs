using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimensHelper
{
    class TCPIPClient
    {
        public Socket Client;
        private bool NetConnectStaus = false;

        public TCPIPClient()
        {

        }

        static readonly object tcplock = new object();
        private static TCPIPClient instance = null;
        public static TCPIPClient Instance
        {
            get
            {
                lock (tcplock)
                {
                    if (instance == null)
                    {
                        instance = new TCPIPClient();
                    }
                    return instance;
                }
            }
        }

        public bool GetConnectStatus()
        {
            if (Client != null)
            {
                NetConnectStaus = Client.Connected;
            }
            else
            {
                NetConnectStaus = false;
            }
            return NetConnectStaus;
        }

        static readonly object connectlock = new object();
        public bool ConnectNet(string IP = "192.168.83.1", int Port = 102)
        {
            bool bConnectStatus = true;
            if (Client != null && Client.Connected)
            {
                Client.Close();
            }
            else
            {
                try
                {
                    lock (connectlock)
                    {
                        if (Client == null)
                        {
                            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        }

                        Client.Connect(new IPEndPoint(IPAddress.Parse(IP), Port));
                    }
                }
                catch
                {
                    bConnectStatus = false;
                }
            }

            return bConnectStatus;
        }

        public void DisConnectNet()
        {
            if (Client != null)
            {
                Client.Close();
                Client = null;
            }
        }

        static readonly object sendlock = new object();
        public byte[] SendReadData(byte[] strMsg)
        {
            byte[] receiveBuffer = new byte[1024];
            try
            {
                lock (sendlock)
                {
                    #region
                    this.Client.Send(strMsg, 0, strMsg.Length, SocketFlags.None);
                    //Thread.Sleep(200);
                    this.Client.ReceiveTimeout = 3000;
                    int count = this.Client.Receive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None);

                    receiveBuffer = receiveBuffer.Take(count).ToArray();

                    #endregion
                }
            }
            catch
            {

            }
            return receiveBuffer;
        }
    }
}
