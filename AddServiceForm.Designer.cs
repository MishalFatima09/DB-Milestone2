using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class AddServiceForm
    {
        private Label lbl;
        private Label lblName;
        private TextBox txtName;
        private Label lblType;
        private ComboBox cmbType;
        private Button btnSubmit;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.lbl.Location = new System.Drawing.Point(30, 20);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(145, 25);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "➕ Add Service";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Service Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 68);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(30, 110);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Items.AddRange(new object[] {
            "Accommodation",
            "Transport",
            "Guide",
            "Other"});
            this.cmbType.Location = new System.Drawing.Point(150, 108);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(250, 21);
            this.cmbType.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(150, 160);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // AddServiceForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(545, 273);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnSubmit);
            this.Name = "AddServiceForm";
            this.Text = "Add Service";
            this.Load += new System.EventHandler(this.AddServiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
