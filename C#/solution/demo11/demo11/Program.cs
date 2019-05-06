using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo11
{
    class Program
    {
        public static int ma_MouthpieceUpload { get; private set; }

        static void Main(string[] args)
        {

            string ssMouthPieceUpload = "1";
            if (ssMouthPieceUpload != "")
            {
                int nOut = 0;
               /* 
               int.Parse()是一种类容转换；表示将数字内容的字符串转为int类型。
                如果字符串为空，则抛出ArgumentNullException异常；
                    如果字符串内容不是数字，则抛出FormatException异常；
                如果字符串内容所表示数字超出int类型可表示的范围，则抛出OverflowException异常；

                int.TryParse 与 int.Parse 又较为类似，但它不会产生异常，转换成功返回 true，转换失败返回 false。
                最后一个参数为输出值，如果转换失败，输出值为 0,如果成功则返回正确的结果
                */ 
                if (Int32.TryParse(ssMouthPieceUpload, out nOut)) 

                    ma_MouthpieceUpload = nOut;
                Console.WriteLine("{0}",ma_MouthpieceUpload);

                double res = Math.Round((double) (20/3),2);
                Console.WriteLine( Math.Round(2.41234,4));
                Console.WriteLine("res: {0}",res);
                Console.ReadKey();
            }
        }
    }
}
