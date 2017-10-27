namespace PdfComponentDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ToJpeg = new System.Windows.Forms.Button();
            this.cmb_Component = new System.Windows.Forms.ComboBox();
            this.txt_PdfFilesDir = new System.Windows.Forms.TextBox();
            this.txt_OutputDir = new System.Windows.Forms.TextBox();
            this.btn_SelectPdfDir = new System.Windows.Forms.Button();
            this.btn_SelectOutputDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ToTxt = new System.Windows.Forms.Button();
            this.btn_XpsFrom = new System.Windows.Forms.Button();
            this.btn_InsertPage = new System.Windows.Forms.Button();
            this.btn_AddWaterprint = new System.Windows.Forms.Button();
            this.btn_AllRun = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ExecuteTimes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ToJpeg
            // 
            this.btn_ToJpeg.Location = new System.Drawing.Point(22, 142);
            this.btn_ToJpeg.Name = "btn_ToJpeg";
            this.btn_ToJpeg.Size = new System.Drawing.Size(75, 23);
            this.btn_ToJpeg.TabIndex = 0;
            this.btn_ToJpeg.Text = "ToJpeg";
            this.btn_ToJpeg.UseVisualStyleBackColor = true;
            this.btn_ToJpeg.Click += new System.EventHandler(this.btn_ToJpeg_Click);
            // 
            // cmb_Component
            // 
            this.cmb_Component.FormattingEnabled = true;
            this.cmb_Component.Location = new System.Drawing.Point(108, 30);
            this.cmb_Component.Name = "cmb_Component";
            this.cmb_Component.Size = new System.Drawing.Size(200, 20);
            this.cmb_Component.TabIndex = 1;
            // 
            // txt_PdfFilesDir
            // 
            this.txt_PdfFilesDir.Location = new System.Drawing.Point(107, 58);
            this.txt_PdfFilesDir.Name = "txt_PdfFilesDir";
            this.txt_PdfFilesDir.Size = new System.Drawing.Size(273, 21);
            this.txt_PdfFilesDir.TabIndex = 2;
            // 
            // txt_OutputDir
            // 
            this.txt_OutputDir.Location = new System.Drawing.Point(107, 85);
            this.txt_OutputDir.Name = "txt_OutputDir";
            this.txt_OutputDir.Size = new System.Drawing.Size(273, 21);
            this.txt_OutputDir.TabIndex = 3;
            // 
            // btn_SelectPdfDir
            // 
            this.btn_SelectPdfDir.Location = new System.Drawing.Point(387, 55);
            this.btn_SelectPdfDir.Name = "btn_SelectPdfDir";
            this.btn_SelectPdfDir.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectPdfDir.TabIndex = 4;
            this.btn_SelectPdfDir.Text = "Browse";
            this.btn_SelectPdfDir.UseVisualStyleBackColor = true;
            this.btn_SelectPdfDir.Click += new System.EventHandler(this.btn_SelectPdfDir_Click);
            // 
            // btn_SelectOutputDir
            // 
            this.btn_SelectOutputDir.Location = new System.Drawing.Point(387, 82);
            this.btn_SelectOutputDir.Name = "btn_SelectOutputDir";
            this.btn_SelectOutputDir.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectOutputDir.TabIndex = 5;
            this.btn_SelectOutputDir.Text = "Browse";
            this.btn_SelectOutputDir.UseVisualStyleBackColor = true;
            this.btn_SelectOutputDir.Click += new System.EventHandler(this.btn_SelectOutputDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "InputFileDir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "UseComponent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "OutputFileDir";
            // 
            // btn_ToTxt
            // 
            this.btn_ToTxt.Location = new System.Drawing.Point(103, 142);
            this.btn_ToTxt.Name = "btn_ToTxt";
            this.btn_ToTxt.Size = new System.Drawing.Size(75, 23);
            this.btn_ToTxt.TabIndex = 0;
            this.btn_ToTxt.Text = "ToTxt";
            this.btn_ToTxt.UseVisualStyleBackColor = true;
            this.btn_ToTxt.Click += new System.EventHandler(this.btn_ToTxt_Click);
            // 
            // btn_XpsFrom
            // 
            this.btn_XpsFrom.Location = new System.Drawing.Point(184, 142);
            this.btn_XpsFrom.Name = "btn_XpsFrom";
            this.btn_XpsFrom.Size = new System.Drawing.Size(75, 23);
            this.btn_XpsFrom.TabIndex = 0;
            this.btn_XpsFrom.Text = "Xps2Pdf";
            this.btn_XpsFrom.UseVisualStyleBackColor = true;
            this.btn_XpsFrom.Click += new System.EventHandler(this.btn_XpsFrom_Click);
            // 
            // btn_InsertPage
            // 
            this.btn_InsertPage.Location = new System.Drawing.Point(265, 142);
            this.btn_InsertPage.Name = "btn_InsertPage";
            this.btn_InsertPage.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertPage.TabIndex = 0;
            this.btn_InsertPage.Text = "InsertPage";
            this.btn_InsertPage.UseVisualStyleBackColor = true;
            this.btn_InsertPage.Click += new System.EventHandler(this.btn_InsertPage_Click);
            // 
            // btn_AddWaterprint
            // 
            this.btn_AddWaterprint.Location = new System.Drawing.Point(346, 142);
            this.btn_AddWaterprint.Name = "btn_AddWaterprint";
            this.btn_AddWaterprint.Size = new System.Drawing.Size(75, 23);
            this.btn_AddWaterprint.TabIndex = 0;
            this.btn_AddWaterprint.Text = "Watermark";
            this.btn_AddWaterprint.UseVisualStyleBackColor = true;
            this.btn_AddWaterprint.Click += new System.EventHandler(this.btn_AddWaterprint_Click);
            // 
            // btn_AllRun
            // 
            this.btn_AllRun.Location = new System.Drawing.Point(157, 176);
            this.btn_AllRun.Name = "btn_AllRun";
            this.btn_AllRun.Size = new System.Drawing.Size(128, 23);
            this.btn_AllRun.TabIndex = 0;
            this.btn_AllRun.Text = "AllRun";
            this.btn_AllRun.UseVisualStyleBackColor = true;
            this.btn_AllRun.Click += new System.EventHandler(this.btn_AllRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(24, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ExecuteTimes";
            // 
            // txt_ExecuteTimes
            // 
            this.txt_ExecuteTimes.Location = new System.Drawing.Point(107, 112);
            this.txt_ExecuteTimes.Name = "txt_ExecuteTimes";
            this.txt_ExecuteTimes.Size = new System.Drawing.Size(41, 21);
            this.txt_ExecuteTimes.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 211);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SelectOutputDir);
            this.Controls.Add(this.btn_SelectPdfDir);
            this.Controls.Add(this.txt_ExecuteTimes);
            this.Controls.Add(this.txt_OutputDir);
            this.Controls.Add(this.txt_PdfFilesDir);
            this.Controls.Add(this.cmb_Component);
            this.Controls.Add(this.btn_AllRun);
            this.Controls.Add(this.btn_AddWaterprint);
            this.Controls.Add(this.btn_InsertPage);
            this.Controls.Add(this.btn_XpsFrom);
            this.Controls.Add(this.btn_ToTxt);
            this.Controls.Add(this.btn_ToJpeg);
            this.Name = "Form1";
            this.Text = "PdfDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ToJpeg;
        private System.Windows.Forms.ComboBox cmb_Component;
        private System.Windows.Forms.TextBox txt_PdfFilesDir;
        private System.Windows.Forms.TextBox txt_OutputDir;
        private System.Windows.Forms.Button btn_SelectPdfDir;
        private System.Windows.Forms.Button btn_SelectOutputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ToTxt;
        private System.Windows.Forms.Button btn_XpsFrom;
        private System.Windows.Forms.Button btn_InsertPage;
        private System.Windows.Forms.Button btn_AddWaterprint;
        private System.Windows.Forms.Button btn_AllRun;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ExecuteTimes;
    }
}

