using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace FormDelegate
{
    public partial class DIYSwitchButton : UserControl
    {
        public DIYSwitchButton()
        {
            InitializeComponent();
        }

        private void DIYSwitchButton_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
