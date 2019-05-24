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
        //参数类型：值类型
        static void ModifyValue(int value)
        {
            value += value;
        }
        //引用类型，重载函数，参数类型不一致
        static void ModifyValue(difclass obj)
        {
            obj.value += 2;
        }
        static void Main(string[] args)
        {
            difclass obj = new difclass();
            Console.WriteLine(obj.value);
            //自动选择了适合参数类型的重载函数
            ModifyValue(obj.value);
            ModifyValue(obj);
            Console.WriteLine(obj.value);
            Console.ReadKey();
        }

        //private static void ModifyValue(difclass difclass, object obj2)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
