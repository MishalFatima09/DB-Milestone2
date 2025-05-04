using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class CategoryForm
    {
        private Label lbl;
        private ListBox lstCategories;
        private TextBox txtNew;
        private Button btnAdd;

        private void InitializeComponent()
        {
            this.lbl = new Label();
            this.lstCategories = new ListBox();
            this.txtNew = new TextBox();
            this.btnAdd = new Button();

            this.SuspendLayout();

            // 
            // CategoryForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(350, 400);
            this.Name = "CategoryForm";
            this.Text = "Manage Categories";
            this.Load += new System.EventHandler(this.CategoryForm_Load);

            // 
            // lbl
            // 
            this.lbl.Text = "🗂️ Manage Categories";
            this.lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lbl.ForeColor = Color.FromArgb(11, 57, 84);
            this.lbl.Location = new Point(30, 20);
            this.lbl.AutoSize = true;

            // 
            // lstCategories
            // 
            this.lstCategories.Location = new Point(30, 60);
            this.lstCategories.Size = new Size(250, 180);
            this.lstCategories.Items.AddRange(new string[] { "Adventure", "Cultural", "Luxury", "Eco" });

            // 
            // txtNew
            // 
            this.txtNew.Location = new Point(30, 260);
            this.txtNew.Width = 250;

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Add Category";
            this.btnAdd.Location = new Point(30, 300);
            this.btnAdd.Width = 250;
            this.btnAdd.BackColor = Color.FromArgb(50, 90, 130);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;

            // 
            // Add Controls
            // 
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lstCategories);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.btnAdd);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
