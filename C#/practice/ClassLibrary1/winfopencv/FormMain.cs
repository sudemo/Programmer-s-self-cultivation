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
            //opencv_method_index index = new opencv_method_index();
            switch (listBox1.SelectedItem.ToString())
            {
                case "颜色空间转换":
                    {
                        Cv2.CvtColor(input, output, ColorConversionCodes.RGB2GRAY);
                        break;
                    }
                case "OSTU":
                    {
                        Cv2.Threshold(input, output, 50, 200, ThresholdTypes.Otsu);
                        break;
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
                default:
                    //Console.WriteLine("default");
                    //FormMain form = new FormMain();
                    MessageBox.Show("请选择处理功能");
                    break;
            }
            return output;
        } 
        #endregion


    }
}