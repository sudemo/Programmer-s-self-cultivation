using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace callqtdemo2
{
    public partial class Form1 : Form
    {


        [DllImport("QtToggle_dll.dll", EntryPoint = "_ZN12QtToggle_dll14callDongleInitEPKc")] //函数名变了

        public static extern bool callDongleInit();

        public Form1()
        {
            InitializeComponent();
            //bool ss = callDongleInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            callDongleInit();
        }
        
    }
}
