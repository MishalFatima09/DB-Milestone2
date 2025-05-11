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

            // Columns
            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Title", DataPropertyName = "Title" });
            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "Price" });
            dgvTrips.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Duration", DataPropertyName = "Duration" });

            // Edit Button
            var editCol = new DataGridViewButtonColumn();
            editCol.HeaderText = "";
            editCol.Text = "Edit";
            editCol.UseColumnTextForButtonValue = true;
            dgvTrips.Columns.Add(editCol);

            // Delete Button
            var deleteCol = new DataGridViewButtonColumn();
            deleteCol.HeaderText = "";
            deleteCol.Text = "Delete";
            deleteCol.UseColumnTextForButtonValue = true;
            dgvTrips.Columns.Add(deleteCol);

            // Event
            this.dgvTrips.CellClick += new DataGridViewCellEventHandler(this.dgvTrips_CellClick);

            // Add to form
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTrips);

        }

        //private void dgvTrips_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
