using CRM.infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly bool _forceChange;

        public ChangePasswordForm(bool forceChange = false)
        {
            InitializeComponent();
            _forceChange = forceChange;

            if (_forceChange)
            {
                lblHint.Text = "You must change the default admin password before continuing.";
                lblHeading.Text = "Set a New Password";
                ControlBox = false;
            }

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                if (_forceChange)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
                Close();
            };
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";

            string current = txtCurrent.Text;
            string next = txtNew.Text;
            string confirm = txtConfirm.Text;

            if (string.IsNullOrWhiteSpace(current) ||
                string.IsNullOrWhiteSpace(next) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                lblStatus.Text = "Please fill in all fields.";
                return;
            }

            if (next.Length < 6)
            {
                lblStatus.Text = "New password must be at least 6 characters.";
                return;
            }

            if (next != confirm)
            {
                lblStatus.Text = "New passwords do not match.";
                return;
            }

            if (next == current)
            {
                lblStatus.Text = "New password must be different from the current one.";
                return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId == CurrentUser.UserId);

                    if (user == null)
                    {
                        lblStatus.Text = "User not found. Please sign in again.";
                        return;
                    }

                    if (!PasswordHasher.Verify(current,
                            user.PasswordHash, user.PasswordSalt))
                    {
                        lblStatus.Text = "Current password is incorrect.";
                        return;
                    }

                    var (hash, salt) = PasswordHasher.Hash(next);
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Password updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unable to change password. " + ex.Message;
            }
        }
    }
}