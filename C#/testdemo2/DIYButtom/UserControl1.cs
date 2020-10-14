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
    public partial class BenNHControl : UserControl
    {
        #region MyRegion
        /*
       bool isCheck = true;
       public UserControl1()
       {
           InitializeComponent();
       }



       protected override void OnPaint(PaintEventArgs e)
       {
           Bitmap bitMapOn = null;
           Bitmap bitMapOff = null;


           bitMapOn = Properties.Resources.kaiguanguan_1;
           bitMapOff = Properties.Resources.kaiguanguan_copy_copy;

           Graphics g = e.Graphics;
           Rectangle rec = new Rectangle(0, 0, Size.Width, this.Size.Height);

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
       */
        #endregion

        private Color valveBackColor = Color.Green;
        [Category("阀门内部"), Description("阀门内部的颜色")]
        public Color ValveBackColor
        {
            get { return valveBackColor; }
            set
            {
                valveBackColor = value;
                this.Invalidate();
            }
        }


        public BenNHControl()
        {
            InitializeComponent();

            //设置透明背景
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.FromArgb(0, 0, 0, 0);
            //BackColor = Color.Transparent;
        }

        private void BenNHValve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            int len = this.Width;
            Point point = new Point(this.Width / 2, this.Height / 2);
            Point[] topTriangLePoints = new Point[4];
            topTriangLePoints[0] = point;
            topTriangLePoints[1] = new Point(point.X - len, point.Y - len);
            topTriangLePoints[2] = new Point(point.X + len, point.Y - len);
            topTriangLePoints[3] = point;
            g.FillPolygon(new SolidBrush(this.valveBackColor), topTriangLePoints);


            Point[] bottomTianglePoints = new Point[4];
            bottomTianglePoints[0] = point;
            bottomTianglePoints[1] = new Point(point.X - len, point.Y + len);
            bottomTianglePoints[2] = new Point(point.X + len, point.Y + len);
            bottomTianglePoints[3] = point;

            g.FillPolygon(new SolidBrush(this.valveBackColor), bottomTianglePoints);
        }

    }
}
