//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace TravelEase.Forms
//{
//    public partial class AnalyticsForm : Form
//    {
//        public AnalyticsForm()
//        {
//            InitializeComponent();
//        }

//        private void AnalyticsForm_Load(object sender, EventArgs e)
//        {
//            cmbTimeFrame.SelectedIndex = 0;
//            cmbChartType.SelectedIndex = 0;
//            LoadData();
//        }

//        private void LoadData()
//        {
//            LoadRevenueData();
//            LoadTopDestinations();
//            UpdateSummaryCards();
//        }

//        private void UpdateSummaryCards()
//        {
//            lblTotalBookings.Text = "1,245";
//            lblTotalRevenue.Text = "$149,750";
//            lblActiveUsers.Text = "3,210";
//            lblCompletedTours.Text = "987";
//        }

//        private void LoadRevenueData()
//        {
//            dgvRevenue.Rows.Clear();
//            dgvRevenue.Rows.Add("Beach Resorts", "$54,320", "36.3%", "+12.5%");
//            dgvRevenue.Rows.Add("Mountain Retreats", "$32,150", "21.5%", "+8.2%");
//            dgvRevenue.Rows.Add("City Tours", "$28,970", "19.3%", "+5.7%");
//            dgvRevenue.Rows.Add("Cultural Experiences", "$19,840", "13.2%", "+15.3%");
//            dgvRevenue.Rows.Add("Adventure Sports", "$14,470", "9.7%", "-2.1%");

//            for (int i = 0; i < dgvRevenue.Rows.Count; i++)
//            {
//                string growth = dgvRevenue.Rows[i].Cells["Growth"].Value.ToString();
//                dgvRevenue.Rows[i].Cells["Growth"].Style.ForeColor =
//                    growth.StartsWith("+") ? Color.Green : Color.Red;
//            }
//        }

//        private void LoadTopDestinations()
//        {
//            dgvTopDestinations.Rows.Clear();
//            dgvTopDestinations.Rows.Add("Bali, Indonesia", "245", "4.8");
//            dgvTopDestinations.Rows.Add("Paris, France", "198", "4.7");
//            dgvTopDestinations.Rows.Add("Santorini, Greece", "176", "4.9");
//            dgvTopDestinations.Rows.Add("Tokyo, Japan", "165", "4.6");
//            dgvTopDestinations.Rows.Add("New York, USA", "154", "4.5");
//        }

//        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            LoadData();
//        }

//        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            // No chart to update
//        }

//        private void btnExportPDF_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Analytics data exported to PDF successfully!", "Export Complete",
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnExportCSV_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Analytics data exported to CSV successfully!", "Export Complete",
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadData();
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

//namespace TravelEase.Forms
//{
//    public partial class AnalyticsForm : Form
//    {
//        public AnalyticsForm()
//        {
//            InitializeComponent();
//        }

//        private void AnalyticsForm_Load(object sender, EventArgs e)
//        {
//            cmbTimeFrame.SelectedIndex = 0; // Set default to "Last 30 Days"
//            cmbChartType.SelectedIndex = 0; // Set default to "Line Chart"
//            LoadData();
//        }

//        private void LoadData()
//        {
//            LoadBookingTrendsChart();
//            LoadUserTrafficChart();
//            LoadRevenueData();
//            LoadTopDestinations();
//            UpdateSummaryCards();
//        }

//        private void UpdateSummaryCards()
//        {
//            // In a real application, these values would be retrieved from a database
//            lblTotalBookings.Text = "1,245";
//            lblTotalRevenue.Text = "$149,750";
//            lblActiveUsers.Text = "3,210";
//            lblCompletedTours.Text = "987";
//        }

//        private void LoadBookingTrendsChart()
//        {
//            chartBookings.Series.Clear();
//            chartBookings.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
//            chartBookings.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
//            chartBookings.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartBookings.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartBookings.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
//            chartBookings.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
//            chartBookings.ChartAreas[0].AxisY.Title = "Number of Bookings";
//            chartBookings.Titles.Add("Booking Trends");
//            chartBookings.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
//            chartBookings.Titles[0].ForeColor = Color.FromArgb(11, 57, 84);

