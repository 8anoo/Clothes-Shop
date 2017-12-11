namespace WindowsFormsApplication5
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.fatoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clothes_shopDataSet = new WindowsFormsApplication5.clothes_shopDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fatoraTableAdapter = new WindowsFormsApplication5.clothes_shopDataSetTableAdapters.fatoraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fatoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothes_shopDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // fatoraBindingSource
            // 
            this.fatoraBindingSource.DataMember = "fatora";
            this.fatoraBindingSource.DataSource = this.clothes_shopDataSet;
            // 
            // clothes_shopDataSet
            // 
            this.clothes_shopDataSet.DataSetName = "clothes_shopDataSet";
            this.clothes_shopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.fatoraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication5.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(540, 717);
            this.reportViewer1.TabIndex = 0;
            // 
            // fatoraTableAdapter
            // 
            this.fatoraTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(563, 741);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعه";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fatoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothes_shopDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource fatoraBindingSource;
        private clothes_shopDataSetTableAdapters.fatoraTableAdapter fatoraTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public clothes_shopDataSet clothes_shopDataSet;
    }
}