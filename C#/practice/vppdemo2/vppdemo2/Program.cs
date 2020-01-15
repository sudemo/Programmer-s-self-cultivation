using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vppdemo2

{
    
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MainForm mf = new MainForm();
            //mf.ShowDialog();
            //CommonProperty.closeFlag=true;
            //if (mf.closeflag ==true)
            {Application.Run(new MainForm());}
            //{ Application.Run(new Form2()); }
        }
    }
}
