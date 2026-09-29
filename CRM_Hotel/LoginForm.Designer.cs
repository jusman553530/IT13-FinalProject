#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlLeft = null!;
        private Label lblLogo = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private Panel pnlRight = null!;
        private Label lblWelcome = null!;
        private Label lblUserHint = null!;

        private Label lblUsername = null!;
        private RoundedPanel pnlUsername = null!;
        private TextBox txtUsername = null!;

        private Label lblPassword = null!;
        private RoundedPanel pnlPassword = null!;
        private TextBox txtPassword = null!;
        private CheckBox chkShowPassword = null!;

        private RoundedButton btnLogin = null!;
        private RoundedButton btnExit = null!;
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

            pnlLeft = new Panel();
            lblLogo = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();

            pnlRight = new Panel();
            lblWelcome = new Label();
            lblUserHint = new Label();

            lblUsername = new Label();
            pnlUsername = new RoundedPanel();
            txtUsername = new TextBox();

            lblPassword = new Label();
            pnlPassword = new RoundedPanel();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();

            btnLogin = new RoundedButton();
            btnExit = new RoundedButton();
            lblStatus = new Label();

            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlUsername.SuspendLayout();
            pnlPassword.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // LEFT PANEL (brand strip)
            // =====================================================

            pnlLeft.BackColor = Theme.Primary;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(360, 620);
            pnlLeft.TabIndex = 0;

            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI Emoji", 55F, FontStyle.Regular);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(40, 160);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(100, 100);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🏨";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(40, 290);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 47);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "HOTEL CRM";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(44, 345);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(250, 19);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Front desk & operations console";

            pnlLeft.Controls.Add(lblLogo);
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Controls.Add(lblSubtitle);

            // =====================================================
            // RIGHT PANEL (form)
            // =====================================================

            pnlRight.BackColor = Color.White;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(360, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(540, 620);
            pnlRight.TabIndex = 1;

            // Welcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 30, 30);
            lblWelcome.Location = new Point(60, 100);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(150, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";

            lblUserHint.AutoSize = true;
            lblUserHint.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblUserHint.ForeColor = Color.Gray;
            lblUserHint.Location = new Point(63, 145);
            lblUserHint.Name = "lblUserHint";
            lblUserHint.Size = new Size(220, 19);
            lblUserHint.TabIndex = 1;
            lblUserHint.Text = "Sign in with your staff account";

            // Username
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(80, 80, 80);
            lblUsername.Location = new Point(63, 200);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(65, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";

            pnlUsername.BackColor = Theme.Field;
            pnlUsername.BorderColor = Theme.Border;
            pnlUsername.BorderThickness = 1;
            pnlUsername.CornerRadius = 10;
            pnlUsername.Location = new Point(60, 220);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Size = new Size(420, 48);
            pnlUsername.TabIndex = 3;

            txtUsername.BackColor = Theme.Field;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(30, 30, 30);
            txtUsername.Location = new Point(14, 14);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter your username";
            txtUsername.Size = new Size(390, 20);
            txtUsername.TabIndex = 0;

            pnlUsername.Controls.Add(txtUsername);

            // Password
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            lblPassword.Location = new Point(63, 285);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";

            pnlPassword.BackColor = Theme.Field;
            pnlPassword.BorderColor = Theme.Border;
            pnlPassword.BorderThickness = 1;
            pnlPassword.CornerRadius = 10;
            pnlPassword.Location = new Point(60, 305);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(420, 48);
            pnlPassword.TabIndex = 5;

            txtPassword.BackColor = Theme.Field;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(30, 30, 30);
            txtPassword.Location = new Point(14, 14);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(390, 20);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;

            pnlPassword.Controls.Add(txtPassword);

            // Show password toggle
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.Gray;
            chkShowPassword.Location = new Point(60, 365);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(110, 19);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show password";
            chkShowPassword.UseVisualStyleBackColor = true;

            // Login
            btnLogin.NormalColor = Theme.Accent;
            btnLogin.HoverColor = Color.FromArgb(210, 90, 30);
            btnLogin.CornerRadius = 10;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(60, 405);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(260, 55);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;

            // Exit
            btnExit.NormalColor = Theme.Field;
            btnExit.HoverColor = Theme.Tint;
            btnExit.CornerRadius = 10;
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(60, 60, 60);
            btnExit.Location = new Point(330, 405);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 55);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;

            // Status
            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(60, 475);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(420, 40);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            pnlRight.Controls.Add(lblWelcome);
            pnlRight.Controls.Add(lblUserHint);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(pnlUsername);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(pnlPassword);
            pnlRight.Controls.Add(chkShowPassword);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(btnExit);
            pnlRight.Controls.Add(lblStatus);

            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 620);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel CRM — Sign In";

            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();

            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();

            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();

            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();

            ResumeLayout(false);
        }
    }
}