using CRM.domain;
using CRM.infrastructure;

using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            txtUsername.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnLogin_Click(s, e); }
            };

            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnLogin_Click(s, e); }
            };

            Load += (s, e) => txtUsername.Focus();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";
            lblStatus.ForeColor = System.Drawing.Color.IndianRed;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                User? matched;
                string tenantSlug = "";
                string tenantName = "";

                using (var db = new HotelDbContext())
                {
                    matched = db.Users
                        .FirstOrDefault(u => u.Username == username);

                    if (matched != null && matched.TenantId.HasValue)
                    {
                        var tenant = db.Tenants
                            .FirstOrDefault(t => t.TenantId == matched.TenantId.Value);

                        if (tenant != null)
                        {
                            tenantSlug = tenant.Slug;
                            tenantName = tenant.Name;
                        }
                    }
                }

                if (matched == null)
                {
                    lblStatus.Text = "Invalid username or password.";
                    return;
                }

                if (!matched.IsActive)
                {
                    lblStatus.Text = "This account has been deactivated.";
                    return;
                }

                bool ok = PasswordHasher.Verify(
                    password,
                    matched.PasswordHash,
                    matched.PasswordSalt);

                if (!ok)
                {
                    lblStatus.Text = "Invalid username or password.";
                    return;
                }

                // Update LastLoginAt
                using (var db = new HotelDbContext())
                {
                    var u = db.Users.FirstOrDefault(x => x.UserId == matched.UserId);
                    if (u != null)
                    {
                        u.LastLoginAt = DateTime.Now;
                        db.SaveChanges();
                    }
                }

                // Set the session with tenant info
                CurrentUser.Set(
                    matched.UserId,
                    matched.Username,
                    matched.FullName ?? matched.Username,
                    matched.Role,
                    matched.TenantId,
                    tenantSlug,
                    tenantName);

                // Force password change on first login — only for the master admin
                // (TenantId == null) using the default password.
                bool isMasterWithDefaultPassword =
                    matched.TenantId == null &&
                    matched.Role == "Admin" &&
                    password == "admin123";

                if (isMasterWithDefaultPassword)
                {
                    using (var change = new ChangePasswordForm(forceChange: true))
                    {
                        if (change.ShowDialog(this) != DialogResult.OK)
                        {
                            CurrentUser.Clear();
                            lblStatus.Text = "You must change the default admin password to continue.";
                            return;
                        }
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Login failed. " + ex.Message;
            }
        }
    }
}