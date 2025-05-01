using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = ColorTranslator.FromHtml("#BFD7EA");

            Label lbl = new Label
            {
                Text = "👤 User Management",
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

            dgv.Columns.Add("UserID", "User ID");
            dgv.Columns.Add("Name", "Name");
            dgv.Columns.Add("Role", "Role");
            dgv.Columns.Add("Status", "Status");

            dgv.Rows.Add("U001", "Ali Raza", "Traveler", "Pending");
            dgv.Rows.Add("U002", "Sana Khan", "Operator", "Approved");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "UserManagementForm";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            this.ResumeLayout(false);

        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
