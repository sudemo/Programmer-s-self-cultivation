using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.IO;

namespace camera
{
    class CaptureService
    {
        public static void DoSomeThing(DateTime? startTime, long count)
        {

            var cap = VideoCapture.FromCamera(CaptureDevice.Any);
            cap.Set(CaptureProperty.FrameWidth, 512);
            cap.Set(CaptureProperty.FrameHeight, 300);
            Mat mat = new Mat();
            //while ())
            {
                cap.Read(mat);
                File.WriteAllBytes(DateTime.Now.Ticks + ".png", mat.ToBytes());

            }
            cap.Release();
            cap.Dispose();
        }
        public static void Main()
        {
            DoSomeThing(new DateTime() ,1);
        }
    }
}
