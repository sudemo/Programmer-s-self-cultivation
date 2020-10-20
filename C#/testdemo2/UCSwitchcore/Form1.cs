using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCSwitchcore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            var s = 0.1 + 0.2;
            MessageBox.Show(s.ToString());
        }
    }
}
