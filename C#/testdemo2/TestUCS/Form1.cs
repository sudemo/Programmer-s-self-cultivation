using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;	//居中字符串【左、右对齐类似】
            Graphics graphics = this.CreateGraphics();
            graphics.DrawString("hello", Font, new SolidBrush(Color.Green), new Point(20,5), stringFormat);
            //g.DrawString("hello", Font, new SolidBrush(m_trueTextColr), new Point((Height - 2 - 4 - 10) / 2, intTextY));
        }
    }
}
