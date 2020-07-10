using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace uidemo1
{
    static class Program
    {
        //[DllImport("kernel32.dll")]
        //public static extern Boolean AllocConsole();
        //[DllImport("kernel32.dll")]
        //public static extern Boolean FreeConsole();
        //[DllImport("kernel32.dll")]
        //static extern bool AttachConsole(int dwProcessId);
        //private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AllocConsole();
            //AttachConsole(ATTACH_PARENT_PROCESS);

            //for (int i = 0; i < 70; i++)
            //{
            //    // if (i / 7 != 5)
            //    if ((i % 7 != 0) && (i / 7 != 5))
            //    {
            //        Console.WriteLine(i.ToString());
            //    }
            //    else
            //    {
            //        Console.WriteLine("chujin： {0}",i.ToString());
            //    }
            //}
           
            Console.WriteLine("hellos");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Form1 fm = new Form1();
            //fm.myevent += fm.hello;
           


            Application.Run(new Form1());
            MyclassA a = new MyclassA();
            MyclassB b = new MyclassB();
            a.mydiyevent += b.methb;
            a.methA();

        }
    }

    
    public delegate void mydeg(); 
    public class MyclassA
    {
        public delegate void myhandle(string ss);
        public event myhandle mydiyevent;
        public void methA()
        {
            mydiyevent("hello");
        }
    }
    public class MyclassB
    {
        public void methb(string s )
        {
            MessageBox.Show(s);
        }
    }
}
