using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sharpdemo2
{
    public partial class Form1 : Form
    {     
        DateTime dt = DateTime.Now.AddHours(10);
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // var time1 =dt.ToShortTimeString();
            var time = dt.ToString(); // dt 是带有年份的长时间
            label1.Text = time;
            //NumericUpDown

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string ss = label1.Text.ToString();
            if (button1.Text == "开始计时")
            {
                timer1.Start();
                button1.Text = "停止计时";
            }
            else if (button1.Text =="停止计时")
            {
                timer1.Stop();
                button1.Text = "继续计时";
            }
            else
            {
                timer1.Start();
                button1.Text = "停止计时";

            }

            #region comboBox1 可选时间段
            /* if (button1.Text == "开始计时")
                if (comboBox1.Text == "" && count == 0)
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

            } */
            #endregion
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            TimeSpan ss=  dt.Subtract(DateTime.Now);
            //将时分秒分开，这样相减之后不会有小数。显示的结果会好点
            string sss = ss.Hours.ToString()+":"+ss.Minutes.ToString()+":"+ss.Seconds.ToString();
            label1.Text = sss;//显示剩余时间

            //string sss = dt.ToString();
            var aa =ss.TotalSeconds.ToString("f0");
            if (aa=="0" )
            
            {
                timer1.Stop();//停止计时              
                button1.Text = "开始计时";
                System.Media.SystemSounds.Asterisk.Play();//提示音
                MessageBox.Show("时间到了！", "提示！");

            }


        }




    }

}
