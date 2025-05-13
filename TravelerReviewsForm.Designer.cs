using System;
using System.Drawing;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    partial class TravelerReviewsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblNewReview;
        private Label lblServiceName;
        private TextBox txtServiceName;
        private Label lblServiceType;
        private ComboBox cmbServiceType;
        private Label lblRating;
        private ComboBox cmbRating;
        private Label lblReviewText;
        private TextBox txtReviewText;
        private Button btnSubmitReview;
        private Button btnClear;
        private DataGridView dgvReviewHistory;
        private Panel panelNewReview;
        private Panel panelActions;
        private Button btnEditReview;
        private Button btnDeleteReview;
        private TextBox txtFilter;
        private Button btnFilter;
        private ComboBox cmbFilterType;
        private Button btnResetFilter;
        private Label lblHistory;
        private PictureBox picRatingStar;

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
                Text = "✏️ My Reviews",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Review History Label
            this.lblHistory = new Label
            {
                Text = "My Review History",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 60),
                AutoSize = true
            };

            // Filter TextBox
            this.txtFilter = new TextBox
            {
                Location = new Point(490, 60),
                Size = new Size(150, 25),
                Text = "Search reviews..."
            };
            this.txtFilter.GotFocus += (s, e) =>
            {
                if (txtFilter.Text == "Search reviews...")
                {
                    txtFilter.Text = "";
                }
            };
            this.txtFilter.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    txtFilter.Text = "Search reviews...";
                }
            };

            // Filter Type ComboBox
            this.cmbFilterType = new ComboBox
            {
                Location = new Point(650, 60),
                Size = new Size(100, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbFilterType.Items.AddRange(new string[] { "All Types", "Hotel", "Tour", "Transport", "Restaurant", "Activity" });
            this.cmbFilterType.SelectedIndex = 0;

            // Filter Button
            this.btnFilter = new Button
            {
                Text = "🔍",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(760, 60),
                Size = new Size(30, 25)
            };
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Click += new EventHandler(this.btnFilter_Click);

            // Reset Filter Button
            this.btnResetFilter = new Button
            {
                Text = "↻",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(450, 60),
                Size = new Size(30, 25)
            };
            this.btnResetFilter.FlatAppearance.BorderSize = 0;
            this.btnResetFilter.Click += new EventHandler(this.btnResetFilter_Click);

            // DataGridView for Review History
            this.dgvReviewHistory = new DataGridView
            {
                Location = new Point(30, 90),
                Size = new Size(760, 180),
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

            // Configure DataGridView columns
            this.dgvReviewHistory.ColumnCount = 6;
            this.dgvReviewHistory.Columns[0].Name = "ReviewID";
            this.dgvReviewHistory.Columns[0].Width = 70;
            this.dgvReviewHistory.Columns[1].Name = "ServiceName";
            this.dgvReviewHistory.Columns[1].Width = 150;
            this.dgvReviewHistory.Columns[2].Name = "ServiceType";
            this.dgvReviewHistory.Columns[2].Width = 90;
            this.dgvReviewHistory.Columns[3].Name = "Rating";
            this.dgvReviewHistory.Columns[3].Width = 110;
            this.dgvReviewHistory.Columns[4].Name = "Date";
            this.dgvReviewHistory.Columns[4].Width = 90;
            this.dgvReviewHistory.Columns[5].Name = "ReviewText";
            this.dgvReviewHistory.Columns[5].Width = 250;

            // Actions Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 280),
                Size = new Size(760, 50),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Edit Review Button
            this.btnEditReview = new Button
            {
                Text = "Edit Review",
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 10),
                Size = new Size(120, 30)
            };
            this.btnEditReview.FlatAppearance.BorderSize = 0;
            this.btnEditReview.Click += new EventHandler(this.btnEditReview_Click);

            // Delete Review Button
            this.btnDeleteReview = new Button
            {
                Text = "Delete Review",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(150, 10),
                Size = new Size(120, 30)
            };
            this.btnDeleteReview.FlatAppearance.BorderSize = 0;
            this.btnDeleteReview.Click += new EventHandler(this.btnDeleteReview_Click);

            // Add buttons to actions panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnEditReview,
                this.btnDeleteReview
            });

            // New Review Panel
            this.panelNewReview = new Panel
            {
                Location = new Point(30, 340),
                Size = new Size(760, 260),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // New Review Label
            this.lblNewReview = new Label
            {
                Text = "Write a New Review",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Service Name Label
            this.lblServiceName = new Label
            {
                Text = "Service Name:",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 50),
                AutoSize = true
            };

            // Service Name TextBox
            this.txtServiceName = new TextBox
            {
                Location = new Point(120, 50),
                Size = new Size(250, 25)
            };

            // Service Type Label
            this.lblServiceType = new Label
            {
                Text = "Service Type:",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 80),
                AutoSize = true
            };

            // Service Type ComboBox
            this.cmbServiceType = new ComboBox
            {
                Location = new Point(120, 80),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Rating Label
            this.lblRating = new Label
            {
                Text = "Rating:",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 110),
                AutoSize = true
            };

            // Rating Star Icon
            this.picRatingStar = new PictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(95, 110),
                BackColor = Color.Transparent
            };
            // In a real application, load a star image
            // this.picRatingStar.Image = ...

            // Rating ComboBox
            this.cmbRating = new ComboBox
            {
                Location = new Point(120, 110),
                Size = new Size(250, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Review Text Label
            this.lblReviewText = new Label
            {
                Text = "Your Review:",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 140),
                AutoSize = true
            };

            // Review Text TextBox
            this.txtReviewText = new TextBox
            {
                Location = new Point(120, 140),
                Size = new Size(620, 75),
                Multiline = true
            };

            // Submit Review Button
            this.btnSubmitReview = new Button
            {
                Text = "Submit Review",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(590, 220),
                Size = new Size(150, 30)
            };
            this.btnSubmitReview.FlatAppearance.BorderSize = 0;
            this.btnSubmitReview.Click += new EventHandler(this.btnSubmitReview_Click);

            // Clear Button
            this.btnClear = new Button
            {
                Text = "Clear",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(480, 220),
                Size = new Size(100, 30)
            };
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // Add controls to new review panel
            this.panelNewReview.Controls.AddRange(new Control[]
            {
                this.lblNewReview,
                this.lblServiceName,
                this.txtServiceName,
                this.lblServiceType,
                this.cmbServiceType,
                this.lblRating,
                this.picRatingStar,
                this.cmbRating,
                this.lblReviewText,
                this.txtReviewText,
                this.btnSubmitReview,
                this.btnClear
            });

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 620);
            this.FormBorderStyle = FormBorderStyle.None;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblHistory,
                this.txtFilter,
                this.cmbFilterType,
                this.btnFilter,
                this.btnResetFilter,
                this.dgvReviewHistory,
                this.panelActions,
                this.panelNewReview
            });

            this.Load += new EventHandler(this.TravelerReviewsForm_Load);
        }
    }
}