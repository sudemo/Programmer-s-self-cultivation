using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace serialdemo2   //demo2
{
    public class Serialdemo
    {
        //实例
        private static SerialPort myserial = new SerialPort();
        //接收
        public static void ReceiveDataThread()
        {
            while (true)
            {
                char[] rec = new char[100];
                myserial.Read(rec, 0, 100);
                Console.WriteLine("接收到信息: {0}", rec);
                Thread.Sleep(500);
                //return rec;
            }

        }
        public static void SendDataTH()
        {
            string inputstr = Console.ReadLine();
            myserial.Write(inputstr);
            Console.WriteLine("send: {0}", inputstr);
        }

        //public void configsetting()
        //{
        //    myserial.PortName = "com2";
        //    myserial.BaudRate = 115200;
        //    myserial.DataBits = 8;
        //    myserial.StopBits = StopBits.One;
        //}
        public static void threadstart()
        {
            Thread recthread = new Thread(ReceiveDataThread);
            Thread sendthread = new Thread(SendDataTH);
            if (recthread != null)
            {
                recthread.Start();
            }
            if (sendthread != null)
            {
                sendthread.Start();
            }
            while (true)
            {
                Thread.Sleep(100);
            }
        }



        static void Main(string[] args)
        {
            //Serialdemo myserialinstance = new Serialdemo();
            SerialPort myserial = new SerialPort();

            myserial.PortName = "com1";
            myserial.BaudRate = 115200;
            myserial.DataBits = 8;
            //myserial.StopBits = StopBits.One;
            myserial.Open();
            if (myserial.IsOpen)
            {
                Console.WriteLine("串口打开成功..");
            }
            else
            {
                Console.WriteLine("串口打开失败..");
            }


            //threadstart();
            // 启动接收线程
            Thread th1 = new Thread(ReceiveDataThread);
            if (th1 != null)
                th1.Start();

            // 启动发送线程
            Thread th2 = new Thread(SendDataTH);
            if (th2 != null)
                th2.Start();
            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}



