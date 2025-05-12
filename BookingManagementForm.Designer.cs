////using System.Drawing;
////using System.Windows.Forms;
////using System;

////namespace DB_M2_Chat
////{
////    partial class BookingManagementForm
////    {
////        private System.ComponentModel.IContainer components = null;
////        private Label lblTitle;
////        private DataGridView dgvBookings;
////        private Panel panelActions;
////        private Button btnConfirm;
////        private Button btnCancel;
////        private Button btnDetails;
////        private Button btnUpdatePayment;
////        private Label lblDescription;
////        private TextBox txtSearch;
////        private Button btnSearch;
////        private Panel panelAvailability;
////        private Label lblAvailability;
////        private TextBox txtRoomId;
////        private ComboBox cmbRoomStatus;
////        private Button btnUpdateAvailability;
////        private Button btnRefresh;

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing && (components != null))
////            {
////                components.Dispose();
////            }
////            base.Dispose(disposing);
////        }

////        private void InitializeComponent()
////        {
////            this.components = new System.ComponentModel.Container();

////            // Title Label
////            this.lblTitle = new Label
////            {
////                Text = "🛎️ Booking Management",
////                Font = new Font("Segoe UI", 14, FontStyle.Bold),
////                ForeColor = Color.FromArgb(11, 57, 84),
////                Location = new Point(30, 20),
////                AutoSize = true
////            };

////            // Description Label
////            this.lblDescription = new Label
////            {
////                Text = "Manage reservations, update availability, and track payments",
////                Font = new Font("Segoe UI", 10),
////                ForeColor = Color.FromArgb(11, 57, 84),
////                Location = new Point(32, 50),
////                AutoSize = true
////            };

////            // Search TextBox
////            this.txtSearch = new TextBox
////            {
////                Location = new Point(600, 50),
////                Size = new Size(150, 25),
////                Text = "Search bookings..."
////            };
////            this.txtSearch.GotFocus += (s, e) =>
////            {
////                if (txtSearch.Text == "Search bookings...")
////                {
////                    txtSearch.Text = "";
////                }
////            };
////            this.txtSearch.LostFocus += (s, e) =>
////            {
////                if (string.IsNullOrWhiteSpace(txtSearch.Text))
////                {
////                    txtSearch.Text = "Search bookings...";
////                }
////            };

////            // Search Button
////            this.btnSearch = new Button
////            {
////                Text = "🔍",
////                BackColor = Color.FromArgb(40, 120, 180),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(760, 50),
////                Size = new Size(30, 25)
////            };
////            this.btnSearch.FlatAppearance.BorderSize = 0;
////            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

////            // Refresh Button
////            this.btnRefresh = new Button
////            {
////                Text = "🔄",
////                BackColor = Color.FromArgb(40, 120, 180),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(560, 50),
////                Size = new Size(30, 25)
////            };
////            this.btnRefresh.FlatAppearance.BorderSize = 0;
////            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

////            // DataGridView for Bookings
////            this.dgvBookings = new DataGridView
////            {
////                Location = new Point(30, 80),
////                Size = new Size(760, 220),
////                BackgroundColor = Color.White,
////                BorderStyle = BorderStyle.None,
////                AllowUserToAddRows = false,
////                AllowUserToDeleteRows = false,
////                ReadOnly = true,
////                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
////                MultiSelect = false,
////                RowHeadersVisible = false,
////                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
////            };

////            // Configure DataGridView columns
////            this.dgvBookings.ColumnCount = 8;
////            this.dgvBookings.Columns[0].Name = "BookingID";
////            this.dgvBookings.Columns[0].Width = 80;
////            this.dgvBookings.Columns[1].Name = "CustomerName";
////            this.dgvBookings.Columns[1].Width = 120;
////            this.dgvBookings.Columns[2].Name = "ServiceType";
////            this.dgvBookings.Columns[2].Width = 120;
////            this.dgvBookings.Columns[3].Name = "CheckIn";
////            this.dgvBookings.Columns[3].Width = 90;
////            this.dgvBookings.Columns[4].Name = "CheckOut";
////            this.dgvBookings.Columns[4].Width = 90;
////            this.dgvBookings.Columns[5].Name = "Status";
////            this.dgvBookings.Columns[5].Width = 80;
////            this.dgvBookings.Columns[6].Name = "Amount";
////            this.dgvBookings.Columns[6].Width = 90;
////            this.dgvBookings.Columns[7].Name = "PaymentStatus";
////            this.dgvBookings.Columns[7].Width = 90;

