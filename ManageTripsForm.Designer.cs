using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class ManageTripsForm
    {
        private Label lbl;
        private DataGridView dgv;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // 
            // ManageTripsForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Name = "ManageTripsForm";
            this.Load += new System.EventHandler(this.ManageTripsForm_Load);

            // 
            // lbl
            // 
            this.lbl.Text = "📋 Manage Trips";
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
            this.dgv.Columns.Add("TripName", "Trip Name");
            this.dgv.Columns.Add("Destination", "Destination");
            this.dgv.Columns.Add("Price", "Price");
            this.dgv.Columns.Add("Capacity", "Capacity");

            this.dgv.Rows.Add("Safari Adventure", "Kenya", "$1800", "15");
            this.dgv.Rows.Add("Ski Resort", "Switzerland", "$3000", "10");

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
