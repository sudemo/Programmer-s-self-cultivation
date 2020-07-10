using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uidemo1
{
    public partial class Form1 : Form
    {
        public event EventHandler myevent;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("text");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("next");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sayhello();

            
           
        }

        public void sayhello()
        {
        }
        public void hello(object sender, EventArgs e)
        {
            MessageBox.Show("hello {0}",sender.ToString());
        }
       

    }
}
