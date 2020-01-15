

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Blob;

namespace vppdemo2
{
    public partial class MainForm : Form
    {
        //CogImageFileTool mIFTool;
        CogAcqFifoTool mAcqTool;
        public bool closeflag = true;
        private bool isMax = false;
        private static MainForm mf =null;
        private CogToolBlock vpp_block =null;
        private CogImageFileTool mIFTool = null;
       // private string vpp_path = @"D:\项目资料\GDL\Height\Height\Debug\SetVpp\ImageProcess\GD1.vpp";
        public MainForm()
        {
            InitializeComponent();
            cogToolBlockEditV21.LocalDisplayVisible = false;
            mIFTool = new CogImageFileTool();
            string pathalpha = Environment.GetEnvironmentVariable("VPRO_ROOT");
            mIFTool.Operator.Open(Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\images\coins.idb", CogImageFileModeConstants.Read);
            mAcqTool = new CogAcqFifoTool();
            //CogToolBlockEditV21
            Init_Vpp();
            cogToolBlockEditV21.Subject = CogSerializer.LoadObjectFromFile(Environment.GetEnvironmentVariable("VPRO_ROOT") + @"\samples\programming\toolblock\toolblockload\tb.vpp") as CogToolBlock;
            cogToolBlockEditV21.Subject.Ran += new EventHandler(Subject_Ran);

        }


        void Subject_Ran(object sender, EventArgs e)
        {
            // This method executes each time the TB runs
            
            // Update the CogDisplayRecord with the image and the lastRunRecord
            cogRecordDisplay1.Image = cogToolBlockEditV21.Subject.Inputs["Image"].Value as CogImage8Grey;
            CogBlobTool mBlobTool = cogToolBlockEditV21.Subject.Tools["CogBlobTool1"] as CogBlobTool;
            cogRecordDisplay1.Record = mBlobTool.CreateLastRunRecord();
            cogRecordDisplay1.Fit(true);
        }
        
        //public MainForm
        public static MainForm GetInstance()
        {
            if (mf == null)
            {
                mf = new MainForm();
            }
            return mf;
        }
        //获取父窗口的大小
        /*public void GetPWindowSize()
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
          
        }*/

        public void Init_Vpp()
        {
            //vpp_block = (CogToolBlock)CogSerializer.LoadObjectFromFile(vpp_path);
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

       

        private void cogToolBlockEditV21_Load(object sender, EventArgs e)
        {

        }

        //private void btnRun_Click(object sender, EventArgs e)
        //{
        //    // Get the next image
        //    if (radImageFile.Checked == true)
        //    {
        //        mIFTool.Run();
        //        CogToolBlock
        //        cogToolBlockEditV21.Subject.Inputs["Image"].Value = mIFTool.OutputImage as CogImage8Grey;
        //    }
        //    else
        //    {
        //        mAcqTool.Run();
        //        cogToolBlockEditV21.Subject.Inputs["Image"].Value = mAcqTool.OutputImage as CogImage8Grey;
        //    }
        //    // Run the toolblock
        //    cogToolBlockEditV21.Subject.Run();
        //}

    }
}
