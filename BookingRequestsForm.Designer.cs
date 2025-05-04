using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class BookingRequestsForm
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
            // BookingRequestsForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Name = "BookingRequestsForm";
            this.Text = "Booking Requests";
            this.Load += new System.EventHandler(this.BookingRequestsForm_Load);

            // 
            // lbl
            // 
            this.lbl.Text = "📩 Booking Requests";
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
            this.dgv.Columns.Add("RequestID", "Request ID");
            this.dgv.Columns.Add("Service", "Service");
            this.dgv.Columns.Add("RequestedBy", "Requested By");
            this.dgv.Columns.Add("Date", "Date");
            this.dgv.Columns.Add("Status", "Status");

            this.dgv.Rows.Add("BR101", "Hotel Paradise", "Ali Raza", "2025-06-01", "Pending");
            this.dgv.Rows.Add("BR102", "Local Transport", "Sana Khan", "2025-06-03", "Confirmed");

            // Add controls
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgv);

            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
