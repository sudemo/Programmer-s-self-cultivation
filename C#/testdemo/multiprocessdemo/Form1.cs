using logbaseQuene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiprocessdemo
{
    public partial class Form1 : Form
    {

        private StreamReader sr;
        private StreamWriter sw;
        bool enable = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();

        }

        // 初始化管道和启动进程的参数
        public void init()
        {

            process1.StartInfo.FileName = "SocketProcess.exe";
            process1.StartInfo.Arguments = "40 127.0.0.1 10 3 1";
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.CreateNoWindow = false;
            process1.StartInfo.RedirectStandardOutput = false;
            #region MyRegion
            //process1.StartInfo();
            //ProcessStartInfo ps = new ProcessStartInfo();
            //try
            //{
            //    PipeServer.WaitForConnection();
            //    string test;
            //    sw.WriteLine("Waiting");
            //    sw.Flush();
            //    PipeServer.WaitForPipeDrain();
            //    test = sr.ReadLine();
            //    Console.WriteLine(test);
            //}

            //catch (Exception ex) { throw ex; }

            //finally
            //{
            //    PipeServer.WaitForPipeDrain();
            //    if (PipeServer.IsConnected) { PipeServer.Disconnect(); }
            //} 
            #endregion
        }

        public void initPipe()
        {
            try

            {


                var PipeServer = new NamedPipeServerStream("np1", PipeDirection.Out);
                var PipeChild = new NamedPipeClientStream(".", "np2", PipeDirection.In);
                 sr = new StreamReader(PipeChild);
                 sw = new StreamWriter(PipeServer);


                PipeServer.WaitForConnection();
                PipeChild.Connect();


                bool res = PipeServer.IsConnected;
                Logger2.Infor("pipe连接结果：" + res.ToString());
                this.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(res.ToString() +" "+ DateTime.Now + "\n");
                }));
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    // Thread.Sleep(100);
                    //string t= ;

                    this.Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText(temp + " " + DateTime.Now + "\n");
                    }));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public bool check_process_status()
        {
            //为什么有时候带.exe有时候不带》》就是不带的

            Process[] plist = Process.GetProcessesByName("SocketProcess");
            if (plist.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// ProcessName = "1.exe"
        /// </summary>
        /// <param name="ProcessName"></param>
        /// <returns></returns>
        public bool check_process_status(string ProcessName)  //
        {
            Process[] plist = Process.GetProcessesByName(ProcessName);
            if (plist.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //启动一个新的socket进程
            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
            // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show((check_process_status()).ToString());
            Process[] plist = Process.GetProcessesByName("SocketProcess");
            if (plist.Length == 1)
            {
                foreach (var p in plist)
                {
                    p.Kill();
                    Console.WriteLine(p.HasExited);
                }
            }

            MessageBox.Show((check_process_status()).ToString());
            #region MyRegion
            //Process piClient = new Process();

            //piClient.StartInfo.FileName = "SocketProcess.exe";

            //using (AnonymousPipeServerStream pipeServer =
            //    new AnonymousPipeServerStream(PipeDirection.Out,
            //    HandleInheritability.Inheritable))
            //{
            //    Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
            //        pipeServer.TransmissionMode);

            //    // Pass the client process a handle to the server.
            //    piClient.StartInfo.Arguments =
            //        pipeServer.GetClientHandleAsString() + "  ssss";
            //    // 如果 UserName 属性不为 空引用（在 Visual Basic 中为 Nothing） 或不是一个空字符串，
            //    // 则 UseShellExecute 必须为 false，否则调用Process.Start(ProcessStartInfo) 
            //    // 方法时将引发 InvalidOperationException。
            //    piClient.StartInfo.UseShellExecute = false;
            //    piClient.StartInfo.CreateNoWindow = true;
            //    //piClient.StartInfo.RedirectStandardInput = true;
            //    //piClient.StartInfo.RedirectStandardOutput = true;

            //    piClient.Start();

            //    pipeServer.DisposeLocalCopyOfClientHandle();
            //    try
            //    {
            //        // Read user input and send that to the client process.
            //        using (StreamWriter sw = new StreamWriter(pipeServer))
            //        {
            //            sw.AutoFlush = true;
            //            // Send a 'sync message' and wait for client to receive it.
            //            sw.WriteLine("SYNC");
            //            pipeServer.WaitForPipeDrain();
            //            // Send the console input to the client process.
            //            Console.Write("[SERVER] Enter text: ");
            //            sw.WriteLine(Console.ReadLine());
            //        }
            //    }
            //    // Catch the IOException that is raised if the pipe is broken
            //    // or disconnected.
            //    catch (IOException ex)
            //    {
            //        Console.WriteLine("[SERVER] Error: {0}", ex.Message);
            //    }
            //}

            //piClient.WaitForExit();

            //piClient.Close();
            //Console.WriteLine("[SERVER] Client quit. Server terminating."); 
            #endregion

        }


        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { //不能多次点击
            //open pro 如果允许点击且进程不存在
            if (button3_open_socketprocess.Enabled && !check_process_status())
            {
                process1.Start();
                new Task(() =>
                initPipe()).Start();

                button3_open_socketprocess.Enabled = !enable;
                GreypictureBox1.Image = Properties.Resources.green;
                //button4_open_socketprocess.Enabled = true;
            }
            else
            {
                button3_open_socketprocess.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { //end process
            
            //string ss = process1.ProcessName;
            if (check_process_status())

            {
                //process1.Close(); //只是用来清理托管资源，不负责退出程序
                process1.Kill();
                process1.Close(); //只是用来清理托管资源，不负责退出程序
                sw.Close();
                sr.Close();     //清理管道资源，可以重复开启而不报错           
            }
            
            GreypictureBox1.Image = Properties.Resources.red;
            
            button3_open_socketprocess.Enabled = true;
            
            //Application.DoEvents();效率低，但是体验好，可以用异步代替更好

        }
        private void button5_Click(object sender, EventArgs e)
        {
            #region test
            //var s = Math.Round(53.3012619227981, 2);

            ////Random sss = new Random(Convert.ToInt32( DateTime.Today.Day));

            //double punchingRadius = 51.9290909090909;
            //punchingRadius = Math.Round(punchingRadius, 2);
            //var sss = Convert.ToDouble(punchingRadius.ToString().Split('.')[1]) / 200;


            //richTextBox1.Text = sss.ToString(); 
            #endregion

            string temp = richTextBox2.Text;
            sw.WriteLine(temp);
            richTextBox2.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

       
    }
}

