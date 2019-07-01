using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
namespace testdll
{
    class Program
    {
        static void Main()
        {
            Mat src1 = Cv2.ImRead("d:/2.jpg", ImreadModes.Color);
            Mat dst = new Mat();


            Cv2.Canny(src1, dst, 30, 30);
            //using (new Window("src image", src))
           Cv2.ImShow("dst image", dst);           
                Cv2.WaitKey();
            
        }
    }
}
