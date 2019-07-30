using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vppdemo2
{
    public partial class MainForm : Form
    {
        //public bool closeflag = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void cogDisplay1_Enter(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.initForm1();
        }

        private void cogDisplay1_DoubleClick(object sender, EventArgs e)
        {
            
            Form1 fm1 = new Form1();
            fm1.initForm1();
        }

        private void display_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
