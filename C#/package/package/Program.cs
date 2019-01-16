
///*
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace package
{
    class Rectangle
    {
        private double len;
        private double wit;

        public void Acceptdetails()
        {
            Console.WriteLine("请输入长");
            len = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入宽");
            wit = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea()
        {
            return len * wit;
        }
        public void Display()
        {
            Console.WriteLine("长：{0} ", len);
            Console.WriteLine("宽： {0}", wit);
            Console.WriteLine("面积：{0}", GetArea());
        }
    }
class Excute
     {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle();
            //a.len = 4.3;
            //a.wit = 3.4;

            
            a.Acceptdetails();
            a.Display();
            Console.ReadLine();
        }
     }
 }       
    
//*/
/*
using System;

namespace RectangleApplication
{
    class Rectangle
    {
        //成员变量
        private double length;
        private double width;

        public void Acceptdetails()
        {
            Console.WriteLine("请输入长度：");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入宽度：");
            width = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("长度： {0}", length);
            Console.WriteLine("宽度： {0}", width);
            Console.WriteLine("面积： {0}", GetArea());
        }
    }//end class Rectangle    
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }
}
*/
/*
//this exm is for private package
using System;

namespace RectangleApplication
{
    class Rectangle
    {
        //成员变量
        internal double length;
        internal double width;
        
        double GetArea()
        {
            return length * width;
        }
       public void Display()
        {
            Console.WriteLine("长度： {0}", length);
            Console.WriteLine("宽度： {0}", width);
            Console.WriteLine("面积： {0}", GetArea());
        }
    }//end class Rectangle    
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }
}
*/