//            // Create sample data for booking trends
//            var seriesBookings = new Series("Bookings")
//            {
//                ChartType = GetSelectedChartType(),
//                Color = Color.FromArgb(11, 57, 84),
//                BorderWidth = 3
//            };

//            var rand = new Random();
//            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

//            for (int i = 0; i < months.Length; i++)
//            {
//                seriesBookings.Points.AddXY(months[i], rand.Next(50, 200));
//            }

//            chartBookings.Series.Add(seriesBookings);
//        }

//        private void LoadUserTrafficChart()
//        {
//            chartUserTraffic.Series.Clear();
//            chartUserTraffic.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
//            chartUserTraffic.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
//            chartUserTraffic.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartUserTraffic.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartUserTraffic.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
//            chartUserTraffic.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
//            chartUserTraffic.ChartAreas[0].AxisY.Title = "User Traffic";
//            chartUserTraffic.Titles.Add("User Traffic by Platform");
//            chartUserTraffic.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
//            chartUserTraffic.Titles[0].ForeColor = Color.FromArgb(11, 57, 84);

//            // Create a pie chart for user traffic by source
//            var seriesTraffic = new Series("Traffic Source")
//            {
//                ChartType = SeriesChartType.Pie,
//                IsValueShownAsLabel = true,
//                LabelFormat = "{0}%"
//            };

//            // Sample data for traffic sources
//            seriesTraffic.Points.AddXY("Mobile App", 45);
//            seriesTraffic.Points.AddXY("Website", 32);
//            seriesTraffic.Points.AddXY("Partners", 15);
//            seriesTraffic.Points.AddXY("Other", 8);

//            // Set colors for each slice
//            seriesTraffic.Points[0].Color = Color.FromArgb(46, 139, 87);
//            seriesTraffic.Points[1].Color = Color.FromArgb(70, 130, 180);
//            seriesTraffic.Points[2].Color = Color.FromArgb(255, 127, 80);
//            seriesTraffic.Points[3].Color = Color.FromArgb(128, 128, 128);

//            chartUserTraffic.Series.Add(seriesTraffic);
//        }

//        private void LoadRevenueData()
//        {
//            dgvRevenue.Rows.Clear();

//            // Sample data for revenue by category
//            dgvRevenue.Rows.Add("Beach Resorts", "$54,320", "36.3%", "+12.5%");
//            dgvRevenue.Rows.Add("Mountain Retreats", "$32,150", "21.5%", "+8.2%");
//            dgvRevenue.Rows.Add("City Tours", "$28,970", "19.3%", "+5.7%");
//            dgvRevenue.Rows.Add("Cultural Experiences", "$19,840", "13.2%", "+15.3%");
//            dgvRevenue.Rows.Add("Adventure Sports", "$14,470", "9.7%", "-2.1%");

//            // Set colors for growth indicators
//            for (int i = 0; i < dgvRevenue.Rows.Count; i++)
//            {
//                string growth = dgvRevenue.Rows[i].Cells["Growth"].Value.ToString();
//                if (growth.StartsWith("+"))
//                {
//                    dgvRevenue.Rows[i].Cells["Growth"].Style.ForeColor = Color.Green;
//                }
//                else
//                {
//                    dgvRevenue.Rows[i].Cells["Growth"].Style.ForeColor = Color.Red;
//                }
//            }
//        }

//        private void LoadTopDestinations()
//        {
//            dgvTopDestinations.Rows.Clear();

//            // Sample data for top destinations
//            dgvTopDestinations.Rows.Add("Bali, Indonesia", "245", "4.8");
//            dgvTopDestinations.Rows.Add("Paris, France", "198", "4.7");
//            dgvTopDestinations.Rows.Add("Santorini, Greece", "176", "4.9");
//            dgvTopDestinations.Rows.Add("Tokyo, Japan", "165", "4.6");
//            dgvTopDestinations.Rows.Add("New York, USA", "154", "4.5");
//        }

