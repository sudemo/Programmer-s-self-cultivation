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
            ChildPipeClient = new NamedPipeClientStream(".", "nps", PipeDirection.In);
            ChildPipeServer = new NamedPipeServerStream("npc", PipeDirection.Out);
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
            this.backgroundWorker1.RunWorkerAsync();
            this.backgroundWorker2.RunWorkerAsync();


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
                //for (int i=0;i<10;i++)
                //{ 
                //    sw.WriteLine("-----start-----");
                //    ChildPipeServer.WaitForPipeDrain();
                //    //ChildPipeClient.WaitForPipeDrain();
                //    Thread.Sleep(1000); 
                //}
                //sr.ReadLine() youbug
                string temp;
                var st = new List<string>();
                Console.WriteLine("here");
                while ((temp = sr.ReadLine()) != null)
                {
                    // st.Add(temp);
                    //此处会导致数据丢失 
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
            #region MyRegion
            /*   
               while (true)
               {
                   string ss = null;
                   ss = sr.ReadLine();
                   //int s2 = ChildPipeClient.ReadByte();          
                   if (ss != null)
                   {
                       try
                       {
                           this.Invoke(new Action(() =>
                           {
                               richTextBox1.AppendText("receive from server " + sr.ReadLine() + DateTime.Now + "\n");
                           }));

                          // Thread.Sleep(1);
                       }

                       catch (Exception ex)
                       {
                           //throw;
                           MessageBox.Show(ex.Message);
                           // break;
                       }

                   }
               }

           */
            #endregion
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                richTextBox1.AppendText("starting \r\nreading.... " + DateTime.Now + "\n");
            }));
            // string temp;
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
