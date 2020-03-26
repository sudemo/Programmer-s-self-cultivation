using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace callqtdemo
{
    class Program
    {
        //[DllImport("QtToggle_dll.dll"，EntryPoint = "_ZN12QtToggle_dll17callDongleGetInfoEPcPKc")]
        //public static extern int init(int n);
        [DllImport("QtToggle_dll.dll", EntryPoint = "_ZN12QtToggle_dll14callDongleInitEPKc")] //函数名变了

        public static extern bool callDongleInit();
      //  public static extern bool callDongleGetInfo();


        static void Main(string[] args)
        {
            
            int a = 1;
            int b = 23;
            Console.WriteLine('1');
           bool ss= callDongleInit();
           // bool ss = callDongleGetInfo();
            //callfunc.myadd n = new callfunc.myadd();
            //int ss = n.myadd1(a, b);
            Console.WriteLine(ss);
            //Console.ReadKey();
        }
    }
}
