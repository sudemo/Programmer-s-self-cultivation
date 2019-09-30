using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace regsetting
{
    class RegHelper
    {
        public void ModifyReg()
        {
            try
            {
                //操作注册表进入指定键值对
                
                //RegistryKey RegistryPath = Microsoft.Win32.Registry.LocalMachine;
                RegistryKey key = Registry.LocalMachine;
                string ret = "";
                RegistryKey CCDserverkey = null;
                //RegistryKey CCDserverkey1 = null;
                CCDserverkey = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\parameters",true);
                //set client's server ip 
                CCDserverkey.SetValue("NtpServer", "192.168.250.31,0x1");
                ret = CCDserverkey.GetValue("NtpServer").ToString();
                CCDserverkey = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\TimeProviders\\Ntpclient",true);
                //set enable client
                CCDserverkey.SetValue("Enabled", "1");
                CCDserverkey.SetValue("SpecialPollInterval", "604800");

                var strenable = CCDserverkey.GetValue("Enabled").ToString();
                var strserver = CCDserverkey.GetValue("SpecialPollInterval").ToString();
                Console.WriteLine(" client status: {0}", strenable);
                Console.WriteLine("CCD server status {0},interval is {1}",ret, strserver);
                Console.ReadKey();


                #region 判断当前登录用户是否为管理员

                //        //判断当前登录用户是否为管理员
                //        if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                //        {
                //            //如果是管理员，则直接运行
                //            System.Diagnostics.Process.Start("regedit.exe", "/s oracle_char.reg");
                //        }
                //        else
                //        {
                //            //创建启动对象
                //            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //            startInfo.UseShellExecute = true;
                //            startInfo.WorkingDirectory = Environment.CurrentDirectory;
                //            //startInfo.FileName = Application.ExecutablePath;
                //            startInfo.FileName = string.Format("{0}oracle_char.bat", AppDomain.CurrentDomain.BaseDirectory);
                //            //设置启动动作,确保以管理员身份运行
                //            startInfo.Verb = "runas";
                //            System.Diagnostics.Process.Start(startInfo);
                //        }
                //    }
                //} 
                #endregion

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message,"failed");
            }
        }
    }
}
