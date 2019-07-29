using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Caliper;           //卡尺命名空间
using Cognex.VisionPro.CalibFix;         //定位工具命名空间FixTureToll
using Cognex.VisionPro.Dimensioning;    //尺寸测量命名空间
using Cognex.VisionPro.Exceptions;

using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vppdemo
{
    public partial class Form1 : Form
    {
        ICogAcqFifo mAcqFifo;//定义一个相机对象
        private ICogFrameGrabber mFrameGrabber = null;
        private CogImageFileTool m_ImageFileTool;//声明
        CogFrameGrabberGigEs mframe = new CogFrameGrabberGigEs();
        public Form1()
        {
            InitializeComponent();
            m_ImageFileTool = new CogImageFileTool();//不能写InitializeComponent()前面。
            //Camera cam = new Camera();
            //cam.Tool11 = (CogToolBlock)CogSerializer.LoadObjectFromFile(cam.CamPath1);

        }
        CogRecordDisplay cogRecordDisplay1 = new CogRecordDisplay();

       
    }
}
