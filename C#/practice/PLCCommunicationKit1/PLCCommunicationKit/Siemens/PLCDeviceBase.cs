using PLCCommunicationKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;


namespace PLCCommunicationKit.Siemens
{
   public class PLCDeviceBase
    {
        public virtual string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    //IPAddress address = new IPAddress();
                    IPAddress address;
                    if (!IPAddress.TryParse(value, out address))
                    {
                        throw new Exception(StringResources.LanguageSet.IpAddresError);
                    }
                    ipAddress = value;
                }
                else
                {
                    ipAddress = "127.0.0.1";
                }
            }
        }

        #region Private Member

        //private TTransform byteTransform;                // 数据变换的接口
        protected string ipAddress = "127.0.0.1";          // 连接的IP地址
        protected int Port = 102;                        // 端口号
        protected int connectTimeOut = 100;              // 连接超时时间设置
        protected string connectionId = string.Empty;      // 当前连接
        protected bool isUseSpecifiedSocket = false;       // 指示是否使用指定的网络套接字访问数据

        /// <summary>
        /// 接收数据的超时时间
        /// </summary>
        protected int receiveTimeOut = 10000;            // 数据接收的超时时间
        #endregion
        public virtual ReturnStatus<byte[]> Read(string address, ushort length)
        {
            return new ReturnStatus<byte[]>();
        }


        /// <summary>
        /// 将原始数据写入设备
        /// </summary>
        /// <param name="address">起始地址</param>
        /// <param name="value">原始数据</param>
        /// <returns>带有成turns功标识的结果对象</re>
        /// <remarks>需要在继承类中重写实现，并且实现地址解析操作</remarks>
        public virtual ReturnStatus Write(string address, byte[] value)
        {
            return new ReturnStatus();
        }

        #region Protect Member
        /// <summary>
        /// 单个数据字节的长度，西门子为2，三菱，欧姆龙，modbusTcp就为1，AB PLC无效
        /// </summary>
        /// <remarks>对设备来说，一个地址的数据对应的字节数，或是1个字节或是2个字节</remarks>
        protected ushort WordLength { get; set; } = 1;

        #endregion

        //#region Customer Support     
        //public ReturnStatus<T> ReadCustomer<T>(string address) where T : IDataTransfer, new()
        //{
        //    ReturnStatus<T> result = new ReturnStatus<T>();
        //    T Content = new T();
        //    ReturnStatus<byte[]> read = Read(address, Content.ReadCount);
        //    if (read.IsSuccess)
        //    {
        //        Content.ParseSource(read.Content);
        //        result.Content = Content;
        //        result.IsSuccess = true;
        //    }
        //    else
        //    {
        //        result.ErrorCode = read.ErrorCode;
        //        result.Message = read.Message;
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 写入自定义类型的数据到设备去，需要规定生成字节的方法
        ///// </summary>
        ///// <typeparam name="T">自定义类型</typeparam>
        ///// <param name="address">起始地址</param>
        ///// <param name="data">实例对象</param>
        ///// <returns>带有成功标识的结果对象</returns>
        ///// <remarks>
        ///// 需要是定义一个类，选择好相对于的<see cref="IDataTransfer"/>实例，才能调用该方法。
        ///// </remarks>
        ///// <example>
        ///// 此处演示三菱的读取示例，先定义一个类，实现<see cref="IDataTransfer"/>接口
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="IDataTransfer Example" title="DataMy示例" />
        ///// 接下来就可以实现数据的读取了
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="WriteCustomerExample" title="WriteCustomer示例" />
        ///// </example>
        //public ReturnStatus WriteCustomer<T>(string address, T data) where T : IDataTransfer, new()
        //{
        //    return Write(address, data.ToSource());
        //}


        //#endregion

        

        //#region Read Support

        ///// <summary>
        ///// 读取设备的short类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt16" title="Int16类型示例" />
        ///// </example>
        //public ReturnStatus<short> ReadInt16(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadInt16(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的short类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt16Array" title="Int16类型示例" />
        ///// </example>
        //public virtual ReturnStatus<short[]> ReadInt16(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength)), m => ByteTransform.TransInt16(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的ushort数据类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt16" title="UInt16类型示例" />
        ///// </example>
        //public ReturnStatus<ushort> ReadUInt16(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadUInt16(address, 1));
        //}


        ///// <summary>
        ///// 读取设备的ushort类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt16Array" title="UInt16类型示例" />
        ///// </example>
        //public virtual ReturnStatus<ushort[]> ReadUInt16(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength)), m => ByteTransform.TransUInt16(m, 0, length));
        //}



        ///// <summary>
        ///// 读取设备的int类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt32" title="Int32类型示例" />
        ///// </example>
        //public ReturnStatus<int> ReadInt32(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadInt32(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的int类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt32Array" title="Int32类型示例" />
        ///// </example>
        //public virtual ReturnStatus<int[]> ReadInt32(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 2)), m => ByteTransform.TransInt32(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的uint类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt32" title="UInt32类型示例" />
        ///// </example>
        //public ReturnStatus<uint> ReadUInt32(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadUInt32(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的uint类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt32Array" title="UInt32类型示例" />
        ///// </example>
        //public virtual ReturnStatus<uint[]> ReadUInt32(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 2)), m => ByteTransform.TransUInt32(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的float类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadFloat" title="Float类型示例" />
        ///// </example>
        //public ReturnStatus<float> ReadFloat(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadFloat(address, 1));
        //}


        ///// <summary>
        ///// 读取设备的float类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadFloatArray" title="Float类型示例" />
        ///// </example>
        //public virtual ReturnStatus<float[]> ReadFloat(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 2)), m => ByteTransform.TransSingle(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的long类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt64" title="Int64类型示例" />
        ///// </example>
        //public ReturnStatus<long> ReadInt64(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadInt64(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的long类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadInt64Array" title="Int64类型示例" />
        ///// </example>
        //public virtual ReturnStatus<long[]> ReadInt64(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 4)), m => ByteTransform.TransInt64(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的ulong类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt64" title="UInt64类型示例" />
        ///// </example>
        //public ReturnStatus<ulong> ReadUInt64(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadUInt64(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的ulong类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadUInt64Array" title="UInt64类型示例" />
        ///// </example>
        //public virtual ReturnStatus<ulong[]> ReadUInt64(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 4)), m => ByteTransform.TransUInt64(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的double类型的数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadDouble" title="Double类型示例" />
        ///// </example>
        //public ReturnStatus<double> ReadDouble(string address)
        //{
        //    return ByteTransformHelper.GetResultFromArray(ReadDouble(address, 1));
        //}

        ///// <summary>
        ///// 读取设备的double类型的数组
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">数组长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadDoubleArray" title="Double类型示例" />
        ///// </example>
        //public virtual ReturnStatus<double[]> ReadDouble(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, (ushort)(length * WordLength * 4)), m => ByteTransform.TransDouble(m, 0, length));
        //}

        ///// <summary>
        ///// 读取设备的字符串数据，编码为ASCII
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">地址长度</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadString" title="String类型示例" />
        ///// </example>
        //public ReturnStatus<string> ReadString(string address, ushort length)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, length), m => ByteTransform.TransString(m, 0, m.Length, Encoding.ASCII));
        //}

        ///// <summary>
        ///// 读取设备的字符串数据，编码为指定的编码信息
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="length">地址长度</param>
        ///// <param name="encoding">编码机制</param>
        ///// <returns>带成功标志的结果数据对象</returns>
        ///// <example>
        ///// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
        ///// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="ReadString" title="String类型示例" />
        ///// </example>
        //public ReturnStatus<string> ReadString(string address, ushort length, Encoding encoding)
        //{
        //    return ByteTransformHelper.GetResultFromBytes(Read(address, length), m => ByteTransform.TransString(m, 0, m.Length, encoding));
        //}

        //#endregion

        //#region Bool Support

        //// Bool类型的读写，不一定所有的设备都实现，比如西门子，就没有实现bool[]的读写，Siemens的fetch/write没有实现bool操作

        ///// <summary>
        ///// 批量读取底层的数据信息，需要指定地址和长度，具体的结果取决于实现
        ///// </summary>
        ///// <param name="address">数据地址</param>
        ///// <param name="length">数据长度</param>
        ///// <returns>带有成功标识的bool[]数组</returns>
        //public virtual ReturnStatus<bool[]> ReadBool(string address, ushort length)
        //{
        //    return new ReturnStatus<bool[]>(StringResources.Language.NotSupportedFunction);
        //}

        ///// <summary>
        ///// 读取底层的bool数据信息，具体的结果取决于实现
        ///// </summary>
        ///// <param name="address">数据地址</param>
        ///// <returns>带有成功标识的bool数组</returns>
        //public virtual ReturnStatus<bool> ReadBool(string address)
        //{
        //    ReturnStatus<bool[]> read = ReadBool(address, 1);
        //    if (!read.IsSuccess) return ReturnStatus.CreateFailedResult<bool>(read);

        //    return ReturnStatus.CreateSuccessResult(read.Content[0]);
        //}

        ///// <summary>
        ///// 写入bool数组数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="value">写入值</param>
        ///// <returns>带有成功标识的结果类对象</returns>
        //public virtual ReturnStatus Write(string address, bool[] value)
        //{
        //    return new ReturnStatus(StringResources.Language.NotSupportedFunction);
        //}

        ///// <summary>
        ///// 写入bool数据
        ///// </summary>
        ///// <param name="address">起始地址</param>
        ///// <param name="value">写入值</param>
        ///// <returns>带有成功标识的结果类对象</returns>
        //public virtual ReturnStatus Write(string address, bool value)
        //{
        //    return Write(address, new bool[] { value });
        //}

        //#endregion

       

//        #region Write Int16

//        /// <summary>
//        /// 向设备中写入short数组，返回是否写入成功
//        /// </summary>
//        /// <param name="address">数据地址</param>
//        /// <param name="values">实际数据</param>
//        /// <returns>是否写入成功的结果对象</returns>
//        /// <example>
//        /// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
//        /// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="WriteInt16Array" title="Int16类型示例" />
//        /// </example>
//        public virtual ReturnStatus Write(string address, short[] values)
//        {
//            return Write(address, ByteTransform.TransByte(values));
//        }

//        /// <summary>
//        /// 向设备中写入short数据，返回是否写入成功
//        /// </summary>
//        /// <param name="address">数据地址</param>
//        /// <param name="value">实际数据</param>
//        /// <returns>是否写入成功的结果对象</returns>
//        /// <example>
//        /// 以下为三菱的连接对象示例，其他的设备读写情况参照下面的代码：
//        /// <code lang="cs" source=".Test\Documentation\Samples\Core\NetworkDeviceBase.cs" region="WriteInt16" title="Int16类型示例" />
//        /// </example>
//        public ReturnStatus Write(string address, short value)
//        {
//            return Write(address, new short[] { value });
//        }
//    }
//}
//#endregion