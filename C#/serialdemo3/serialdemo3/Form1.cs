using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace serialdemo3
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        void s_DataReceived(object sender, SerialDataReceivedEventArgs e)   //数据接收事件，读到数据的长度赋值给count，如果是8位（节点内部编程规定好的），就申请一个byte类型的buff数组，s句柄来读数据
        {
            string str = s.ReadExisting();     //字符串方式读
            richTextBox2.AppendText(str);     //添加内容

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!s.IsOpen)
                {
                    s.Open();
                }

                else
                {
                    s.Close();
                    s.DataReceived -= s_DataReceived;
                    button1.Text = "打开串口";
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
           
         

        private void button3_Click(object sender, EventArgs e)   //每次发一个字节
        {
            if (s.IsOpen)      //如果串口开启
            {
                if (richTextBox2.Text.Trim() != "")     //如果框内不为空则
                {
                    //串口发送数据的方式1
                    s.Write(richTextBox2.Text.Trim()); // Trim()去掉头尾的空白字符
                    //串口发送数据的方式2
                    //Byte[] TxData ={1,2,3,4,5,6,7,8 };
                    //com.Write(TxData, 0, 8);
                }
                else
                {
                    MessageBox.Show("发送框没有数据");
                }
            }
            else
            {
                MessageBox.Show("串口未打开");
            }
        }

      
    }
}