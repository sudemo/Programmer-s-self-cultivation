using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tupledemo
{
    class Program
    {
        static void Main(string[] args)
        {
            (int one, int two) tupleex = (1, 2);
            Console.WriteLine($"first：{tupleex.one}, second：{tupleex.two}");
            var tuple2 = (one: 1, two: 2);
            Console.WriteLine($"first：{tuple2.one}, second：{tuple2.two}");
            //定义vp的返回值元组
            (string  arg1, string param2) vpparg = ("hello","this is vpp");
            Console.WriteLine($"{vpparg.arg1},{vpparg.param2}");
            Console.ReadKey();
        }
    }
}
