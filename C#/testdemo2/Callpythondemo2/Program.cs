using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Callpythondemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "C:/Users/Neo/.conda/envs/exceldemo/python.exe";
            ps.Arguments = "d:/S7demo1.py script 1 -u";
            //ps.Arguments = "d:/demo1.py 1 1";
            ps.UseShellExecute = true;
            ps.RedirectStandardOutput = true;
            ps.RedirectStandardInput = true;
            ps.RedirectStandardError = true;
            ps.CreateNoWindow = false;
            Program p = new Program();
            //NewMethod(ps);
            p.StartProcess(ps);
            Console.Read();
        }

     

        public void StartProcess(ProcessStartInfo ps)
        {
            try
            {

                using (Process pt = Process.Start(ps))
                //using (Process progressTest = Process.Start(ps))
                {
                    // _ = progressTest.TotalProcessorTime;
                    // 异步获取命令行内容
                    pt.BeginOutputReadLine();

                    // 为异步获取订阅事件
                    pt.OutputDataReceived += new DataReceivedEventHandler(outputDataReceived);
                    pt.ErrorDataReceived += new DataReceivedEventHandler(outputDataReceived);
                    //
                }

            }
            catch (Exception ee)
            {

                throw;
            }
        }
        public void outputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
            else
            {
                Console.WriteLine("nullllll");
            }
        }

    }
}
