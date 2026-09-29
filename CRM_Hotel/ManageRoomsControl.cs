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
    public partial class ManageRoomsControl : UserControl
    {
        public ManageRoomsControl()
        {
            InitializeComponent();
            WireEvents();
            LoadFilters();
            LoadRooms();
        }

        public void ReloadData()
        {
            LoadFilters();
            LoadRooms();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadRooms();
            cmbTypeFilter.SelectedIndexChanged += (s, e) => LoadRooms();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadRooms();

            btnAddRoom.Click += BtnAddRoom_Click;
            btnEdit.Click += BtnEdit_Click;
            btnBulkPrice.Click += BtnBulkPrice_Click;
            btnRefresh.Click += (s, e) => ReloadData();

            dgvRooms.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) BtnEdit_Click(s, EventArgs.Empty);
            };
        }

        private void LoadFilters()
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

                    cmbTypeFilter.DataSource = types;
                    cmbTypeFilter.SelectedIndex = 0;
                }

                cmbStatusFilter.Items.Clear();
                cmbStatusFilter.Items.AddRange(new object[]
                {
                    "All", "Available", "Occupied", "Maintenance"
                });
                cmbStatusFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load filters.", ex);
            }
        }

        private void LoadRooms()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string typeFilter = cmbTypeFilter.SelectedItem?.ToString() ?? "All";
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

                using (var db = new HotelDbContext())
                {
                    var query = db.Rooms.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(search))
                        query = query.Where(r => r.RoomNumber.Contains(search));

                    if (typeFilter != "All")
                        query = query.Where(r => r.RoomType == typeFilter);

                    if (statusFilter != "All")
                        query = query.Where(r => r.Status == statusFilter);

                    var rows = query
                        .OrderBy(r => r.RoomNumber)
                        .Select(r => new RoomRow
                        {
                            RoomId = r.RoomId,
                            RoomNumber = r.RoomNumber,
                            RoomType = r.RoomType,
                            Price = r.Price,
                            Status = r.Status
                        })
                        .ToList();

                    dgvRooms.DataSource = rows;
                    ConfigureGrid();

                    lblCounter.Text = rows.Count + " room" +
                                      (rows.Count == 1 ? "" : "s");
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load rooms.", ex);
            }
        }

        private void ConfigureGrid()
        {
            if (dgvRooms.Columns.Count == 0) return;

            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader("RoomId", "ID");
            SetHeader("RoomNumber", "Room #");
            SetHeader("RoomType", "Type");
            SetHeader("Price", "Price / Night");
            SetHeader("Status", "Status");

            SetWeight("RoomId", 40);
            SetWeight("RoomNumber", 100);
            SetWeight("RoomType", 160);
            SetWeight("Price", 130);
            SetWeight("Status", 120);

            if (dgvRooms.Columns.Contains("RoomId"))
                dgvRooms.Columns["RoomId"].Visible = false;

            if (dgvRooms.Columns.Contains("Price"))
                dgvRooms.Columns["Price"].DefaultCellStyle.Format = "N2";

            dgvRooms.CellFormatting -= StatusFormatter;
            dgvRooms.CellFormatting += StatusFormatter;
        }

        private void StatusFormatter(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            string col = dgvRooms.Columns[e.ColumnIndex].Name;
            if (col != "Status") return;

            if (e.Value is not string status) return;

            switch (status)
            {
                case "Available":
                    e.CellStyle.ForeColor = Color.SeaGreen;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
                case "Occupied":
                    e.CellStyle.ForeColor = Theme.Primary;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
                case "Maintenance":
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
            }
        }

        private void SetHeader(string column, string text)
        {
            if (dgvRooms.Columns.Contains(column))
                dgvRooms.Columns[column].HeaderText = text;
        }

        private void SetWeight(string column, float weight)
        {
            if (dgvRooms.Columns.Contains(column))
                dgvRooms.Columns[column].FillWeight = weight;
        }

        // =========================================================
        // ACTIONS
        // =========================================================
        private void BtnAddRoom_Click(object? sender, EventArgs e)
        {
            using (var dlg = new RoomEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Room added.");
                    ReloadData();
                }
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            int? id = GetSelectedRoomId();
            if (id == null) { Warn("Please select a room first."); return; }

            using (var db = new HotelDbContext())
            {
                var room = db.Rooms.FirstOrDefault(r => r.RoomId == id.Value);
                if (room == null) { Warn("Room not found."); return; }

                using (var dlg = new RoomEditForm(room))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        SetStatus("Room updated.");
                        ReloadData();
                    }
                }
            }
        }

        private void BtnBulkPrice_Click(object? sender, EventArgs e)
        {
            using (var dlg = new BulkPriceForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Bulk price updated.");
                    ReloadData();
                }
            }
        }

        private int? GetSelectedRoomId()
        {
            var cell = dgvRooms.CurrentRow?.Cells["RoomId"].Value;
            if (cell == null) return null;
            return Convert.ToInt32(cell);
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Manage Rooms",
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

        private class RoomRow
        {
            public int RoomId { get; set; }
            public string RoomNumber { get; set; } = "";
            public string RoomType { get; set; } = "";
            public decimal Price { get; set; }
            public string Status { get; set; } = "";
        }
    }
}