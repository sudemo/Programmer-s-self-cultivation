using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;

namespace serialdemo2
{
    public class Serialdemo
    {
        //实例
        private SerialPort myserial = new SerialPort();
        //接收
        public static void ReceiveDataThread()
        {
            while (true)
            {
                char[] rec = new char[100];
                myserial.Read(rec, 0, 100);
                Console.WriteLine("接收到信息: {0}", rec);
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
            Thread sendthread = new Thread(SendDataTH());
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

            myserial.PortName = "com3";
            myserial.BaudRate = 115200;
            myserial.DataBits = 8;
            myserial.StopBits = StopBits.One;
            myserial.Open();
            
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
            //myserialinstance.
            //Serialdemo se = new Serialdemo();
            // //se.configsetting();
            // se.threadstart();
        }
    }
}



