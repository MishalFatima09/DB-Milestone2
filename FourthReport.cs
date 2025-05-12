using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using DB_M2_Chat;

namespace TravelEase.Forms
{
    public partial class FourthReport : Form
    {
        public FourthReport()
        {
            InitializeComponent();
        }

        private void FourthReport_Load(object sender, EventArgs e)
        {
            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM HotelOccupancy"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "HotelOccupancy"); 

                ReportDataSource rds = new ReportDataSource("hOTELoCCUPANCY", ds.Tables["HotelOccupancy"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuideRatings guideRatingsForm = new GuideRatings();
            guideRatingsForm.Show();
            this.Hide();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
