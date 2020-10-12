using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
namespace DIYButtom
{
    public partial class UserControl1: UserControl
    {

        bool isCheck = true;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitMapOn = null;
            Bitmap bitMapOff = null;

           
            bitMapOn = Properties.Resources.kaiguanguan_1;
            bitMapOff = Properties.Resources.kaiguanguan_copy_copy;

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, Size.Width/2, this.Size.Height);

            if (isCheck)
            {
                //g.
                g.DrawImage(bitMapOn, rec);
            }
            else
            {
                g.DrawImage(bitMapOff, rec);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            this.Invalidate();
            //Console.WriteLine(Application.StartupPath);
           // pictureBox1.Image = Properties.Resources.kaiguanguan_copy_copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.kaiguanguan_1;
         }
    }
}
