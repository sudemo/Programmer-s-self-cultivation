using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo2
{
    public partial class Form1 : Form
    {
        public static NamedPipeClientStream ChildPipeClient;// read 
        public static NamedPipeServerStream ChildPipeServer;//write

        public static StreamReader sr;
        public static StreamWriter sw;
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //initPipe();
            new Task(() =>
             initPipe()).Start();
        }

        private void initPipe()
        {
            ChildPipeClient = new NamedPipeClientStream(".", "np1", PipeDirection.In);
            ChildPipeServer = new NamedPipeServerStream("np2", PipeDirection.Out);
            sr = new StreamReader(ChildPipeClient);
            sw = new StreamWriter(ChildPipeServer);
            
            ChildPipeServer.WaitForConnection();
            ChildPipeClient.Connect();
            this.Invoke(new Action(() =>
            {
                richTextBox1.AppendText("connected" + ChildPipeServer.IsConnected.ToString() +
                    ChildPipeClient.IsConnected.ToString());
            }));
            sw.AutoFlush = true;
            this.ReadbackgroundWorker1.RunWorkerAsync();
            this.SendbackgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
              {
                  richTextBox1.AppendText("starting \r\nconnecting to the pipe.... " + DateTime.Now + "\n");
              }));
                //richTextBox1.SaveFile
                this.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText($"Conneted {ChildPipeClient.NumberOfServerInstances} pipe server instances open " +
                ChildPipeServer.IsConnected.ToString() + DateTime.Now + "\n");
                }));          
                string temp;
                var st = new List<string>();
                Console.WriteLine("here");
                while ((temp = sr.ReadLine()) != null)
                {
                    // st.Add(temp);
                    this.Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText("receive from server " + temp + DateTime.Now + "\n");
                    }));
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                richTextBox1.AppendText("starting \r\nwriting.... " + DateTime.Now + "\n");
            }));
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("helllllo  " + i.ToString());
                }

                this.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText("send to client finished " + DateTime.Now + "\n");
                }));

                Thread.Sleep(1000);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }



}