////            // Actions Panel
////            this.panelActions = new Panel
////            {
////                Location = new Point(30, 310),
////                Size = new Size(760, 60),
////                BackColor = Color.FromArgb(191, 215, 234)
////            };

////            // Confirm Button
////            this.btnConfirm = new Button
////            {
////                Text = "Confirm",
////                BackColor = Color.FromArgb(40, 167, 69),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(10, 10),
////                Size = new Size(110, 35)
////            };
////            this.btnConfirm.FlatAppearance.BorderSize = 0;
////            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);

////            // Cancel Button
////            this.btnCancel = new Button
////            {
////                Text = "Cancel",
////                BackColor = Color.FromArgb(220, 53, 69),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(130, 10),
////                Size = new Size(110, 35)
////            };
////            this.btnCancel.FlatAppearance.BorderSize = 0;
////            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

////            // Update Payment Button
////            this.btnUpdatePayment = new Button
////            {
////                Text = "Update Payment",
////                BackColor = Color.FromArgb(255, 193, 7),
////                ForeColor = Color.Black,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(250, 10),
////                Size = new Size(150, 35)
////            };
////            this.btnUpdatePayment.FlatAppearance.BorderSize = 0;
////            this.btnUpdatePayment.Click += new EventHandler(this.btnUpdatePayment_Click);

////            // Details Button
////            this.btnDetails = new Button
////            {
////                Text = "View Details",
////                BackColor = Color.FromArgb(40, 120, 180),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(410, 10),
////                Size = new Size(120, 35)
////            };
////            this.btnDetails.FlatAppearance.BorderSize = 0;
////            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

////            // Add buttons to panel
////            this.panelActions.Controls.AddRange(new Control[]
////            {
////                this.btnConfirm,
////                this.btnCancel,
////                this.btnUpdatePayment,
////                this.btnDetails
////            });

////            // Availability Panel
////            this.panelAvailability = new Panel
////            {
////                Location = new Point(30, 380),
////                Size = new Size(760, 80),
////                BorderStyle = BorderStyle.FixedSingle,
////                BackColor = Color.White
////            };

////            // Availability Label
////            this.lblAvailability = new Label
////            {
////                Text = "Update Room/Seat Availability:",
////                Font = new Font("Segoe UI", 10, FontStyle.Bold),
////                ForeColor = Color.FromArgb(11, 57, 84),
////                Location = new Point(10, 10),
////                AutoSize = true
////            };

////            // Room ID TextBox
////            this.txtRoomId = new TextBox
////            {
////                Location = new Point(10, 40),
////                Size = new Size(150, 25),
////                Text = "Room/Seat ID"
////            };
////            this.txtRoomId.GotFocus += (s, e) =>
////            {
////                if (txtRoomId.Text == "Room/Seat ID")
////                {
////                    txtRoomId.Text = "";
////                }
////            };
////            this.txtRoomId.LostFocus += (s, e) =>
////            {
////                if (string.IsNullOrWhiteSpace(txtRoomId.Text))
////                {
////                    txtRoomId.Text = "Room/Seat ID";
////                }
////            };

////            // Room Status ComboBox
////            this.cmbRoomStatus = new ComboBox
////            {
////                Location = new Point(170, 40),
////                Size = new Size(150, 25),
////                DropDownStyle = ComboBoxStyle.DropDownList
////            };

////            // Update Availability Button
////            this.btnUpdateAvailability = new Button
////            {
////                Text = "Update Availability",
////                BackColor = Color.FromArgb(40, 120, 180),
////                ForeColor = Color.White,
////                FlatStyle = FlatStyle.Flat,
////                Location = new Point(330, 40),
////                Size = new Size(150, 25)
////            };
////            this.btnUpdateAvailability.FlatAppearance.BorderSize = 0;
////            this.btnUpdateAvailability.Click += new EventHandler(this.btnUpdateAvailability_Click);

