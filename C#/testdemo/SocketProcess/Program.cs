using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpYaml;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using SharpYaml.Serialization;
using System.Data;

namespace SocketProcess
{
    class Program
    {
        public struct SettingStruct
        {
            public bool status;
            public byte content;
            public int num;
        }


        static void Main(string[] args)
        {
            //ParseYaml py = new ParseYaml();
            //py.parse_myyaml();

           // Console.ReadKey();



            CreateSocketProcess cs = new CreateSocketProcess(CpuType.S71500, "127.0.0.1");
            Plc MyProxy = cs.MyPlcInstance; 
            MyProxy.Open();
            MyProxy.ReadBytes(DataType.DataBlock,cs.DB,cs.StartAddr,cs.ReadCount);
            
            
            //Plc client1= cs.GetInstance(CpuType.S71500,"127.0.0.1");
            //client1.ReadBytes(DataType.DataBlock,20,0,50);
            // var ss= client1.ReadStruct(typeof(SettingStruct),25);
           // var s1 = client1.ReadBytes(DataType.DataBlock,25,0,5);
        }
    }

    

    public class ParseYaml
    {
        string path = @"d:/Configuration/Configuration.ini";
        string path2 = @"d:/Configuration/motorconfig.yaml";
        public void parse_myyaml()
        {
            //TextReader tx = File.OpenText(path);
            //StreamReader tx = File.OpenText(path);

            StreamReader tx = new StreamReader(path2);
            StreamReader sr = new StreamReader(path);
            string[] arrstr = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var yaml = new YamlStream();
            yaml.Load(tx);
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            string key = string.Empty;
            foreach (var m in mapping.Children)
            {
                Console.WriteLine("keyss: {0}", m);
            }
        }
    }

    public class CreateSocketProcess
    {
        
        public Plc MyPlcInstance;


        public int DB { get; set; };
        public int StartAddr { get; set; }
        public int ReadCount { get; set; }
        //public int StartAddr { get; set; }

        public CreateSocketProcess(CpuType cpu, string ip, short rack=0, short slot=0)
        {
            MyPlcInstance = new Plc(cpu,ip,rack,slot);
            
        }
        public CreateSocketProcess(CpuType cpu, string ip,int db,int Start, int Count)
        {
            MyPlcInstance = new Plc(cpu, ip, 0,0);
            ReadCount = Count;
            this.StartAddr = Start;
            DB = db;
        }

        public CreateSocketProcess( string ip, int db, int Start, int Count)
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
        public Plc GetInstance(CpuType C, string  ip)

        {
            Plc myclient = new Plc(C, ip, 0, 0);
            
            myclient.Open();
            return myclient;
        }


    }
}
