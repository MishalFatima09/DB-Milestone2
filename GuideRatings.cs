using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TravelEase;

namespace DB_M2_Chat
{
    public partial class GuideRatings : Form
    {
        public GuideRatings()
        {
            InitializeComponent();
        }

        private void GuideRatings_Load(object sender, EventArgs e)
        {
            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM GuideRatings";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "GuideRatings");

                ReportDataSource rds = new ReportDataSource("GuideRatings", ds.Tables["GuideRatings"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
          
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            TransportPerformance tp = new TransportPerformance();
            tp.Show();
            this.Hide();
        }
    }
}
