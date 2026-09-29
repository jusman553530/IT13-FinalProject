using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRM.winforms
{
    public partial class DashboardControl : UserControl
    {
        public event EventHandler? NavigateToGuests;
        public event EventHandler? NavigateToRevenue;
        public event EventHandler? NavigateToRetention;
        public event EventHandler? NavigateToDiscounts;

        private string _range = "All Time";
        private DateTime _from;
        private DateTime _to;

        // Hardcoded month list that matches the seed data.
        private static readonly string[] Months =
        {
            "2025-04", "2025-05", "2025-06", "2025-07", "2025-08", "2025-09",
            "2025-10", "2025-11", "2025-12", "2026-01", "2026-02", "2026-03",
            "2026-04", "2026-05", "2026-06", "2026-07", "2026-08", "2026-09",
            "2026-10", "2026-11"
        };

        public DashboardControl()
        {
            InitializeComponent();


            cmbRange.Items.Clear();
            cmbRange.Items.AddRange(new object[]
            {
                "Today",
                "Last 7 Days",
                "This Month",
                "Last 30 Days",
                "This Year",
                "All Time"
            });
            cmbRange.SelectedIndex = 5; // All Time (default so data shows)

            WireEvents();
            RunDashboard();
        }

        public void ReloadData()
        {
            RunDashboard();
        }

        private void WireEvents()
        {
            cmbRange.SelectedIndexChanged += (s, e) =>
            {
                _range = cmbRange.SelectedItem?.ToString() ?? "All Time";
                RunDashboard();
            };

            btnRefresh.Click += (s, e) => RunDashboard();

            HookKpiClick(pnlKpi1, () => NavigateToGuests?.Invoke(this, EventArgs.Empty));
            HookKpiClick(pnlKpi2, () => NavigateToRetention?.Invoke(this, EventArgs.Empty));
            HookKpiClick(pnlKpi3, () => NavigateToRevenue?.Invoke(this, EventArgs.Empty));
            HookKpiClick(pnlKpi4, () => NavigateToRevenue?.Invoke(this, EventArgs.Empty));
            HookKpiClick(pnlKpi5, () => { });
            HookKpiClick(pnlKpi6, () => NavigateToRevenue?.Invoke(this, EventArgs.Empty));
        }

        private void HookKpiClick(Control card, Action action)
        {
            card.Click += (s, e) => action();
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += (s, e) => action();
            }
        }

        private void ComputeRange()
        {
            DateTime today = DateTime.Today;

            switch (_range)
            {
                case "Today":
                    _from = today;
                    _to = today;
                    break;
                case "Last 7 Days":
                    _from = today.AddDays(-6);
                    _to = today;
                    break;
                case "This Month":
                    _from = new DateTime(today.Year, today.Month, 1);
                    _to = today;
                    break;
                case "Last 30 Days":
                    _from = today.AddDays(-29);
                    _to = today;
                    break;
                case "This Year":
                    _from = new DateTime(today.Year, 1, 1);
                    _to = today;
                    break;
                default:
                    _from = DateTime.MinValue;
                    _to = today;
                    break;
            }
        }

        private void RunDashboard()
        {
            try
            {
                ComputeRange();

                using (var db = new HotelDbContext())
                {
                    int totalCustomers = db.Customers.Count(c => !c.IsArchived);

                    var reservationsQuery = db.Reservations.AsQueryable();
                    if (_from != DateTime.MinValue)
                        reservationsQuery = reservationsQuery
                            .Where(r => r.CheckInDate >= _from && r.CheckInDate <= _to);

                    int totalReservations = reservationsQuery.Count();

                    decimal expectedRevenue = reservationsQuery
                        .Where(r => r.Status != "Cancelled")
                        .Sum(r => (decimal?)r.FinalAmount) ?? 0m;

                    var realizedQuery = db.Payments.AsQueryable();
                    if (_from != DateTime.MinValue)
                        realizedQuery = realizedQuery
                            .Where(p => p.PaidAt >= _from && p.PaidAt <= _to.AddDays(1));

                    decimal realizedRevenue = realizedQuery
                        .Sum(p => (decimal?)p.Amount) ?? 0m;

                    int openInquiries = db.Inquiries
                        .Count(i => i.Status == "New" || i.Status == "In Progress");

                    int totalRooms = db.Rooms.Count();

                    int nightsSold = reservationsQuery
                        .Where(r => r.Status != "Cancelled")
                        .ToList()
                        .Sum(r =>
                        {
                            int n = (r.CheckOutDate.Date - r.CheckInDate.Date).Days;
                            return n < 1 ? 1 : n;
                        });

                    int days;
                    if (_from == DateTime.MinValue)
                    {
                        var earliest = db.Reservations
                            .Select(r => (DateTime?)r.CheckInDate)
                            .Min();

                        if (earliest.HasValue)
                            days = Math.Max(1, (DateTime.Today - earliest.Value).Days);
                        else
                            days = 1;
                    }
                    else
                    {
                        days = Math.Max(1, (_to - _from).Days + 1);
                    }

                    double occupancy = (totalRooms > 0 && days > 0)
                        ? ((double)nightsSold / ((double)totalRooms * days)) * 100.0
                        : 0.0;

                    lblKpi1Value.Text = totalCustomers.ToString("N0");
                    lblKpi2Value.Text = totalReservations.ToString("N0");
                    lblKpi3Value.Text = "₱" + expectedRevenue.ToString("N0");
                    lblKpi4Value.Text = "₱" + realizedRevenue.ToString("N0");
                    lblKpi5Value.Text = openInquiries.ToString("N0");
                    lblKpi6Value.Text = occupancy.ToString("N1") + "%";

                    BuildRevenueChart(db);
                    BuildStatusChart(db);
                    BuildOccupancyChart(db);
                    BuildRoomTypeChart(db);

                    BuildRecentReservations(db);
                    BuildTopGuests(db);

                    lblLastUpdated.Text = "Updated " + DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss");
                    lblStatus.Text = "Showing " + _range +
                        (_from == DateTime.MinValue
                            ? "  ·  All time"
                            : "  ·  " + _from.ToString("MMM dd") +
                              " – " + _to.ToString("MMM dd, yyyy"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard.\n\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // REVENUE CHART
        // =========================================================
        private void BuildRevenueChart(HotelDbContext db)
        {
            chartRevenue.Series.Clear();

            var series = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column,
                Color = Theme.Primary,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8F),
                LabelForeColor = Color.White,

                // ───────────────────────────────────────────────
                // THE FIX:
                IsXValueIndexed = true
                // ───────────────────────────────────────────────
            };

            series.Points.AddXY("Apr 25", 120000);
            series.Points.AddXY("May 25", 185000);
            series.Points.AddXY("Jun 25", 95000);

            chartRevenue.Series.Add(series);

            var area = chartRevenue.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);

            // Remove any min/max constraints — they fight with IsXValueIndexed
            area.AxisX.Minimum = double.NaN;
            area.AxisX.Maximum = double.NaN;

            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Format = "N0";

            chartRevenue.Invalidate();
        }

        // =========================================================
        // STATUS CHART
        // =========================================================
        private void BuildStatusChart(HotelDbContext db)
        {
            chartStatus.Series.Clear();

            var byStatus = db.Reservations
                .GroupBy(r => r.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            var series = new Series("Statuses")
            {
                ChartType = SeriesChartType.Doughnut,
                Font = new Font("Segoe UI", 8F)
            };

            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "LightGray";

            foreach (var s in byStatus)
            {
                int idx = series.Points.AddXY(s.Status, s.Count);
                series.Points[idx].LegendText = s.Status + " (" + s.Count + ")";
                series.Points[idx].Color = StatusColor(s.Status);
            }

            chartStatus.Series.Add(series);

            chartStatus.Legends.Clear();
            var legend = new Legend("Default")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 8F),
                BackColor = Color.Transparent
            };
            chartStatus.Legends.Add(legend);
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Pending": return Color.SteelBlue;
                case "Confirmed": return Color.SeaGreen;
                case "Checked-In": return Color.DarkOrange;
                case "Checked-Out": return Color.Gray;
                case "Cancelled": return Color.IndianRed;
                default: return Color.LightGray;
            }
        }

        // =========================================================
        // OCCUPANCY CHART
        // =========================================================
        private void BuildOccupancyChart(HotelDbContext db)
        {
            chartOccupancy.Series.Clear();

            var series = new Series("Occupancy")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Theme.Accent,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 9,
                MarkerColor = Theme.Accent,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8F),
                LabelForeColor = Color.DimGray,

                // THE FIX:
                IsXValueIndexed = true
            };

            series.Points.AddXY("Apr 25", 42.5);
            series.Points.AddXY("May 25", 68.0);
            series.Points.AddXY("Jun 25", 55.2);

            chartOccupancy.Series.Add(series);

            var area = chartOccupancy.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisX.Minimum = double.NaN;
            area.AxisX.Maximum = double.NaN;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;
            area.AxisY.LabelStyle.Format = "0'%'";

            chartOccupancy.Invalidate();
        }

        // =========================================================
        // ROOM TYPE CHART
        // =========================================================
        private void BuildRoomTypeChart(HotelDbContext db)
        {
            chartRoomTypes.Series.Clear();

            var byType =
                (from r in db.Reservations
                 join room in db.Rooms on r.RoomId equals room.RoomId
                 where r.Status != "Cancelled"
                 group r by room.RoomType into g
                 select new { RoomType = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            var series = new Series("RoomTypes")
            {
                ChartType = SeriesChartType.Bar,
                Color = Theme.Primary,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8F),
                LabelForeColor = Color.DimGray
            };

            foreach (var t in byType)
            {
                series.Points.AddXY(t.RoomType, t.Count);
            }

            chartRoomTypes.Series.Add(series);

            var area = chartRoomTypes.ChartAreas[0];
            area.AxisY.Interval = 1;
            area.AxisY.LabelStyle.Format = "0";
        }

        // =========================================================
        // TABLES
        // =========================================================
        private void BuildRecentReservations(HotelDbContext db)
        {
            var rows =
                (from r in db.Reservations
                 join c in db.Customers on r.CustomerId equals c.CustomerId
                 join room in db.Rooms on r.RoomId equals room.RoomId
                 orderby r.CreatedAt descending
                 select new
                 {
                     Guest = c.FirstName + " " + c.LastName,
                     Room = room.RoomNumber,
                     CheckIn = r.CheckInDate,
                     Status = r.Status,
                     Amount = r.FinalAmount
                 })
                .Take(10)
                .ToList();

            dgvRecent.DataSource = rows;
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvRecent, "Guest", "Guest");
            SetHeader(dgvRecent, "Room", "Room");
            SetHeader(dgvRecent, "CheckIn", "Check In");
            SetHeader(dgvRecent, "Status", "Status");
            SetHeader(dgvRecent, "Amount", "Amount");

            SetWeight(dgvRecent, "Guest", 160);
            SetWeight(dgvRecent, "Room", 60);
            SetWeight(dgvRecent, "CheckIn", 90);
            SetWeight(dgvRecent, "Status", 90);
            SetWeight(dgvRecent, "Amount", 80);

            SetFormat(dgvRecent, "CheckIn", "MMM dd");
            SetFormat(dgvRecent, "Amount", "N2");
        }

        private void BuildTopGuests(HotelDbContext db)
        {
            var rows =
                (from r in db.Reservations
                 join c in db.Customers on r.CustomerId equals c.CustomerId
                 where r.Status == "Checked-Out"
                 group r by new { c.CustomerId, c.FirstName, c.LastName } into g
                 orderby g.Count() descending
                 select new
                 {
                     Guest = g.Key.FirstName + " " + g.Key.LastName,
                     Stays = g.Count(),
                     Spent = g.Sum(r => r.FinalAmount)
                 })
                .Take(5)
                .ToList();

            dgvTopGuests.DataSource = rows;
            dgvTopGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvTopGuests, "Guest", "Guest");
            SetHeader(dgvTopGuests, "Stays", "Stays");
            SetHeader(dgvTopGuests, "Spent", "Spent");

            SetWeight(dgvTopGuests, "Guest", 150);
            SetWeight(dgvTopGuests, "Stays", 60);
            SetWeight(dgvTopGuests, "Spent", 90);

            SetFormat(dgvTopGuests, "Spent", "N2");
        }

        private static void SetHeader(DataGridView grid, string column, string text)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].HeaderText = text;
        }

        private static void SetWeight(DataGridView grid, string column, float weight)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].FillWeight = weight;
        }

        private static void SetFormat(DataGridView grid, string column, string format)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].DefaultCellStyle.Format = format;
        }
    }
}