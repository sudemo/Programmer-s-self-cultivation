using System;
/////////////////以下为参数的传递 实例////////////////
//namespace CalculatorApplication
//{
//    class NumberManipulator
//    {
//        public void swap(ref int x, ref int y)
//        {
//            int temp;

//            temp = x; /* 保存 x 的值 */
//            x = y;    /* 把 y 赋值给 x */
//            y = temp; /* 把 temp 赋值给 y */
//        }

//        static void Main(string[] args)
//        {
//            NumberManipulator n = new NumberManipulator();
//            /* 局部变量定义 */
//            int a = 100;
//            int b = 200;

//            Console.WriteLine("在交换之前，a 的值： {0}", a);
//            Console.WriteLine("在交换之前，b 的值： {0}", b);

//            /* 调用函数来交换值 */
//            n.swap(ref a, ref b);

//            Console.WriteLine("在交换之后，a 的值： {0}", a);
//            Console.WriteLine("在交换之后，b 的值： {0}", b);

//            Console.ReadLine();

//        }
//    }
//}
//////////////以下为///////////////////

namespace ArrayApplication
{
    class MyArray
    {
        static void Main(string[] args)
        {
            int[] n = new int[10]; /* n 是一个带有 10 个整数的数组 */
            int i, j;


            /* 初始化数组 n 中的元素 */
            for (i = 0; i < 10; i++)
            {
                n[i] = i + 100;
            }

            /* 输出每个数组元素的值 */
            for (j = 0; j < 10; j++)
            {
                Console.WriteLine("数组中的第[{0}]个元素 = {1}", j, n[j]);
            }
            Console.ReadKey();
        }
    }
}