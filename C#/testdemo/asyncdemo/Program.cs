using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace asyncdemo
{
    class Program
    {
        /*
        static async Task Main(string[] args)
        {
            Console.WriteLine("start");
            var ss = callCount();
            Console.WriteLine("同步工作开始last");
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("同步内容Writing from callCount loop: " + i);
            }
            //Task.WaitAll(callCount());
            
            Console.ReadKey();

        }

        static void count_method()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("异步被调用方法 执行中count loop: " + i);
            }
        }

        static async Task callCount()
        {
            Task task = new Task(count_method);
            task.Start();
            await task;
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(400);
                Console.WriteLine("异步工作内容,Writing from callCount loop: " + i);
            }
            Console.WriteLine("just before await");
            
            Console.WriteLine("异步 马上结束callCount completed");
            
        }*/


        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
