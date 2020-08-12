using logbaseQuene;
using S7.Net;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

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
                    Logger2.Infor("args is :" + s);
                }
                // Console.WriteLine(args[0]);
                //sw.WriteLine("client recieved :"+temp);
                PipeHelper ph = new PipeHelper();
                ph.InitPipe();
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
                Console.ReadKey();
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


    }
    public class PipeHelper
    {
        public static NamedPipeClientStream ChildPipeClient_1;// read 
        public static NamedPipeServerStream ChildPipeServer_2;//write

        public static StreamReader sr_1;
        public static StreamWriter sw_2;

        public void InitPipe()
        {
            try
            {
                ChildPipeClient_1 = new NamedPipeClientStream(".", "np1", PipeDirection.In);  //所有管道都在使用中，父子说明重复了
                ChildPipeServer_2 = new NamedPipeServerStream("np2", PipeDirection.Out);
                sr_1 = new StreamReader(ChildPipeClient_1);
                sw_2 = new StreamWriter(ChildPipeServer_2);

                ChildPipeClient_1.Connect(); //此处的顺序很重要，必须与服务器向匹配，否则会一直阻塞
                ChildPipeServer_2.WaitForConnection();
                //reconnecting  只有客户端
                //ReConnect();
                Logger2.Infor("connected");
                StartPipeThread();

            }
            catch (Exception ex)
            {
                Logger2.Error(ex.Message);
                throw;
            }
        }

        private void ReConnect()
        {
            if (ChildPipeClient_1.IsConnected != true)

            {

                ChildPipeClient_1.Connect(10000);
                Console.WriteLine("pipe1 before  " + ChildPipeClient_1.IsConnected.ToString());
                Logger2.Infor("pipe1 before  " + ChildPipeClient_1.IsConnected.ToString());
            }
        }

        /// <summary>
        /// 子进程 读取来自服务器
        /// </summary>
        public void Pipe4Reading()
        {
            string temp1;
            while ((temp1 = sr_1.ReadLine()) != null)
            // while ((temp = sr_1.ReadLine()) != null)

            {
                //子进程 读取来自服务器的命令，
                Console.WriteLine(temp1);
               // Logger2.Infor("recing   " + temp1);
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool Pipe4Sending(string arg)
        {
            sw_2.AutoFlush = true;

            //向服务器发送从plc读取的数据，注意数据格式
            bool status;
            try
            {
                sw_2.WriteLine(arg);
                ChildPipeServer_2.WaitForPipeDrain();
                status = true;
                return status;
            }
            catch (Exception)
            {
                status = false;
                return status;
                throw;
            }

        }


        public void Pipe4Sending()
        {
            sw_2.AutoFlush = true;
            //向服务器发送从plc读取的数据，注意数据格式
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    sw_2.WriteLine($"hello{i.ToString()}");
                }
               

            }
            catch (Exception)
            {


                throw;
            }

        }
        public void Pipe4Sending(object arg)
        {
            sw_2.AutoFlush = true;
            //向服务器发送从plc读取的数据，注意数据格式
            try
            {
                sw_2.WriteLine(arg);

            }
            catch (Exception)
            {


                throw;
            }

        }
        private void StartPipeThread()
        {
            //Task ReadingTask = new Task(Pipe4Reading);
            //Task<bool> SendingTask = new Task(Pipe4Sending,"ss");
            //Task SendingTask  = new Task(() => Pipe4Sending("initing"));
            Thread th = new Thread(Pipe4Reading);
            Thread th2 = new Thread(new ParameterizedThreadStart(Pipe4Sending));
            th.IsBackground = true;
            th2.IsBackground = true;
            th.Name = "p4r";
            th.Start();
            th2.Name = "p4w";
            
            th2.Start("ssss");
            Console.WriteLine("start rec send thread {0} {1}",th.IsAlive,th2.IsAlive);
            //Pipe4Sending("ssss");
            Pipe4Sending();
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
        /// <param name="Cpu">s7型号</param>
        /// <param name="ip">plcIP地址</param>
        /// <returns></returns>
        public Plc GetInstance(CpuType Cpu, string ip)

        {
            Plc myclient = new Plc(Cpu, ip, 0, 0);

            myclient.Open();
            return myclient;
        }


    }
}
