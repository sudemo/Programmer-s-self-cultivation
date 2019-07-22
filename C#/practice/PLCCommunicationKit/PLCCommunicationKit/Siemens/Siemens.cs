using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCCommunicationKit.SocketBaseKit;


namespace PLCCommunicationKit.Siemens
{

        public class SiemensS7Net:PLCDeviceBase
        {


        #region 暂时无法使用，后续设置为按型号初始化即可
        /// <summary>
        /// 实例化一个西门子的S7协议的通讯对象 ->
        /// Instantiate a communication object for a Siemens S7 protocol
        /// </summary>
        /// <param name="siemens">指定西门子的型号</param>
        public SiemensS7Net(SiemensType siemens)
        {
            Initialization(siemens, string.Empty);
        }
        public SiemensS7Net()
        { }
        /// <summary>
        /// 实例化一个西门子的S7协议的通讯对象并指定Ip地址 ->
        /// Instantiate a communication object for a Siemens S7 protocol and specify an IP address
        /// </summary>
        /// <param name="siemens">指定西门子的型号</param>
        /// <param name="ipAddress">Ip地址</param>
        public SiemensS7Net(SiemensType siemens, string ipAddress)
        {
            Initialization(siemens, ipAddress);
        }

        /// <summary>
        /// 初始化方法 -> Initialize method
        /// </summary>
        /// <param name="siemens">指定西门子的型号 -> Designation of Siemens</param>
        /// <param name="ipAddress">Ip地址 -> IpAddress</param>
        private void Initialization(SiemensType siemens, string ip)//plc型号选择,默认是1200，ip默认为127.0.0.1
        {
            WordLength = 2;

            IpAddress = ip;
            Port = 102;
            CurrentPlc = siemens;

            switch (siemens)
            {
                case SiemensType.S1200: plcHead1[21] = 0; break;
                case SiemensType.S300: plcHead1[21] = 2; break;
                case SiemensType.S400: plcHead1[21] = 3; plcHead1[17] = 0x00; break;
                case SiemensType.S1500: plcHead1[21] = 0; break;
                case SiemensType.S200Smart:
                    {
                        plcHead1 = plcHead1_200smart;
                        plcHead2 = plcHead2_200smart;
                        break;
                    }
                case SiemensType.S200:
                    {
                        plcHead1 = plcHead1_200;
                        plcHead2 = plcHead2_200;
                        break;
                    }
                default: plcHead1[18] = 0; break;
            }
            SocketBase sk = new SocketBase();
            //sk.initSocketBase(ip, Port);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnStatus handshakewithplc()
        {

            Initialization(SiemensType.S1200, "172.16.8.204");
            //SocketBaseKit.SocketBase.
            // Write();
            return ReturnStatus.CreatSuccessStatus<bool>();
        }
        #endregion
        public bool init_plc_Connect() //与plc连接的初始化
          {
            bool status; //判断返回值是否对的标志
            //SocketBase sk = new SocketBase();
            SocketBase.initSocketBase();
            SocketBase.SocketSend(plcHead1);
            //Console.ReadKey();
            if (SocketBase.SocketRec() == 22)
            {
                SocketBase.SocketSend(plcHead2);
                int res = SocketBase.SocketRec();
                if (res == 27)
                {
                    status = true;
                    return status;
                }
                else
                {
                    status = false;
                    return status;
                }
            }
            else
            {
                Console.WriteLine("rec {0}", SocketBase.SocketRec());
                status = false;
                return status;
            }
        }
        #region plc headercmd
        private byte[] plcHead1_1200 = new byte[22] //
                {
            0x03, 0x00, 0x00, 0x16, 0x11, 0xE0, 0x00, 0x00, 0x00, 0x01, 0x00, 0xC1, 0x02, 0x01,
            0x00, 0xC2, 0x02, 0x01, 0x01, 0xC0, 0x01, 0x09
                 };
        private byte[] plcHead2_1200 = new byte[25]
            {
            0x03, 0x00, 0x00, 0x19, 0x02, 0xF0, 0x80, 0x32, 0x01, 0x00, 0x00, 0xFF, 0xFF, 0x00,
            0x08, 0x00, 0x00, 0xF0, 0x00, 0x00, 0x01, 0x00, 0x01, 0x07, 0x80
            };
        private byte[] plcHead1 = new byte[22] //
                {
            0x03,0x00,0x00,0x16,0x11,0xE0,0x00,0x00,0x00,0x01,0x00,0xC0,0x01,0x0A,0xC1,0x02,
            0x01,0x02,0xC2,0x02,0x01,0x00
                 };
            private byte[] plcHead2 = new byte[25]
            {
            0x03,0x00,0x00,0x19,0x02,0xF0,0x80,0x32,0x01,0x00,0x00,0x04,0x00,0x00,0x08,0x00,
            0x00,0xF0,0x00,0x00,0x01,0x00,0x01,0x01,0xE0
            };
            private byte[] plcOrderNumber = new byte[]
            {
            0x03,0x00,0x00,0x21,0x02,0xF0,0x80,0x32,0x07,0x00,0x00,0x00,0x01,0x00,0x08,0x00,
            0x08,0x00,0x01,0x12,0x04,0x11,0x44,0x01,0x00,0xFF,0x09,0x00,0x04,0x00,0x11,0x00,
            0x00
            };
            private SiemensType CurrentPlc = SiemensType.S1200;
            private byte[] plcHead1_200smart = new byte[22]
            {
            0x03,0x00,0x00,0x16,0x11,0xE0,0x00,0x00,0x00,0x01,0x00,0xC1,0x02,0x10,0x00,0xC2,
            0x02,0x03,0x00,0xC0,0x01,0x0A
            };
            private byte[] plcHead2_200smart = new byte[25]
            {
            0x03,0x00,0x00,0x19,0x02,0xF0,0x80,0x32,0x01,0x00,0x00,0xCC,0xC1,0x00,0x08,0x00,
            0x00,0xF0,0x00,0x00,0x01,0x00,0x01,0x03,0xC0
            };

            private byte[] plcHead1_200 = new byte[]
            {
            0x03,0x00,0x00,0x16,0x11,0xE0,0x00,0x00,0x00,0x01,0x00,0xC1,0x02,0x4D,0x57,0xC2,
            0x02,0x4D,0x57,0xC0,0x01,0x09
            };
            private byte[] plcHead2_200 = new byte[]
            {
            0x03,0x00,0x00,0x19,0x02,0xF0,0x80,0x32,0x01,0x00,0x00,0x00,0x00,0x00,0x08,0x00,
            0x00,0xF0,0x00,0x00,0x01,0x00,0x01,0x03,0xC0
            };

            byte[] S7_STOP = {
            0x03, 0x00, 0x00, 0x21, 0x02, 0xf0, 0x80, 0x32, 0x01, 0x00, 0x00, 0x0e, 0x00, 0x00, 0x10, 0x00,
            0x00, 0x29, 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x50, 0x5f, 0x50, 0x52, 0x4f, 0x47, 0x52, 0x41,
            0x4d
            };

            byte[] S7_HOT_START = {
            0x03, 0x00, 0x00, 0x25, 0x02, 0xf0, 0x80, 0x32, 0x01, 0x00, 0x00, 0x0c, 0x00, 0x00, 0x14, 0x00,
            0x00, 0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xfd, 0x00, 0x00, 0x09, 0x50, 0x5f, 0x50, 0x52,
            0x4f, 0x47, 0x52, 0x41, 0x4d
            };

            byte[] S7_COLD_START = {
            0x03, 0x00, 0x00, 0x27, 0x02, 0xf0, 0x80, 0x32, 0x01, 0x00, 0x00, 0x0f, 0x00, 0x00, 0x16, 0x00,
            0x00, 0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xfd, 0x00, 0x02, 0x43, 0x20, 0x09, 0x50, 0x5f,
            0x50, 0x52, 0x4f, 0x47, 0x52, 0x41, 0x4d
            }; 
            #endregion
        }
    }
