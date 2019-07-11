using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;

namespace winfopencv

{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        public string my_imagesource, my_imagesource2;
        //static opencvmethod obj_opencv_method = null;
        private Mat image1;
        private Mat image2;

        private static double getFps(VideoCapture capture)
        {
            using (var image = new Mat())
            {
                while (true)
                {
                    /* start camera */
                    capture.Read(image);
                    if (!image.Empty())
                    {
                        break;
                    }
                }
            }

            using (var image = new Mat())
            {
                double counter = 0;
                double seconds = 0;
                var watch = Stopwatch.StartNew();
                while (true)
                {
                    capture.Read(image);
                    if (image.Empty())
                    {
                        break;
                    }

                    counter++;
                    seconds = watch.ElapsedMilliseconds / (double)1000;
                    if (seconds >= 3)
                    {
                        watch.Stop();
                        break;
                    }
                }
                var fps = counter / seconds;
                return fps;
            }
        }




        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int methodnum;
            methodnum = listBox1.SelectedIndex;
            listBox2.Items.Add(listBox1.SelectedItem);
            textBox1.AppendText("成功添加" + listBox1.SelectedItem.ToString() + "!\r\n");
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //用于修改参数
        }
        private void BtnRun_Click(object sender, System.EventArgs e)
        {
            if (my_imagesource != null)
            {
                //MessageBox.Show("ok");
                image1 = new Mat(my_imagesource);
                image2 = new Mat();
                //opencvmethod obj_opencv_method = new opencvmethod();

                //image2 = obj_opencv_method.opencv_method_run(image1, image2);//运行
                image2 = opencv_method_run(image1, image2);
                try
                {
                    pictureBox1.Image = image2.ToBitmap();
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                    //break;
                }

                textBox1.AppendText("\r\n 处理完成！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            else
            {
                textBox1.AppendText("\r\n 请先加载图片？！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
        }

        private void btn_open_image_Click(object sender, System.EventArgs e)
        {
            //FormMain form1 = (FormMain)this.Owner;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "JPEG图像(*.jpg)|*.jpg|PNG图像(*.png)|*.png|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != string.Empty)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                my_imagesource = openFileDialog1.FileName;

                textBox1.AppendText("\r\n打开文件路径：" + openFileDialog1.FileName);
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            else
            {
                textBox1.AppendText("\r\n 请先选择打开一张图片？！");
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }

        }


        #region opencv method
        public Mat opencv_method_run(Mat input, Mat output)
        {
            try
            {
                //opencv_method_index index = new opencv_method_index();
                #region switch
                Scalar scalargreen = new Scalar(0x00, 0xFF, 0x00);//绿色 same as 255
                Scalar scalarred = new Scalar(0x00, 0x00, 0xff);//red
                Scalar scalar = new Scalar(0, 255, 255);
                Mat binImage = new Mat();
                switch (listBox1.SelectedItem.ToString())
                {
                    case "颜色空间转换":
                        {
                            Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            break;
                        }
                    case "OSTU":
                        {
                            Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            Cv2.Threshold(output, binImage, 10, 250, ThresholdTypes.Otsu);
                            return binImage;
                            //break;
                        }
                    case "Hist":
                        {
                            Rangef[] rangefs = new Rangef[]
                                     {
                                        new Rangef(0, 256),
                                     };
                            int[] hsize = {250};
                            Mat mask =new Mat();
                            Mat[] mats = new Mat[] { output };
                            int[] channels = new int[] { 0 };
                           Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            Cv2.CalcHist(mats,channels,mask,binImage,1,hsize,rangefs,true,false);

                            //Console.WritleLine的后面加上
                            //Mat HistImage = new Mat(MatType.CV_8UC3, new Scalar(0, 0, 0));
                            Mat HistImage = new Mat(binImage.Width, binImage.Height, MatType.CV_8UC3, new Scalar(0, 0, 0));
                            for (int i = 0; i < 256; i++)//画直方图
                            {

                                Cv2.Line(HistImage, new Point(binImage.Width/256 * (i - 1), binImage.Height - Math.Round(binImage.At<float>(i - 1))), new Point(binImage.Width/256 * (i - 1), binImage.Height - Math.Round(binImage.At<float>(i))), new Scalar(255, 0, 0), 1, LineTypes.AntiAlias);
                               
                                //int len = (int)((binImage.Get<float>(i)) * output.Rows);//单个箱子的长度，
                                //                                                           // 10000) * panda.Rows)的作用只是让他变短，别超出了
                                //Cv2.Line(output, i, 0, i, len, Scalar.Black, 2);//把线画出来

                            }
                            //Cv2.ImShow("s",HistImage);
                            using (new Window("histImage", WindowMode.Normal, HistImage))
                                return HistImage;
                            //break;
                        }
                    case "固定阈值化":
                        {
                            Cv2.Threshold(input, output, 150, 200, ThresholdTypes.Binary);
                            break;
                        }
                    case "边缘检测CANNY":
                        {
                            Cv2.Canny(input, output, 45, 200);
                            break;
                        }
                    case "霍夫圆变换":
                        #region hough circle
                        {
                           
                                                                         //LineSegmentPoint[] lines;
                            CircleSegment[] circles;
                            OpenCvSharp.Size size = new OpenCvSharp.Size(output.Width, output.Height);
                            Mat image_out3 = new Mat(size, MatType.CV_8UC3);
                            Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            //3: dp:累加器分辨率与图像分辨率的反比。默认=1
                            /*4：minDist: 检测到的圆的中心之间的最小距离。(最短距离 - 可以分辨是两个圆的，否则认为是同心圆 - src_gray.rows / 8)
                             *5:param1: 第一个方法特定的参数。[默认值是100] canny边缘检测阈值低                        
                            *6:param2:  第二个方法特定于参数。[默认值是100] 中心点累加器阈值 – 候选圆心                         
                            *7:minRadius: 最小半径
                            *8:maxRadius: 最大半径*/
                            circles = Cv2.HoughCircles(output, HoughMethods.Gradient, 1, 20, 100, 30, 1, 5000);
                            Mat dst = new Mat();
                            input.CopyTo(dst);
                            for (int i = 0; i < circles.Length; i++)
                            { 
                                //圆
                                Cv2.Circle(dst, (int)circles[i].Center.X, (int)circles[i].Center.Y, (int)circles[i].Radius, scalargreen, 2, LineTypes.AntiAlias);
                                //加强圆心显示
                                Cv2.Circle(dst, (int)circles[i].Center.X, (int)circles[i].Center.Y, 3,scalarred, 2, LineTypes.Link8);
                            }
                            //using (new Window("OutputImage", WindowMode.AutoSize, dst)) ;
                            //Cv2.WaitKey();                     
                            //break;
                            return dst;
                        }
                    #endregion
                    #region hough linesp
                    case "霍夫累计概率变换":
                        {
                            // Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            /*
                              1； image: 输入图像 （只能输入单通道图像）
                  *      2； rho:   累加器的距离分辨率(以像素为单位) 生成极坐标时候的像素扫描步长
                  *      3； theta: 累加器的角度分辨率(以弧度为单位)生成极坐标时候的角度步长，一般取值CV_PI/180 ==1度
                  *      4； threshold: 累加器阈值参数。只有那些足够的行才会返回 投票(>阈值)；设置认为几个像素连载一起才能被看做是直线。
                  *      5； minLineLength: 最小线长度，设置最小线段是有几个像素组成。
                  *      6；maxLineGap: 同一条线上的点之间连接它们的最大允许间隙。(默认情况下是0）：设置你认为像素之间隔多少个间隙也能认为是直线
                              */
                            Cv2.Canny(input, output, 45, 200);
                            LineSegmentPoint[] linePoint;
                            linePoint = Cv2.HoughLinesP(output, 1, 2, 10, 1);
                            for (int i = 0; i < linePoint.Length; i++)
                            {
                                Point p1 = linePoint[i].P1;
                                Point p2 = linePoint[i].P2;
                                Cv2.Line(output, p1, p2, scalar, 4, LineTypes.AntiAlias);
                            }

                            using (new Window("DST", WindowMode.AutoSize, output))
                                return output;
                        }
                    #endregion
                    case "自适应阈值":
                        {
                            
                            Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            Cv2.AdaptiveThreshold(~output,binImage, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 15, -2);
                            return binImage;
                        }
                    case "漫水填充":
                        {
                           // Mat binImage = new Mat();
                            Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                            Cv2.AdaptiveThreshold(~output, binImage, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 15, -2);
                            return binImage;
                        }

                    default:
                        //Console.WriteLine("default");
                        //FormMain form = new FormMain();
                        MessageBox.Show("请选择处理功能");
                        break;
               

                }
                #endregion
                return output;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+"未先选择处理方法或者处理异常");
                return input;
            }                    
            
            
            #endregion
        }

    }
}