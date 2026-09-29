#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblUsername = null!;
        private RoundedPanel pnlUsername = null!;
        private TextBox txtUsername = null!;

        private Label lblFullName = null!;
        private RoundedPanel pnlFullName = null!;
        private TextBox txtFullName = null!;

        private Label lblRole = null!;
        private ComboBox cmbRole = null!;

        private Label lblPassword = null!;
        private RoundedPanel pnlPassword = null!;
        private TextBox txtPassword = null!;

        private Label lblConfirm = null!;
        private RoundedPanel pnlConfirm = null!;
        private TextBox txtConfirm = null!;

        private RoundedButton btnSave = null!;
        private RoundedButton btnCancel = null!;
        private Label lblStatus = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblHeading = new Label();
            lblUsername = new Label();
            pnlUsername = new RoundedPanel();
            txtUsername = new TextBox();
            lblFullName = new Label();
            pnlFullName = new RoundedPanel();
            txtFullName = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblPassword = new Label();
            pnlPassword = new RoundedPanel();
            txtPassword = new TextBox();
            lblConfirm = new Label();
            pnlConfirm = new RoundedPanel();
            txtConfirm = new TextBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatus = new Label();

            pnlUsername.SuspendLayout();
            pnlFullName.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlConfirm.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(540, 640);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User";

            // Heading
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Add User";

            // Username
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(80, 80, 80);
            lblUsername.Location = new Point(38, 85);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(65, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username *";

            pnlUsername.BackColor = Theme.Field;
            pnlUsername.BorderColor = Theme.Border;
            pnlUsername.BorderThickness = 1;
            pnlUsername.CornerRadius = 10;
            pnlUsername.Location = new Point(35, 105);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(470, 44);
            pnlUsername.TabIndex = 2;

            txtUsername.BackColor = Theme.Field;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 10.5F);
            txtUsername.Location = new Point(14, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(440, 20);
            txtUsername.TabIndex = 0;

            pnlUsername.Controls.Add(txtUsername);

            // Full Name
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(80, 80, 80);
            lblFullName.Location = new Point(38, 165);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(65, 15);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Full Name *";

            pnlFullName.BackColor = Theme.Field;
            pnlFullName.BorderColor = Theme.Border;
            pnlFullName.BorderThickness = 1;
            pnlFullName.CornerRadius = 10;
            pnlFullName.Location = new Point(35, 185);
            pnlFullName.Name = "pnlFullName";
            pnlFullName.Size = new Size(470, 44);
            pnlFullName.TabIndex = 4;

            txtFullName.BackColor = Theme.Field;
            txtFullName.BorderStyle = BorderStyle.None;
            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.Location = new Point(14, 12);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(440, 20);
            txtFullName.TabIndex = 0;

            pnlFullName.Controls.Add(txtFullName);

            // Role
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(80, 80, 80);
            lblRole.Location = new Point(38, 245);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(40, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "Role *";

            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 10.5F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(35, 265);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(470, 27);
            cmbRole.TabIndex = 6;

            // Password
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            lblPassword.Location = new Point(38, 315);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(110, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Initial Password *";

            pnlPassword.BackColor = Theme.Field;
            pnlPassword.BorderColor = Theme.Border;
            pnlPassword.BorderThickness = 1;
            pnlPassword.CornerRadius = 10;
            pnlPassword.Location = new Point(35, 335);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(470, 44);
            pnlPassword.TabIndex = 8;

            txtPassword.BackColor = Theme.Field;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(14, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(440, 20);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;

            pnlPassword.Controls.Add(txtPassword);

            // Confirm
            lblConfirm.AutoSize = true;
            lblConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirm.ForeColor = Color.FromArgb(80, 80, 80);
            lblConfirm.Location = new Point(38, 395);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(105, 15);
            lblConfirm.TabIndex = 9;
            lblConfirm.Text = "Confirm Password";

            pnlConfirm.BackColor = Theme.Field;
            pnlConfirm.BorderColor = Theme.Border;
            pnlConfirm.BorderThickness = 1;
            pnlConfirm.CornerRadius = 10;
            pnlConfirm.Location = new Point(35, 415);
            pnlConfirm.Name = "pnlConfirm";
            pnlConfirm.Size = new Size(470, 44);
            pnlConfirm.TabIndex = 10;

            txtConfirm.BackColor = Theme.Field;
            txtConfirm.BorderStyle = BorderStyle.None;
            txtConfirm.Font = new Font("Segoe UI", 10.5F);
            txtConfirm.Location = new Point(14, 12);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(440, 20);
            txtConfirm.TabIndex = 0;
            txtConfirm.UseSystemPasswordChar = true;

            pnlConfirm.Controls.Add(txtConfirm);

            // Save
            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 495);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(255, 50);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;

            // Cancel
            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(300, 495);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(205, 50);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            // Status
            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(35, 555);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(470, 40);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "";

            Controls.Add(lblHeading);
            Controls.Add(lblUsername);
            Controls.Add(pnlUsername);
            Controls.Add(lblFullName);
            Controls.Add(pnlFullName);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(lblPassword);
            Controls.Add(pnlPassword);
            Controls.Add(lblConfirm);
            Controls.Add(pnlConfirm);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);

            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            pnlFullName.ResumeLayout(false);
            pnlFullName.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlConfirm.ResumeLayout(false);
            pnlConfirm.PerformLayout();

            ResumeLayout(false);
        }
    }
}