////            // Add controls to availability panel
////            this.panelAvailability.Controls.AddRange(new Control[]
////            {
////                this.lblAvailability,
////                this.txtRoomId,
////                this.cmbRoomStatus,
////                this.btnUpdateAvailability
////            });

////            // Form properties
////            this.BackColor = Color.FromArgb(191, 215, 234);
////            this.ClientSize = new Size(820, 480);
////            this.FormBorderStyle = FormBorderStyle.None;

////            // Add controls to form
////            this.Controls.AddRange(new Control[]
////            {
////                this.lblTitle,
////                this.lblDescription,
////                this.txtSearch,
////                this.btnSearch,
////                this.btnRefresh,
////                this.dgvBookings,
////                this.panelActions,
////                this.panelAvailability
////            });

////            this.Load += new EventHandler(this.BookingManagementForm_Load);
////        }
////    }
////}


//using System.Drawing;
//using System.Windows.Forms;
//using System;

//namespace DB_M2_Chat
//{
//    partial class BookingManagementForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private Label lblTitle;
//        private DataGridView dgvBookings;
//        private Panel panelActions;
//        private Button btnConfirm;
//        private Button btnCancel;
//        private Button btnDetails;
//        private Button btnUpdatePayment;
//        private Label lblDescription;
//        private TextBox txtSearch;
//        private Button btnSearch;
//        private Panel panelAvailability;
//        private Label lblAvailability;
//        private TextBox txtRoomId;
//        private ComboBox cmbRoomStatus;
//        private Button btnUpdateAvailability;
//        private Button btnRefresh;
//        private ComboBox cmbStatusFilter;
//        private Label lblStatusFilter;
//        private RadioButton rdoHotel;
//        private RadioButton rdoTransport;
//        private GroupBox grpAccommodationType;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();

//            // Title Label
//            this.lblTitle = new Label
//            {
//                Text = "🛎️ Booking Management",
//                Font = new Font("Segoe UI", 14, FontStyle.Bold),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(30, 20),
//                AutoSize = true
//            };

//            // Description Label
//            this.lblDescription = new Label
//            {
//                Text = "Manage reservations, update availability, and track payments",
//                Font = new Font("Segoe UI", 10),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(32, 50),
//                AutoSize = true
//            };

//            // Status Filter Label
//            this.lblStatusFilter = new Label
//            {
//                Text = "Status:",
//                Font = new Font("Segoe UI", 9),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(470, 52),
//                AutoSize = true
//            };

//            // Status Filter ComboBox
//            this.cmbStatusFilter = new ComboBox
//            {
//                Location = new Point(520, 50),
//                Size = new Size(100, 25),
//                DropDownStyle = ComboBoxStyle.DropDownList
//            };
//            this.cmbStatusFilter.SelectedIndexChanged += new EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

//            // Search TextBox
//            this.txtSearch = new TextBox
//            {
//                Location = new Point(630, 50),
//                Size = new Size(150, 25),
//                Text = "Search bookings..."
//            };
//            this.txtSearch.GotFocus += (s, e) =>
//            {
//                if (txtSearch.Text == "Search bookings...")
//                {
//                    txtSearch.Text = "";
//                }
//            };
//            this.txtSearch.LostFocus += (s, e) =>
//            {
//                if (string.IsNullOrWhiteSpace(txtSearch.Text))
//                {
//                    txtSearch.Text = "Search bookings...";
//                }
//            };

//            // Search Button
//            this.btnSearch = new Button
//            {
//                Text = "🔍",
//                BackColor = Color.FromArgb(40, 120, 180),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(790, 50),
//                Size = new Size(30, 25)
//            };
//            this.btnSearch.FlatAppearance.BorderSize = 0;
//            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

//            // Refresh Button
//            this.btnRefresh = new Button
//            {
//                Text = "🔄",
//                BackColor = Color.FromArgb(40, 120, 180),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(430, 50),
//                Size = new Size(30, 25)
//            };
//            this.btnRefresh.FlatAppearance.BorderSize = 0;
//            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

