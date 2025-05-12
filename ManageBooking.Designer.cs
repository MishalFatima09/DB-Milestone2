namespace TravelEase.Forms
{
    partial class ManageBookingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnAddBooking;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnAddBooking = new System.Windows.Forms.Button();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.cmbTravelerID = new System.Windows.Forms.ComboBox();
            this.cmbTripID = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbPolicy = new System.Windows.Forms.ComboBox();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.dtpBookingDate = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.SuspendLayout();

            // dgvBookings
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AllowUserToResizeRows = false;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(30, 30);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(700, 200);
            this.dgvBookings.TabIndex = 0;

            // cmbTravelerID
            this.cmbTravelerID.Location = new System.Drawing.Point(30, 250);
            this.cmbTravelerID.Name = "cmbTravelerID";
            this.cmbTravelerID.Size = new System.Drawing.Size(120, 21);

            // cmbTripID
            this.cmbTripID.Location = new System.Drawing.Point(160, 250);
            this.cmbTripID.Name = "cmbTripID";
            this.cmbTripID.Size = new System.Drawing.Size(120, 21);

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(290, 250);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Cancelled" });

            // cmbPolicy
            this.cmbPolicy.Location = new System.Drawing.Point(420, 250);
            this.cmbPolicy.Name = "cmbPolicy";
            this.cmbPolicy.Size = new System.Drawing.Size(120, 21);
            this.cmbPolicy.Items.AddRange(new object[] { "Flexible", "Moderate", "Strict" });

            // numCost
            this.numCost.Location = new System.Drawing.Point(550, 250);
            this.numCost.Name = "numCost";
            this.numCost.Size = new System.Drawing.Size(80, 20);
            this.numCost.Maximum = 1000000;

            // dtpBookingDate
            this.dtpBookingDate.Location = new System.Drawing.Point(640, 250);
            this.dtpBookingDate.Name = "dtpBookingDate";
            this.dtpBookingDate.Size = new System.Drawing.Size(200, 20);

            // btnAddBooking
            this.btnAddBooking.Location = new System.Drawing.Point(30, 300);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(150, 40);
            this.btnAddBooking.Text = "➕ Add Booking";
            this.btnAddBooking.UseVisualStyleBackColor = true;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);

            // btnDeleteBooking
            this.btnDeleteBooking.Location = new System.Drawing.Point(200, 300);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteBooking.Text = "🗑️ Delete Booking";
            this.btnDeleteBooking.UseVisualStyleBackColor = true;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(370, 300);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ManageBookingForm
            this.ClientSize = new System.Drawing.Size(900, 370);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.cmbTravelerID);
            this.Controls.Add(this.cmbTripID);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbPolicy);
            this.Controls.Add(this.numCost);
            this.Controls.Add(this.dtpBookingDate);
            this.Controls.Add(this.btnAddBooking);
            this.Controls.Add(this.btnDeleteBooking);
            this.Controls.Add(this.btnRefresh);
            this.Name = "ManageBookingForm";
            this.Text = "📅 Manage Bookings";
            this.Load += new System.EventHandler(this.ManageBookingForm_Load);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.ResumeLayout(false);
        }

    }
}
