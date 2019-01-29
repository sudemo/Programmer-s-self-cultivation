using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内插demo2
{
    public class Vegetable
    {





        public string Name
        {
            get;
        }
        public Vegetable(string name)
        {
            //Console.WriteLine("ji");
            //这个构造函数存在的问题是：无法使用lambda表达式 必须补充函数的定义 实现部分
            Name = name;
        }
        //public Vegetable(string name) => Name = name;
        public override string ToString() => Name;


        public enum Unit { sitem, kilogram, gram, dozen };
        static void Main()
        {

            //Vegetable item = new Vegetable();
            var ite = new Vegetable("eggplant");
            var date = DateTime.Now;
            var price = 1.99m;
            var unit = Unit.kilogram;
            //表达式的不同格式 “yyyy”（显示四位数年份）。 将 {price:C2} 中的“C2”更改为“e”（用于指数计数法）和“F3”（使数值在小数点后保持三位数字）。
            Console.WriteLine($"On {date:t}, the price of {ite} was {price:f3} per {unit}.");
            Console.ReadKey();

        }
    }
}
