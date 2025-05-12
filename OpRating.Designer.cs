namespace DB_M2_Chat
{
    partial class OpRating
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
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.opRatings = new DB_M2_Chat.OpRatings();
            this.opRatingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.opRatings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opRatingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.button1.Location = new System.Drawing.Point(583, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "OperatorRating";
            reportDataSource1.Value = this.opRatingsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DB_M2_Chat.OpRating.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(735, 380);
            this.reportViewer1.TabIndex = 6;
            // 
            // opRatings
            // 
            this.opRatings.DataSetName = "OpRatings";
            this.opRatings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opRatingsBindingSource
            // 
            this.opRatingsBindingSource.DataSource = this.opRatings;
            this.opRatingsBindingSource.Position = 0;
            // 
            // OpRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Name = "OpRating";
            this.Text = "OpRating";
            this.Load += new System.EventHandler(this.OpRating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opRatings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opRatingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource opRatingsBindingSource;
        private OpRatings opRatings;
    }
}