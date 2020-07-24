using PLCHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multisocketdemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Thread th1 = new Thread(socdemo1);
            //Thread th2 = new Thread(socdemo2);
            //th2.Start();
            int i = 0;
            //string ip;
            //IPAddress[] iparray;
            //iparray = Dns.GetHostAddresses(Dns.GetHostName());
            //IPAddress localip = iparray.First(ip =>ip.AddressFamily==AddressFamily.InterNetwork);
            //Console.WriteLine(localip);
            //var ip2 = "192.168.0.11";
            //ProcessStartInfo st = new ProcessStartInfo();
            //st.FileName = @"poweroff.exe";
            //st.Arguments = ip2;
            //st.CreateNoWindow = true;
            //st.UseShellExecute = false;
            ////var res =  Process.Start("poweroff.exe", ip2);  
            //Process p = Process.Start(st);
            //Thread.Sleep(3000);

            mystartinfo();
           // Console.ReadKey();

        }



        static void mystartinfo()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("poweroff.exe");
            // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
           // Process.Start(startInfo);

            startInfo.Arguments = "127.0.0.1";

            Process.Start(startInfo);
        }


        public static void socdemo1()
        {

            var myclient1 = PlcHelper.plcHelper_ins.GetInstance();
            myclient1.Open();
            object res1 = myclient1.ReadDB(1, 3, 3);
            byte[] res = (byte[])res1;
            foreach (short r in res)
            {
                Console.Write(r);
            }
            //Console.Write
            // this.richTextBox1.Text = res2.ToString();
        }

        public static void socdemo2()
        {

            var myclient2 = PlcHelper.plcHelper_ins.GetInstance();
            myclient2.Open();
            var res2 = myclient2.ReadDB(1, 3, 3);
            // this.richTextBox1.Text = res2.ToString();
            byte[] res = (byte[])res2;
            foreach (short r in res)
            {
                Console.Write(r);
            }
        }

        public static void generate_soc()
        {
            List<PlcHelper> soc = new List<PlcHelper>();
            for (int i = 0; i < 10; i++)

            {
                soc[i] = PlcHelper.plcHelper_ins.GetInstance();
            }

        }
    }
}
