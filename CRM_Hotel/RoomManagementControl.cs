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
    public partial class RoomManagementControl : UserControl
    {
        public RoomManagementControl()
        {
            InitializeComponent();
            WireEvents();
            LoadFilterOptions();
            LoadRooms();
        }

        public void ReloadData()
        {
            LoadRooms();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadRooms();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => LoadRooms();
            btnAddRoom.Click += BtnAddRoom_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBulkPrice.Click += BtnBulkPrice_Click;
            btnRefresh.Click += (s, e) => LoadRooms();
        }

        private void LoadFilterOptions()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new object[]
            {
                "All", "Available", "Occupied", "Maintenance"
            });
            cmbStatusFilter.SelectedIndex = 0;
        }

        // =========================================================
        // LOAD
        // =========================================================
        private void LoadRooms()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

                using (var db = new HotelDbContext())
                {
                    var query = db.Rooms.AsQueryable();

                    if (statusFilter != "All")
                        query = query.Where(r => r.Status == statusFilter);

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query = query.Where(r =>
                            r.RoomNumber.Contains(search) ||
                            r.RoomType.Contains(search));
                    }

                    var rows = query
                        .OrderBy(r => r.RoomNumber)
                        .Select(r => new
                        {
                            r.RoomId,
                            r.RoomNumber,
                            r.RoomType,
                            r.Status,
                            r.Price
                        })
                        .ToList();

                    dgvRooms.DataSource = rows;
                    ConfigureGrid();
                    lblCounter.Text = rows.Count + " room" + (rows.Count == 1 ? "" : "s");
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
            SetHeader("RoomNumber", "Room Number");
            SetHeader("RoomType", "Type");
            SetHeader("Status", "Status");
            SetHeader("Price", "Price");

            SetWeight("RoomId", 40);
            SetWeight("RoomNumber", 100);
            SetWeight("RoomType", 120);
            SetWeight("Status", 110);
            SetWeight("Price", 100);

            if (dgvRooms.Columns.Contains("RoomId"))
                dgvRooms.Columns["RoomId"].Visible = false;

            if (dgvRooms.Columns.Contains("Price"))
                dgvRooms.Columns["Price"].DefaultCellStyle.Format = "N2";

            dgvRooms.CellFormatting -= DgvRooms_CellFormatting;
            dgvRooms.CellFormatting += DgvRooms_CellFormatting;
        }

        private void DgvRooms_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            string col = dgvRooms.Columns[e.ColumnIndex].Name;

            if (col == "Status" && e.Value is string status)
            {
                switch (status)
                {
                    case "Available":
                        e.CellStyle.ForeColor = Color.SeaGreen;
                        e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case "Occupied":
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case "Maintenance":
                        e.CellStyle.ForeColor = Color.IndianRed;
                        break;
                }
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
        // ADD
        // =========================================================
        private void BtnAddRoom_Click(object? sender, EventArgs e)
        {
            using (var dlg = new RoomEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Room added.");
                    LoadRooms();
                }
            }
        }

        // =========================================================
        // EDIT
        // =========================================================
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            var room = GetSelectedRoom();
            if (room == null) { Warn("Please select a room first."); return; }

            using (var dlg = new RoomEditForm(room))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Room updated.");
                    LoadRooms();
                }
            }
        }

        // =========================================================
        // DELETE
        // =========================================================
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            var room = GetSelectedRoom();
            if (room == null) { Warn("Please select a room first."); return; }

            // Block delete if the room has any reservations
            try
            {
                using (var db = new HotelDbContext())
                {
                    bool hasReservations = db.Reservations
                        .Any(r => r.RoomId == room.RoomId);

                    if (hasReservations)
                    {
                        Warn("This room has reservations and cannot be deleted.\n" +
                             "Consider marking it as Maintenance instead.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to check reservations.", ex);
                return;
            }

            var confirm = MessageBox.Show(
                "Delete room " + room.RoomNumber + "?\n\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var tracked = db.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
                    if (tracked == null) { Warn("Room not found."); return; }

                    db.Rooms.Remove(tracked);
                    db.SaveChanges();
                }

                SetStatus("Room deleted.");
                LoadRooms();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to delete room.", ex);
            }
        }

        // =========================================================
        // BULK PRICE
        // =========================================================
        private void BtnBulkPrice_Click(object? sender, EventArgs e)
        {
            using (var dlg = new BulkPriceForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Prices updated.");
                    LoadRooms();
                }
            }
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private Room? GetSelectedRoom()
        {
            if (dgvRooms.CurrentRow == null) return null;

            var idCell = dgvRooms.CurrentRow.Cells["RoomId"].Value;
            if (idCell == null) return null;

            int roomId = Convert.ToInt32(idCell);

            try
            {
                using (var db = new HotelDbContext())
                {
                    return db.Rooms.FirstOrDefault(r => r.RoomId == roomId);
                }
            }
            catch
            {
                return null;
            }
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Rooms",
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
    }
}