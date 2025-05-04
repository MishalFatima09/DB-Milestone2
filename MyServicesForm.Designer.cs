using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class MyServicesForm
    {
        private Label lbl;
        private DataGridView dgv;

        private void InitializeComponent()
        {
            this.lbl = new Label();
            this.dgv = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // 
            // MyServicesForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(900, 400);
            this.Name = "MyServicesForm";
            this.Load += new System.EventHandler(this.MyServicesForm_Load);

            // 
            // lbl
            // 
            this.lbl.Text = "🏷️ My Services";
            this.lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lbl.ForeColor = Color.FromArgb(11, 57, 84);
            this.lbl.Location = new Point(30, 20);
            this.lbl.AutoSize = true;

            // 
            // dgv
            // 
            this.dgv.Location = new Point(30, 60);
            this.dgv.Size = new Size(800, 300);
            this.dgv.ReadOnly = true;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgv.Columns.Add("ServiceID", "Service ID");
            this.dgv.Columns.Add("ServiceName", "Service Name");
            this.dgv.Columns.Add("Type", "Type");

            this.dgv.Rows.Add("S001", "Oceanview Hotel", "Accommodation");
            this.dgv.Rows.Add("S002", "City Van", "Transport");

            // 
            // Controls
            // 
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgv);

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
