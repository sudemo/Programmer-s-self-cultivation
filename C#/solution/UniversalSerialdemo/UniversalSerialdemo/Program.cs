using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO.Pipes;
using static System.Console;
namespace UniversalSerialdemo
{
    class serialdemo
    {
       // private SerialPort sp;

       SerialPort sp = new SerialPort();
        private bool PortState;

        //public void PortControlConfig()
        //{

        //    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        //}
        public void OpenPort(string portName="com1", int boudRate = 115200, int dataBit = 8, int stopBit = 1, int timeout = 5000)
        {
            try
            {
                sp.PortName = portName;
                sp.BaudRate = boudRate;
                sp.DataBits = dataBit;
                sp.StopBits = (StopBits)stopBit;
                sp.ReadTimeout = timeout;
                sp.Open();
                PortState = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            try
            {
                sp.Close();
                PortState = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendData"></param>
        public void SendData(string sendData)
        {
            try
            {
                //sp.Encoding = EncodingType;
                sp.Write(sendData);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 接收数据回调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived()
        {
            while (true)
            {
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                //string str = UTF8Encoding.GetEncoding(buffer);
                string str = System.Text.Encoding.UTF8.GetString(buffer);
                WriteLine("rec {0}", str);
                //ReadKey();
            }
        }

 
static void Main(string[] args)
        {
            serialdemo serial = new serialdemo();
            serial.OpenPort();
            serial.DataReceived();
        }
    }
}
