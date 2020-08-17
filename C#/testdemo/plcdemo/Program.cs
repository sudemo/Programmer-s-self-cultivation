using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ML;

namespace plcdemo
{
    class Program
    {
        //public PlcHelper static instance_plc = new PlcHelper
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("db10");
            //直接读
            List<int> ll = new List<int>();
            int t = 0;
            for (int i = 0; i < 10; i++)
            {
                ll.Add(i);
            }
            int max = 0;
            foreach (int i in  ll)
            {
                int m = 1;
                if (i > m) { m = i; }
               
                max = m;
            }
            var s = ll.Max();
            // Console.WriteLine(max);


            int a = 32768;
            short b = (short)a;
            Console.WriteLine(b);

            var ss = Read_DB1101();
            var s2 = Read_DIntDB10();
            var s3 = (Int16)PlcHelper.plcHelper_ins.GetInstance().ReadDB_int(10,0,1);
            var s4 = PlcHelper.plcHelper_ins.GetInstance().ReadDB_Word(10,0,2);
            //byte[] a = (byte[])ss;
            Console.WriteLine(ss);
            //Task<object> t1 = new Task<object>(() => Read_DB10());
            //Task<object> t2 = new Task<object>(()=> Read_DB1101());
            //Task t1 = new Task(() => Read_async_DB10());
            //Task t2 = new Task(() => Read_async_DB1101());
            //t1.Start();
            //t2.Start();

            //var res = t1.Result;

            //Task<byte[]> rr1 = Read_async_DB10();
            //Thread.Sleep(100);

            //Task<byte[]> rr2 = Read_async_DB1101();
            #region tongbu readwrite
            /*
              byte[] res110 = (byte[])Read_DB1101();
              byte[] res = (byte[])Read_DB10();
              foreach (byte r in res110)
              {
                  Console.Write(r);
              }
              Console.WriteLine("after");
              foreach (byte r in res)
              {
                  Console.Write(r);
              }
              Console.WriteLine("after");*/

            #endregion
            //if (rr1.Status == TaskStatus.RanToCompletion)

            //{
            //    byte[] rr = rr1.Result;

            //    foreach (byte r1 in rr)
            //    {
            //        Console.Write(r1);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine('n'); 
            //}
            Console.WriteLine("1101: ");
            //object rr2 = Read_DB1101();
           /*
            object rr2 = ReadDB1000_int();
            short[] rr3 = (short[])rr2;

            //byte[] r2 = rr2.Result;

            foreach (short r in rr3)
            {
                Console.Write(r);
            }*/
            Console.ReadKey();

        }

        static object Read_DB1101()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open();
            return PlcHelper.plcHelper_ins.ReadDB(10, 0, 1);
            //PlcHelper.GetInstance();
            //var res = PlcHelper.  (DataType.DataBlock, 1011, 70, 2);

        }

        static object ReadDB1000_int()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open();
            return PlcHelper.plcHelper_ins.ReadDB_int(1000, 0, 10);
            //PlcHelper.GetInstance();
            //var res = PlcHelper.  (DataType.DataBlock, 1011, 70, 2);

        }


        async static Task <Byte[]> Read_async_DB1101()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open_async();
            return await PlcHelper.plcHelper_ins.ReadDB_Bytes_Async(1000, 4, 5);
            //PlcHelper.GetInstance();
            //var res = PlcHelper.  (DataType.DataBlock, 1011, 70, 2);

        }


        static Task <Byte[]> Read_async_DB10()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open_async();

            return PlcHelper.plcHelper_ins.ReadDB_Bytes_Async(10, 0, 10);
            //PlcHelper.GetInstance();
            //var res = PlcHelper.  (DataType.DataBlock, 1011, 70, 2);

        }

        static object Read_DB10()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open();
            return PlcHelper.plcHelper_ins.ReadDB(10, 0, 10);
            //PlcHelper.GetInstance();
            //var res = PlcHelper.  (DataType.DataBlock, 1011, 70, 2);

        }

        static object Read_DIntDB10()
        {

            PlcHelper.plcHelper_ins.GetInstance();
            PlcHelper.plcHelper_ins.Open();
            return PlcHelper.plcHelper_ins.ReadDB_dint(10, 0, 1);
        }


        #region 序列化

        public static byte[] Serialize(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, obj);
            byte[] datas = stream.ToArray();
            stream.Dispose();
            return datas;
        }
        //反序列化
        public static object Deserialize(byte[] datas)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(datas, 0, datas.Length);
            object obj = bf.Deserialize(stream);
            stream.Dispose();
            return obj;
        }

        #endregion


    }
}
