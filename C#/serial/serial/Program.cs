using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
namespace serial2
{
    public partial class Form1 : Form
    {
        SerialPort s = new SerialPort();    //实例化一个串口对象，在前端控件中可以直接拖过来，但最好是在后端代码中写代码，这样复制到其他地方不会出错。s是一个串口的句柄
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;   //防止跨线程访问出错，好多地方会用到
            button1.Text = "打开串口";
            int[] item = { 9600, 115200 };    //定义一个Item数组，遍历item中每一个变量a，增加到comboBox2的列表中
            foreach (int a in item)
            {
                comboBox2.Items.Add(a.ToString());
            }

            comboBox2.SelectedItem = comboBox2.Items[1];    //默认为列表第二个变量
        }
        private void Form1_Load(object sender, EventArgs e)   //窗体事件要先配置端口信息。
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedItem = comboBox1.Items[0];
            //Array.Sort(ports);

        }
        private void button1_Click(object sender, EventArgs e)   //下面讲解中差不多已经讲清楚了
        {
            try
            {
                if (!s.IsOpen)
                {
                    s.PortName = comboBox1.SelectedItem.ToString();
                    s.BaudRate = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                    s.Open();
                    s.DataReceived += s_DataReceived;
                    button1.Text = "关闭串口";
                    //MessageBox.Show("串口已打开");
                }
                else
                {
                    s.Close();
                    s.DataReceived -= s_DataReceived;
                    button1.Text = "打开串口";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        void s_DataReceived(object sender, SerialDataReceivedEventArgs e)   //数据接收事件，读到数据的长度赋值给count，如果是8位（节点内部编程规定好的），就申请一个byte类型的buff数组，s句柄来读数据
        {
            int count = s.BytesToRead;
            string str = null;
            if (count == 8)
            {
                byte[] buff = new byte[count];
                s.Read(buff, 0, count);
                foreach (byte item in buff)    //读取Buff中存的数据，转换成显示的十六进制数
                {
                    str += item.ToString("X2") + " ";
                }
                richTextBox1.Text = System.DateTime.Now.ToString() + ": " + str + "\n" + richTextBox1.Text;      //这是跨线程访问richtextbox,原程序和DataReceived事件是两个不同的线程同时在执行
                if (buff[0] == 0x04)   //如果节点是04发来的数据
                {
                    ID.Text = buff[0].ToString();   //这下面是上位机右边那一段，用来显示处理好的数据的温度、湿度、光照、灰尘、ID信息的。buff【0】中存的是数据的ID信息，显示在ID的Label上面
                    switch (buff[2])   //判断数据类型  buff【0】和buff【1】代表ID的低位和高位，同理2和3代表数据类型的低位和高位，当2和3的值为1时，4和5代表温度，6和7代表湿度；

                    {
                        case 0x01:       //当2和3的值为1,4和5是温度，6和7是湿度
                            {
                                Tem.Text = (buff[5] * 4 + buff[4] * 0.05 - 30).ToString();
                                Hum.Text = (buff[6] + buff[7]).ToString();
                                break;
                            }
                        case 0x02://6和7是光照
                            {
                                Light.Text = (buff[6] + buff[7]).ToString();
                                break;
                            }
                        case 0x04://6和7是灰尘
                            {
                                Dust.Text = (buff[6] + buff[7]).ToString();
                                break;
                            }
                        default:
                            break;
                    }
                }

            }

        }
        private void button3_Click(object sender, EventArgs e)   //每次发一个字节
        {
            string[] sendbuff = richTextBox2.Text.Split();  //分割输入的字符串，判断有多少个字节需要发送
            Debug.WriteLine("发送字节数：" + sendbuff.Length);
            foreach (string item in sendbuff)
            {
                int count = 1;
                byte[] buff = new byte[count];
                buff[0] = byte.Parse(item, System.Globalization.NumberStyles.HexNumber);//格式化字符串为十六进制数值
                s.Write(buff, 0, count);
            }
        }
        private void button2_Click(object sender, EventArgs e)//刷新右边的数值
        {
            int count = 1;
            byte[] buff = new byte[count];
            buff[0] = byte.Parse("04", System.Globalization.NumberStyles.HexNumber);//这里只显示04节点的信息
            s.Write(buff, 0, count);
        }
    }
}