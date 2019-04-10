using System;

delegate int NumberChanger(int n);
namespace DelegateAppl
{
    class TestDelegate
    {
        static int num = 10; //default =10
        public static int AddNum(int p) //定义一个方法，需要一个参数 int p,num = num + p
        {
            num += p;
            return num;
        }

        public static int MultNum(int q) //num = q * num
        {
            num *= q;
            return num;
        }
        public static int getNum() //no use
        {
            return num;
        }

        static void Main(string[] args) //程序入口
        {
            // 创建委托实例
            NumberChanger nc1 = new NumberChanger(AddNum);//带一个方法
            NumberChanger nc2 = new NumberChanger(MultNum);
            // 使用委托对象调用方法
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());//此时num 的值已经为 35
            Console.ReadKey();
            //re
        }
    }
}