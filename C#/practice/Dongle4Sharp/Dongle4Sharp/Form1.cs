using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dongle4Sharp2test
{
    public partial class Form1 : Form
    {
        int count;//用于定时器计数
        int time;//存储设定的定时值
        Timer timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               int i;
         
            for(i=1;i<100;i++)//计数范围（0-99）
            {
                comboBox1.Items.Add(i.ToString() + " 秒");//初始化下拉列表框（数字后加一个空格便于程序读取）
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();

            /*if(button1.Text == "开始计时") 
                if (comboBox1.Text == ""&&count ==0)

                {
                    MessageBox.Show("请选择时间！", "提示！");
                }
                else
                {
                    string str = comboBox1.Text;//将下拉框内容添加到一个变量中
                    time = Convert.ToInt16(str.Substring(0, 2));
                    //progressBar1.Maximum = time;
                    
                    timer1.Start();
                    button1.Text = "停止计时";
                }
            else if (button1.Text == "停止计时")
            {
                timer1.Stop();
                //progressBar1.Value = count;
                button1.Text = "继续计时";

            }
            else
            {
                timer1.Start();
                button1.Text = "停止计时";

            }
*/

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            label3.Text = (time - count).ToString() + "秒";//显示剩余时间
            //progressBar1.Value = count;//设置进度条进度
            if (count == time)
            {
                timer1.Stop();//停止计时
                //progressBar1.Value = 0;
                count = 0;
                button1.Text = "开始计时";
                System.Media.SystemSounds.Asterisk.Play();//提示音
                MessageBox.Show("时间到了！", "提示！");
            }


        }
    }
}
