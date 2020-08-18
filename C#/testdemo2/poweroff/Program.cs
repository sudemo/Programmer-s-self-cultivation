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
            Logger2.Infor("enter poweroff");
            if (args.Length < 1)
            {
                Logger2.Infor("input args number less than 1");
                Console.ReadKey();
                Thread.Sleep(100);
                return;
            }

            Plc myplc = new Plc(CpuType.S71500, args[0], 0, 0);//192.168.0.11/31
            myplc.Open();
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    //int chineseScore = Convert.ToInt32(Console.ReadLine());
                    object res = myplc.ReadBytes(DataType.DataBlock, 100, 0, 1);
                    byte[] r = (byte[])res;
                    if (r[0] == 1)
                    {
                        Logger2.Infor("shutdown by plc");
                        Thread.Sleep(500);
                        //Process.Start("shutdown.exe", "-s -t 0");
                        Process.Start("notepad.exe");
                        break;
                    }
                }

                catch (Exception ex)
                {
                    Logger2.Infor(ex.Message);
                    Thread.Sleep(2000);
                    continue;
                }
            }
        }
    }
}
