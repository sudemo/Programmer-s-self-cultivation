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
        private static SerialPort myserial=null; 
        //接收
        public static void ReceiveDataThread()
        {
            while (true)
            {    
                    byte[] rec = new byte[100];
                    myserial.Read(rec, 0, 100);
                    string str = Encoding.Default.GetString(rec);
                    Console.WriteLine("接收到信息: {0}", str);
                    Thread.Sleep(50);

                //return rec;
            }

        }
        public static void SendDataTH()
        {
            while (true)
            {
                Console.Write("plz inout: ");
                string inputstr = Console.ReadLine();
                myserial.Write(inputstr);
                Console.WriteLine("send: {0}", inputstr);
            }
        }

        //public void configsetting()
        //{
        //    myserial.PortName = "com2";
        //    myserial.BaudRate = 115200;
        //    myserial.DataBits = 8;
        //    myserial.StopBits = StopBits.One;
        //}
        //public static void threadstart()
        //{
        //    Thread recthread = new Thread(ReceiveDataThread);
        //    Thread sendthread = new Thread(SendDataTH);
        //    if (recthread != null)
        //    {
        //        recthread.Start();
        //    }
        //    if (sendthread != null)
        //    {
        //        sendthread.Start();
        //    }
            //while (true)
            //{
            //    Thread.Sleep(100);
            //}
        //}



        static void Main(string[] args)
        {
            //Serialdemo myserialinstance = new Serialdemo();
            myserial = new SerialPort();

            myserial.PortName = "com1";
            myserial.BaudRate = 9600;
            myserial.DataBits = 8;
            myserial.StopBits = StopBits.One;
            myserial.Parity = Parity.Odd;
            //myserial.ReadTimeout = 5000;
            myserial.Encoding = Encoding.GetEncoding("utf-8");
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
            Thread th11 = new Thread(ReceiveDataThread);
            if (th11 != null)
                th11.Start();

            // 启动发送线程
            Thread th22 = new Thread(SendDataTH);
            if (th22 != null)
                th22.Start();
            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}



