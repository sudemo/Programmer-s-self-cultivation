using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gouzao函数
{
    class Animal
    {
        static void Main(string[] args)
        {
            //方法一
            Animal animal1 = new Animal();
            animal1.Name = "兔子";
            animal1.Color = "白色";
            animal1.Speed = 20;
            animal1.Run();
            //方法二
            Animal animal2 = new Animal("兔子", "黑色");
            animal2.Run(30);
            //方法三
            Animal animal3 = new Animal("狗", "棕色", 50);
            animal3.Run();
            Console.WriteLine();
        }
        //构造函数重载
        public Animal()
        {
        }
        public Animal(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        public Animal(string name, string color, int speed)
        {

            this.name = name;

            this.color = color;

            this.speed = speed;
        }
        //名称
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //颜色
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        //速度
        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        //方法的重载Run方法的不同实现
        public void Run()
        {
            Console.WriteLine("一只" + this.color + "的" + this.name + "正在以" + this.speed + "Km/h的速度在奔跑\n"); 

        }
        public void Run(int speed, int color)
        {

            Console.WriteLine("一只" + this.color + "的" + this.name + "正在以" + speed + "km/h的速度在奔跑\n");
            Console.ReadKey();
        }
        public void Run(int speed)
        {

            Console.WriteLine("一只" + this.color + "的" + this.name + "正在以" + speed + "km/h的速度在奔跑\n");
            Console.ReadKey();
        }

    }
}
