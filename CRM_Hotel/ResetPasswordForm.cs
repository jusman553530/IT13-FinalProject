using CRM.domain;
using CRM.infrastructure;

using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ResetPasswordForm : Form
    {
        private readonly User _user;

        public ResetPasswordForm(User user)
        {
            InitializeComponent();
            _user = user;

            lblHeading.Text = "Reset Password — " + _user.Username;

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

            string next = txtNew.Text;
            string confirm = txtConfirm.Text;

            if (string.IsNullOrWhiteSpace(next))
            {
                lblStatus.Text = "Please enter a new password."; return;
            }

            if (next.Length < 6)
            {
                lblStatus.Text = "Password must be at least 6 characters."; return;
            }

            if (next != confirm)
            {
                lblStatus.Text = "Passwords do not match."; return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserId == _user.UserId);
                    if (user == null)
                    {
                        lblStatus.Text = "User not found."; return;
                    }

                    var (hash, salt) = PasswordHasher.Hash(next);
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;
                    user.MustChangePassword = true;

                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Password has been reset. The user must change it on next login.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unable to reset password. " + ex.Message;
            }
        }
    }
}