namespace DB_M2_Chat
{
    partial class GuideRatings
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.travelEaseDataSet3 = new DB_M2_Chat.TravelEaseDataSet3();
            this.travelEaseDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GuideRatingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.travelEaseDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelEaseDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideRatingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "GuideRatings";
            reportDataSource3.Value = this.travelEaseDataSet3BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DB_M2_Chat.GuideRatings.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(30, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(712, 389);
            this.reportViewer1.TabIndex = 0;
            // 
            // travelEaseDataSet3
            // 
            this.travelEaseDataSet3.DataSetName = "TravelEaseDataSet3";
            this.travelEaseDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // travelEaseDataSet3BindingSource
            // 
            this.travelEaseDataSet3BindingSource.DataSource = this.travelEaseDataSet3;
            this.travelEaseDataSet3BindingSource.Position = 0;
            // 
            // GuideRatingsBindingSource
            // 
            this.GuideRatingsBindingSource.DataMember = "GuideRatings";
            this.GuideRatingsBindingSource.DataSource = this.travelEaseDataSet3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.button1.Location = new System.Drawing.Point(610, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GuideRatings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "GuideRatings";
            this.Text = "GuideRatings";
            this.Load += new System.EventHandler(this.GuideRatings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.travelEaseDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelEaseDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideRatingsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource travelEaseDataSet3BindingSource;
        private TravelEaseDataSet3 travelEaseDataSet3;
        private System.Windows.Forms.BindingSource GuideRatingsBindingSource;
        private System.Windows.Forms.Button button1;
    }
}