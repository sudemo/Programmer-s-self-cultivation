using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///这里添加串口操作类
using System.IO.Ports;
///这里添加线程管理类
using System.Threading;

namespace HelloWorld //demo2example
{
    class program
    {
        // 声明串口类实例
        static SerialPort port = new SerialPort();
        //private static SerialPort port = null;

        // 将char[]数组转换为string类型并返回
        private static string CharArrayTosting(char[] cha, int len)
        {
            string str = "";

            for (int i = 0; i < len; i++)
            {
                str += string.Format("{0}", cha[i]);
            }

            return str;
        }
        // 接收线程
        private static void receivedata()
        {
            byte[] rec = new byte[100];
            while (true)
            {
                port.Read(rec, 0, 100);
                //if (rec.Length >1)                
                //string str = CharArrayTosting(rec, 100);
                string str = Encoding.Default.GetString(rec);
                Console.WriteLine("接收线程:{0}", str);
                
                //Thread.Sleep(50);
            }
        }
        // 发送线程
        private static void senddata()
        {
            while (true)
            {
                string str = Console.ReadLine();
                Console.Write("plz input: ");
                port.Write(str);
                //Console.WriteLine("发送线程:" + str);
                Thread.Sleep(50);
            }
        }
        static void Main(string[] args)
        {
            // 配置串口
            port = new SerialPort("COM1");
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Odd;
            port.Open();

            // 打开
           // labelcheck:
            if (port.IsOpen)
            {
                Console.WriteLine("串口打开成功1");
            }
            else
            {
                Console.WriteLine("串口打开失败1");
             
               // goto labelcheck;
            }
            // 启动接收线程
            Thread th1 = new Thread(receivedata);
            if (th1 != null)
                th1.Start();

            // 启动发送线程
            Thread th2 = new Thread(senddata);
            if (th2 != null)
                th2.Start();

            //while (true)
            //{
            //    Thread.Sleep(100);
            //}
        }
    }
}