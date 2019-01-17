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

namespace uidemo2
{
    public partial class Form1 : Form
    {
        SerialPort s = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            button1.Text = "open";
            int[] item = { 9600, 115200 };
            foreach (int a in item)
            {
                comboBox2.Items.Add(a.ToString());
            }
            comboBox2.SelectedItem = comboBox2.Items[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            //comboBox1.SelectedItem = comboBox1.Items[0];
            s.DataReceived += new SerialDataReceivedEventHandler(S_DataReceived);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try   
            {
                if (!s.IsOpen)
                {
                    s.Open();
                    button1.Text = "closed serialport";
                    s.DataReceived += S_DataReceived;
                }
                else
                {
                    s.Close();
                    button1.Text = "open port";
                }     

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

       

        private void S_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // string str = s.ReadExisting();     //字符串方式读
            // richTextBox1.AppendText(str);//添加内容
            
            string indata = s.ReadExisting();
            Console.WriteLine("Data Received:{0}",indata);
            richTextBox1.AppendText(indata);//添加内容
            //richTextBox1.ResetText(indata);
            //richTextBox1.ResetText()
            //Console.Write(indata);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (s.IsOpen)
            {
                if (richTextBox2.Text.Trim() != "")
                {
                    s.Write(richTextBox2.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("no data in the box");
            }
        }

       
    }
}
