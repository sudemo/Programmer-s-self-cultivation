using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace opencvdemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Mat src = new Mat("d:/2.jpg", ImreadModes.Grayscale);
             Mat src = Cv2.ImRead("d:/2.jpg", ImreadModes.Grayscale);
            Mat src1 = Cv2.ImRead("d:/2.jpg", ImreadModes.Color);
            Mat dst = new Mat();
            
            Cv2.Canny(src1, dst, 50, 200);
            using (new Window("src image", src))
            using (new Window("dst image", dst))
            {
                Cv2.WaitKey();
                
            }
        }
    }
}
