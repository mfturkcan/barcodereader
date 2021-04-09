using System;
using IronBarCode;
using System.Drawing;
using System.Collections;

namespace BarcodeReaderIron
{
    public class IronReader
    {
        private string value;
        private Bitmap Img;
        private BarcodeEncoding barcodeType;
        private byte[] binary;
        private ArrayList currentPaths = new ArrayList();
        private BarcodeReader.BarcodeRotationCorrection rotationCorrection = BarcodeReader.BarcodeRotationCorrection.High
            | BarcodeReader.BarcodeRotationCorrection.Low;

        private BarcodeReader.BarcodeImageCorrection imageCorrection = BarcodeReader.BarcodeImageCorrection.MediumCleanPixels
            | BarcodeReader.BarcodeImageCorrection.LightlyCleanPixels;





        public IronReader(dynamic path)
        {
            
            
                if (path is System.Collections.ArrayList && path.Count != 0) currentPaths = path;
                else if (path is string)currentPaths.Add(path);
            
            
        }

        public void readBarcodes()
        {

            for(int i = 0; i< currentPaths.Count; i++)
            {
                BarcodeResult result = IronBarCode.BarcodeReader.ReadASingleBarcode((string)currentPaths[i],
                    BarcodeEncoding.QRCode | BarcodeEncoding.Code128,
                    this.rotationCorrection,
                    this.imageCorrection);
                this.value = result.Value;
                this.Img = result.BarcodeImage;
                this.barcodeType = result.BarcodeType;
                this.binary = result.BinaryValue;

                Console.WriteLine($"#{i} value:{value},\nimg:{Img}, barcodeType:{barcodeType}, binary: {binary}");
                Console.Write("**********");


            }
            


        }
    }
}
