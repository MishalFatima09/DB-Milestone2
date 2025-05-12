using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class ViewAssignedServicesForm : Form
    {
        private DataGridView dgv;
        private Label lbl;

        public ViewAssignedServicesForm()
        {
            this.Text = "Assigned Services";
            this.BackColor = System.Drawing.Color.FromArgb(191, 215, 234);
            this.Size = new Size(900, 400);
            InitializeComponentCustom(); 
            LoadAssignedServices();
        }

        private void InitializeComponentCustom() 
        {
            this.lbl = new Label();
            this.lbl.Text = "📋 Assigned Services";
            this.lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lbl.ForeColor = Color.FromArgb(11, 57, 84);
            this.lbl.Location = new Point(30, 20);
            this.lbl.AutoSize = true;

            this.dgv = new DataGridView();
            this.dgv.Location = new Point(30, 60);
            this.dgv.Size = new Size(800, 280);
            this.dgv.ReadOnly = true;
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgv);
        }

        private void LoadAssignedServices()
        {
            try
            {
                string connStr = @"Data Source=MISHALSLAPPY\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
                {
                    conn.Open();
                    string query = @"  
                           SELECT   
                               a.AssignmentID, s.Name AS ServiceName, s.Type,  
                               a.Status, a.ScheduledDeparture, a.ScheduledArrival,  
                               a.BookingID  
                           FROM AssignedService a  
                           JOIN Service s ON a.ServiceID = s.ServiceID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assigned services:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewAssignedServicesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
