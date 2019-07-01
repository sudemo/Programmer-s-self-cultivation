using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;

namespace surfdemo
{
    class surf
    {
        public void configfile()
        {
            string path = "d:/2.jpg";
            string path2 = "d:/2.jpg";

            var src1 = new Mat(path, ImreadModes.Color);
            var src2 = new Mat(path2, ImreadModes.Color);
            siftcharacterors(src1, src2);
        }

        public void siftcharacterors(Mat src1,Mat src2)
        {
            Mat gray1= new Mat();
            Mat gray2 = new Mat();
            Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

            var siftdemo = SIFT.Create();
            //寻找特征点
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfFloat();
            var descriptors2 = new MatOfFloat();
            siftdemo.DetectAndCompute(gray1, null, out keypoints1, descriptors1);
            siftdemo.DetectAndCompute(gray2, null, out keypoints2, descriptors2);

            var bfMatcher = new BFMatcher(NormTypes.L2, false);
            var flannMatcher = new FlannBasedMatcher();
            DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
            DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

            // Draw matches
            var bfView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, bfMatches, bfView);
            var flannView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, flannMatches, flannView);

            using (new Window("SIFT matching (by BFMather)", WindowMode.AutoSize, bfView))
            //using (new Window("SIFT matching (by FlannBasedMatcher)", WindowMode.AutoSize, flannView))
            {
                Cv2.WaitKey();
            }
        }
    }
}
