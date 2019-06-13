using System;
using System.Collections.Generic;
using System.IO.Ports;              //需要引入的命名空间
using System.Text;
using System.Data;
using System.Xml;


namespace 串口通信发送和接收端
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPortTest port = new SerialPortTest();
            //port.Send();    //发送数据
            //port.Close();   //关闭COM口
            while (true)
            {
                
            }
        }

    }


    public class SerialPortTest
    {
        SerialPort port;
        public SerialPortTest()
        {
            //指定COM1口,根据情况也可以指定COM2口
            port = new SerialPort("COM1");
            //指定波特率
            port.BaudRate = 9600;
            port.Encoding = System.Text.Encoding.GetEncoding("gb2312");
            try
            {
                //打开COM口
                port.Open();
                //接收数据
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

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //存储接收的字符串
            string strReceive = string.Empty;
            if (port != null)
            {
                //读取接收到的字节长度
                int n = port.BytesToRead;
                //定义字节存储器数组
                byte[] byteReceive = new byte[100];
                //接收的字节存入字节存储器数组
                port.Read(byteReceive, 0, 100);
                //把接收的的字节数组转成字符串
                strReceive = Encoding.Default.GetString(byteReceive);
                Console.WriteLine("接收到的数据是: " + strReceive);
            }
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
}