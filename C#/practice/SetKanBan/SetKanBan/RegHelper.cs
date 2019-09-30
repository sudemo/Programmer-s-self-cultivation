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
                RegistryKey KBserverkey = null;
                //RegistryKey CCDserverkey1 = null;
                KBserverkey = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\parameters",true);
                //set KB client's server ip 
                KBserverkey.SetValue("NtpServer", "172.22.149.250,0x1");
                ret = KBserverkey.GetValue("NtpServer").ToString();

                KBserverkey = key.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\W32Time\TimeProviders\NtpServer\",true);
                KBserverkey.SetValue("Enabled", "1");

                KBserverkey = key.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\W32Time\\TimeProviders\\Ntpclient",true);
                //set KB enable client
                KBserverkey.SetValue("Enabled", "1");
                KBserverkey.SetValue("SpecialPollInterval", "604800");

                var strenable = KBserverkey.GetValue("Enabled").ToString();
                var strserver = KBserverkey.GetValue("SpecialPollInterval").ToString();
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
