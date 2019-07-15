﻿using System;

using OpenCvSharp;

using ZXing;

namespace barcodedemo
{
    /// <summary>
    /// a barcode reader class which can be used with the Mat type from OpenCVSharp
    /// </summary>
    public class BarcodeReaderImage : BarcodeReader<Mat>, IBarcodeReaderImage
    {
        /// <summary>
        /// define a custom function for creation of a luminance source with our specialized Mat-supporting class
        /// </summary>
        private static readonly Func<Mat, LuminanceSource> defaultCreateLuminanceSource =
           (image) => new ImageLuminanceSource(image);

        /// <summary>
        /// constructor which uses a custom luminance source with Mat support
        /// </summary>
        public BarcodeReaderImage()
           : base(null, defaultCreateLuminanceSource, null)
        {
        }
    }
}