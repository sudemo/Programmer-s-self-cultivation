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
        SerialPort port;

        public program()
        {
            // 配置串口
            port = new SerialPort("COM1");
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;
            port.Open();
        }
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
        public void receivedata()
        {
            while (true)
            {
                int n = port.BytesToRead;
                if (n > 0)
                {
                    byte[] rec = new byte[n];
                    port.Read(rec, 0, n);
                    //if (rec.Length >1)                
                    //string str = CharArrayTosting(rec, 100);
                    string str = Encoding.Default.GetString(rec);
                    Console.WriteLine("接收线程:{0}", str);
                    Thread.Sleep(50);
                }
            }
        }
        // 发送线程
        public void senddata()
        {
            while (true)
            {
                Console.Write("plz input: ");
                string str = Console.ReadLine();
               
                port.Write(str);
                //Console.WriteLine("发送线程:" + str);
                Thread.Sleep(50);
            }
        }
    }
    public class mainclass
        {
            static void Main(string[] args)
            {
                program myport = new program();

            myport.receivedata();
            myport.senddata();
            }
    }
}