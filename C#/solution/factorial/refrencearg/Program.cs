using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refrencearg
{
    class difclass
    {
        public int value = 100;
        public int va = 12;
        static int sva = 121;
        //参数类型：值类型
        public static void ModifyValue(int arg) //静态方法必须将参数传入，才能使用。无法直接使用类内的实例字段
        {
            arg *= arg;
            Console.WriteLine("arg is {0}",arg);
           // value = 2*arg;
           
        }
        //引用类型，重载函数，参数类型不一致
        static void ModifyValue(difclass obj)
        {
            obj.value += 2;
        }

        public void Addm() //可以直接使用类内的字段，因为他是非静态方法
        {   
            
            va = va + 1;
        }
        public void dispva()
        {
            Console.WriteLine("va is {0},value2 is {1}",va,value);
        }
        static void Main(string[] args)
        {
            difclass obj = new difclass();
            Console.WriteLine("value is {0}",obj.value);
            //自动选择了适合参数类型的重载函数
            ModifyValue(obj.value);
            Console.WriteLine("value2 is {0}", obj.value);
            ModifyValue(obj);
            Console.WriteLine(obj.value);
            obj.Addm();
            obj.dispva();
            //Console.WriteLine();
            Console.ReadKey();
        }

        
    }
}
