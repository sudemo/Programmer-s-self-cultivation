using logbaseQuene;
using S7.Net;
using System;
using System.IO;
using System.IO.Pipes;

namespace SocketProcess
{
    class Childprogram
    {
        public struct SettingStruct
        {
            public bool status;
            public byte content;
            public int num;
        }

        /// <summary>
        /// args 的内容为： cpu ip db st count eg,"40 ip 23 0 1"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Logger2.Infor("inside sub process");
            if (args.Length > 0)
            {
                /*CpuType cpu = (CpuType)Convert.ToInt32(args[0]);
                string ip = args[1];
                CreateSocketProcess cs = new CreateSocketProcess(cpu, ip);
                Plc MyProxy = cs.MyPlcInstance;
                MyProxy.Open();
                cs.DB = Convert.ToInt32(args[2]);
                cs.StartAddr = Convert.ToInt32(args[3]);
                cs.ReadCount = Convert.ToInt32(args[4]);*/

                //pip communicate
                foreach (string s in args)
                {
                    Logger2.Infor("args is :"+s);
                }
               // Console.WriteLine(args[0]);
                //sw.WriteLine("client recieved :"+temp);
                
                initpipe();
                /*while (true)
                {
                    Thread.Sleep(1000);
                    byte[] res = MyProxy.ReadBytes(DataType.DataBlock, cs.DB, cs.StartAddr, cs.ReadCount);

                    foreach (var b in res)
                    {
                        Console.Write(b);
                    }
                    break;
                }*/
                // Console.ReadKey();
            }
            else
            {
                Console.WriteLine("wrong input para number,please check");
                Console.ReadKey();
            }



        }
        
        public static void exit()
        {
            Environment.Exit(0);
        }


        public static void initpipe()
        {
            var pipeClient = new NamedPipeClientStream(".",
                                         "testpipe", PipeDirection.InOut, PipeOptions.None);


            if (pipeClient.IsConnected != true)
                Console.WriteLine("pipe1 before  " + pipeClient.IsConnected.ToString());
                Logger2.Infor("pipe1 before  " + pipeClient.IsConnected.ToString());
            {
                try
                {
                    pipeClient.Connect(10000);
                }
                catch (Exception ex)
                {
                    Logger2.Error(ex.Message);
                    throw;
                    
                }

                
            }

            StreamReader sr = new StreamReader(pipeClient);
            StreamWriter sw = new StreamWriter(pipeClient);
            Console.WriteLine("in pipe,please input");
            Logger2.Infor("pipe2  after  " + pipeClient.IsConnected.ToString());
            //string temp 
            string temp = Console.ReadLine();
            sw.Write(temp);
          
            
            //temp = sr.ReadLine();

            //pipeClient.Close();
        }
    }






    public class CreateSocketProcess
    {

        public Plc MyPlcInstance;


        public int DB { get; set; } = 0;
        public int StartAddr { get; set; } = 0;
        public int ReadCount { get; set; } = 0;
        //public int StartAddr { get; set; }

        public CreateSocketProcess(CpuType cpu, string ip, short rack = 0, short slot = 0)
        {
            MyPlcInstance = new Plc(cpu, ip, rack, slot);

        }
        public CreateSocketProcess(CpuType cpu, string ip, int db, int Start, int Count)
        {
            MyPlcInstance = new Plc(cpu, ip, 0, 0);
            ReadCount = Count;
            this.StartAddr = Start;
            DB = db;
        }

        public CreateSocketProcess(string ip, int db, int Start, int Count)
        {
            MyPlcInstance = new Plc(CpuType.S71500, ip, 0, 0);
            ReadCount = Count;
            this.StartAddr = Start;
            DB = db;
        }

        //private CreateSocketProcess() { } //屏蔽new

        public string Ipconfig { get; set; } = "";


        /// <summary>
        /// 从配置文件读取socket配置
        /// </summary>


        /// <summary>
        /// 实例
        /// </summary>
        /// <param name="C">s7型号</param>
        /// <param name="ip">plcIP地址</param>
        /// <returns></returns>
        public Plc GetInstance(CpuType C, string ip)

        {
            Plc myclient = new Plc(C, ip, 0, 0);

            myclient.Open();
            return myclient;
        }


    }
}
