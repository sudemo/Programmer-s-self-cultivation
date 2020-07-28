using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
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
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //启动一个新的socket进程
            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
            // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            // Process.Start(startInfo);

            startInfo.Arguments = "127.0.0.1";

            Process.Start(startInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            Process piClient = new Process();

            piClient.StartInfo.FileName = "SocketProcess.exe";
            piClient.StartInfo.Arguments = "2";
            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.Out,
                HandleInheritability.Inheritable))
            {
                Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                    pipeServer.TransmissionMode);

                // Pass the client process a handle to the server.
                piClient.StartInfo.Arguments =
                    pipeServer.GetClientHandleAsString();
                piClient.StartInfo.UseShellExecute = false;
                piClient.Start();

                pipeServer.DisposeLocalCopyOfClientHandle();

            }

        }
    }
}
