using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using OpenCvSharp;

namespace _2ddemo
{
    /// <summary>
    /// interface for a barcode reader class which can be used with the Mat type from OpenCVSharp
    /// </summary>
    public interface IBarcodeReaderImage : IBarcodeReader<Mat>
    {
    }
}
