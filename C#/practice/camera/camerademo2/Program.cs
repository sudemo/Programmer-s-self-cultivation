using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace camerademo2

{
    public class program
    {
        public static void Main()
        {
            Mat a = new Mat();
            a= Cv2.ImRead("d:/2.jpg");
            Cv2.ImShow("a",a);
            Cv2.WaitKey();
           // Console.ReadKey();
        }
    
    }

}   
