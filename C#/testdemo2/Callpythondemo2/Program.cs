using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using poweroff;
using System.Threading;

namespace Callpythondemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "C:/Users/Neo/.conda/envs/exceldemo/python.exe";
            ps.Arguments =  "d:/S7demo1.py -u";
            //ps.Arguments = "D:/Gitrepository/github/Programmer self-cultivation/pythontoolkits/UniversalS7";
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.RedirectStandardInput = true;
            ps.RedirectStandardError = true;
            ps.CreateNoWindow = true;
           
            Program p = new Program();
            //NewMethod(ps);
            p.StartProcess(ps);
            
            Console.Read();
        }

     

        public void StartProcess(ProcessStartInfo ps)
        {
            try
            {
                Logger2.Infor("starting process");
                using (Process pt = Process.Start(ps))
                //using (Process progressTest = Process.Start(ps))
                {
                    // _ = progressTest.TotalProcessorTime;
                   

                    // 为异步获取订阅事件
                    pt.OutputDataReceived += new DataReceivedEventHandler(OnDataReceived);
                    pt.ErrorDataReceived += new DataReceivedEventHandler(OnDataReceived);
                    // 异步获取命令行内容
                    pt.BeginOutputReadLine();
                    //Thread.Sleep(2000);
                    //pt.WaitForExit();
                    //pt.Close();
                }

            }
            catch (Exception ee)
            {

                throw;
            }
        }

        private static void OnDataReceived(object Sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)

            {
                Console.WriteLine(e.Data);
                Logger2.Infor(e.Data);
            }
        }
        //public void outputDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(e.Data))
        //    {
        //        Logger2.Infor(e.Data);
        //        //Console.WriteLine(e.Data);
        //    }
        //    else
        //    {
        //        Console.WriteLine("nullllll");
        //    }
        //}

    }
}
