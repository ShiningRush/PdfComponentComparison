using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfComponent.Lib.Interfaces
{
    public interface IPdfComponentFunc
    {
        string ComponentName { get; }
        void ToJpeg(string absoluteFilePath, string outputPath);
        void ToTxt(string absoluteFilePath, string outputPath);
        void FromXps(string absoluteFilePath, string outputPath);
        void InsertPage(string absoluteFilePath, string outputPath);
        void AddWaterprint(string absoluteFilePath, string outputPath);
    }
}
