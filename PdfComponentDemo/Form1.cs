using PdfComponent.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfComponentDemo
{
    public partial class Form1 : Form
    {
        private readonly List<IPdfComponentFunc> _pdfComponents = new List<IPdfComponentFunc>();

        public Form1()
        {
            InitializeComponent();
            InitComponentList();
        }

        private void InitComponentList()
        {
            var implementedComponents = typeof(IPdfComponentFunc).Assembly.GetTypes()
                .Where(p => typeof(IPdfComponentFunc).IsAssignableFrom(p) && !p.IsInterface);

            foreach (var aComponent in implementedComponents)
            {
                var componentInstance = (IPdfComponentFunc)Activator.CreateInstance(aComponent);
                _pdfComponents.Add(componentInstance);
                cmb_Component.DisplayMember = "ComponentName";
                cmb_Component.Items.Add(new { ComponentName = componentInstance.ComponentName, ComponentIns = componentInstance });
            }
        }

        private void btn_SelectPdfDir_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_PdfFilesDir.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_SelectOutputDir_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_OutputDir.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_ToJpeg_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();

                selectCompoent.ToJpeg(aPdfFile, outputDir);
            });
        }

        private void btn_ToTxt_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();

                selectCompoent.ToTxt(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + ".txt"));
            });
        }

        private void btn_XpsFrom_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();

                selectCompoent.FromXps(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_FromXps.pdf"));
            },".xps");
        }

        private void btn_InsertPage_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();

                selectCompoent.InsertPage(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_InsertedPage.pdf"));
            });
        }

        private void btn_AddWaterprint_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();

                selectCompoent.AddWaterprint(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_AddWatermakr.pdf"));
            });
        }

        private void btn_AllRun_Click(object sender, EventArgs e)
        {
            CommonWorkFlow((aPdfFile, outputDir) =>
            {
                var selectCompoent = GetSelectedComponent();
                if (Path.GetExtension(aPdfFile).Equals(".xps", StringComparison.OrdinalIgnoreCase))
                    selectCompoent.FromXps(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_FromXps.pdf"));
                else
                {
                    selectCompoent.ToJpeg(aPdfFile, outputDir);
                    selectCompoent.ToTxt(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + ".txt"));
                    selectCompoent.AddWaterprint(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_AddWatermakr.pdf"));
                    selectCompoent.InsertPage(aPdfFile, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(aPdfFile) + "_InsertedPage.pdf"));
                }

            }, ".pdf,.xps");
        }

        private void CommonWorkFlow(Action<string, string> childDeal, string fileExtensionFilter = ".pdf")
        {
            if (!CheckSelect())
                return;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int excuteTimes = 1;
            if (!string.IsNullOrEmpty(txt_ExecuteTimes.Text))
                Int32.TryParse(txt_ExecuteTimes.Text, out excuteTimes);

            for (int i = 0; i < excuteTimes; i++)
            {
                var pdfFiles = Directory.GetFiles(txt_PdfFilesDir.Text);
                foreach (var aPdfFile in pdfFiles)
                {
                    var pdfOutputDir = Path.Combine(txt_OutputDir.Text, Path.GetFileNameWithoutExtension(aPdfFile));

                    if (!string.IsNullOrEmpty(fileExtensionFilter) &&
                        !fileExtensionFilter.Split(',').Any(p => p.Equals(Path.GetExtension(aPdfFile), StringComparison.OrdinalIgnoreCase)))
                        continue;

                    if (!Directory.Exists(pdfOutputDir))
                        Directory.CreateDirectory(pdfOutputDir);

                    childDeal(aPdfFile, pdfOutputDir);
                }
            }

            stopWatch.Stop();
            MessageBox.Show($"Executed { excuteTimes } times,costed time：{stopWatch.ElapsedMilliseconds} milliseconds in total.");
        }

        private IPdfComponentFunc GetSelectedComponent()
        {
            dynamic selectedItem = cmb_Component.SelectedItem;
            return (IPdfComponentFunc)selectedItem.ComponentIns;
        }

        private bool CheckSelect()
        {
            if (cmb_Component.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Pdf Component");
                return false;
            }

            if( string.IsNullOrEmpty(txt_PdfFilesDir.Text))
            {
                MessageBox.Show("Please Select Input File Directory");
                return false;
            }

            if (string.IsNullOrEmpty(txt_OutputDir.Text))
            {
                MessageBox.Show("Please Select Output Directory");
                return false;
            }

            int i;
            if (!string.IsNullOrEmpty(txt_ExecuteTimes.Text) && !Int32.TryParse(txt_ExecuteTimes.Text, out i))
            {
                MessageBox.Show("ExecuteTimes Must Be Numberic");
                return false;
            }

            return true;
        }
    }
}
