using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class UserEditForm : Form
    {
        private readonly User? _existing;

        public UserEditForm()
        {
            InitializeComponent();

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "Admin", "Manager", "Staff" });

            lblHeading.Text = "Add User";
            cmbRole.SelectedIndex = 2; // Staff

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        public UserEditForm(User existing)
        {
            InitializeComponent();

            _existing = existing;

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "Admin", "Manager", "Staff" });

            lblHeading.Text = "Edit User";
            txtUsername.Text = existing.Username;
            txtUsername.ReadOnly = true;
            txtUsername.BackColor = Theme.Card;

            txtFullName.Text = existing.FullName ?? "";

            int idx = cmbRole.Items.IndexOf(existing.Role);
            cmbRole.SelectedIndex = idx >= 0 ? idx : 2;

            // Password fields hidden in edit mode
            lblPassword.Visible = false;
            pnlPassword.Visible = false;
            lblConfirm.Visible = false;
            pnlConfirm.Visible = false;

            // Shrink window to fit fewer fields
            ClientSize = new System.Drawing.Size(540, 470);
            btnSave.Location = new System.Drawing.Point(35, 325);
            btnCancel.Location = new System.Drawing.Point(300, 325);
            lblStatus.Location = new System.Drawing.Point(35, 385);

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";

            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "Staff";

            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatus.Text = "Username is required."; return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                lblStatus.Text = "Full name is required."; return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    if (_existing == null)
                    {
                        // Add
                        string password = txtPassword.Text;
                        string confirm = txtConfirm.Text;

                        if (string.IsNullOrWhiteSpace(password))
                        {
                            lblStatus.Text = "Initial password is required."; return;
                        }

                        if (password.Length < 6)
                        {
                            lblStatus.Text = "Password must be at least 6 characters."; return;
                        }

                        if (password != confirm)
                        {
                            lblStatus.Text = "Passwords do not match."; return;
                        }

                        bool taken = db.Users.Any(u => u.Username == username);
                        if (taken)
                        {
                            lblStatus.Text = "That username is already taken."; return;
                        }

                        var (hash, salt) = PasswordHasher.Hash(password);

                        var user = new User
                        {
                            Username = username,
                            PasswordHash = hash,
                            PasswordSalt = salt,
                            Role = role,
                            FullName = fullName,
                            IsActive = true,
                            MustChangePassword = true,
                            CreatedAt = DateTime.Now,
                            TenantId = CurrentUser.TenantId
                        };

                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Edit
                        var user = db.Users.FirstOrDefault(u => u.UserId == _existing.UserId);
                        if (user == null)
                        {
                            lblStatus.Text = "User not found."; return;
                        }

                        user.FullName = fullName;
                        user.Role = role;
                        db.SaveChanges();
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unable to save user. " + ex.Message;
            }
        }
    }
}