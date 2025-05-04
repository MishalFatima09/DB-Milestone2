using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class AnalyticsForm
    {
        private Label lbl;
        private DataGridView dgv;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // AnalyticsForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Name = "AnalyticsForm";
            this.Text = "Analytics";
            this.Load += new System.EventHandler(this.AnalyticsForm_Load);
            // 
            // lbl
            // 
            this.lbl.Text = "📊 Analytics";
            this.lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lbl.ForeColor = Color.FromArgb(11, 57, 84);
            this.lbl.Location = new Point(30, 20);
            this.lbl.AutoSize = true;
            // 
            // dgv
            // 
            this.dgv.Location = new Point(30, 60);
            this.dgv.Size = new Size(800, 300);
            this.dgv.ReadOnly = true;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Columns.Add("Metric", "Metric");
            this.dgv.Columns.Add("Value", "Value");
            this.dgv.Rows.Add("Total Trips", "25");
            this.dgv.Rows.Add("Active Users", "112");
            this.dgv.Rows.Add("Total Bookings", "384");
            this.dgv.Rows.Add("Revenue", "$56,000");

            // Add controls to the form
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgv);

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