//        private SeriesChartType GetSelectedChartType()
//        {
//            switch (cmbChartType.SelectedIndex)
//            {
//                case 0:
//                    return SeriesChartType.Line;
//                case 1:
//                    return SeriesChartType.Column;
//                case 2:
//                    return SeriesChartType.Area;
//                default:
//                    return SeriesChartType.Line;
//            }
//        }

//        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            LoadData(); // Reload data when time frame changes
//        }

//        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            LoadBookingTrendsChart(); // Update chart type
//        }

//        private void btnExportPDF_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Analytics data exported to PDF successfully!", "Export Complete",
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnExportCSV_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Analytics data exported to CSV successfully!", "Export Complete",
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadData(); // Reload all data
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
//using System.Data.SqlClient;
//using System.IO;

//namespace TravelEase.Forms
//{
//    public partial class AnalyticsForm : Form
//    {
//        // Database connection string
//        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

//        public AnalyticsForm()
//        {
//            InitializeComponent();
//        }

//        private void AnalyticsForm_Load(object sender, EventArgs e)
//        {
//            cmbTimeFrame.SelectedIndex = 0; // Set default to "Last 30 Days"
//            cmbChartType.SelectedIndex = 0; // Set default to "Line Chart"
//            LoadData();
//        }

//        private void LoadData()
//        {
//            try
//            {
//                LoadBookingTrendsChart();
//                LoadUserTrafficChart();
//                LoadRevenueData();
//                LoadTopDestinations();
//                UpdateSummaryCards();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading analytics data: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateSummaryCards()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Total Bookings
//                //string bookingsQuery = @"
//                //    SELECT COUNT(*) AS TotalBookings 
//                //    FROM Booking
//                //    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";  /////////////////////////

//                string bookingsQuery = @"
//                    SELECT COUNT(*) AS TotalBookings 
//                    FROM Booking";  /////////////////////////
//                using (SqlCommand cmd = new SqlCommand(bookingsQuery, connection))
//                {
//                    lblTotalBookings.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
//                }

//                // Total Revenue
//                string revenueQuery = @"
//                    SELECT SUM(p.Amount) AS TotalRevenue 
//                    FROM Payment p
//                    JOIN Booking b ON p.BookingID = b.BookingID
//                    WHERE p.PaymentDate >= DATEADD(day, -30, GETDATE()) 
//                    AND p.Status = 'Completed'";
//                using (SqlCommand cmd = new SqlCommand(revenueQuery, connection))
//                {
//                    decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
//                    lblTotalRevenue.Text = revenue.ToString("C0");
//                }

//                // Active Users
//                string usersQuery = @"
//                    SELECT COUNT(DISTINCT TravelerID) AS ActiveUsers 
//                    FROM Booking 
//                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";
//                using (SqlCommand cmd = new SqlCommand(usersQuery, connection))
//                {
//                    lblActiveUsers.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
//                }

//                // Completed Tours
//                string toursQuery = @"
//                    SELECT COUNT(*) AS CompletedTours 
//                    FROM Booking 
//                    WHERE Status = 'Completed' 
//                    AND BookingDate >= DATEADD(day, -30, GETDATE())";
//                using (SqlCommand cmd = new SqlCommand(toursQuery, connection))
//                {
//                    lblCompletedTours.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
//                }
//            }
//        }

//        private void LoadBookingTrendsChart()
//        {
//            chartBookings.Series.Clear();
//            chartBookings.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
//            chartBookings.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
//            chartBookings.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartBookings.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartBookings.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
//            chartBookings.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
//            chartBookings.ChartAreas[0].AxisY.Title = "Number of Bookings";
//            chartBookings.Titles.Clear();
//            chartBookings.Titles.Add("Booking Trends");
//            chartBookings.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
//            chartBookings.Titles[0].ForeColor = Color.FromArgb(11, 57, 84);

//            var seriesBookings = new Series("Bookings")
//            {
//                ChartType = GetSelectedChartType(),
//                Color = Color.FromArgb(11, 57, 84),
//                BorderWidth = 3
//            };

//            // Fetch booking trends from database
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = @"
//                    SELECT 
//                        CONVERT(VARCHAR(10), BookingDate, 120) AS BookingMonth, 
//                        COUNT(*) AS BookingCount
//                    FROM Booking
//                    WHERE BookingDate >= DATEADD(month, -12, GETDATE())
//                    GROUP BY CONVERT(VARCHAR(10), BookingDate, 120)
//                    ORDER BY BookingMonth";

