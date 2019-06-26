using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 空合并运算
{
   
    class NullCoalesce
    {
        static int? GetNullableInt()
        {
            return null;
        }

        static string GetStringValue()
        {
            return null;
        }

        static void Main()
        {
            int? x = null;
            int y = x ?? -1;
            Console.WriteLine(string.Format("x={0},y={1}", x, y));

            int i = GetNullableInt() ?? default(int);
            Console.WriteLine(string.Format("i={0} ", i));

            string s = GetStringValue();
            Console.WriteLine(s ?? "Unspecified");

            Console.ReadKey();
        }
    }
}
