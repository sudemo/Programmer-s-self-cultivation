using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using PLCHelper;


namespace multisocketdemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            socdemo1();

        }


        public void socdemo1()
        {

           var myclient1 =     PlcHelper.plcHelper_ins.GetInstance();
            myclient1.Open();
           var res1= myclient1.ReadDB(1,0,2);
            this.richTextBox1.Text = res1.ToString();

        }

        public void socdemo2()
        {

            var myclient2 = PlcHelper.plcHelper_ins.GetInstance();
            myclient2.Open();
            var res2= myclient2.ReadDB(1,3,3);
            this.richTextBox1.Text = res2.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            socdemo2();
           
        }
    }
}
