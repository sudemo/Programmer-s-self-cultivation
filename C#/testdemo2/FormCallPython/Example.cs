using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolApp
{
    public partial class Example : Form
    {
        private Process progressTest;

        public Example()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 开始测试
        /// </summary>
        /// <param name="pathAlg">py文件路径</param>
        /// <param name="a">加数a</param>
        /// <param name="b">加数b</param>
        /// <returns></returns>
        public bool StartTest(string pathAlg, int a, int b)
        {
            bool state = true;

            if (!File.Exists(pathAlg))
            {
                throw new Exception("The file was not found.");
                //return false;
            }
            string sArguments = pathAlg;
            //sArguments += " " + a.ToString() + " " + b.ToString() + " -u";//Python文件的路径用“/”划分比较常见
            sArguments += " " + "f1" + " -u";
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "C:/Users/Neo/.conda/envs/exceldemo/python.exe";//环境路径需要配置好
            //start.FileName = "python.exe";
            ps.Arguments = sArguments;
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.RedirectStandardInput = true;
            ps.RedirectStandardError = true;
            ps.CreateNoWindow = true;

            try
            {



                using (progressTest = Process.Start(ps))
                {
                   // _ = progressTest.TotalProcessorTime;
                    // 异步获取命令行内容
                    progressTest.BeginOutputReadLine();

                    // 为异步获取订阅事件
                    progressTest.OutputDataReceived += new DataReceivedEventHandler(outputDataReceived);
                    progressTest.ErrorDataReceived += new DataReceivedEventHandler(outputDataReceived);
                    //
                }
            }
            catch (Exception e2)
            {

                MessageBox.Show(e2.Message);
            }
            //progressTest.WaitForExit();
            return state;

        }

        public void outputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                this.Invoke(new Action(() =>
                {
                    this.textBox3.Text = e.Data;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.richTextBox1.AppendText("no data\n");
                }));
            }
        }

        private void Example_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                //string path = Application.StartupPath + @"/demo2.py";//py文件路径
                string path = "d:/S7demo1.py";
                //string path = "D:/Gitrepository/github/Programmer self-cultivation/pythontoolkits/UniversalS7/S7demo1.py";
                int a = Convert.ToInt32(this.textBox1.Text);
                int b = Convert.ToInt32(this.textBox2.Text);
                StartTest(path, a, b);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
    }
}