using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class AssignResourcesForm : Form
    {
        public AssignResourcesForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(191, 215, 234);

            Label lbl = new Label
            {
                Text = "📦 Assign Resources",
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
            dgv.Columns.Add("Resource", "Resource");
            dgv.Columns.Add("AssignedTo", "Assigned To");
            dgv.Columns.Add("Status", "Status");

            dgv.Rows.Add("Tour Guide - English", "Safari Adventure", "Assigned");
            dgv.Rows.Add("Transport Bus", "Ski Resort", "Pending");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AssignResourcesForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AssignResourcesForm";
            this.Load += new System.EventHandler(this.AssignResourcesForm_Load);
            this.ResumeLayout(false);

        }

        private void AssignResourcesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
