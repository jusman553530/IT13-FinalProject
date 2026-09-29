#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblHint = null!;
        private Label lblNew = null!;
        private RoundedPanel pnlNew = null!;
        private TextBox txtNew = null!;
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
            lblHint = new Label();
            lblNew = new Label();
            pnlNew = new RoundedPanel();
            txtNew = new TextBox();
            lblConfirm = new Label();
            pnlConfirm = new RoundedPanel();
            txtConfirm = new TextBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatus = new Label();

            pnlNew.SuspendLayout();
            pnlConfirm.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 440);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ResetPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reset Password";

            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Reset Password";

            lblHint.AutoSize = false;
            lblHint.Font = new Font("Segoe UI", 9.5F);
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(38, 65);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(450, 40);
            lblHint.TabIndex = 1;
            lblHint.Text = "Set a temporary password. The user will be required to change it on next login.";

            lblNew.AutoSize = true;
            lblNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNew.ForeColor = Color.FromArgb(80, 80, 80);
            lblNew.Location = new Point(38, 120);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(90, 15);
            lblNew.TabIndex = 2;
            lblNew.Text = "New Password";

            pnlNew.BackColor = Theme.Field;
            pnlNew.BorderColor = Theme.Border;
            pnlNew.BorderThickness = 1;
            pnlNew.CornerRadius = 10;
            pnlNew.Location = new Point(35, 140);
            pnlNew.Name = "pnlNew";
            pnlNew.Size = new Size(450, 44);
            pnlNew.TabIndex = 3;

            txtNew.BackColor = Theme.Field;
            txtNew.BorderStyle = BorderStyle.None;
            txtNew.Font = new Font("Segoe UI", 10.5F);
            txtNew.Location = new Point(14, 12);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(420, 20);
            txtNew.TabIndex = 0;
            txtNew.UseSystemPasswordChar = true;

            pnlNew.Controls.Add(txtNew);

            lblConfirm.AutoSize = true;
            lblConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirm.ForeColor = Color.FromArgb(80, 80, 80);
            lblConfirm.Location = new Point(38, 200);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(130, 15);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Confirm Password";

            pnlConfirm.BackColor = Theme.Field;
            pnlConfirm.BorderColor = Theme.Border;
            pnlConfirm.BorderThickness = 1;
            pnlConfirm.CornerRadius = 10;
            pnlConfirm.Location = new Point(35, 220);
            pnlConfirm.Name = "pnlConfirm";
            pnlConfirm.Size = new Size(450, 44);
            pnlConfirm.TabIndex = 5;

            txtConfirm.BackColor = Theme.Field;
            txtConfirm.BorderStyle = BorderStyle.None;
            txtConfirm.Font = new Font("Segoe UI", 10.5F);
            txtConfirm.Location = new Point(14, 12);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(420, 20);
            txtConfirm.TabIndex = 0;
            txtConfirm.UseSystemPasswordChar = true;

            pnlConfirm.Controls.Add(txtConfirm);

            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(260, 50);
            btnSave.TabIndex = 6;
            btnSave.Text = "Reset Password";
            btnSave.UseVisualStyleBackColor = false;

            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(310, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(35, 355);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(450, 60);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "";

            Controls.Add(lblHeading);
            Controls.Add(lblHint);
            Controls.Add(lblNew);
            Controls.Add(pnlNew);
            Controls.Add(lblConfirm);
            Controls.Add(pnlConfirm);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);

            pnlNew.ResumeLayout(false);
            pnlNew.PerformLayout();
            pnlConfirm.ResumeLayout(false);
            pnlConfirm.PerformLayout();

            ResumeLayout(false);
        }
    }
}