//            // DataGridView for Bookings
//            this.dgvBookings = new DataGridView
//            {
//                Location = new Point(30, 80),
//                Size = new Size(790, 220),
//                BackgroundColor = Color.White,
//                BorderStyle = BorderStyle.None,
//                AllowUserToAddRows = false,
//                AllowUserToDeleteRows = false,
//                ReadOnly = true,
//                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
//                MultiSelect = false,
//                RowHeadersVisible = false,
//                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
//            };

//            // Actions Panel
//            this.panelActions = new Panel
//            {
//                Location = new Point(30, 310),
//                Size = new Size(790, 60),
//                BackColor = Color.FromArgb(191, 215, 234)
//            };

//            // Confirm Button
//            this.btnConfirm = new Button
//            {
//                Text = "Confirm",
//                BackColor = Color.FromArgb(40, 167, 69),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(20, 10),
//                Size = new Size(120, 35)
//            };
//            this.btnConfirm.FlatAppearance.BorderSize = 0;
//            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);

//            // Cancel Button
//            this.btnCancel = new Button
//            {
//                Text = "Cancel",
//                BackColor = Color.FromArgb(220, 53, 69),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(150, 10),
//                Size = new Size(120, 35)
//            };
//            this.btnCancel.FlatAppearance.BorderSize = 0;
//            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

//            // Update Payment Button
//            this.btnUpdatePayment = new Button
//            {
//                Text = "Update Payment",
//                BackColor = Color.FromArgb(255, 193, 7),
//                ForeColor = Color.Black,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(280, 10),
//                Size = new Size(150, 35)
//            };
//            this.btnUpdatePayment.FlatAppearance.BorderSize = 0;
//            this.btnUpdatePayment.Click += new EventHandler(this.btnUpdatePayment_Click);

//            // Details Button
//            this.btnDetails = new Button
//            {
//                Text = "View Details",
//                BackColor = Color.FromArgb(40, 120, 180),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(440, 10),
//                Size = new Size(120, 35)
//            };
//            this.btnDetails.FlatAppearance.BorderSize = 0;
//            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

//            // Add buttons to panel
//            this.panelActions.Controls.AddRange(new Control[]
//            {
//                this.btnConfirm,
//                this.btnCancel,
//                this.btnUpdatePayment,
//                this.btnDetails
//            });

//            // Availability Panel
//            this.panelAvailability = new Panel
//            {
//                Location = new Point(30, 380),
//                Size = new Size(790, 100),
//                BorderStyle = BorderStyle.FixedSingle,
//                BackColor = Color.White
//            };

//            // Availability Label
//            this.lblAvailability = new Label
//            {
//                Text = "Update Room/Seat Availability:",
//                Font = new Font("Segoe UI", 10, FontStyle.Bold),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(10, 10),
//                AutoSize = true
//            };

//            // Accommodation Type Group Box
//            this.grpAccommodationType = new GroupBox
//            {
//                Text = "Type",
//                Location = new Point(10, 35),
//                Size = new Size(150, 55),
//                Font = new Font("Segoe UI", 9)
//            };

//            // Hotel Radio Button
//            this.rdoHotel = new RadioButton
//            {
//                Text = "Hotel Room",
//                Location = new Point(10, 20),
//                AutoSize = true,
//                Checked = true
//            };

//            // Transport Radio Button
//            this.rdoTransport = new RadioButton
//            {
//                Text = "Transport Seat",
//                Location = new Point(10, 40),
//                AutoSize = true
//            };

//            this.grpAccommodationType.Controls.AddRange(new Control[]
//            {
//                this.rdoHotel,
//                this.rdoTransport
//            });

//            // Room ID TextBox
//            this.txtRoomId = new TextBox
//            {
//                Location = new Point(170, 55),
//                Size = new Size(150, 25),
//                Text = "Room/Seat ID"
//            };
//            this.txtRoomId.GotFocus += (s, e) =>
//            {
//                if (txtRoomId.Text == "Room/Seat ID")
//                {
//                    txtRoomId.Text = "";
//                }
//            };
//            this.txtRoomId.LostFocus += (s, e) =>
//            {
//                if (string.IsNullOrWhiteSpace(txtRoomId.Text))
//                {
//                    txtRoomId.Text = "Room/Seat ID";
//                }
//            };

