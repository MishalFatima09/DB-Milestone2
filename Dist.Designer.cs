namespace DB_M2_Chat
{
    partial class Dist
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
            this.distribute = new DB_M2_Chat.distribute();
            this.distributeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.distribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.button1.Location = new System.Drawing.Point(610, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Distribution";
            reportDataSource1.Value = this.distributeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DB_M2_Chat.Dist.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(753, 363);
            this.reportViewer1.TabIndex = 7;
            // 
            // distribute
            // 
            this.distribute.DataSetName = "distribute";
            this.distribute.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // distributeBindingSource
            // 
            this.distributeBindingSource.DataSource = this.distribute;
            this.distributeBindingSource.Position = 0;
            // 
            // Dist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Name = "Dist";
            this.Text = "Dist";
            this.Load += new System.EventHandler(this.Dist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.distribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distributeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource distributeBindingSource;
        private distribute distribute;
    }
}