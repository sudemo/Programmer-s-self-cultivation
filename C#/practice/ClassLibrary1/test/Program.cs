using System;
using ClassLibrary1;
using OpenCvSharp;


namespace test
{
    class Program
    {
        //[DllImport("dlltest.dll")]
        static void Main(string[] args)
        {
            ClassLibrary1.doble_add a = new doble_add();
            double b=a.doubleadd(2.1, 1.1);
            Console.Write(b);
            //Console.ReadKey();
            Mat src1 = Cv2.ImRead("d:/2.jpg", ImreadModes.Color);
            Mat dst = new Mat();

            Cv2.Canny(src1, dst, 50, 200);
            //using (new Window("src image", src))
            using (new Window("dst image", dst))
            {
                Cv2.WaitKey();
            }
        }
    }
}
