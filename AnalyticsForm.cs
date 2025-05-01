using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class AnalyticsForm : Form
    {
        public AnalyticsForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(191, 215, 234);

            Label lbl = new Label
            {
                Text = "📊 Analytics",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            DataGridView dgv = new DataGridView
            {
                Location = new Point(30, 60),
                Size = new Size(800, 300),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add("Metric", "Metric");
            dgv.Columns.Add("Value", "Value");

            dgv.Rows.Add("Total Trips", "25");
            dgv.Rows.Add("Active Users", "112");
            dgv.Rows.Add("Total Bookings", "384");
            dgv.Rows.Add("Revenue", "$56,000");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AnalyticsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AnalyticsForm";
            this.Load += new System.EventHandler(this.AnalyticsForm_Load);
            this.ResumeLayout(false);

        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
