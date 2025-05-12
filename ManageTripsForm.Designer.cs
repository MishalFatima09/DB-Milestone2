using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class ManageTripsForm
    {
        private DataGridView dgvTrips;
        private TextBox txtSearch;
        private Button btnSearch, btnRefresh;


        private void InitializeComponent()
        {
            this.dgvTrips = new DataGridView();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnRefresh = new Button();

            // Search TextBox
            this.txtSearch.Location = new Point(20, 20);
            this.txtSearch.Size = new Size(200, 25);

            // Search Button
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new Point(230, 20);
            this.btnSearch.Size = new Size(75, 25);
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Refresh Button
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Location = new Point(320, 20);
            this.btnRefresh.Size = new Size(80, 25);
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // DataGridView
            this.dgvTrips.Location = new Point(20, 60);
            this.dgvTrips.Size = new Size(900, 400);
            this.dgvTrips.AutoGenerateColumns = false;
            this.dgvTrips.AllowUserToAddRows = false;

            // TripID (hidden)
            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TripID",
                DataPropertyName = "TripID",
                Name = "TripID",
                Visible = false // Hidden from user
            });

            // Visible Columns
            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                Name = "Title"
            });

            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                DataPropertyName = "Price",
                Name = "Price"
            });

            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Duration",
                DataPropertyName = "Duration",
                Name = "Duration"
            });

            // Edit Button
            var editCol = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit" //  Must match click handler
            };
            dgvTrips.Columns.Add(editCol);

            // Delete Button
            var deleteCol = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete" //  Must match click handler
            };
            dgvTrips.Columns.Add(deleteCol);

            // Event
            this.dgvTrips.CellClick += new DataGridViewCellEventHandler(this.dgvTrips_CellClick);

            // Add controls to the form
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTrips);
        }


    }
}
