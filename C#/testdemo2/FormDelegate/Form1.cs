using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDelegate
{

    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Visible = false;
            f2.SetTextBoxTxt = "hello this is s";
            f2.Show();
            //Form1 f1 = new Form1();
            Common.f1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show("Test");
            Console.WriteLine("HESE");
        }
    }
}
