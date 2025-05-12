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
    public partial class OpResponse : Form
    {
        public OpResponse()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(11, 57, 84);
        }

        private void OpResponse_Load(object sender, EventArgs e)
        {
            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM OpResponse";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "OpResponse");

                ReportDataSource rds = new ReportDataSource("OpResponse", ds.Tables["OpResponse"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Spending tp = new Spending();
            tp.Show();  // Show the new form normally
            this.Hide();
        }
    }
}
