using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//<Access Specifier> <Return Type> <Method Name>(Parameter List)
//{
//   Method Body 关于放法的定义
//}
namespace methodqoute
{
    class findmaxfunc
    {
        public int findmax ( int arg1,int arg2)
        {
            /*局部变量声明*/
            int result;
            if (arg1 > arg2)
                result = arg1;
            else
                result = arg2;
            return  result;
        }
        static void Main(string[] args)
        {
           // string ab = Console.ReadLine();
            Console.WriteLine("plz input");
            int b = Convert.ToInt32(Console.ReadLine());
            int  a = Convert.ToInt32(Console.ReadLine());
            //int a = string ab
            //int b = string bb;
            int ret;
            findmaxfunc aa = new findmaxfunc();
            //调用
            ret = aa.findmax(a, b);
            Console.Write("max: {0}",ret);
            Console.ReadLine();
            
        }

    }
}
