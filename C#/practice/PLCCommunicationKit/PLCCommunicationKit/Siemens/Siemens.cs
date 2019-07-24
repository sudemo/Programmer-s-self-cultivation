using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCCommunicationKit.SocketBaseKit;
using System.Threading;

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

        public byte[] headCmd;         //固定的报文
        public byte[] msgLenth;        //报文长度（35+写入长度）
        public byte[] fixedCmd1;       //固定的报文
        public byte[] serialFlag;      //标识序列号
        public byte[] fixedCmd2;       //固定的报文
        public byte[] writeLenth;      //写入长度+4
        public byte[] fixedCmd3;       //固定的报文
        public byte writeWay;          //0x01:bit 0x02:byte
        public byte[] writeCnt;        //写入个数，按write_way区分
        public byte[] DBNo;            //DB块编号
        public byte DataBlockType;     //input:0x81,output:0x82,flag:0x83,DB:0x84
        public byte[] DBOffset;        //地址+1（以byte为单位）
        public byte[] writeBitCnt;     //写入bit的个数
        public byte[] writeData;       //写入值

        struct ReadStructCmd
        {
            public byte[] headCmd;         //固定的报文
            public byte[] msgLenth;        //报文长度（0x1F = 31）
            public byte[] fixedCmd1;       //固定的报文
            public byte[] serialFlag;      //序列号标识（发送、接收的标识符一样）
            public byte[] fixedCmd2;       //固定的报文
            public byte[] accessCnt;       //访问数据个数，bit为单位
            public byte[] DBNo;            //DB块编号
            public byte dataType;            //input:0x81,output:0x82,flag:0x83,DB:0x84
            public byte[] DBOffset;        //访问DB块的偏移量offset(地址+1，以byte为单位）

            public void ReadCmdInit()
            {
                headCmd = new byte[] { 0x03, 0x00 };
                msgLenth = new byte[] { 0x00, 0x1F };
                fixedCmd1 = new byte[] { 0x02, 0xF0, 0x80, 0x32, 0x01, 0x00, 0x00 };
                serialFlag = new byte[] { 0x00, 0x00 };
                fixedCmd2 = new byte[] { 0x00, 0x0E, 0x00, 0x00, 0x04, 0x01, 0x12, 0x0A, 0x10, 0x02 };
                accessCnt = new byte[] { 0x00, 0x00 };
                DBNo = new byte[] { 0x00, 0x00 };
                dataType = 0x00;
                DBOffset = new byte[] { 0x00, 0x00, 0x00 };
            }
        }
        public void writeCmdInit()
        {

            headCmd = new byte[] { 0x03, 0x00 };
            msgLenth = new byte[] { 0x00, 0x00 };//报文长度（35+写入长度）
            fixedCmd1 = new byte[] { 0x02, 0xF0, 0x80, 0x32, 0x01, 0x00, 0x00 };
            serialFlag = new byte[] { 0x00, 0x00 };
            fixedCmd2 = new byte[] { 0x00, 0x0E };
            writeLenth = new byte[] { 0x00, 0x00 };
            fixedCmd3 = new byte[] { 0x05, 0x01, 0x12, 0x0A, 0x10 };
            writeWay = 0x00; //0x01:bit 0x02:byte
            writeCnt = new byte[] { 0x00, 0x00 };
            DBNo = new byte[] { 0x00, 0x00 };
            DataBlockType = 0x00;
            DBOffset = new byte[] { 0x00, 0x00, 0x00 };
            writeBitCnt = new byte[] { 0x00, 0x00 };
            writeData = new byte[] { };
            //byte[] Uwritecmd = new byte[] { headCmd, msgLenth, fixedCmd1 }; 
            List<byte> ad = new List<byte>();
            ad.AddRange(fixedCmd1);
            //ad.Add(fixedCmd1);
        }
        public bool init_plc_Connect() //与plc连接的初始化
        {
            bool status; //判断返回值是否对的标志
            //SocketBase sk = new SocketBase();

            if (SocketBase.initSocketBase())
            {
                SocketBase.SocketSend(plcHead1);
                //Console.ReadKey();
                if (SocketBase.SocketRec().Length == 22)
                {
                    Logger.Infor("handshake first done");
                    SocketBase.SocketSend(plcHead2);
                    byte[] res = SocketBase.SocketRec();
                    if (res.Length == 27)
                    {
                        status = true;
                        Logger.Infor("handshake second done,init ok " + res);                      
                    }
                    else
                    {
                        status = false;
                        Logger.Error("handshake second failed");                       
                    }
                }
                else
                {
                    //Console.WriteLine("rec {0}", SocketBase.SocketRec());
                    Logger.Error("handshake first error,plc init failed");
                    status = false;
                }
            }
            else
            {
                status = false;
            }
            return status;
        }

        public byte[] IntToByte(int num)
        {
            byte[] tmp = BitConverter.GetBytes(Convert.ToUInt16(num));
            Array.Reverse(tmp);
            return tmp;
        }
        /// <summary>
        /// msg区分写入1byte,2byte
        /// </summary>
        /// <param name="wData"></param>
        /// <param name="WriteType"></param>
        /// <param name="DBNode"></param>
        /// <param name="ioffset"></param>
        /// <param name="writeWay"></param>
        /// <param name="datablockType"></param>
        /// <returns></returns>
        public bool writeByteData(byte[] wData, int WriteType, int DBNode, int ioffset, int writeWay, byte datablockType = 0x84)
        {
            bool isSuccess = false;
            try
            {
                //writeStructCmd writeStruct = new writeStructCmd();
                //writeStruct.writeCmdInit();

                writeCmdInit();
                List<byte> writeCmd = new List<byte>();
  
                byte[] msgLen = IntToByte(35 + wData.Length);
                if (msgLen.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(msgLen);

                writeCmd.AddRange(fixedCmd1);
                writeCmd.AddRange(serialFlag);
                writeCmd.AddRange(fixedCmd2);

                byte[] wLen = IntToByte(wData.Length + 4);
                if (wLen.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(wLen);

                writeCmd.AddRange(fixedCmd3);
                byte wtype = (byte)(WriteType & 0xFF);
                writeCmd.Add(wtype);    //写入方式

                byte[] len = new byte[] { };
                if (WriteType == 1) //bit
                {
                    len = IntToByte(wData.Length * 8);
                }
                else if (WriteType == 2)//byte
                {
                    len = IntToByte(wData.Length);
                }
                if (len.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(len);

                byte[] db = IntToByte(DBNode);
                if (db.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(db);

                writeCmd.Add(datablockType);

                byte[] offset = IntToByte(ioffset * 8);
                if (offset.Length == 1)
                {
                    writeCmd.Add(0x00);
                    writeCmd.Add(0x00);
                }
                else if (offset.Length == 2)
                {
                    writeCmd.Add(0x00);
                }
                writeCmd.AddRange(offset);

                byte[] wWay = IntToByte(writeWay);
                if (wWay.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(wWay);

                byte[] bitCnt = IntToByte(wData.Length * 8);//写入bit的个数（以bit为单位)
                if (wWay.Length < 2)
                    writeCmd.Add(0x00);
                writeCmd.AddRange(bitCnt);

                //双字、单字处理？？？
                getLittleEndianBytes(wData);

                writeCmd.AddRange(wData);
                //发送数据
                SocketBase.SocketSend(writeCmd.ToArray());
                Thread.Sleep(500);
                byte[] recvData = SocketBase.SocketRec();
                if (recvData[0] == 0x03 && recvData[1] == 0x00 && recvData[recvData.Length - 1] == 0xFF)
                //if(true)
                {
                    Console.WriteLine(recvData);
                    Console.ReadKey();
                    isSuccess = true;
                    Logger.Infor("write ok");
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                Logger.Error("写入plc失败"+ex);
            }
            //Logger.Infor("写入plc成功");
            return isSuccess;
        }

        public bool ReadByteData(int DBNode, int ioffset, byte datablockType, int byteCnt, out byte[] receiveData)
        {
            bool isSuccess = false;

            try
            {
                #region 填充读取指令
                ReadStructCmd readStruct = new ReadStructCmd();
                readStruct.ReadCmdInit();
                List<byte> readCmd = new List<byte>();


                readCmd.AddRange(readStruct.headCmd);
                readCmd.AddRange(readStruct.msgLenth);
                readCmd.AddRange(readStruct.fixedCmd1);

                //标识序列号，自定义
                readStruct.serialFlag = new byte[] { 0x00, 0x05 };
                readCmd.AddRange(readStruct.serialFlag);
                readCmd.AddRange(readStruct.fixedCmd2);
                byte[] readCnt = IntToByte(byteCnt);
                if (readCnt.Length < 2)
                {
                    readCmd.Add(0x00);
                }
                readCmd.AddRange(readCnt);
                byte[] DBNo = IntToByte(DBNode);
                if (DBNo.Length < 2)
                {
                    readCmd.Add(0x00);
                }
                readCmd.AddRange(DBNo);

                readCmd.Add(datablockType);

                byte[] offset = IntToByte(ioffset * 8);

                if (offset.Length == 1)
                {
                    readCmd.Add(0x00);
                    readCmd.Add(0x00);
                }
                else if (offset.Length == 2)
                {
                    readCmd.Add(0x00);
                }
                readCmd.AddRange(offset);

                #endregion

                SocketBase.SocketSend(readCmd.ToArray());
                byte[] data = SocketBase.SocketRec();
                int len = BitConverter.ToInt32(data.Skip(2).Take(2).ToArray(), 0);
                if (len == 25 + byteCnt) //25+读取长度
                {
                    receiveData = data.Skip(24).Take(data.Length - 24).ToArray();
                    //双字、单字处理？？？
                    getLittleEndianBytes(receiveData);
                    isSuccess = true;
                }
                else
                {
                    receiveData = new byte[] { };
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("read byte error",ex);
                receiveData = new byte[] { };
                isSuccess = false;
            }
            return isSuccess;
        }


        public bool ReadSignal(int DBNode, int ioffset, byte datablockType, int byteCnt)
        {
            bool isResult = false;
            byte[] receiveData;
            if (ReadByteData(DBNode, ioffset, datablockType, byteCnt, out receiveData))
            {
                if (receiveData.Length > 0)
                {
                    byte b = 0x03;
                    b = (byte)(b >> 1);
                }
            }


            return isResult;
        }

        //public bool WriteByte()
        //{

        //    return false;
        //}

        //public void WriteBit()
        //{
        //}

        //public void Write2Bit()
        //{
        //}

        public byte[] getLittleEndianBytes(byte[] wData)
        {
            if (BitConverter.IsLittleEndian)
            {
                for (int i = 0; i < wData.Length / 4; i++)
                {

                    byte[] tmp = wData.Skip(i * 2).Take(2).ToArray();
                    wData[i * 2] = wData[(i + 1) * 2];
                    wData[i * 2 + 1] = wData[(i + 1) * 2 + 1];

                    wData[(i + 1) * 2] = tmp[0];
                    wData[(i + 1) * 2 + 1] = tmp[1];
                }
            }
            return wData;
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
