using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Line_Parameters
{

    /// <summary>
    /// 解析命令行参数
    /// 可以用作进程调用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("no argument input");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Number of command line arguments = {0}", args.Length);
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);//这个用法很有趣
                    Console.ReadKey();
                }
            }
        }

    }
}
/*
 using System;
 
if (args.Length == 0)
{
  System.Console.WriteLine("No arguments found!!");
  return 1;
}*

 
static int Main(string[] args)
*/
