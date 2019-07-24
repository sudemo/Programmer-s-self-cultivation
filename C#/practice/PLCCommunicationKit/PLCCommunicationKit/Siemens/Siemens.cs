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
            //#region databyte
            //byte[] _PLCCommand = new byte[35 + data.Length];
            //_PLCCommand[0] = 0x03;
            //_PLCCommand[1] = 0x00;
            //// 长度 -> Length
            //_PLCCommand[2] = (byte)((35 + data.Length) / 256);
            //_PLCCommand[3] = (byte)((35 + data.Length) % 256);
            //// 固定 -> Fixed
            //_PLCCommand[4] = 0x02;
            //_PLCCommand[5] = 0xF0;
            //_PLCCommand[6] = 0x80;
            //_PLCCommand[7] = 0x32;
            //// 命令 发 -> command to send
            //_PLCCommand[8] = 0x01;

            //_PLCCommand[9] = 0x00;
            //_PLCCommand[10] = 0x00;
            //// 标识序列号 -> Identification serial Number
            //_PLCCommand[11] = 0x00;
            //_PLCCommand[12] = 0x01;
            //// 固定 -> Fixed
            //_PLCCommand[13] = 0x00;
            //_PLCCommand[14] = 0x0E;
            //// 写入长度+4 -> Write Length +4
            //_PLCCommand[15] = (byte)((4 + data.Length) / 256);
            //_PLCCommand[16] = (byte)((4 + data.Length) % 256);
            //// 读写指令 -> Read and write instructions
            //_PLCCommand[17] = 0x05;
            //// 写入数据块个数 -> Number of data blocks written
            //_PLCCommand[18] = 0x01;
            //// 固定，返回数据长度 -> Fixed, return data length
            //_PLCCommand[19] = 0x12;
            //_PLCCommand[20] = 0x0A;
            //_PLCCommand[21] = 0x10;
            //// 写入方式，1是按位，2是按字 -> Write mode, 1 is bitwise, 2 is by word
            //_PLCCommand[22] = 0x02;
            //// 写入数据的个数 -> Number of Write Data
            //_PLCCommand[23] = (byte)(data.Length / 256);
            //_PLCCommand[24] = (byte)(data.Length % 256);
            //// DB块编号，如果访问的是DB块的话 -> DB block number, if you are accessing a DB block
            //_PLCCommand[25] = 0x00; //(byte)(analysis.Content.DbBlock / 256);
            //_PLCCommand[26] = 0x00; //(byte)(analysis.Content.DbBlock % 256);
            //// 写入数据的类型 -> Types of writing data
            //_PLCCommand[27] = 0x00; //analysis.Content.DataCode;
            //// 偏移位置 -> Offset position
            //_PLCCommand[28] = 0x00; //(byte)(analysis.Content.AddressStart / 256 / 256 % 256); ;
            //_PLCCommand[29] = 0x00; //(byte)(analysis.Content.AddressStart / 256 % 256);
            //_PLCCommand[30] = 0x00; // (byte)(analysis.Content.AddressStart % 256);
            //// 按字写入 -> Write by Word
            //_PLCCommand[31] = 0x00;
            //_PLCCommand[32] = 0x04;
            //// 按位计算的长度 -> The length of the bitwise calculation
            //_PLCCommand[33] = (byte)(data.Length * 8 / 256);
            //_PLCCommand[34] = (byte)(data.Length * 8 % 256);

            //data.CopyTo(_PLCCommand, 35); 
            //#endregion

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
                    LogHelper.Infor("handshake first done");
                    int res = SocketBase.SocketSend(plcHead2);
                     
                    if (res == 27)
                    {
                        status = true;
                        LogHelper.Infor("handshake second done,init ok");                      
                    }
                    else
                    {
                        status = false;
                        LogHelper.Infor("handshake second failed");                       
                    }
                }
                else
                {
                    //Console.WriteLine("rec {0}", SocketBase.SocketRec());
                    LogHelper.Error("handshake error,plc init failed");
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
                byte[] recvData = SocketBase.SocketRec();
                //if (recvData[0] == 0x03 && recvData[1] == 0x00 && recvData[recvData.Length - 1] == 0xFF)
                if(true)
                {
                    Console.WriteLine(recvData);
                    Console.ReadKey();
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                LogHelper.Error("写入plc失败",ex);
            }
            LogHelper.Infor("写入plc成功");
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
