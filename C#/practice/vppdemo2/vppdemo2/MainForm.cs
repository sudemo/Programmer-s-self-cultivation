using Cognex.VisionPro;
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
        public bool closeflag = true;
        private bool isMax = false;
        private static MainForm mf =null;
        public MainForm()
        {
            InitializeComponent();
        }

        public static MainForm GetInstance()
        {
            if (mf == null)
            {
                mf = new MainForm();
            }
            return mf;
        }
        //获取父窗口的大小
        public void GetPWindowSize()
        {
            int x = cogDisplay1.Location.X;
            int y = cogDisplay1.Location.Y;
            int wid = cogDisplay1.Width;
            int height = cogDisplay1.Height;
        
        }

        public void ChangeWindowSize()
        {
            MainForm.GetInstance();
            if (!isMax)
            {
                //cogDisplay1.SetBounds(0, 0, mf.Right - mf.Left, mf.Bottom - mf.Top);
                cogDisplay1.SetBounds(0,0,20,10);
                cogDisplay1.Show();
                isMax = true;
            }
            else
            {//原来位置大小
                cogDisplay1.SetBounds(74, 104, 192, 192);
                cogDisplay1.Show();
                isMax = false;
            }
        }

        private void cogDisplay1_Enter(object sender, EventArgs e)
        {
            mf.ChangeWindowSize();
        }
        //双击与enter 的区别 
        private void cogDisplay1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.GetInstance();
            mf.ChangeWindowSize();
            //MessageBox.Show("1 ok");
          
        }

       
       
        private void cogDisplay1_Enter_1(object sender, EventArgs e)
        {

        }

        private void cogDisplay2_Enter(object sender, EventArgs e)
        {

        }

        private void 相机1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

 
    }
}
