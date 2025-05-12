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
    public partial class OpRating : Form
    {
        public OpRating()
        {
            InitializeComponent();
        }

        private void OpRating_Load(object sender, EventArgs e)
        {

            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM OperatorAverageRatings";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "OperatorRating");

                ReportDataSource rds = new ReportDataSource("OperatorRating", ds.Tables["OperatorRating"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpRevenue tp = new OpRevenue();
            tp.Show();  // Show the new form normally
            this.Hide();

        }
    }
}
