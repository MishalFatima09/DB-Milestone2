using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class EditProfileForm
    {
        private Label lbl;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Button btnSave;

        private void InitializeComponent()
        {
            this.lbl = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.btnSave = new Button();

            this.SuspendLayout();

            // 
            // Form properties
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(420, 280);
            this.Name = "EditProfileForm";
            this.Text = "Edit Profile";
            this.Load += new System.EventHandler(this.EditProfileForm_Load);

            // 
            // lbl
            // 
            this.lbl.Text = "✏️ Edit Profile";
            this.lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lbl.ForeColor = Color.FromArgb(11, 57, 84);
            this.lbl.Location = new Point(30, 20);
            this.lbl.AutoSize = true;

            // 
            // lblName
            // 
            this.lblName.Text = "Full Name:";
            this.lblName.Location = new Point(30, 70);
            this.lblName.AutoSize = true;

            // 
            // txtName
            // 
            this.txtName.Location = new Point(150, 68);
            this.txtName.Width = 200;

            // 
            // lblEmail
            // 
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(30, 110);
            this.lblEmail.AutoSize = true;

            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(150, 108);
            this.txtEmail.Width = 200;

            // 
            // lblPhone
            // 
            this.lblPhone.Text = "Phone:";
            this.lblPhone.Location = new Point(30, 150);
            this.lblPhone.AutoSize = true;

            // 
            // txtPhone
            // 
            this.txtPhone.Location = new Point(150, 148);
            this.txtPhone.Width = 200;

            // 
            // btnSave
            // 
            this.btnSave.Text = "💾 Save";
            this.btnSave.Location = new Point(150, 200);
            this.btnSave.Width = 100;
            this.btnSave.BackColor = Color.FromArgb(235, 166, 169);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;

            // 
            // Add Controls
            // 
            this.Controls.AddRange(new Control[] {
                this.lbl, this.lblName, this.txtName,
                this.lblEmail, this.txtEmail,
                this.lblPhone, this.txtPhone,
                this.btnSave
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
