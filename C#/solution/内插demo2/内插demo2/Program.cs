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
            Console.WriteLine($"On {date}, the price of {ite} was {price} per {unit}.");
            Console.ReadKey();

        }
    }
}
