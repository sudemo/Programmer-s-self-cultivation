using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace sharpdemo2
{
    public class Dongle
    {

    }

    public class qttongle
    {

        public bool callDongleInit(char key)
        {
            string mode_info_string;
            bool b_Dongle = false;
            //bool ret = callDongleInit(key);
            //if (!ret)
            if (!true)
            {
                return false;
            }
            b_Dongle = true;
            int[] mode_info = new int[10];
            b_Dongle = false;
            
            //debug mode
            //if()
            if (true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                return true;
            }

           
        }
        public bool callDongleStatus()
        {
            return false;
        }
        public bool callDongleGetInfo(char output, char key)
        {
            return false;
        }
        public bool callDongleClose()
        {
            return true;
        }


        ///private
        ///
      /*  
        private string callCheckSum()
        {}
        private string getFileMd5()
        { }
     */  
    }
}
