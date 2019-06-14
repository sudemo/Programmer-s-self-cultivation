using System;
using System.Collections.Generic;
using System.IO.Ports;              
using System.Text;
using System.Data;
using System.Xml;
using log4net;
//using Log;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace UniversalSerial //利用事件，日志读写可以放在异步中做。
{
    #region 调用方法demo
    class Example
    {
        static void Main(string[] args)
        {
            //log4net.Config.XmlConfigurator.Configure();
            UniversalSerialPort port = new UniversalSerialPort();
            //port.rec  rec 是私有的，只能由事件触发
            port.Send();    //发送数据
            //port.Close();   //关闭COM口
            LogHelper.Info ("初始化连接开始");
            LogHelper.WriteLog("this is  a test");

            while (true)
            {
                //nth 
                //LogHelper.Info("send thread start");
            }
        }
    }
    #endregion
    #region 封装的串口类
    public class UniversalSerialPort
    {
        SerialPort port;//默认是私有
        public UniversalSerialPort() //构造方法内初始化
        {            
            port = new SerialPort("COM1");
            port.BaudRate = 9600;
            port.Encoding = System.Text.Encoding.GetEncoding("gb2312");
            try
            {
                port.Open();
                Receieve();
            }
            catch (Exception)
            {
                Console.WriteLine("打开COM口失败");
            }
        }

        //接收数据
        private void Receieve()
        {
            //接收到数据就会触发port_DataReceived方法
            port.DataReceived += port_DataReceived;
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e) //todo: 在这里可以做 解析接收到的信息
        {
            //存储接收的字符串
            string strReceive = string.Empty;
            if (port != null)
            {
                //读取接收到的字节长度
                int n = port.BytesToRead;
                //定义字节存储器数组
                byte[] byteReceive = new byte[n];
                //接收的字节存入字节存储器数组
                port.Read(byteReceive, 0, n);
                //把接收的的字节数组转成字符串
                strReceive = Encoding.Default.GetString(byteReceive);
                string res = Response(strReceive);
                Console.WriteLine("接收到的数据是: " + res);
            }
        }

        public string Response(string arg) //返回信息处理部分，此处只能接收并返回string,可以考虑重载或者用泛型
        {
            string[] arg1=arg.Split(',');
            string arg2 = String.Join("", arg1);
            return arg2;
        }

        //发送数据
        public void Send()
        {
            //从控制台获取输入的字符串
            Console.WriteLine("请输入字符串:");
            string strRead = Console.ReadLine();
            //当输入不是q时，就一直等到输入并发送
            while (strRead != "q")
            {
                //去掉输入字符串的前后空格
                //strRead = strRead.Trim();
                if (!strRead.Equals(""))
                {
                    //串口发送数据
                    port.WriteLine(strRead);
                    LogHelper.Info("send finish");
                }
                Console.WriteLine("请输入字符串:");
                strRead = Console.ReadLine();
            }

        }
        public void Send(string str) //重载发送函数
        {
            if (!str.Equals(""))
            {
                //串口发送数据
                port.WriteLine(str);
            }
            //Console.WriteLine("请输入字符串:");
           // strRead = Console.ReadLine();
        }
        
        //关闭COM口
        public void Close()
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                port.Dispose();
            }
        }

    }
    #endregion
}