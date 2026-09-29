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
    public partial class ManageUsersControl : UserControl
    {
        public ManageUsersControl()
        {
            InitializeComponent();
            WireEvents();
            LoadRoleFilter();
            LoadUsers();
        }

        public void ReloadData()
        {
            LoadUsers();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => LoadUsers();
            cmbRoleFilter.SelectedIndexChanged += (s, e) => LoadUsers();

            btnAddUser.Click += BtnAddUser_Click;
            btnEdit.Click += BtnEdit_Click;
            btnResetPassword.Click += BtnResetPassword_Click;
            btnToggleActive.Click += BtnToggleActive_Click;
            btnRefresh.Click += (s, e) => LoadUsers();

            dgvUsers.SelectionChanged += (s, e) => UpdateToggleButton();
        }

        // =========================================================
        // ROLE FILTER
        // =========================================================
        private void LoadRoleFilter()
        {
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.AddRange(new object[]
            {
                "All", "Admin", "Manager", "Staff"
            });
            cmbRoleFilter.SelectedIndex = 0;
        }

        // =========================================================
        // LOAD USERS
        // =========================================================
        private void LoadUsers()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                string roleFilter = cmbRoleFilter.SelectedItem?.ToString() ?? "All";

                using (var db = new HotelDbContext())
                {
                    var query = db.Users.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query = query.Where(u =>
                            u.Username.Contains(search) ||
                            (u.FullName != null && u.FullName.Contains(search)));
                    }

                    if (roleFilter != "All")
                    {
                        query = query.Where(u => u.Role == roleFilter);
                    }

                    var rows = query
                        .OrderBy(u => u.Role)
                        .ThenBy(u => u.Username)
                        .Select(u => new UserRow
                        {
                            UserId = u.UserId,
                            Username = u.Username,
                            FullName = u.FullName ?? "",
                            Role = u.Role,
                            IsActive = u.IsActive,
                            Status = u.IsActive ? "Active" : "Inactive",
                            LastLoginAt = u.LastLoginAt,
                            CreatedAt = u.CreatedAt,
                            MustChangePassword = u.MustChangePassword
                        })
                        .ToList();

                    dgvUsers.DataSource = rows;
                    ConfigureGrid();

                    lblCounter.Text = rows.Count + " user" + (rows.Count == 1 ? "" : "s");
                }

                UpdateToggleButton();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load users.", ex);
            }
        }

        private void ConfigureGrid()
        {
            if (dgvUsers.Columns.Count == 0) return;

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader("UserId", "ID");
            SetHeader("Username", "Username");
            SetHeader("FullName", "Full Name");
            SetHeader("Role", "Role");
            SetHeader("Status", "Status");
            SetHeader("LastLoginAt", "Last Login");
            SetHeader("CreatedAt", "Created");

            SetWeight("UserId", 40);
            SetWeight("Username", 120);
            SetWeight("FullName", 170);
            SetWeight("Role", 90);
            SetWeight("Status", 80);
            SetWeight("LastLoginAt", 140);
            SetWeight("CreatedAt", 120);

            if (dgvUsers.Columns.Contains("LastLoginAt"))
                dgvUsers.Columns["LastLoginAt"].DefaultCellStyle.Format = "MMM dd, yyyy HH:mm";

            if (dgvUsers.Columns.Contains("CreatedAt"))
                dgvUsers.Columns["CreatedAt"].DefaultCellStyle.Format = "MMM dd, yyyy";

            // Hide helper columns
            if (dgvUsers.Columns.Contains("UserId"))
                dgvUsers.Columns["UserId"].Visible = false;

            if (dgvUsers.Columns.Contains("IsActive"))
                dgvUsers.Columns["IsActive"].Visible = false;

            if (dgvUsers.Columns.Contains("MustChangePassword"))
                dgvUsers.Columns["MustChangePassword"].Visible = false;

            // Color-code the role and status cells
            dgvUsers.CellFormatting -= DgvUsers_CellFormatting;
            dgvUsers.CellFormatting += DgvUsers_CellFormatting;
        }

        private void DgvUsers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            string colName = dgvUsers.Columns[e.ColumnIndex].Name;

            if (colName == "Role" && e.Value is string role)
            {
                switch (role)
                {
                    case "Admin":
                        e.CellStyle.ForeColor = Color.IndianRed;
                        e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    case "Manager":
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        break;
                    default:
                        e.CellStyle.ForeColor = Theme.TextDark;
                        break;
                }
            }
            else if (colName == "Status" && e.Value is string status)
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
            if (dgvUsers.Columns.Contains(column))
                dgvUsers.Columns[column].HeaderText = text;
        }

        private void SetWeight(string column, float weight)
        {
            if (dgvUsers.Columns.Contains(column))
                dgvUsers.Columns[column].FillWeight = weight;
        }

        // =========================================================
        // ADD USER
        // =========================================================
        private void BtnAddUser_Click(object? sender, EventArgs e)
        {
            using (var dlg = new UserEditForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("User added.");
                    LoadUsers();
                }
            }
        }

        // =========================================================
        // EDIT USER
        // =========================================================
        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) { Warn("Please select a user first."); return; }

            // Guard: don't let the admin edit themselves into another role
            if (user.UserId == CurrentUser.UserId)
            {
                Warn("You cannot change your own role from here.");
                return;
            }

            using (var db = new HotelDbContext())
            {
                var tracked = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (tracked == null) { Warn("User not found."); return; }

                using (var dlg = new UserEditForm(tracked))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        SetStatus("User updated.");
                        LoadUsers();
                    }
                }
            }
        }

        // =========================================================
        // RESET PASSWORD
        // =========================================================
        private void BtnResetPassword_Click(object? sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) { Warn("Please select a user first."); return; }

            using (var db = new HotelDbContext())
            {
                var tracked = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (tracked == null) { Warn("User not found."); return; }

                using (var dlg = new ResetPasswordForm(tracked))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        SetStatus("Password reset. User must change it on next login.");
                        LoadUsers();
                    }
                }
            }
        }

        // =========================================================
        // TOGGLE ACTIVE / INACTIVE
        // =========================================================
        private void BtnToggleActive_Click(object? sender, EventArgs e)
        {
            var user = GetSelectedUser();
            if (user == null) { Warn("Please select a user first."); return; }

            if (user.UserId == CurrentUser.UserId)
            {
                Warn("You cannot deactivate your own account.");
                return;
            }

            // If deactivating an admin, ensure at least one other active admin exists
            if (user.IsActive && user.Role == "Admin")
            {
                using (var db = new HotelDbContext())
                {
                    int otherActiveAdmins = db.Users.Count(u =>
                        u.Role == "Admin" && u.IsActive && u.UserId != user.UserId);

                    if (otherActiveAdmins == 0)
                    {
                        Warn("Cannot deactivate the last active admin.");
                        return;
                    }
                }
            }

            string verb = user.IsActive ? "deactivate" : "reactivate";

            var confirm = MessageBox.Show(
                "Are you sure you want to " + verb + " " + user.Username + "?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var tracked = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
                    if (tracked == null) { Warn("User not found."); return; }

                    tracked.IsActive = !tracked.IsActive;
                    db.SaveChanges();
                }

                SetStatus("User " + (user.IsActive ? "deactivated." : "reactivated."));
                LoadUsers();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to update user status.", ex);
            }
        }

        private void UpdateToggleButton()
        {
            var user = GetSelectedUser();

            if (user == null)
            {
                btnToggleActive.Text = "Deactivate";
                btnToggleActive.Enabled = false;
                btnEdit.Enabled = false;
                btnResetPassword.Enabled = false;
                return;
            }

            btnToggleActive.Text = user.IsActive ? "Deactivate" : "Reactivate";
            btnToggleActive.Enabled = true;
            btnEdit.Enabled = true;
            btnResetPassword.Enabled = true;
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private UserRow? GetSelectedUser()
        {
            if (dgvUsers.CurrentRow == null) return null;

            var value = dgvUsers.CurrentRow.Cells["UserId"].Value;
            if (value == null) return null;

            int userId = Convert.ToInt32(value);

            // Look up the row DTO by id
            if (dgvUsers.DataSource is List<UserRow> rows)
                return rows.FirstOrDefault(r => r.UserId == userId);

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
                "User Management",
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
        private class UserRow
        {
            public int UserId { get; set; }
            public string Username { get; set; } = "";
            public string FullName { get; set; } = "";
            public string Role { get; set; } = "";
            public bool IsActive { get; set; }
            public string Status { get; set; } = "";
            public DateTime? LastLoginAt { get; set; }
            public DateTime CreatedAt { get; set; }
            public bool MustChangePassword { get; set; }
        }
    }
}