using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class AddTripForm : Form
    {
        public AddTripForm()
        {
            this.Text = "AddTripForm";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(191, 215, 234); //coral blue

            Label lbl = new Label
            {
                Text = "➕ Operator - Add Trip",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 30),
                AutoSize = true
            };

            this.Controls.Add(lbl);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddTripForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AddTripForm";
            this.Load += new System.EventHandler(this.AddTripForm_Load);
            this.ResumeLayout(false);

        }

        private void AddTripForm_Load(object sender, EventArgs e)
        {

        }
    }
}
