using System;
namespace RectangleApplication
{
    class Rectangle
    {
        // ��Ա����
        double length ;
        double width;
        public void Acceptdetails()
        {
             length =  10.1;
             width =  11.1;
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
		{
          //  Console.WriteLine("Length: {0}", length);
            //Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
    
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            
			r.GetArea();
			r.Display();
            Console.ReadLine();
        }
    }
}
