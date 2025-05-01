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
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "📦 Assign Resources",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
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
    }
}
