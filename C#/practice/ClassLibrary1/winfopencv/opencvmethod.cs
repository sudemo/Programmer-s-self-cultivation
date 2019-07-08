using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        }
        #endregion
        //public static opencvmethod obj_opencv_method = null;

        public Mat anopencv_method_run(Mat input_img, Mat output_img)
        {
            opencv_method_index index =new opencv_method_index();
            switch (index)
            {
                case opencv_method_index.cvt_color:
                    {
                        Cv2.CvtColor(input_img, output_img, ColorConversionCodes.RGB2BGR);
                        break;
                    }
                case opencv_method_index.threshold:
                    {
                        Cv2.Threshold(input_img, output_img, 50, 200, ThresholdTypes.Otsu);
                        break;
                    }
                case opencv_method_index.canny:
                    {
                        Cv2.Canny(input_img,output_img,45,200);
                        break;
                    }
                default:
                    //Console.WriteLine("default");
                    //FormMain form = new FormMain();
                    MessageBox.Show("default");
                    break;
            }


            //FormMain form = new FormMain();


            return output_img;
        }

        //测试
        //opencv_method_index op;
        public void testswitch()
        {
            opencv_method_index op = new opencv_method_index();
            switch (op)
            {
                case opencv_method_index.cvt_color:
                    MessageBox.Show("1");
                    break;

            }
        }
       
           
    }
}