//            // Room Status ComboBox
//            this.cmbRoomStatus = new ComboBox
//            {
//                Location = new Point(330, 55),
//                Size = new Size(150, 25),
//                DropDownStyle = ComboBoxStyle.DropDownList
//            };

//            // Update Availability Button
//            this.btnUpdateAvailability = new Button
//            {
//                Text = "Update Availability",
//                BackColor = Color.FromArgb(40, 120, 180),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(490, 55),
//                Size = new Size(150, 25)
//            };
//            this.btnUpdateAvailability.FlatAppearance.BorderSize = 0;
//            this.btnUpdateAvailability.Click += new EventHandler(this.btnUpdateAvailability_Click);

//            // Add controls to availability panel
//            this.panelAvailability.Controls.AddRange(new Control[]
//            {
//                this.lblAvailability,
//                this.grpAccommodationType,
//                this.txtRoomId,
//                this.cmbRoomStatus,
//                this.btnUpdateAvailability
//            });

//            // Form properties
//            this.BackColor = Color.FromArgb(191, 215, 234);
//            this.ClientSize = new Size(850, 500);
//            this.FormBorderStyle = FormBorderStyle.None;

//            // Add controls to form
//            this.Controls.AddRange(new Control[]
//            {
//                this.lblTitle,
//                this.lblDescription,
//                this.lblStatusFilter,
//                this.cmbStatusFilter,
//                this.txtSearch,
//                this.btnSearch,
//                this.btnRefresh,
//                this.dgvBookings,
//                this.panelActions,
//                this.panelAvailability
//            });

//            this.Load += new EventHandler(this.BookingManagementForm_Load);
//        }
//    }
//}


