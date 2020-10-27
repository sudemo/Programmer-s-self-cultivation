using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
namespace ConsoleApplication1
{
    class Program
    {

        static StringBuilder sb1 = new StringBuilder(3000);
        public static void Main(string[] args)
        {
            ////返回类型引用第一种方式直接用typeof,其参数就是类型
            Type t1=typeof(double);

            Console.WriteLine(t1.Name);
            //fullname不含程序集，含命名空间
            Console.WriteLine(t1.FullName);
            Console.WriteLine(t1.Namespace);
            Console.WriteLine(t1.BaseType);
            Console.WriteLine(t1.UnderlyingSystemType.ToString());
            Console.WriteLine(t1.IsAbstract);
            Console.WriteLine(t1.IsArray);
            Console.WriteLine(t1.IsValueType);
            Console.WriteLine(t1.GetMethods()) ;




            Program p1 = new Program();
            //通过类实例（对象）来调用gettype返回类型引用
            Type t2 = p1.GetType();
            //Console.WriteLine(t2.FullName);
            MemberInfo[] mi = t2.GetMembers();
            long[] l1 = { 1, 2, 3 };

            for (long sub1 = 0; sub1 <= 2; sub1++)
            {
                object x = mi.GetValue(l1[sub1]);
                MemberInfo z = (MemberInfo)x;
                //Console.WriteLine(z.IsDefined);
                Console.WriteLine(z.Name);
            }
            //foreach (MemberInfo x in mi)
            //{
            //    //memberinfo.name方称名称
            //    Console.WriteLine(x.Name);
            //    //memberinfo.reflectedtype返回方法所属的类名称
            //    Console.WriteLine(x.ReflectedType.ToString());
            //    Console.WriteLine(x.DeclaringType.ToString());
            //     Console.WriteLine(x.GetHashCode().ToString());

            //}
            Console.ReadKey();
        }
    }
}