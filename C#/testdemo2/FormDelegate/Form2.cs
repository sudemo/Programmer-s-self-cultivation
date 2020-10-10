using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDelegate
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string SetTextBoxTxt
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.f1.Show();
        }
    }
}
