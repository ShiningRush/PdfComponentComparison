using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Geom;
using PdfComponent.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

namespace PdfComponent.Lib.Components
{
    public class ITextPdfComponent : IPdfComponentFunc
    {
        public string ComponentName => "iText7";

        public void AddWaterprint(string absoluteFilePath, string outputPath)
        {
            var watermarkImgPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "DefaultResource", "waterMarkImg.jpeg");
            using (var pdfDocument = new PdfDocument(new PdfReader(absoluteFilePath), new PdfWriter(outputPath)))
            {
                // image watermark
                ImageData img = ImageDataFactory.Create(watermarkImgPath);

                // transparency
                var gs1 = new PdfExtGState();
                gs1.SetFillOpacity(0.3f);
                for (var pageIndex = 1; pageIndex < pdfDocument.GetNumberOfPages(); pageIndex++)
                {
                    // properties
                    PdfCanvas over = new PdfCanvas(pdfDocument.GetPage(pageIndex));
                    Rectangle pagesize = pdfDocument.GetPage(pageIndex).GetPageSize();
                    over.SaveState();
                    over.SetExtGState(gs1);
                    over.AddImage(img, 80, 0, 0, 81, 300, (pagesize.GetTop() + pagesize.GetBottom()) - 200, true);
                    over.RestoreState();
                }
            }
        }

        public void FromXps(string absoluteFilePath, string outputPath)
        {
            throw new NotImplementedException();
        }

        public void InsertPage(string absoluteFilePath, string outputPath)
        {
            var insertPageImgPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "DefaultResource", "insertPage.jpeg");
            using (var pdfDocument = new PdfDocument(new PdfReader(absoluteFilePath), new PdfWriter(outputPath)))
            {
                var newPage = pdfDocument.AddNewPage(2);
                var newPageCanvas = new PdfCanvas(newPage);
                newPageCanvas.SaveState();
                var imageData = ImageDataFactory.Create(insertPageImgPath);
                newPageCanvas.AddImage(imageData, imageData.GetWidth(), 0, 0, imageData.GetHeight(), 0, 0, true);
                newPageCanvas.RestoreState();
            }
        }

        public void ToJpeg(string absoluteFilePath, string outputPath)
        {
            throw new NotImplementedException();
        }

        public void ToTxt(string absoluteFilePath, string outputPath)
        {
            using (var pdfDocument = new PdfDocument(new PdfReader(absoluteFilePath)))
            {
                for (var pageIndex = 1; pageIndex < pdfDocument.GetNumberOfPages(); pageIndex++)
                {
                    using (var fos = System.IO.File.OpenWrite(outputPath))
                    {
                        var strategy = new LocationTextExtractionStrategy();
                        var parser = new PdfCanvasProcessor(strategy);
                        parser.ProcessPageContent(pdfDocument.GetPage(pageIndex));
                        var array = Encoding.UTF8.GetBytes(strategy.GetResultantText());
                        fos.Write(array, 0, array.Length);

                        fos.Flush();
                    }
                }
            }
        }
    }
}
