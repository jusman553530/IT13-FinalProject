using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class RevenueReportsControl : UserControl
    {
        private DateTime _from;
        private DateTime _to;
        private string _roomTypeFilter = "All";

        public RevenueReportsControl()
        {
            InitializeComponent();
            WireEvents();
            LoadPresets();
            LoadRoomTypeFilter();
            ApplyPreset("This Month");
        }

        public void ReloadData()
        {
            RunReport();
        }

        private void WireEvents()
        {
            cmbPreset.SelectedIndexChanged += (s, e) =>
            {
                if (cmbPreset.SelectedItem is string preset && preset != "Custom")
                    ApplyPreset(preset);
            };

            btnApply.Click += (s, e) => RunReport();
            btnRefresh.Click += (s, e) => RunReport();
            btnExport.Click += BtnExport_Click;
        }

        private void LoadPresets()
        {
            cmbPreset.Items.Clear();
            cmbPreset.Items.AddRange(new object[]
            {
                "This Month",
                "Last 30 Days",
                "This Quarter",
                "This Year",
                "Custom"
            });
        }

        private void LoadRoomTypeFilter()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var types = db.Rooms
                        .Select(r => r.RoomType)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();

                    types.Insert(0, "All");

                    cmbRoomType.DataSource = types;
                    cmbRoomType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load room types.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // PRESET RANGES
        // =========================================================
        private void ApplyPreset(string preset)
        {
            DateTime today = DateTime.Today;

            switch (preset)
            {
                case "This Month":
                    _from = new DateTime(today.Year, today.Month, 1);
                    _to = _from.AddMonths(1).AddDays(-1);
                    break;

                case "Last 30 Days":
                    _from = today.AddDays(-29);
                    _to = today;
                    break;

                case "This Quarter":
                    int q = ((today.Month - 1) / 3) + 1;
                    int qStartMonth = ((q - 1) * 3) + 1;
                    _from = new DateTime(today.Year, qStartMonth, 1);
                    _to = _from.AddMonths(3).AddDays(-1);
                    break;

                case "This Year":
                    _from = new DateTime(today.Year, 1, 1);
                    _to = new DateTime(today.Year, 12, 31);
                    break;

                default: // Custom
                    _from = dtpFrom.Value.Date;
                    _to = dtpTo.Value.Date;
                    break;
            }

            dtpFrom.Value = _from;
            dtpTo.Value = _to;

            lblRange.Text = _from.ToString("MMM dd, yyyy") +
                            "  –  " +
                            _to.ToString("MMM dd, yyyy");

            RunReport();
        }

        // =========================================================
        // RUN REPORT
        // =========================================================
        private void RunReport()
        {
            try
            {
                _from = dtpFrom.Value.Date;
                _to = dtpTo.Value.Date;

                _roomTypeFilter = cmbRoomType.SelectedItem?.ToString() ?? "All";

                if (_to < _from)
                {
                    lblStatus.Text = "To date cannot be before From date.";
                    return;
                }

                lblRange.Text = _from.ToString("MMM dd, yyyy") +
                                "  –  " +
                                _to.ToString("MMM dd, yyyy");

                using (var db = new HotelDbContext())
                {
                    // ------------------------------------------
                    // Base filtered reservations
                    // ------------------------------------------
                    var query =
                        from r in db.Reservations
                        join room in db.Rooms on r.RoomId equals room.RoomId
                        where r.Status != "Cancelled"
                              && r.CheckInDate >= _from
                              && r.CheckInDate <= _to
                        select new
                        {
                            Reservation = r,
                            RoomType = room.RoomType
                        };

                    if (_roomTypeFilter != "All")
                    {
                        query = query.Where(x => x.RoomType == _roomTypeFilter);
                    }

                    var rows = query.ToList();

                    // ------------------------------------------
                    // Expected revenue + nights
                    // ------------------------------------------
                    decimal expectedRevenue = 0m;
                    int nightsSold = 0;
                    int bookings = rows.Count;

                    foreach (var x in rows)
                    {
                        int nights = (x.Reservation.CheckOutDate.Date -
                                      x.Reservation.CheckInDate.Date).Days;
                        if (nights < 1) nights = 1;

                        expectedRevenue += x.Reservation.TotalAmount;
                        nightsSold += nights;
                    }

                    // ------------------------------------------
                    // Realized revenue in period (from Payments)
                    // ------------------------------------------
                    decimal realizedRevenue = db.Payments
                        .Where(p => p.PaidAt >= _from && p.PaidAt <= _to.AddDays(1))
                        .Sum(p => (decimal?)p.Amount) ?? 0m;

                    // ------------------------------------------
                    // Outstanding (snapshot, not period-bound)
                    // ------------------------------------------
                    var outstandingList = db.Reservations
                        .Where(r => r.Status != "Cancelled" && r.Status != "Refunded")
                        .Select(r => new
                        {
                            r.ReservationId,
                            r.TotalAmount,
                            r.DownPayment
                        })
                        .ToList();

                    var allPayments = db.Payments
                        .Select(p => new { p.ReservationId, p.Amount })
                        .ToList();

                    decimal outstanding = 0m;

                    foreach (var r in outstandingList)
                    {
                        decimal paid = r.DownPayment;
                        paid += allPayments
                            .Where(p => p.ReservationId == r.ReservationId)
                            .Sum(p => p.Amount);

                        decimal owed = r.TotalAmount - paid;
                        if (owed > 0) outstanding += owed;
                    }

                    // ------------------------------------------
                    // ADR + Occupancy
                    // ------------------------------------------
                    int totalRooms = db.Rooms.Count();
                    int daysInPeriod = (_to - _from).Days + 1;

                    decimal adr = nightsSold > 0
                        ? expectedRevenue / nightsSold
                        : 0m;

                    double occupancy = (totalRooms > 0 && daysInPeriod > 0)
                        ? ((double)nightsSold /
                           ((double)totalRooms * daysInPeriod)) * 100.0
                        : 0.0;

                    // ------------------------------------------
                    // KPI labels
                    // ------------------------------------------
                    lblKpi1Value.Text = "₱" + expectedRevenue.ToString("N2");
                    lblKpi2Value.Text = "₱" + realizedRevenue.ToString("N2");
                    lblKpi3Value.Text = "₱" + outstanding.ToString("N2");
                    lblKpi4Value.Text = "₱" + adr.ToString("N2");
                    lblKpi5Value.Text = occupancy.ToString("N1") + "%";

                    // ------------------------------------------
                    // Revenue by Room Type
                    // ------------------------------------------
                    var byRoomType = rows
                        .GroupBy(x => x.RoomType)
                        .Select(g => new
                        {
                            RoomType = g.Key,
                            Bookings = g.Count(),
                            Nights = g.Sum(x =>
                            {
                                int n = (x.Reservation.CheckOutDate.Date -
                                         x.Reservation.CheckInDate.Date).Days;
                                return n < 1 ? 1 : n;
                            }),
                            Expected = g.Sum(x => x.Reservation.TotalAmount)
                        })
                        .OrderByDescending(x => x.Expected)
                        .ToList();

                    decimal grandTotal = byRoomType.Sum(x => x.Expected);

                    var byRoomTypeRows = byRoomType
                        .Select(x => new
                        {
                            x.RoomType,
                            x.Bookings,
                            x.Nights,
                            x.Expected,
                            Share = grandTotal > 0
                                ? (double)(x.Expected / grandTotal) * 100.0
                                : 0.0
                        })
                        .ToList();

                    dgvByRoomType.DataSource = byRoomTypeRows;
                    ConfigureByRoomTypeColumns();

                    // ------------------------------------------
                    // Payment Status Breakdown
                    // ------------------------------------------
                    var paymentBreakdown = db.Reservations
                        .Where(r => r.Status != "Cancelled")
                        .GroupBy(r => r.PaymentStatus)
                        .Select(g => new
                        {
                            Status = g.Key,
                            Count = g.Count(),
                            Amount = g.Sum(r => r.TotalAmount)
                        })
                        .ToList();

                    dgvPaymentStatus.DataSource = paymentBreakdown;
                    ConfigurePaymentStatusColumns();

                    // ------------------------------------------
                    // Top Guests
                    // ------------------------------------------
                    var topGuests =
                        (from r in db.Reservations
                         join c in db.Customers on r.CustomerId equals c.CustomerId
                         where r.Status != "Cancelled"
                         group r by new { c.CustomerId, c.FirstName, c.LastName, c.ContactNumber }
                         into g
                         select new
                         {
                             Guest = g.Key.FirstName + " " + g.Key.LastName,
                             Contact = g.Key.ContactNumber,
                             Bookings = g.Count(),
                             TotalSpent = g.Sum(r => r.TotalAmount)
                         })
                        .OrderByDescending(x => x.TotalSpent)
                        .Take(10)
                        .ToList();

                    dgvTopGuests.DataSource = topGuests;
                    ConfigureTopGuestsColumns();

                    lblStatus.Text = "Report generated: " +
                        bookings + " booking(s), " +
                        nightsSold + " night(s) sold.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to generate report.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureByRoomTypeColumns()
        {
            if (dgvByRoomType.Columns.Count == 0) return;
            dgvByRoomType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvByRoomType, "RoomType", "Room Type");
            SetHeader(dgvByRoomType, "Bookings", "Bookings");
            SetHeader(dgvByRoomType, "Nights", "Nights");
            SetHeader(dgvByRoomType, "Expected", "Expected");
            SetHeader(dgvByRoomType, "Share", "Share %");

            SetWeight(dgvByRoomType, "RoomType", 120);
            SetWeight(dgvByRoomType, "Bookings", 70);
            SetWeight(dgvByRoomType, "Nights", 60);
            SetWeight(dgvByRoomType, "Expected", 90);
            SetWeight(dgvByRoomType, "Share", 70);

            if (dgvByRoomType.Columns.Contains("Expected"))
                dgvByRoomType.Columns["Expected"].DefaultCellStyle.Format = "N2";

            if (dgvByRoomType.Columns.Contains("Share"))
                dgvByRoomType.Columns["Share"].DefaultCellStyle.Format = "N1";
        }

        private void ConfigurePaymentStatusColumns()
        {
            if (dgvPaymentStatus.Columns.Count == 0) return;
            dgvPaymentStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvPaymentStatus, "Status", "Status");
            SetHeader(dgvPaymentStatus, "Count", "Bookings");
            SetHeader(dgvPaymentStatus, "Amount", "Total Amount");

            SetWeight(dgvPaymentStatus, "Status", 100);
            SetWeight(dgvPaymentStatus, "Count", 80);
            SetWeight(dgvPaymentStatus, "Amount", 140);

            if (dgvPaymentStatus.Columns.Contains("Amount"))
                dgvPaymentStatus.Columns["Amount"].DefaultCellStyle.Format = "N2";
        }

        private void ConfigureTopGuestsColumns()
        {
            if (dgvTopGuests.Columns.Count == 0) return;
            dgvTopGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvTopGuests, "Guest", "Guest");
            SetHeader(dgvTopGuests, "Contact", "Contact");
            SetHeader(dgvTopGuests, "Bookings", "Bookings");
            SetHeader(dgvTopGuests, "TotalSpent", "Total Spent");

            SetWeight(dgvTopGuests, "Guest", 200);
            SetWeight(dgvTopGuests, "Contact", 140);
            SetWeight(dgvTopGuests, "Bookings", 90);
            SetWeight(dgvTopGuests, "TotalSpent", 140);

            if (dgvTopGuests.Columns.Contains("TotalSpent"))
                dgvTopGuests.Columns["TotalSpent"].DefaultCellStyle.Format = "N2";
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

        // =========================================================
        // EXPORT CSV
        // =========================================================
        private void BtnExport_Click(object? sender, EventArgs e)
        {
            try
            {
                string folder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "HotelCRM");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string filename = "revenue_" +
                    _from.ToString("yyyyMMdd") + "_" +
                    _to.ToString("yyyyMMdd") + "_" +
                    DateTime.Now.ToString("HHmmss") + ".csv";

                string fullPath = Path.Combine(folder, filename);

                var sb = new StringBuilder();

                sb.AppendLine("Hotel CRM — Revenue Report");
                sb.AppendLine("Range," +
                    _from.ToString("yyyy-MM-dd") + " to " +
                    _to.ToString("yyyy-MM-dd"));
                sb.AppendLine("Room Type Filter," + _roomTypeFilter);
                sb.AppendLine();

                sb.AppendLine("KPI");
                sb.AppendLine("Expected Revenue," + lblKpi1Value.Text);
                sb.AppendLine("Realized Revenue," + lblKpi2Value.Text);
                sb.AppendLine("Outstanding," + lblKpi3Value.Text);
                sb.AppendLine("ADR," + lblKpi4Value.Text);
                sb.AppendLine("Occupancy," + lblKpi5Value.Text);
                sb.AppendLine();

                sb.AppendLine("Revenue by Room Type");
                sb.AppendLine("Room Type,Bookings,Nights,Expected,Share %");
                foreach (DataGridViewRow row in dgvByRoomType.Rows)
                {
                    if (row.IsNewRow) continue;
                    sb.AppendLine(string.Join(",",
                        Csv(row.Cells["RoomType"].Value),
                        Csv(row.Cells["Bookings"].Value),
                        Csv(row.Cells["Nights"].Value),
                        Csv(row.Cells["Expected"].Value),
                        Csv(row.Cells["Share"].Value)));
                }
                sb.AppendLine();

                sb.AppendLine("Payment Status Breakdown");
                sb.AppendLine("Status,Bookings,Amount");
                foreach (DataGridViewRow row in dgvPaymentStatus.Rows)
                {
                    if (row.IsNewRow) continue;
                    sb.AppendLine(string.Join(",",
                        Csv(row.Cells["Status"].Value),
                        Csv(row.Cells["Count"].Value),
                        Csv(row.Cells["Amount"].Value)));
                }
                sb.AppendLine();

                sb.AppendLine("Top Guests by Revenue");
                sb.AppendLine("Guest,Contact,Bookings,Total Spent");
                foreach (DataGridViewRow row in dgvTopGuests.Rows)
                {
                    if (row.IsNewRow) continue;
                    sb.AppendLine(string.Join(",",
                        Csv(row.Cells["Guest"].Value),
                        Csv(row.Cells["Contact"].Value),
                        Csv(row.Cells["Bookings"].Value),
                        Csv(row.Cells["TotalSpent"].Value)));
                }

                File.WriteAllText(fullPath, sb.ToString(), Encoding.UTF8);

                lblStatus.Text = "Exported to " + fullPath;

                MessageBox.Show(
                    "Report exported successfully.\n\n" + fullPath,
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to export report.\n\n" + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string Csv(object? value)
        {
            if (value == null) return "";

            string s = value.ToString() ?? "";

            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
            {
                s = "\"" + s.Replace("\"", "\"\"") + "\"";
            }

            return s;
        }
    }
}