using S7.Net;
using System;
using System.Diagnostics;
using System.Threading;

namespace poweroff
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("running in poweroff");

            if (args.Length < 1)
            {
                Console.WriteLine("please input args");
                return;
            }

            #region 调用
            /* diaoyong 方式
                  ProcessStartInfo startInfo = new ProcessStartInfo("poweroff.exe");
               // startInfo.WindowStyle = ProcessWindowStyle.Minimized;
               startInfo.CreateNoWindow = true;
               startInfo.UseShellExecute = false;
              // Process.Start(startInfo);

               startInfo.Arguments = "127.0.0.1";

               Process.Start(startInfo);

                */ 
            #endregion


            try
            {
                #region MyRegion
                //int arg = Convert.ToInt32(args[0]);
                //string local = "192.168.0.11";
                //Console.WriteLine(arg);
                //if (arg == 1)  //1 预制线
                //{
                //    local = "192.168.0.11";
                //    //local = "127.0.0.1";
                //}
                //else
                //{
                //    local = "192.168.0.31";
                //} 
                #endregion

                Plc myplc = new Plc(CpuType.S71500, args[0], 0, 0);//192.168.0.11/31
                myplc.Open();
                while (true)
                {
                    Thread.Sleep(1000);
                    object res= myplc.ReadBytes(DataType.DataBlock, 100, 0,1);
                    res.GetType();
                    byte[] r = (byte[])res;
                    if (r[0] == 1)
                    {
                        Process.Start("shutdown.exe", "-s -t 0");
                        //Process.Start("notepad.exe");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
