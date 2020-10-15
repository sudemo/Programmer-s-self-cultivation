using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIYButton2
{
    public partial class Form1 : Form
    {
        bool isCheck=true;
        public Form1()
        {
            InitializeComponent();
        }
        Switch sw = new Switch();
        protected override void OnPaint(PaintEventArgs e)
        {

            //true is green color ,false is grey

            if(isCheck)
            { 
                sw.pictureBox1.Image = Properties.Resources.kaiguanguan_1; //绿色
            }
            else sw.pictureBox1.Image = Properties.Resources.soff; //黑白
            //sw.pictureBox1.Image = isCheck ? Properties.Resources.kaiguanguan_1 : Properties.Resources.soff;
        }
        private void switch1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("triggered");
            isCheck = !isCheck;
            //this.Refresh();
            this.Invalidate();
            //sw.pictureBox1.Image = Properties.Resources.soff; //黑白
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

    
    }
}
