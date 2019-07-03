using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace capturedemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        
        //=void run_cap()
        //{
        //    try
        //    {
        //        Mat src = new Mat();
        //        //FrameSource frame = Cv2.CreateFrameSource_Camera(0);
        //        FrameSource frame = Cv2.CreateFrameSource_Video("C:/Users/zwzhang/Pictures/Movie/bach.mp4");
        //        while (f1)
        //        {

        //            frame.NextFrame(src);

        //            Bitmap bitmap = BitmapConverter.ToBitmap(src);


        //            Invalidate();
        //            pictureBox1.Invalidate();

        //            //Bitmap imshow = null;
        //            Bitmap imgshow = bitmap;

        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        //Console.Write(e);
        //        MessageBox.Show(e.Message);
        //       // throw;
        //    }

        //}

        static string file = "C:/Users/zwzhang/Pictures/Movie/bach.mp4";
        //public static VideoCapture FromFile(string file)
        //{ }
        VideoCapture capture = VideoCapture.FromFile(file);
        //static VideoCapture capture = new VideoCapture(@"C:/Users/zwzhang/Pictures/Movie/bach.mp4");
        static bool isopen = false;
       
        private void button1_Click(object sender, EventArgs e)
        {   if (isopen = false)
            {
                isopen = !isopen;
                Run();
            }
            else {
                isopen = false;
                Run();
            }
            //MessageBox.Show("here");

            //pictureBox1.Refresh();//马上刷新

            //Image imgshow0 = Image.FromFile("d:/lenna.jpg");
            //pictureBox1.Image = imgshow0;
            //Thread threadA = new Thread();
            //threadA.Start();
        }
        
        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    if (isopen)
        //    {
        //        Mat image = new Mat();
        //        capture.Read(image);
        //        if (image.Empty())
        //        {
        //            isopen = !isopen;
        //        }
        //        else
        //        {
        //            int sleepTime = (int)Math.Round(1000 / capture.Fps);
        //            // When the movie playback reaches end, Mat.data becomes NULL.
        //            while (true)
        //            {
        //                capture.Read(image); // same as cvQueryFrame
        //                if (image.Empty())
        //                    break;
        //                //Window.ShowImage(image);
                     
        //                //pictureBox1.BackgroundImage(image);
                        
        //                Cv2.WaitKey(sleepTime);
        //            }
        //        }
        //    }
        //}

        public void Run()
        {
            // Opens MP4 file (ffmpeg is probably needed)
            var capture = new VideoCapture(file);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using (var window = new Window("capture"))
            {
                // Frame image buffer
                Mat image = new Mat();

                // When the movie playback reaches end, Mat.data becomes NULL.
                while (sleepTime>0)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty())
                        break;
                    //pictureBox1_Paint.Show(image);
                    window.ShowImage(image);
                    Cv2.WaitKey(sleepTime);
                }
            }
        }
        }
}