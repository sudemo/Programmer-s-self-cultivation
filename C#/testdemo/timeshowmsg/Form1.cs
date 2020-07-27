using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timeshowmsg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //closemsg();
        }
        public void closemsg()
        {
            Task.Delay(1000);
            new Task(() =>
            {
                SendKeys.Send("{ENTER}");
            }
            ).Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //new Task(() => { Console.WriteLine('1'); }).Start();
            this.AcceptButton = this.button2;
        }
        #region MyRegion

        void ShowMsg(string msg)
        {
            new Thread(() =>
            {
                TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                for (int i = 3; i > 0; i--)
                {
                    bool _forceVisible = false;
                    // 如果强制不显示，则终止循环显示
                    if (_forceVisible)
                    {
                        _forceVisible = false;
                        return;
                    }
                    OperationLabelMethod(lab, msg + "\r\n" + i + "秒后关闭");
                    Thread.Sleep(ts);
                }
                OperationLabelMethod(lab, null);
            }).Start();
            //MessageBox.Show(msg);
        }
        delegate void OperationLabel(Label lab, string txt);
        /// <summary>
        /// 通过委托方法设置或隐藏Label
        /// </summary>
        /// <param name="lab"></param>
        /// <param name="txt"></param>
        void OperationLabelMethod(Label lab, string txt)
        {
            if (lab.InvokeRequired)
            {
                OperationLabel method = OperationLabelMethod;
                if (!this.IsDisposed)// 点保存，然后马上关闭窗体时，会导致this变成null了，所以这里要判断
                    Invoke(method, lab, txt);
            }
            else
            {
                if (string.IsNullOrEmpty(txt))
                {
                    lab.Text = string.Empty;
                    lab.Visible = false;
                }
                else
                {
                    lab.Text = txt;
                    lab.Visible = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        } 
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            //ShowMsg("hello");
            //this.Close();
            

            if (MessageBox.Show("closing", "info", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MessageBox.Show("ok");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok2");
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }
    }
}
