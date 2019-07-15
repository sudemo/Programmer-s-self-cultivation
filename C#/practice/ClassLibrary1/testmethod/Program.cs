using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;
using ZXing.Datamatrix;
using ZXing.Common;

namespace testmethod
{
    class Program
    {

        public void datamatrix()
        {
            IBarcodeReader reader = new BarcodeReader();
            // load a bitmap
            

            var barcodeBitmap =(Bitmap)Image.LoadFrom("d:\\2.jpg");
            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(barcodeBitmap);
            // do something with the result
            if (result != null)
            {
                Form1 fm = new Form1();
                txtDecoderType.Text = result.BarcodeFormat.ToString();
                txtDecoderContent.Text = result.Text;

            }

        }

        public void testhist()
        {
            Mat img = new Mat();
            img = Cv2.ImRead("d:/lena1.jpg");
            //Console.WriteLine("hist");
            //using (new Window("histimg", img)) ;
            Cv2.ImShow("hs",img);
           // Cv2.WaitKey();
            Rangef[] rangefs = new Rangef[]
                                     {
                                        new Rangef(0, 256),
                                     };
            int[] hsize = { 255 };
            Mat histimg = new Mat();
            Mat output = new Mat();
            Mat[] mats = new Mat[] { img };
            int[] channels = new int[] { 1 };
            Cv2.CvtColor(img, output, ColorConversionCodes.RGB2GRAY);
            Cv2.CalcHist(mats, channels, output, histimg, 1, hsize, rangefs, true, false);
            for (int i = 0; i < 256; i++)//画直方图
            {
                // Cv2.Line(HistImage, new Point(binImage.Width/256 * (i - 1), binImage.Height - Math.Round(binImage.At<float>(i - 1))), new Point(binImage.Width/256 * (i - 1), binImage.Height - Math.Round(binImage.At<float>(i))), new Scalar(255, 0, 0), 1, LineTypes.AntiAlias);

                // int len = (int)((binImage.Get<float>(i)) * output.Rows);//单个箱子的长度，
                //                                                           
                Cv2.Line(histimg, new Point(img.Width/256*(i-1), img.Height - Math.Round(img.At<float>(i - 1))), new Point(img.Width / 256 * (i - 1), img.Height - Math.Round(img.At<float>(i))), Scalar.Black, 2);//把线画出来
            }
            Cv2.ImShow("hist", histimg);
            Cv2.WaitKey();
        }

        static void Main(string[] args)
        {
            Program a = new Program();
            a.testhist();
        }
    }
}
