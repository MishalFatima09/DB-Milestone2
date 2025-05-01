using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class CategoryForm : Form
    {
        public CategoryForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "🗂️ Manage Categories",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            ListBox lstCategories = new ListBox
            {
                Location = new Point(30, 60),
                Size = new Size(250, 180)
            };
            lstCategories.Items.AddRange(new string[] { "Adventure", "Cultural", "Luxury", "Eco" });

            TextBox txtNew = new TextBox { Location = new Point(30, 260), Width = 250 };
            Button btnAdd = new Button
            {
                Text = "Add Category",
                Location = new Point(30, 300),
                Width = 250,
                BackColor = Color.FromArgb(50, 90, 130),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAdd.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lbl, lstCategories, txtNew, btnAdd });
        }
    }
}
