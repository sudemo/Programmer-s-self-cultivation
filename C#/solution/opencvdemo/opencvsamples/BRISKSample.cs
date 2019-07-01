using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
//using 

namespace opencvsamples
{
   //using OpenCvSharp;
    //using SampleBase;

    namespace SamplesCS
    {
        /// <summary>
        /// Retrieves keypoints using the BRISK algorithm.
        /// </summary>
        class BRISKSample : ISample
        {
            public void Run()
            {
                Mat gray = new Mat("d:/2.jpg", ImreadModes.Grayscale);
                //Mat gray = new Mat("d:/2.jpg", ImreadModes.Grayscale);
                Mat dst = new Mat("d:/2.jpg", ImreadModes.Color);
                BRISK brisk = BRISK.Create();
                KeyPoint[] keypoints = brisk.Detect(gray);

                if (keypoints != null)
                {
                    var color = new Scalar(0, 255, 0);
                    foreach (KeyPoint kpt in keypoints)
                    {
                        float r = kpt.Size / 2;
                        Cv2.Circle(dst, (Point)kpt.Pt, (int)r, color);
                        Cv2.Line(dst,
                            (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r),
                            (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r),
                            color);
                        Cv2.Line(dst,
                            (Point)new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r),
                            (Point)new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r),
                            color);
                    }
                }

                using (new Window("BRISK features", dst))
                {
                    Cv2.WaitKey();
                }
            }
        }
    }
}
