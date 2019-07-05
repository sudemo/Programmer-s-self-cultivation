using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
namespace winfopencv
{
    class opencvmethod
    {
        #region opencv_method index
        public enum opencv_method_index  //方法排排坐写这里面一一对应一个下标
        {
            cvt_color = 0,
            boxfilter,
            blur,
            gaussianblur,
            medianblur,
            bilateralfilter,
            dilate,
            erode,
            morphologyex,
            floodfill,
            pyrup,
            pyrdown,
            resize,
            threshold,
            canny,
            sobel,
            laplacian,
            scharr,
            convertscaleabs,
            addweighted,
            houghlines,
            houghlinep,
            houghcircles,
            remap,
            warpaffine,
            equalizehist,
            facedetection,
            findcontours,
            drawcontours,
            convexhull,
            boundingrect,
            minarearect,
            minenclosingcircle,
            fillellipse,
            approxpolydp,
            moments,
            contourarea,
            arclength,
            watershed,
            inpaint,
            calchist,
            minmaxloc,
            comparehist,
            calcbackproject,
            matchtemplate,
            cornerharris,
            goodfeaturestotrack,
            cornersubpix,
            drawkeypoints,
            drawmatches,
            ORB,


            number  //用于统计总数
        };
        #endregion
        public static opencvmethod obj_opencv_method = null;

        public Mat opencv_method_run(Mat input_img,Mat output_img)
        {
            var index =new opencv_method_index();
            switch ( index)
            {
                case opencv_method_index.cvt_color:
                    {
                        Cv2.CvtColor(input_img, output_img,ColorConversionCodes.BayerRG2GRAY);
                        break;
                    }
            }
            return output_img;
        }
    }
}
