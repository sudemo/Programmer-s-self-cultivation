using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using S7.Net;


namespace PLCHelper

{
    class PlcHelper
    {
        private static CpuType c = CpuType.S71500;
        public static string ip = "127.0.0.1";
        //public static string ip = "192.168.0.10";
        private Plc s7netplc_instance = new Plc(c, ip, 0, 1);

        public static PlcHelper plcHelper_ins = new PlcHelper();



        //public PlcHelper() : base(CpuType.S71500, ip, 0, 1) { }



        //public PlcHelper()
        //{
        //    Plc myplc = new Plc(CpuType.S71500, "192.168.0.10", 0, 1);

        //}

        public PlcHelper GetInstance()
        {
            if (plcHelper_ins == null)
            {
                return plcHelper_ins = new PlcHelper();
            }
            else
            {
                return plcHelper_ins;
            }
        }


        public void Open()
        {
            s7netplc_instance.Open();
        }

        public void Open_async()
        {
            s7netplc_instance.OpenAsync();//zhege 才是真的异步的地方，其内部是异步的，此处往上封装 的都不是异步
        }

        //默认读取DB，需要参数DB number, startaddress,count
        public object ReadDB(int db, int startaddr, int count)
        {
            return s7netplc_instance.Read(DataType.DataBlock, db, startaddr, VarType.Byte, count);
        }

        public object ReadDB_dint(int db, int startaddr, int count)
        {
            return s7netplc_instance.Read(DataType.DataBlock, db, startaddr, VarType.DInt, count);
        }
        public object ReadDB_int(int db, int startaddr, int count)
        {
            return s7netplc_instance.Read(DataType.DataBlock, db, startaddr, VarType.Int, count);
        }


        //异步读
        public Task<object> ReadDB_Async(int db, int startaddr, int count)
        {
            return s7netplc_instance.ReadAsync(DataType.DataBlock, db, startaddr, VarType.DWord, count);
        }

        public Task<byte[]> ReadDB_Bytes_Async(int db, int startaddr, int count)
        {
            return s7netplc_instance.ReadBytesAsync(DataType.DataBlock, db, startaddr, count);
        }


    }

}
