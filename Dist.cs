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
    public partial class Dist : Form
    {
        public Dist()
        {
            InitializeComponent();
        }

        private void Dist_Load(object sender, EventArgs e)
        {
            //Distribution

            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM TravelerAgeNationalityDistribution";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Distribution");

                ReportDataSource rds = new ReportDataSource("Distribution", ds.Tables["Distribution"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
