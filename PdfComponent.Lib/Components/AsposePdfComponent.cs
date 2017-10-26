using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Text;
using PdfComponent.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfComponent.Lib.Components
{
    public class AsposePdfComponent : IPdfComponentFunc
    {
        public string ComponentName => "Aspose.Pdf";

        private const string Key = "PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPlNoYW5naGFpIEh1ZHVuIEluZm9ybWF0aW9uIFRlY2hub2xvZ3kgQ28uLCBMdGQ8L0xpY2Vuc2VkVG8+DQogICAgPEVtYWlsVG8+MzE3NzAxODA5QHFxLmNvbTwvRW1haWxUbz4NCiAgICA8TGljZW5zZVR5cGU+RGV2ZWxvcGVyIE9FTTwvTGljZW5zZVR5cGU+DQogICAgPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMSBkZXZlbG9wZXIsIHVubGltaXRlZCBwaHlzaWNhbCBsb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPg0KICAgIDxPcmRlcklEPjE2MDkwMjAwNDQwMDwvT3JkZXJJRD4NCiAgICA8VXNlcklEPjI2NjE2NjwvVXNlcklEPg0KICAgIDxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+DQogICAgPFByb2R1Y3RzPg0KICAgICAgPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0Pg0KICAgIDwvUHJvZHVjdHM+DQogICAgPEVkaXRpb25UeXBlPkVudGVycHJpc2U8L0VkaXRpb25UeXBlPg0KICAgIDxTZXJpYWxOdW1iZXI+NzM4MDNhYmUtYzZkMi00MTY3LTg2MTgtN2I0NDViNDRmOGY0PC9TZXJpYWxOdW1iZXI+DQogICAgPFN1YnNjcmlwdGlvbkV4cGlyeT4yMDE3MDkwNzwvU3Vic2NyaXB0aW9uRXhwaXJ5Pg0KICAgIDxMaWNlbnNlVmVyc2lvbj4zLjA8L0xpY2Vuc2VWZXJzaW9uPg0KICAgIDxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHA6Ly93d3cuYXNwb3NlLmNvbS9jb3Jwb3JhdGUvcHVyY2hhc2UvbGljZW5zZS1pbnN0cnVjdGlvbnMuYXNweDwvTGljZW5zZUluc3RydWN0aW9ucz4NCiAgPC9EYXRhPg0KICA8U2lnbmF0dXJlPm5LNVVUR3dZMWVJSEtIV0d2NW5sQUxXUy81bDEzWkFuamlvdnlBcGNqQis0ZjNGbm5yOWhjeUlzazlvVzQySWp0ZFYra2JHZlNSMUV4OUozSGlkaThCeE43aHFiR1BERXNaWGo2RlYxaGl1N2MxWmUyNEp3VGc2UnpsNUNJRHY1YVhxbDQyczBkSGw4eXpreDRBM2RTTU5KTzRiQ094a2V2OFBiOWxSaUc3ST08L1NpZ25hdHVyZT4NCjwvTGljZW5zZT4=";
        private static Stream LStream = (Stream)new MemoryStream(Convert.FromBase64String(Key));
        public AsposePdfComponent()
        {
            SetPdfLicense();
        }

        public void SetPdfLicense()
        {
            var l = new Aspose.Pdf.License();
            //l.SetLicense(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Aspose.Total.lic"));
            l.SetLicense(LStream);
        }


        public void AddWaterprint(string absoluteFilePath, string outputPath)
        {
            var watermarkImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultResource", "waterMarkImg.jpeg");
            using (var pdfDocument = new Document(absoluteFilePath))
            using (BackgroundArtifact background = new BackgroundArtifact())
            {
                foreach (Page aPdfPage in pdfDocument.Pages)
                {
                    ImageStamp imageStamp = new ImageStamp(watermarkImgPath);
                    imageStamp.XIndent = 300;
                    imageStamp.YIndent = aPdfPage.PageInfo.Height - 200;
                    imageStamp.Height = 81;
                    imageStamp.Width = 80;
                    aPdfPage.AddStamp(imageStamp);
                }


                pdfDocument.Save(outputPath);
            }
        }

        public void FromXps(string absoluteFilePath, string outputPath)
        {
            // Instantiate LoadOption object using XPS load option
            Aspose.Pdf.LoadOptions options = new XpsLoadOptions();

            // Create document object 
            Aspose.Pdf.Document document = new Aspose.Pdf.Document(absoluteFilePath, options);

            // Save the resultant PDF document
            document.Save(outputPath);
        }

        public void InsertPage(string absoluteFilePath, string outputPath)
        {
            var insertPageImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultResource","insertPage.jpeg");
            using (var pdfDocument = new Document(absoluteFilePath))
            using (BackgroundArtifact background = new BackgroundArtifact())
            {
                // Add a new page to document object
                Page page = pdfDocument.Pages.Insert(2);
                page.AddImage(insertPageImgPath, page.Rect);

                pdfDocument.Save(outputPath);
            }
        }

        public void ToJpeg(string absoluteFilePath, string outputPath)
        {
            using (var pdfDocument = new Document(absoluteFilePath))
            {
                for(var i = 1; i < pdfDocument.Pages.Count + 1; i++)
                {

                    using (FileStream imageStream = new FileStream(Path.Combine(outputPath, i.ToString() + ".jpeg"), FileMode.Create))
                    {
                        //Quality [0-100], 100 is Maximum
                        //create Resolution object
                        Resolution resolution = new Resolution(300);
                        JpegDevice jpegDevice = new JpegDevice(resolution, 100);

                        //convert a particular page and save the image to stream
                        jpegDevice.Process(pdfDocument.Pages[i], imageStream);

                        //close stream
                        imageStream.Close();
                    }
                }
            }
        }

        public void ToTxt(string absoluteFilePath, string outputPath)
        {
            var txtAbsorber = new TextAbsorber();
            using (var pdfDocument = new Document(absoluteFilePath))
            {
                pdfDocument.Pages.Accept(txtAbsorber);
                File.WriteAllText(outputPath, txtAbsorber.Text);
            }
        }
    }
}
