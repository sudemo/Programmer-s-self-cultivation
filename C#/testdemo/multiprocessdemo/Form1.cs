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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiprocessdemo
{
    public partial class Form1 : Form
    {
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
            process1.StartInfo.Arguments = "hello";
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.CreateNoWindow = false;
            process1.StartInfo.RedirectStandardOutput = false;
            //process1.StartInfo();
            //ProcessStartInfo ps = new ProcessStartInfo();
            //try
            //{
            //    pipeServer.WaitForConnection();
            //    string test;
            //    sw.WriteLine("Waiting");
            //    sw.Flush();
            //    pipeServer.WaitForPipeDrain();
            //    test = sr.ReadLine();
            //    Console.WriteLine(test);
            //}

            //catch (Exception ex) { throw ex; }

            //finally
            //{
            //    pipeServer.WaitForPipeDrain();
            //    if (pipeServer.IsConnected) { pipeServer.Disconnect(); }
            //}
        }

        public void　initPipe()
        {
            var pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 4);

            StreamReader sr = new StreamReader(pipeServer);
            StreamWriter sw = new StreamWriter(pipeServer);

            Task taskPipe = Task.Run(() => pipeServer.WaitForConnection());
            //Task taskPipe1 = new Task(() => pipeServer.WaitForConnection());   taskPipe1.Start();

            //string t= sr.ReadLine();
            bool res = pipeServer.IsConnected;
            Logger2.Infor(res.ToString());
            richTextBox1.Text = res.ToString();
        }

        public bool check_process_status()
        {
            Process[] plist = Process.GetProcessesByName("SocketProcess.exe");
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
            // Process.Start(startInfo);

            //startInfo.Arguments = "127.0.0.1";

            Process.Start(startInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Process piClient = new Process();

            piClient.StartInfo.FileName = "SocketProcess.exe";

            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out,
                HandleInheritability.Inheritable))
            {
                Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                    pipeServer.TransmissionMode);

                // Pass the client process a handle to the server.
                piClient.StartInfo.Arguments =
                    pipeServer.GetClientHandleAsString() + "  ssss";
                // 如果 UserName 属性不为 空引用（在 Visual Basic 中为 Nothing） 或不是一个空字符串，
                // 则 UseShellExecute 必须为 false，否则调用Process.Start(ProcessStartInfo) 
                // 方法时将引发 InvalidOperationException。
                piClient.StartInfo.UseShellExecute = false;
                piClient.StartInfo.CreateNoWindow = true;
                //piClient.StartInfo.RedirectStandardInput = true;
                //piClient.StartInfo.RedirectStandardOutput = true;

                piClient.Start();

                pipeServer.DisposeLocalCopyOfClientHandle();
                try
                {
                    // Read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        // Send a 'sync message' and wait for client to receive it.
                        sw.WriteLine("SYNC");
                        pipeServer.WaitForPipeDrain();
                        // Send the console input to the client process.
                        Console.Write("[SERVER] Enter text: ");
                        sw.WriteLine(Console.ReadLine());
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException ex)
                {
                    Console.WriteLine("[SERVER] Error: {0}", ex.Message);
                }
            }

            piClient.WaitForExit();

            piClient.Close();
            Console.WriteLine("[SERVER] Client quit. Server terminating.");

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { //不能多次点击
            if (!check_process_status())
            {
                process1.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check_process_status())
            { process1.Kill(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var s=Math.Round(53.3012619227981, 2);

            //Random sss = new Random(Convert.ToInt32( DateTime.Today.Day));

            double punchingRadius = 51.9290909090909;
            punchingRadius = Math.Round(punchingRadius,2);
            var sss = Convert.ToDouble(punchingRadius.ToString().Split('.')[1])/200;


            richTextBox1.Text = sss.ToString();
        }
    }
}