using System;
using System.Drawing;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    partial class BookingManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvBookings;
        private Panel panelActions;
        private Button btnConfirm;
        private Button btnCancel;
        private Button btnDetails;
        private Button btnUpdatePayment;
        private Label lblDescription;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel panelAvailability;
        private Label lblAvailability;
        private TextBox txtRoomId;
        private ComboBox cmbRoomStatus;
        private Button btnUpdateAvailability;
        private Button btnRefresh;
        private Panel panelFilters;
        private Label lblFilters;
        private ComboBox cmbServiceTypeFilter;
        private Label lblServiceType;
        private Button btnPending;
        private ComboBox cmbAccommodationType;
        private Label lblAccommodationType;
        private ComboBox cmbServiceId;
        private Label lblServiceId;
        private Label lblRoomSeatId;
        private ComboBox cmbBookingStatus;

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
            this.components = new System.ComponentModel.Container();

            // Title Label
            this.lblTitle = new Label
            {
                Text = "🛎️ Booking Management",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Manage reservations, update availability, and track payments",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Search TextBox
            this.txtSearch = new TextBox
            {
                Location = new Point(600, 50),
                Size = new Size(150, 25),
                Text = "Search bookings..."
            };
            this.txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Search bookings...")
                {
                    txtSearch.Text = "";
                }
            };
            this.txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search bookings...";
                }
            };

            // Search Button
            this.btnSearch = new Button
            {
                Text = "🔍",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(760, 50),
                Size = new Size(30, 25)
            };
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Refresh Button
            this.btnRefresh = new Button
            {
                Text = "🔄",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(560, 50),
                Size = new Size(30, 25)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Filters Panel
            this.panelFilters = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(760, 40),
                BackColor = Color.FromArgb(225, 237, 247)
            };

            // Filters Label
            this.lblFilters = new Label
            {
                Text = "Filters:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(10, 12),
                AutoSize = true
            };

            // Service Type Label
            this.lblServiceType = new Label
            {
                Text = "Service Type:",
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(80, 12),
                AutoSize = true
            };

            // Service Type Filter ComboBox
            this.cmbServiceTypeFilter = new ComboBox
            {
                Location = new Point(165, 10),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbServiceTypeFilter.SelectedIndexChanged += new EventHandler(this.cmbServiceTypeFilter_SelectedIndexChanged);

            // Add controls to filters panel
            this.panelFilters.Controls.AddRange(new Control[]
            {
                this.lblFilters,
                this.lblServiceType,
                this.cmbServiceTypeFilter
            });

            // DataGridView for Bookings
            this.dgvBookings = new DataGridView
            {
                Location = new Point(30, 130),
                Size = new Size(760, 220),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Actions Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 360),
                Size = new Size(760, 60),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Confirm Button
            this.btnConfirm = new Button
            {
                Text = "Confirm",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 10),
                Size = new Size(110, 35)
            };
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);

            // Cancel Button
            this.btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(130, 10),
                Size = new Size(110, 35)
            };
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Pending Button
            this.btnPending = new Button
            {
                Text = "Set Pending",
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(250, 10),
                Size = new Size(110, 35)
            };
            this.btnPending.FlatAppearance.BorderSize = 0;
            this.btnPending.Click += new EventHandler(this.btnPending_Click);

            // Update Payment Button
            this.btnUpdatePayment = new Button
            {
                Text = "Update Payment",
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(370, 10),
                Size = new Size(150, 35)
            };
            this.btnUpdatePayment.FlatAppearance.BorderSize = 0;
            this.btnUpdatePayment.Click += new EventHandler(this.btnUpdatePayment_Click);

            // Details Button
            this.btnDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(530, 10),
                Size = new Size(120, 35)
            };
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

            // Add buttons to panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnConfirm,
                this.btnCancel,
                this.btnPending,
                this.btnUpdatePayment,
                this.btnDetails
            });

            // Availability Panel
            this.panelAvailability = new Panel
            {
                Location = new Point(30, 430),
                Size = new Size(760, 120),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Availability Label
            this.lblAvailability = new Label
            {
                Text = "Update Room/Seat Availability:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(10, 10),
                AutoSize = true
            };

            // Accommodation Type Label
            this.lblAccommodationType = new Label
            {
                Text = "Type:",
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(10, 40),
                AutoSize = true
            };

            // Accommodation Type ComboBox
            this.cmbAccommodationType = new ComboBox
            {
                Location = new Point(50, 40),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Service ID Label
            this.lblServiceId = new Label
            {
                Text = "Service:",
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(220, 40),
                AutoSize = true
            };

            // Service ID ComboBox
            this.cmbServiceId = new ComboBox
            {
                Location = new Point(270, 40),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Room/Seat ID Label
            this.lblRoomSeatId = new Label
            {
                Text = "Room/Seat:",
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(10, 75),
                AutoSize = true
            };

            // Room ID TextBox
            this.txtRoomId = new TextBox
            {
                Location = new Point(100, 75),
                Size = new Size(100, 25)
            };

            // Booking Status Label
            Label lblBookingStatus = new Label
            {
                Text = "Status:",
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(220, 75),
                AutoSize = true
            };

            // Room Status ComboBox
            this.cmbRoomStatus = new ComboBox
            {
                Location = new Point(270, 75),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Booking Status ComboBox
            this.cmbBookingStatus = new ComboBox
            {
                Location = new Point(580, 45),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Visible = false // We'll use this for future functionality
            };

            // Update Availability Button
            this.btnUpdateAvailability = new Button
            {
                Text = "Update Availability",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(480, 75),
                Size = new Size(150, 25)
            };
            this.btnUpdateAvailability.FlatAppearance.BorderSize = 0;
            this.btnUpdateAvailability.Click += new EventHandler(this.btnUpdateAvailability_Click);

            // Add controls to availability panel
            this.panelAvailability.Controls.AddRange(new Control[]
            {
                this.lblAvailability,
                this.lblAccommodationType,
                this.cmbAccommodationType,
                this.lblServiceId,
                this.cmbServiceId,
                this.lblRoomSeatId,
                this.txtRoomId,
                lblBookingStatus,
                this.cmbRoomStatus,
                this.btnUpdateAvailability
            });

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 570);
            this.FormBorderStyle = FormBorderStyle.None;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.txtSearch,
                this.btnSearch,
                this.btnRefresh,
                this.panelFilters,
                this.dgvBookings,
                this.panelActions,
                this.panelAvailability,
                this.cmbBookingStatus
            });

            this.Load += new EventHandler(this.BookingManagementForm_Load);
        }
    }
}