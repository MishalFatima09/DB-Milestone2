using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class AddTripForm
    {
        private Label lbl;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.lbl.Location = new System.Drawing.Point(30, 30);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(215, 25);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "➕ Operator - Add Trip";
            // 
            // AddTripForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1040, 531);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTripForm";
            this.Text = "AddTripForm";
            this.Load += new System.EventHandler(this.AddTripForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
