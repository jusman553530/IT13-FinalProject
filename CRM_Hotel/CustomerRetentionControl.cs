using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class CustomerRetentionControl : UserControl
    {
        private DateTime _windowFrom;
        private int _churnDays = 180;

        public CustomerRetentionControl()
        {
            InitializeComponent();
            WireEvents();
            LoadFilterOptions();

            cmbWindow.SelectedIndex = 3;    // Last 365 days
            cmbChurn.SelectedIndex = 3;     // 180 days

            RunReport();
        }

        public void ReloadData()
        {
            RunReport();
        }

        private void WireEvents()
        {
            btnApply.Click += (s, e) => RunReport();
            btnRefresh.Click += (s, e) => RunReport();
            btnExport.Click += BtnExport_Click;
            btnViewHistory.Click += (s, e) => ViewHistoryFromCurrent();
        }

        private void LoadFilterOptions()
        {
            cmbWindow.Items.Clear();
            cmbWindow.Items.AddRange(new object[]
            {
                "Last 30 Days",
                "Last 90 Days",
                "Last 180 Days",
                "Last 365 Days",
                "All Time"
            });

            cmbChurn.Items.Clear();
            cmbChurn.Items.AddRange(new object[]
            {
                "30 days",
                "60 days",
                "90 days",
                "180 days",
                "365 days"
            });
        }

        // =========================================================
        // RUN REPORT
        // =========================================================
        private void RunReport()
        {
            try
            {
                DateTime today = DateTime.Today;

                switch (cmbWindow.SelectedIndex)
                {
                    case 0: _windowFrom = today.AddDays(-29); break;
                    case 1: _windowFrom = today.AddDays(-89); break;
                    case 2: _windowFrom = today.AddDays(-179); break;
                    case 3: _windowFrom = today.AddDays(-364); break;
                    default: _windowFrom = DateTime.MinValue; break;
                }

                switch (cmbChurn.SelectedIndex)
                {
                    case 0: _churnDays = 30; break;
                    case 1: _churnDays = 60; break;
                    case 2: _churnDays = 90; break;
                    case 3: _churnDays = 180; break;
                    case 4: _churnDays = 365; break;
                }

                lblRange.Text = _windowFrom == DateTime.MinValue
                    ? "All time  ·  Churn > " + _churnDays + " days"
                    : _windowFrom.ToString("MMM dd, yyyy") +
                      "  –  " + today.ToString("MMM dd, yyyy") +
                      "  ·  Churn > " + _churnDays + " days";

                using (var db = new HotelDbContext())
                {
                    var completedStays = db.Reservations
                        .Where(r => r.Status == "Checked-Out")
                        .Select(r => new
                        {
                            r.ReservationId,
                            r.CustomerId,
                            r.CheckInDate,
                            r.CheckOutDate,
                            r.TotalAmount
                        })
                        .ToList();

                    var customers = db.Customers
                        .Select(c => new
                        {
                            c.CustomerId,
                            c.FirstName,
                            c.MiddleName,
                            c.LastName,
                            c.ContactNumber,
                            c.Email,
                            c.IsArchived
                        })
                        .ToList();

                    // Aggregate per customer
                    var perCustomer = completedStays
                        .GroupBy(r => r.CustomerId)
                        .Select(g => new
                        {
                            CustomerId = g.Key,
                            Stays = g.Count(),
                            Nights = g.Sum(r =>
                                (r.CheckOutDate.Date - r.CheckInDate.Date).Days < 1
                                    ? 1
                                    : (r.CheckOutDate.Date - r.CheckInDate.Date).Days),
                            Spend = g.Sum(r => r.TotalAmount),
                            LastVisit = g.Max(r => r.CheckOutDate),
                            FirstVisit = g.Min(r => r.CheckInDate)
                        })
                        .ToList();

                    // --------------------------------------------
                    // KPI cards (all-time, not windowed)
                    // --------------------------------------------
                    int totalGuests = perCustomer.Count;
                    int repeatGuests = perCustomer.Count(x => x.Stays > 1);
                    double returnRate = totalGuests > 0
                        ? ((double)repeatGuests / totalGuests) * 100.0
                        : 0.0;
                    double avgVisits = totalGuests > 0
                        ? (double)perCustomer.Sum(x => x.Stays) / totalGuests
                        : 0.0;
                    decimal avgSpend = totalGuests > 0
                        ? perCustomer.Sum(x => x.Spend) / totalGuests
                        : 0m;

                    var activeGuests = perCustomer
                        .Where(x => (today - x.LastVisit.Date).TotalDays <= 365)
                        .ToList();

                    double avgDaysSince = activeGuests.Count > 0
                        ? activeGuests.Average(x =>
                            (today - x.LastVisit.Date).TotalDays)
                        : 0.0;

                    lblKpi1Value.Text = repeatGuests.ToString();
                    lblKpi2Value.Text = returnRate.ToString("N1") + "%";
                    lblKpi3Value.Text = avgVisits.ToString("N2");
                    lblKpi4Value.Text = "₱" + avgSpend.ToString("N2");
                    lblKpi5Value.Text = avgDaysSince.ToString("N0") + " d";

                    // --------------------------------------------
                    // Merge with customer names + tier
                    // --------------------------------------------
                    var merged = perCustomer
                        .Join(customers,
                              p => p.CustomerId,
                              c => c.CustomerId,
                              (p, c) => new
                              {
                                  p.CustomerId,
                                  Name = c.FirstName + " " +
                                         (c.MiddleName == null ? "" : c.MiddleName + " ") +
                                         c.LastName,
                                  c.ContactNumber,
                                  c.Email,
                                  p.Stays,
                                  p.Nights,
                                  p.Spend,
                                  p.LastVisit,
                                  Tier = TierFor(p.Stays),
                                  DaysSince = (int)(today - p.LastVisit.Date).TotalDays
                              })
                        .ToList();

                    // --------------------------------------------
                    // Filter by window for tables
                    // --------------------------------------------
                    var windowed = _windowFrom == DateTime.MinValue
                        ? merged
                        : merged.Where(x => x.LastVisit.Date >= _windowFrom).ToList();

                    // --------------------------------------------
                    // Top Returning Guests
                    // --------------------------------------------
                    var topReturning = windowed
                        .Where(x => x.Stays > 1)
                        .OrderByDescending(x => x.Stays)
                        .ThenByDescending(x => x.Spend)
                        .Take(20)
                        .Select(x => new
                        {
                            x.CustomerId,
                            Guest = x.Name,
                            Contact = x.ContactNumber,
                            x.Tier,
                            x.Stays,
                            x.Nights,
                            x.Spend,
                            LastVisit = x.LastVisit,
                            DaysSince = x.DaysSince
                        })
                        .ToList();

                    dgvTopReturning.DataSource = topReturning;
                    ConfigureTopReturningColumns();

                    // --------------------------------------------
                    // Inactive (churn risk)
                    // --------------------------------------------
                    var inactive = merged
                        .Where(x => x.DaysSince > _churnDays)
                        .OrderByDescending(x => x.Spend)
                        .Take(20)
                        .Select(x => new
                        {
                            x.CustomerId,
                            Guest = x.Name,
                            Contact = x.ContactNumber,
                            x.Tier,
                            x.Stays,
                            x.Spend,
                            LastVisit = x.LastVisit,
                            DaysSince = x.DaysSince
                        })
                        .ToList();

                    dgvInactive.DataSource = inactive;
                    ConfigureInactiveColumns();

                    lblInactiveHeading.Text = "Inactive Guests — Win-Back List (" +
                        inactive.Count + " shown, churn > " + _churnDays + " days)";

                    // --------------------------------------------
                    // One-Time Guests
                    // --------------------------------------------
                    var oneTime = windowed
                        .Where(x => x.Stays == 1)
                        .OrderByDescending(x => x.LastVisit)
                        .Take(20)
                        .Select(x => new
                        {
                            x.CustomerId,
                            Guest = x.Name,
                            Contact = x.ContactNumber,
                            x.Stays,
                            x.Spend,
                            LastVisit = x.LastVisit,
                            DaysSince = x.DaysSince
                        })
                        .ToList();

                    dgvOneTime.DataSource = oneTime;
                    ConfigureOneTimeColumns();

                    lblStatus.Text = "Report ready — " +
                        merged.Count + " guest(s), " +
                        repeatGuests + " repeat, " +
                        inactive.Count + " at churn risk.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to generate retention report.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string TierFor(int stays)
        {
            if (stays >= 10) return "Platinum";
            if (stays >= 5) return "Gold";
            if (stays >= 3) return "Silver";
            return "Bronze";
        }

        private void ConfigureTopReturningColumns()
        {
            if (dgvTopReturning.Columns.Count == 0) return;
            dgvTopReturning.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvTopReturning, "CustomerId", "ID");
            SetHeader(dgvTopReturning, "Guest", "Guest");
            SetHeader(dgvTopReturning, "Contact", "Contact");
            SetHeader(dgvTopReturning, "Tier", "Tier");
            SetHeader(dgvTopReturning, "Stays", "Stays");
            SetHeader(dgvTopReturning, "Nights", "Nights");
            SetHeader(dgvTopReturning, "Spend", "Spend");
            SetHeader(dgvTopReturning, "LastVisit", "Last Visit");
            SetHeader(dgvTopReturning, "DaysSince", "Days Ago");

            HideIfPresent(dgvTopReturning, "CustomerId");

            SetWeight(dgvTopReturning, "Guest", 180);
            SetWeight(dgvTopReturning, "Contact", 120);
            SetWeight(dgvTopReturning, "Tier", 80);
            SetWeight(dgvTopReturning, "Stays", 60);
            SetWeight(dgvTopReturning, "Nights", 60);
            SetWeight(dgvTopReturning, "Spend", 90);
            SetWeight(dgvTopReturning, "LastVisit", 100);
            SetWeight(dgvTopReturning, "DaysSince", 70);

            SetFormat(dgvTopReturning, "Spend", "N2");
            SetFormat(dgvTopReturning, "LastVisit", "MMM dd, yyyy");

            dgvTopReturning.CellFormatting -= TierFormatter;
            dgvTopReturning.CellFormatting += TierFormatter;
        }

        private void ConfigureInactiveColumns()
        {
            if (dgvInactive.Columns.Count == 0) return;
            dgvInactive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvInactive, "CustomerId", "ID");
            SetHeader(dgvInactive, "Guest", "Guest");
            SetHeader(dgvInactive, "Contact", "Contact");
            SetHeader(dgvInactive, "Tier", "Tier");
            SetHeader(dgvInactive, "Stays", "Stays");
            SetHeader(dgvInactive, "Spend", "Spend");
            SetHeader(dgvInactive, "LastVisit", "Last Visit");
            SetHeader(dgvInactive, "DaysSince", "Days Ago");

            HideIfPresent(dgvInactive, "CustomerId");

            SetWeight(dgvInactive, "Guest", 200);
            SetWeight(dgvInactive, "Contact", 140);
            SetWeight(dgvInactive, "Tier", 80);
            SetWeight(dgvInactive, "Stays", 60);
            SetWeight(dgvInactive, "Spend", 100);
            SetWeight(dgvInactive, "LastVisit", 110);
            SetWeight(dgvInactive, "DaysSince", 80);

            SetFormat(dgvInactive, "Spend", "N2");
            SetFormat(dgvInactive, "LastVisit", "MMM dd, yyyy");

            dgvInactive.CellFormatting -= TierFormatter;
            dgvInactive.CellFormatting += TierFormatter;
        }

        private void ConfigureOneTimeColumns()
        {
            if (dgvOneTime.Columns.Count == 0) return;
            dgvOneTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvOneTime, "CustomerId", "ID");
            SetHeader(dgvOneTime, "Guest", "Guest");
            SetHeader(dgvOneTime, "Contact", "Contact");
            SetHeader(dgvOneTime, "Stays", "Stays");
            SetHeader(dgvOneTime, "Spend", "Spend");
            SetHeader(dgvOneTime, "LastVisit", "Last Visit");
            SetHeader(dgvOneTime, "DaysSince", "Days Ago");

            HideIfPresent(dgvOneTime, "CustomerId");

            SetWeight(dgvOneTime, "Guest", 220);
            SetWeight(dgvOneTime, "Contact", 140);
            SetWeight(dgvOneTime, "Stays", 60);
            SetWeight(dgvOneTime, "Spend", 100);
            SetWeight(dgvOneTime, "LastVisit", 110);
            SetWeight(dgvOneTime, "DaysSince", 80);

            SetFormat(dgvOneTime, "Spend", "N2");
            SetFormat(dgvOneTime, "LastVisit", "MMM dd, yyyy");
        }

        private void TierFormatter(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView grid) return;

            string col = grid.Columns[e.ColumnIndex].Name;
            if (col != "Tier") return;

            if (e.Value is not string tier) return;

            switch (tier)
            {
                case "Platinum":
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 20, 120);
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
                    break;
                case "Gold":
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkGoldenrod;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
                    break;
                case "Silver":
                    e.CellStyle.ForeColor = System.Drawing.Color.SlateGray;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
                    break;
                default:
                    e.CellStyle.ForeColor = System.Drawing.Color.Chocolate;
                    break;
            }
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

        private static void HideIfPresent(DataGridView grid, string column)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].Visible = false;
        }

        // =========================================================
        // VIEW HISTORY
        // =========================================================
        private void ViewHistoryFromGrid(DataGridView grid)
        {
            var idCell = grid.CurrentRow?.Cells["CustomerId"].Value;
            if (idCell == null) return;

            int customerId = Convert.ToInt32(idCell);

            try
            {
                using (var db = new HotelDbContext())
                {
                    var customer = db.Customers
                        .FirstOrDefault(c => c.CustomerId == customerId);

                    if (customer == null)
                    {
                        MessageBox.Show("Guest not found.",
                            "Retention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (var dlg = new GuestHistoryForm(customer))
                    {
                        dlg.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open history.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ViewHistoryFromCurrent()
        {
            var active =
                dgvTopReturning.ContainsFocus ? dgvTopReturning :
                dgvInactive.ContainsFocus ? dgvInactive :
                dgvOneTime.ContainsFocus ? dgvOneTime :
                dgvTopReturning;

            ViewHistoryFromGrid(active);
        }

        // =========================================================
        // EXPORT
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

                string filename = "retention_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                string fullPath = Path.Combine(folder, filename);

                var sb = new StringBuilder();

                sb.AppendLine("Hotel CRM — Customer Retention Report");
                sb.AppendLine("Generated," + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                sb.AppendLine("Churn threshold (days)," + _churnDays);
                sb.AppendLine();

                sb.AppendLine("KPI");
                sb.AppendLine("Repeat Guests," + lblKpi1Value.Text);
                sb.AppendLine("Return Rate," + lblKpi2Value.Text);
                sb.AppendLine("Avg Visits," + lblKpi3Value.Text);
                sb.AppendLine("Avg Spend," + lblKpi4Value.Text);
                sb.AppendLine("Avg Days Since Last Visit," + lblKpi5Value.Text);
                sb.AppendLine();

                AppendGridCsv(sb, "Top Returning Guests", dgvTopReturning,
                    new[] { "Guest", "Contact", "Tier", "Stays", "Nights", "Spend", "LastVisit", "DaysSince" });

                AppendGridCsv(sb, "Inactive (Churn Risk)", dgvInactive,
                    new[] { "Guest", "Contact", "Tier", "Stays", "Spend", "LastVisit", "DaysSince" });

                AppendGridCsv(sb, "One-Time Guests", dgvOneTime,
                    new[] { "Guest", "Contact", "Stays", "Spend", "LastVisit", "DaysSince" });

                File.WriteAllText(fullPath, sb.ToString(), Encoding.UTF8);

                lblStatus.Text = "Exported to " + fullPath;

                MessageBox.Show(
                    "Retention report exported.\n\n" + fullPath,
                    "Export Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to export.\n\n" + ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void AppendGridCsv(StringBuilder sb, string title,
            DataGridView grid, string[] columns)
        {
            sb.AppendLine(title);
            sb.AppendLine(string.Join(",", columns));

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                var values = new List<string>();
                foreach (var col in columns)
                {
                    if (grid.Columns.Contains(col))
                        values.Add(Csv(row.Cells[col].Value));
                    else
                        values.Add("");
                }
                sb.AppendLine(string.Join(",", values));
            }

            sb.AppendLine();
        }

        private static string Csv(object? value)
        {
            if (value == null) return "";
            string s = value.ToString() ?? "";
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
                s = "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }
    }
}