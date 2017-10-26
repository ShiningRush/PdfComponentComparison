using PdfComponent.Lib.Interfaces;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfComponent.Lib.Components
{
    public class SpirePdfComponent : IPdfComponentFunc
    {
        public string ComponentName => "Spire.Pdf";

        public void AddWaterprint(string absoluteFilePath, string outputPath)
        {
            var watermarkImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "DefaultResource", "waterMarkImg.jpeg");
            using (PdfDocument doc = new PdfDocument(absoluteFilePath))
            using (var watermarkImg = Image.FromFile(watermarkImgPath))
            {
                foreach (PdfPageBase aPdfPage in doc.Pages)
                {
                    aPdfPage.BackgroundRegion = new RectangleF(300, 200, 80, 81);
                    aPdfPage.BackgroundImage = watermarkImg;
                }

                doc.SaveToFile(outputPath);
            }
        }

        public void FromXps(string absoluteFilePath, string outputPath)
        {
            //open xps document
            using (PdfDocument doc = new PdfDocument())
            {
                doc.LoadFromXPS(absoluteFilePath);
                //convert to pdf file.
                doc.SaveToFile(outputPath);
            }
        }

        public void InsertPage(string absoluteFilePath, string outputPath)
        {
            var insertPageImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "DefaultResource", "insertPage.jpeg");
            //open xps document
            using (PdfDocument doc = new PdfDocument(absoluteFilePath))
            {
                var insertPagekImg = PdfImage.FromFile(insertPageImgPath);
                var insertedPage = doc.Pages.Insert(1);
                float widthFitRate = insertPagekImg.PhysicalDimension.Width / insertedPage.Canvas.ClientSize.Width;
                float heightFitRate = insertPagekImg.PhysicalDimension.Height / insertedPage.Canvas.ClientSize.Height;
                float fitRate = Math.Max(widthFitRate, heightFitRate);
                float fitWidth = insertPagekImg.PhysicalDimension.Width / fitRate;
                float fitHeight = insertPagekImg.PhysicalDimension.Height / fitRate;
                insertedPage.Canvas.DrawImage(insertPagekImg, 30, 30, fitWidth, fitHeight);


                //convert to pdf file.
                doc.SaveToFile(outputPath);
            }
        }

        public void ToJpeg(string absoluteFilePath, string outputPath)
        {
            //open xps document
            using (PdfDocument doc = new PdfDocument(absoluteFilePath))
            {
                //convert to pdf file.
                for (var i = 0; i < doc.Pages.Count; i++)
                {
                    using (var img = doc.SaveAsImage(i))
                    {
                        img.Save(Path.Combine(outputPath, i.ToString() + ".jpeg"));
                    }
                }
            }
        }

        public void ToTxt(string absoluteFilePath, string outputPath)
        {
            using (PdfDocument doc = new PdfDocument(absoluteFilePath))
            {
                var stringBuilder = new StringBuilder();
                foreach (PdfPageBase aPdfPage in doc.Pages)
                {
                    stringBuilder.Append(aPdfPage.ExtractText());
                }

                File.WriteAllText(outputPath, stringBuilder.ToString());
            }
        }
    }
}
