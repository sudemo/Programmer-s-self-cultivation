using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.UserInterface;

namespace winfopencv

{   
    public partial class FormMain : Form
    {
        
        
        public FormMain()
        {
            InitializeComponent();
        }

        static opencvmethod obj_opencv_method = null;
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
            textBox1.AppendText("成功添加" + listBox1.SelectedItem.ToString() + "!");

        }

        private void listBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }

        private void BtnRun_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("ok");
        }

        
    }
}