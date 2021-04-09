using System;
using System.Collections;

namespace BarcodeReaderIron
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList paths = new ArrayList();
            paths.Add("barcode.png");

            IronReader reader = new IronReader("barcode.png");

            reader.readBarcodes();
        }
    }
}
