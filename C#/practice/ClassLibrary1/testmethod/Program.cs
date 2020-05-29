using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;
using ZXing.Datamatrix;
using ZXing.Common;
using System.IO;
using System.Drawing.Imaging;

namespace testmethod
{
    class Program
    {
        string filepath = "C:/Users/zwzhang/Pictures/barcode/1563173493.png";
        string filepath1 = "C:/Users/zwzhang/Pictures/barcode/cli-DATAMATRIX.png";
        public void qrcode()
        {
            IBarcodeReader reader = new BarcodeReader();
            // load a bitmap            
            try
            {
                var barcodeBitmap = (Bitmap)Image.FromFile(filepath);
                //var barcodeBitmap =(Bitmap)Image.LoadFrom("d:\\2.jpg");
                // detect and decode the barcode inside the bitmap
                var result = reader.Decode(barcodeBitmap);
                // do something with the result
                if (result != null)
                {                
                    MessageBox.Show(result.Text);
                }
                else               
                    MessageBox.Show("没有解析到内容");                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);                
            }           
        }

        public void datamatrix()
        {
            Bitmap img = Cv2.ImRead(filepath).ToBitmap();
            //DatamatrixEncodingOptions opt = new DatamatrixEncodingOptions();
            DataMatrixReader dm = new DataMatrixReader();          
            byte[] bmap = Bitmap2Byte(img);
            LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Length, bmap.Length);
            //LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Length, bmap.Length);
            BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
            //Result result;
            var result= dm.decode(bitmap);
            if (result != null)
            { MessageBox.Show(result.Text); }
            else
            { MessageBox.Show("null"); }
        }


        public static byte[] Bitmap2Byte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }

        //private void decodematrix()
        //{
            
        //    Image img = Image.FromFile(filepath1);
        //    Bitmap bmap1;
        //    try
        //    {
        //        bmap1 = new Bitmap(img);
        //    }
        //    catch (System.IO.IOException ioe)
        //    {
        //        MessageBox.Show(ioe.ToString());
        //        return;
        //    }
        //    if (bmap1 == null)
        //    {
        //        MessageBox.Show("Could not decode image");
        //        return;
        //    }

        
        //    LuminanceSource source = new RGBLuminanceSource(bmap, bmap.Width, bmap.Height);
        //    BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
        //    Result result;
        //    try
        //    {
        //        result = new MultiFormatReader().decode(bitmap);
        //    }
        //    catch (ReaderException re)
        //    {
        //        MessageBox.Show(re.ToString());
        //        return;
        //    }

        //    MessageBox.Show(result.Text);
        //}

        public void testhist()
        {
            Mat img = new Mat();
            img = Cv2.ImRead("d:/lena1.jpg");
            //Console.WriteLine("hist");
            //using (new Window("histimg", img)) ;
            Cv2.ImShow("hs",img);
           Cv2.WaitKey();
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
                //Cv2.Line(histimg, new Point(img.Width/256*(i-1), img.Height - Math.Round(img.At<float>(i - 1))), new Point(img.Width / 256 * (i - 1), img.Height - Math.Round(img.At<float>(i))), Scalar.Black, 2);//把线画出来
            }
           // Cv2.ImShow("hist", histimg);
            //Cv2.WaitKey();
        }

        static void Main(string[] args)
        {
            Program a = new Program();
           a.testhist();
            //a.datamatrix();
            //a.qrcode();
        }
    }
}
