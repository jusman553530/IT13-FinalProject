using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ManageGuestsControl : UserControl
    {
        public ManageGuestsControl()
        {
            InitializeComponent();
            WireEvents();
            LoadStatusFilter();
            LoadGuests();
        }

        public void ReloadData()
        {
            LoadGuests();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadGuests();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadGuests();

            btnAddGuest.Click += BtnAddGuest_Click;
            btnEdit.Click += BtnEdit_Click;
            btnHistory.Click += BtnHistory_Click;
            btnArchiveToggle.Click += BtnArchiveToggle_Click;
            btnRefresh.Click += (s, e) => LoadGuests();

            dgvGuests.SelectionChanged += (s, e) => UpdateActionButtons();
        }

        private void LoadStatusFilter()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[]
            {
                "Active", "Archived", "All"
            });
            cmbStatusFilter.SelectedIndex = 0;
        }

        // =========================================================
        // LOAD
        // =========================================================
        private void LoadGuests()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "Active";

                using (var db = new HotelDbContext())
                {
                    var query = db.Customers.AsQueryable();

                    if (statusFilter == "Active")
                        query = query.Where(c => !c.IsArchived);
                    else if (statusFilter == "Archived")
                        query = query.Where(c => c.IsArchived);

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query = query.Where(c =>
                            c.FirstName.Contains(search) ||
                            c.LastName.Contains(search) ||
                            (c.MiddleName != null && c.MiddleName.Contains(search)) ||
                            c.ContactNumber.Contains(search) ||
                            (c.Email != null && c.Email.Contains(search)) ||
                            (c.Address != null && c.Address.Contains(search)));
                    }

                    var rows = query
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .Select(c => new GuestRow
                        {
                            CustomerId = c.CustomerId,
                            FirstName = c.FirstName,
                            MiddleName = c.MiddleName ?? "",
                            LastName = c.LastName,
                            ContactNumber = c.ContactNumber,
                            Email = c.Email ?? "",
                            Address = c.Address ?? "",
                            IsArchived = c.IsArchived,
                            Status = c.IsArchived ? "Archived" : "Active"
                        })
                        .ToList();

                    dgvGuests.DataSource = rows;
                    ConfigureGrid();
                    lblCounter.Text = rows.Count + " guest" + (rows.Count == 1 ? "" : "s");
                }

                UpdateActionButtons();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load guests.", ex);
            }
        }

        private void ConfigureGrid()
        {
            if (dgvGuests.Columns.Count == 0) return;

            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader("CustomerId", "ID");
            SetHeader("FirstName", "First Name");
            SetHeader("MiddleName", "Middle Name");
            SetHeader("LastName", "Last Name");
            SetHeader("ContactNumber", "Contact");
            SetHeader("Email", "Email");
            SetHeader("Address", "Address");
            SetHeader("Status", "Status");

            SetWeight("CustomerId", 40);
            SetWeight("FirstName", 90);
            SetWeight("MiddleName", 90);
            SetWeight("LastName", 90);
            SetWeight("ContactNumber", 110);
            SetWeight("Email", 140);
            SetWeight("Address", 150);
            SetWeight("Status", 80);

            if (dgvGuests.Columns.Contains("CustomerId"))
                dgvGuests.Columns["CustomerId"].Visible = false;

            if (dgvGuests.Columns.Contains("IsArchived"))
                dgvGuests.Columns["IsArchived"].Visible = false;

            dgvGuests.CellFormatting -= DgvGuests_CellFormatting;
            dgvGuests.CellFormatting += DgvGuests_CellFormatting;
        }

        private void DgvGuests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            string col = dgvGuests.Columns[e.ColumnIndex].Name;

            if (col == "Status" && e.Value is string status)
            {
                if (status == "Active")
                {
                    e.CellStyle.ForeColor = Color.SeaGreen;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void SetHeader(string column, string text)
        {
            if (dgvGuests.Columns.Contains(column))
                dgvGuests.Columns[column].HeaderText = text;
        }

        private void SetWeight(string column, float weight)
        {
            if (dgvGuests.Columns.Contains(column))
                dgvGuests.Columns[column].FillWeight = weight;
        }

        // =========================================================
        // ADD
        // =========================================================
        private void BtnAddGuest_Click(object? sender, EventArgs e)
        {
            using (var dlg = new GuestEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Guest added.");
                    LoadGuests();
                }
            }
        }

        // =========================================================
        // EDIT
        // =========================================================
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null) { Warn("Please select a guest first."); return; }

            using (var db = new HotelDbContext())
            {
                var tracked = db.Customers.FirstOrDefault(c => c.CustomerId == row.CustomerId);
                if (tracked == null) { Warn("Guest not found."); return; }

                using (var dlg = new GuestEditForm(tracked))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        SetStatus("Guest updated.");
                        LoadGuests();
                    }
                }
            }
        }

        // =========================================================
        // HISTORY
        // =========================================================
        private void BtnHistory_Click(object? sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null) { Warn("Please select a guest first."); return; }

            using (var db = new HotelDbContext())
            {
                var tracked = db.Customers.FirstOrDefault(c => c.CustomerId == row.CustomerId);
                if (tracked == null) { Warn("Guest not found."); return; }

                using (var dlg = new GuestHistoryForm(tracked))
                {
                    dlg.ShowDialog(this);
                }
            }
        }

        // =========================================================
        // ARCHIVE / RESTORE
        // =========================================================
        private void BtnArchiveToggle_Click(object? sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null) { Warn("Please select a guest first."); return; }

            string verb = row.IsArchived ? "restore" : "archive";

            var confirm = MessageBox.Show(
                "Are you sure you want to " + verb + " this guest?\n\n" +
                "Guest: " + row.FirstName + " " + row.LastName,
                "Confirm " + (row.IsArchived ? "Restore" : "Archive"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var tracked = db.Customers.FirstOrDefault(c => c.CustomerId == row.CustomerId);
                    if (tracked == null) { Warn("Guest not found."); return; }

                    tracked.IsArchived = !tracked.IsArchived;
                    db.SaveChanges();
                }

                SetStatus(row.IsArchived ? "Guest restored." : "Guest archived.");
                LoadGuests();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to update guest status.", ex);
            }
        }

        private void UpdateActionButtons()
        {
            var row = GetSelectedRow();

            if (row == null)
            {
                btnEdit.Enabled = false;
                btnHistory.Enabled = false;
                btnArchiveToggle.Enabled = false;
                btnArchiveToggle.Text = "Archive";
                return;
            }

            btnEdit.Enabled = true;
            btnHistory.Enabled = true;
            btnArchiveToggle.Enabled = true;
            btnArchiveToggle.Text = row.IsArchived ? "Restore" : "Archive";
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private GuestRow? GetSelectedRow()
        {
            if (dgvGuests.CurrentRow == null) return null;

            var value = dgvGuests.CurrentRow.Cells["CustomerId"].Value;
            if (value == null) return null;

            int customerId = Convert.ToInt32(value);

            if (dgvGuests.DataSource is List<GuestRow> rows)
                return rows.FirstOrDefault(r => r.CustomerId == customerId);

            return null;
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Manage Guests",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void ShowDbError(string message, Exception ex)
        {
            MessageBox.Show(
                message + "\n\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // =========================================================
        // ROW DTO
        // =========================================================
        private class GuestRow
        {
            public int CustomerId { get; set; } 
            public string FirstName { get; set; } = "";
            public string MiddleName { get; set; } = "";
            public string LastName { get; set; } = "";
            public string ContactNumber { get; set; } = "";
            public string Email { get; set; } = "";
            public string Address { get; set; } = "";
            public bool IsArchived { get; set; }
            public string Status { get; set; } = "";
        }
    }
}