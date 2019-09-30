using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericdemo
{
    class Program
    {
        public static void EnumerateAll<T>(IEnumerable<T> thecollection, Action<T> argmethod)
        {
            foreach (T thing in thecollection)
                argmethod(thing);
        }
        public static void Dosth<T>(T s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            //字典不允许有key 重合，相同的情况出现
            Dictionary<int, int> d = new Dictionary<int, int> { { 2, 2 }, { 1, 3 }, { 3, 4 } };
            List<float> e = new List<float> { 1.3f, 1.2f, 3.4f };
            EnumerateAll(d, Dosth);
            Console.ReadKey();
        }
    }
}