//                using (SqlCommand cmd = new SqlCommand(query, connection))
//                {
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            seriesBookings.Points.AddXY(
//                                reader["BookingMonth"].ToString(),
//                                Convert.ToInt32(reader["BookingCount"])
//                            );
//                        }
//                    }
//                }
//            }

//            chartBookings.Series.Add(seriesBookings);
//        }

//        private void LoadUserTrafficChart()
//        {
//            chartUserTraffic.Series.Clear();
//            chartUserTraffic.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
//            chartUserTraffic.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
//            chartUserTraffic.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartUserTraffic.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
//            chartUserTraffic.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10);
//            chartUserTraffic.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10);
//            chartUserTraffic.ChartAreas[0].AxisY.Title = "User Traffic";
//            chartUserTraffic.Titles.Clear();
//            chartUserTraffic.Titles.Add("User Traffic by Platform");
//            chartUserTraffic.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
//            chartUserTraffic.Titles[0].ForeColor = Color.FromArgb(11, 57, 84);

//            var seriesTraffic = new Series("Traffic Source")
//            {
//                ChartType = SeriesChartType.Pie,
//                IsValueShownAsLabel = true,
//                LabelFormat = "{0}%"
//            };

//            // Fetch user traffic from database (you might need to track this separately)
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = @"
//                    WITH TrafficSources AS (
//                        SELECT 
//                            CASE 
//                                WHEN BookingSource LIKE '%Mobile%' THEN 'Mobile App'
//                                WHEN BookingSource LIKE '%Web%' THEN 'Website'
//                                WHEN BookingSource LIKE '%Partner%' THEN 'Partners'
//                                ELSE 'Other'
//                            END AS Source,
//                            COUNT(*) AS SourceCount
//                        FROM Booking
//                        WHERE BookingDate >= DATEADD(day, -30, GETDATE())
//                        GROUP BY 
//                            CASE 
//                                WHEN BookingSource LIKE '%Mobile%' THEN 'Mobile App'
//                                WHEN BookingSource LIKE '%Web%' THEN 'Website'
//                                WHEN BookingSource LIKE '%Partner%' THEN 'Partners'
//                                ELSE 'Other'
//                            END
//                    ),
//                    TotalBookings AS (
//                        SELECT SUM(SourceCount) AS Total FROM TrafficSources
//                    )
//                    SELECT 
//                        Source, 
//                        SourceCount, 
//                        ROUND(SourceCount * 100.0 / Total, 2) AS Percentage
//                    FROM TrafficSources, TotalBookings
//                    ORDER BY SourceCount DESC";

//                using (SqlCommand cmd = new SqlCommand(query, connection))
//                {
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            seriesTraffic.Points.AddXY(
//                                reader["Source"].ToString(),
//                                Convert.ToDouble(reader["Percentage"])
//                            );
//                        }
//                    }
//                }
//            }

//            // Set colors for each slice
//            seriesTraffic.Points[0].Color = Color.FromArgb(46, 139, 87);
//            seriesTraffic.Points[1].Color = Color.FromArgb(70, 130, 180);
//            seriesTraffic.Points[2].Color = Color.FromArgb(255, 127, 80);
//            if (seriesTraffic.Points.Count > 3)
//                seriesTraffic.Points[3].Color = Color.FromArgb(128, 128, 128);

//            chartUserTraffic.Series.Add(seriesTraffic);
//        }

//        private void LoadRevenueData()
//        {
//            dgvRevenue.Rows.Clear();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = @"
//                    WITH CategoryRevenue AS (
//                        SELECT 
//                            t.TourCategory,
//                            SUM(p.Amount) AS CategoryRevenue,
//                            SUM(p.Amount) * 100.0 / (SELECT SUM(Amount) FROM Payment WHERE PaymentDate >= DATEADD(day, -30, GETDATE())) AS Percentage,
//                            (SUM(p.Amount) - LAG(SUM(p.Amount)) OVER (ORDER BY t.TourCategory)) * 100.0 / LAG(SUM(p.Amount)) OVER (ORDER BY t.TourCategory) AS GrowthRate
//                        FROM Payment p
//                        JOIN Booking b ON p.BookingID = b.BookingID
//                        JOIN Trip t ON b.TripID = t.TripID
//                        WHERE p.PaymentDate >= DATEADD(day, -30, GETDATE())
//                        GROUP BY t.TourCategory
//                    )
//                    SELECT 
//                        TourCategory, 
//                        FORMAT(CategoryRevenue, 'C0') AS Revenue,
//                        FORMAT(Percentage, '0.0') + '%' AS Percentage,
//                        CASE 
//                            WHEN GrowthRate IS NOT NULL THEN 
//                                CASE 
//                                    WHEN GrowthRate > 0 THEN '+' + FORMAT(GrowthRate, '0.0') + '%'
//                                    ELSE FORMAT(GrowthRate, '0.0') + '%'
//                                END
//                            ELSE 'N/A'
//                        END AS Growth
//                    FROM CategoryRevenue
//                    ORDER BY CategoryRevenue DESC";

//                using (SqlCommand cmd = new SqlCommand(query, connection))
//                {
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            int rowIndex = dgvRevenue.Rows.Add(
//                                reader["TourCategory"].ToString(),
//                                reader["Revenue"].ToString(),
//                                reader["Percentage"].ToString(),
//                                reader["Growth"].ToString()
//                            );

//                            // Color coding for growth
//                            string growth = reader["Growth"].ToString();
//                            if (growth.StartsWith("+"))
//                            {
//                                dgvRevenue.Rows[rowIndex].Cells["Growth"].Style.ForeColor = Color.Green;
//                            }
//                            else if (growth.StartsWith("-"))
//                            {
//                                dgvRevenue.Rows[rowIndex].Cells["Growth"].Style.ForeColor = Color.Red;
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private void LoadTopDestinations()
//        {
//            dgvTopDestinations.Rows.Clear();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = @"
//                    WITH DestinationRankings AS (
//                        SELECT 
//                            td.Destination,
//                            COUNT(b.BookingID) AS BookingCount,
//                            AVG(t.Sustainability_Score * 1.0) AS AverageRating
//                        FROM TripDestination td
//                        JOIN Trip t ON td.TripID = t.TripID
//                        JOIN Booking b ON t.TripID = b.TripID
//                        WHERE b.BookingDate >= DATEADD(day, -30, GETDATE())
//                        GROUP BY td.Destination
//                    )
//                    SELECT TOP 5
//                        Destination,
//                        BookingCount,
//                        FORMAT(AverageRating, '0.1') AS AverageRating
//                    FROM DestinationRankings
//                    ORDER BY BookingCount DESC";

//                using (SqlCommand cmd = new SqlCommand(query, connection))
//                {
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            dgvTopDestinations.Rows.Add(
//                                reader["Destination"].ToString(),
//                                reader["BookingCount"].ToString(),
//                                reader["AverageRating"].ToString()
//                            );
//                        }
//                    }
//                }
//            }
//        }

//        private SeriesChartType GetSelectedChartType()
//        {
//            switch (cmbChartType.SelectedIndex)
//            {
//                case 0:
//                    return SeriesChartType.Line;
//                case 1:
//                    return SeriesChartType.Column;
//                case 2:
//                    return SeriesChartType.Area;
//                default:
//                    return SeriesChartType.Line;
//            }
//        }

//        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            LoadData(); // Reload data when time frame changes
//        }

//        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            LoadBookingTrendsChart(); // Update chart type
//        }

//        private void btnExportPDF_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // Implement PDF export logic
//                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
//                {
//                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
//                    saveFileDialog.Title = "Export Analytics to PDF";
//                    saveFileDialog.FileName = $"TravelEase_Analytics_{DateTime.Now:yyyyMMdd}.pdf";

//                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
//                    {
//                        // Implement PDF export using a PDF library like iTextSharp or PdfSharp
//                        // This is a placeholder for actual PDF generation
//                        GeneratePDFReport(saveFileDialog.FileName);
//                        MessageBox.Show("Analytics data exported to PDF successfully!", "Export Complete",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error exporting PDF: {ex.Message}", "Export Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void GeneratePDFReport(string filePath)
//        {
//            // Note: This requires adding a PDF library reference
//            // Example using iTextSharp (you'd need to add the NuGet package)
//            /*
//            using (FileStream fs = new FileStream(filePath, FileMode.Create))
//            {
//                Document document = new Document();
//                PdfWriter writer = PdfWriter.GetInstance(document, fs);

//                document.Open();

//                // Add title
//                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
//                document.Add(new Paragraph("TravelEase Platform Analytics", titleFont));

//                // Add summary cards data
//                document.Add(new Paragraph($"Total Bookings: {lblTotalBookings.Text}"));
//                document.Add(new Paragraph($"Total Revenue: {lblTotalRevenue.Text}"));
//                document.Add(new Paragraph($"Active Users: {lblActiveUsers.Text}"));
//                document.Add(new Paragraph($"Completed Tours: {lblCompletedTours.Text}"));

//                // Add charts as images
//                using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
//                {
//                    chartBookings.SaveImage(ms1, ChartImageFormat.Png);
//                    chartUserTraffic.SaveImage(ms2, ChartImageFormat.Png);

//                    iTextSharp.text.Image bookingChart = iTextSharp.text.Image.GetInstance(ms1.ToArray());
//                    iTextSharp.text.Image trafficChart = iTextSharp.text.Image.GetInstance(ms2.ToArray());

//                    document.Add(bookingChart);
//                    document.Add(trafficChart);
//                }

//                // Add revenue and destinations tables
//                PdfPTable revenueTable = new PdfPTable(4);
//                foreach (DataGridViewRow row in dgvRevenue.Rows)
//                {
//                    revenueTable.AddCell(row.Cells[0].Value?.ToString() ?? "");
//                    revenueTable.AddCell(row.Cells[1].Value?.ToString() ?? "");
//                    revenueTable.AddCell(row.Cells[2].Value?.ToString() ?? "");
//                    revenueTable.AddCell(row.Cells[3].Value?.ToString() ?? "");
//                }
//                document.Add(revenueTable);

//                document.Close();
//            }
//            */
//            // Simplified placeholder if no PDF library is available
//            using (StreamWriter writer = new StreamWriter(filePath))
//            {
//                writer.WriteLine("TravelEase Platform Analytics Report");
//                writer.WriteLine($"Generated on: {DateTime.Now}");
//                writer.WriteLine("\nSummary:");
//                writer.WriteLine($"Total Bookings: {lblTotalBookings.Text}");
//                writer.WriteLine($"Total Revenue: {lblTotalRevenue.Text}");
//                writer.WriteLine($"Active Users: {lblActiveUsers.Text}");
//                writer.WriteLine($"Completed Tours: {lblCompletedTours.Text}");
//            }
//        }

//        private void btnExportCSV_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
//                {
//                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
//                    saveFileDialog.Title = "Export Analytics to CSV";
//                    saveFileDialog.FileName = $"TravelEase_Analytics_{DateTime.Now:yyyyMMdd}.csv";

//                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
//                    {
//                        ExportToCSV(saveFileDialog.FileName);
//                        MessageBox.Show("Analytics data exported to CSV successfully!", "Export Complete",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Export Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ExportToCSV(string filePath)
//        {
//            using (StreamWriter writer = new StreamWriter(filePath))
//            {
//                // Write summary data
//                writer.WriteLine("TravelEase Platform Analytics Report");
//                writer.WriteLine($"Generated on,{DateTime.Now}");
//                writer.WriteLine("\nSummary:");
//                writer.WriteLine($"Total Bookings,{lblTotalBookings.Text}");
//                writer.WriteLine($"Total Revenue,{lblTotalRevenue.Text}");
//                writer.WriteLine($"Active Users,{lblActiveUsers.Text}");
//                writer.WriteLine($"Completed Tours,{lblCompletedTours.Text}");

//                // Export Revenue by Category
//                writer.WriteLine("\nRevenue by Category:");
//                writer.WriteLine("Category,Revenue,Percentage,Growth");
//                foreach (DataGridViewRow row in dgvRevenue.Rows)
//                {
//                    writer.WriteLine(string.Join(",",
//                        row.Cells[0].Value?.ToString() ?? "",
//                        row.Cells[1].Value?.ToString() ?? "",
//                        row.Cells[2].Value?.ToString() ?? "",
//                        row.Cells[3].Value?.ToString() ?? ""));
//                }

//                // Export Top Destinations
//                writer.WriteLine("\nTop Destinations:");
//                writer.WriteLine("Destination,Bookings,Rating");
//                foreach (DataGridViewRow row in dgvTopDestinations.Rows)
//                {
//                    writer.WriteLine(string.Join(",",
//                        row.Cells[0].Value?.ToString() ?? "",
//                        row.Cells[1].Value?.ToString() ?? "",
//                        row.Cells[2].Value?.ToString() ?? ""));
//                }
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadData(); // Reload all data
//        }
//    }
//}


using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace TravelEase.Forms
{
    public partial class AnalyticsForm : Form
    {
        // Database connection string - MUST BE REPLACED
        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        public AnalyticsForm()
        {
            InitializeComponent();
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            cmbTimeFrame.SelectedIndex = 0; // Default to "Last 30 Days"
            cmbChartType.SelectedIndex = 0; // Default to "Line Chart"
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Separate method calls to isolate potential errors
                UpdateSummaryCards();
                LoadBookingTrendsChart();
                LoadUserTrafficChart();
                LoadRevenueData();
                LoadTopDestinations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummaryCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Total Bookings in last 30 days
                string bookingsQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Total Revenue in last 30 days
                string revenueQuery = @"
                    SELECT ISNULL(SUM(TotalCost), 0) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Active Users in last 30 days
                string usersQuery = @"
                    SELECT COUNT(DISTINCT TravelerID) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Completed Tours in last 30 days
                string toursQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking 
                    WHERE Status = 'Completed' 
                    AND BookingDate >= DATEADD(day, -30, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(bookingsQuery, connection))
                    lblTotalBookings.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");

                using (SqlCommand cmd = new SqlCommand(revenueQuery, connection))
                    lblTotalRevenue.Text = Convert.ToDecimal(cmd.ExecuteScalar()).ToString("C0");

                using (SqlCommand cmd = new SqlCommand(usersQuery, connection))
                    lblActiveUsers.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");

                using (SqlCommand cmd = new SqlCommand(toursQuery, connection))
                    lblCompletedTours.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
            }
        }

        private void LoadBookingTrendsChart()
        {
            chartBookings.Series.Clear();
            chartBookings.ChartAreas[0].AxisY.Title = "Number of Bookings";
            chartBookings.Titles.Clear();
            chartBookings.Titles.Add("Booking Trends");

            var bookingSeries = new Series("Bookings")
            {
                ChartType = GetSelectedChartType(),
                Color = Color.FromArgb(11, 57, 84),
                BorderWidth = 3
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        CONVERT(VARCHAR(7), BookingDate, 120) AS BookingMonth, 
                        COUNT(*) AS BookingCount
                    FROM Booking
                    WHERE BookingDate >= DATEADD(month, -12, GETDATE())
                    GROUP BY CONVERT(VARCHAR(7), BookingDate, 120)
                    ORDER BY BookingMonth";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookingSeries.Points.AddXY(
                            reader["BookingMonth"].ToString(),
                            Convert.ToInt32(reader["BookingCount"])
                        );
                    }
                }
            }

            chartBookings.Series.Add(bookingSeries);
        }

        private void LoadUserTrafficChart()
        {
            chartUserTraffic.Series.Clear();
            chartUserTraffic.Titles.Clear();
            chartUserTraffic.Titles.Add("User Traffic Distribution");

            var trafficSeries = new Series("Traffic")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "{0}%"
            };

            // Mock data since we don't have platform tracking
            trafficSeries.Points.AddXY("Web Bookings", 45);
            trafficSeries.Points.AddXY("Mobile Bookings", 35);
            trafficSeries.Points.AddXY("Direct Bookings", 20);

            // Color each slice
            trafficSeries.Points[0].Color = Color.FromArgb(46, 139, 87);
            trafficSeries.Points[1].Color = Color.FromArgb(70, 130, 180);
            trafficSeries.Points[2].Color = Color.FromArgb(255, 127, 80);

            chartUserTraffic.Series.Add(trafficSeries);
        }

        private void LoadRevenueData()
        {
            dgvRevenue.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        TourCategory,
                        SUM(t.Price) AS CategoryRevenue,
                        ROUND(SUM(t.Price) * 100.0 / (SELECT SUM(Price) FROM Trip), 2) AS Percentage
                    FROM Trip t
                    JOIN Booking b ON t.TripID = b.TripID
                    GROUP BY t.TourCategory
                    ORDER BY CategoryRevenue DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvRevenue.Rows.Add(
                            reader["TourCategory"].ToString(),
                            Convert.ToDecimal(reader["CategoryRevenue"]).ToString("C0"),
                            reader["Percentage"].ToString() + "%",
                            "+5.2%" // Mock growth rate
                        );

                        // Color code growth
                        dgvRevenue.Rows[rowIndex].Cells["Growth"].Style.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void LoadTopDestinations()
        {
            dgvTopDestinations.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT TOP 5 
                        td.Destination, 
                        COUNT(b.BookingID) AS BookingCount,
                        ROUND(AVG(CAST(t.Sustainability_Score AS FLOAT)), 1) AS AvgRating
                    FROM TripDestination td
                    JOIN Trip t ON td.TripID = t.TripID
                    JOIN Booking b ON t.TripID = b.TripID
                    GROUP BY td.Destination
                    ORDER BY BookingCount DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvTopDestinations.Rows.Add(
                            reader["Destination"].ToString(),
                            reader["BookingCount"].ToString(),
                            reader["AvgRating"].ToString()
                        );
                    }
                }
            }
        }

        // Utility method for chart type selection
        private SeriesChartType GetSelectedChartType()
        {
            switch (cmbChartType.SelectedIndex)
            {
                case 0:
                    return SeriesChartType.Line;
                case 1:
                    return SeriesChartType.Column;
                case 2:
                    return SeriesChartType.Area;
                default:
                    return SeriesChartType.Line;
            }
        }

        // Event handlers for time frame and chart type changes
        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingTrendsChart();
        }

        // Export methods
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF Export functionality to be implemented", "Export PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.Title = "Export Analytics to CSV";
                    saveDialog.FileName = $"TravelEase_Analytics_{DateTime.Now:yyyyMMdd}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCSV(saveDialog.FileName);
                        MessageBox.Show("CSV Export completed successfully!", "Export Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                // Write summary data
                writer.WriteLine("TravelEase Platform Analytics");
                writer.WriteLine($"Generated on,{DateTime.Now}");
                writer.WriteLine($"Total Bookings,{lblTotalBookings.Text}");
                writer.WriteLine($"Total Revenue,{lblTotalRevenue.Text}");
                writer.WriteLine($"Active Users,{lblActiveUsers.Text}");
                writer.WriteLine($"Completed Tours,{lblCompletedTours.Text}");

                // Revenue by Category
                writer.WriteLine("\nRevenue by Category");
                writer.WriteLine("Category,Revenue,Percentage,Growth");
                foreach (DataGridViewRow row in dgvRevenue.Rows)
                {
                    writer.WriteLine(string.Join(",",
                        row.Cells[0].Value?.ToString() ?? "",
                        row.Cells[1].Value?.ToString() ?? "",
                        row.Cells[2].Value?.ToString() ?? "",
                        row.Cells[3].Value?.ToString() ?? ""));
                }

                // Top Destinations
                writer.WriteLine("\nTop Destinations");
                writer.WriteLine("Destination,Bookings,Rating");
                foreach (DataGridViewRow row in dgvTopDestinations.Rows)
                {
                    writer.WriteLine(string.Join(",",
                        row.Cells[0].Value?.ToString() ?? "",
                        row.Cells[1].Value?.ToString() ?? "",
                        row.Cells[2].Value?.ToString() ?? ""));
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}