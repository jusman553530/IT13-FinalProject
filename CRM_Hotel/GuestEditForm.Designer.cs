#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class GuestEditForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblFirst = null!;
        private RoundedPanel pnlFirst = null!;
        private TextBox txtFirst = null!;
        private Label lblMiddle = null!;
        private RoundedPanel pnlMiddle = null!;
        private TextBox txtMiddle = null!;
        private Label lblLast = null!;
        private RoundedPanel pnlLast = null!;
        private TextBox txtLast = null!;
        private Label lblContact = null!;
        private RoundedPanel pnlContact = null!;
        private TextBox txtContact = null!;
        private Label lblEmail = null!;
        private RoundedPanel pnlEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblAddress = null!;
        private TextBox txtAddress = null!;
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
            lblFirst = new Label();
            pnlFirst = new RoundedPanel();
            txtFirst = new TextBox();
            lblMiddle = new Label();
            pnlMiddle = new RoundedPanel();
            txtMiddle = new TextBox();
            lblLast = new Label();
            pnlLast = new RoundedPanel();
            txtLast = new TextBox();
            lblContact = new Label();
            pnlContact = new RoundedPanel();
            txtContact = new TextBox();
            lblEmail = new Label();
            pnlEmail = new RoundedPanel();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatus = new Label();

            pnlFirst.SuspendLayout();
            pnlMiddle.SuspendLayout();
            pnlLast.SuspendLayout();
            pnlContact.SuspendLayout();
            pnlEmail.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 620);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GuestEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Guest";

            // Heading
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Add Guest";

            // First name
            lblFirst.AutoSize = true;
            lblFirst.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirst.ForeColor = Color.FromArgb(80, 80, 80);
            lblFirst.Location = new Point(38, 85);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(75, 15);
            lblFirst.TabIndex = 1;
            lblFirst.Text = "First Name *";

            pnlFirst.BackColor = Theme.Field;
            pnlFirst.BorderColor = Theme.Border;
            pnlFirst.BorderThickness = 1;
            pnlFirst.CornerRadius = 10;
            pnlFirst.Location = new Point(35, 105);
            pnlFirst.Name = "pnlFirst";
            pnlFirst.Size = new Size(170, 44);
            pnlFirst.TabIndex = 2;

            txtFirst.BackColor = Theme.Field;
            txtFirst.BorderStyle = BorderStyle.None;
            txtFirst.Font = new Font("Segoe UI", 10.5F);
            txtFirst.Location = new Point(14, 12);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(140, 20);
            txtFirst.TabIndex = 0;

            pnlFirst.Controls.Add(txtFirst);

            // Middle name
            lblMiddle.AutoSize = true;
            lblMiddle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMiddle.ForeColor = Color.FromArgb(80, 80, 80);
            lblMiddle.Location = new Point(218, 85);
            lblMiddle.Name = "lblMiddle";
            lblMiddle.Size = new Size(80, 15);
            lblMiddle.TabIndex = 3;
            lblMiddle.Text = "Middle Name";

            pnlMiddle.BackColor = Theme.Field;
            pnlMiddle.BorderColor = Theme.Border;
            pnlMiddle.BorderThickness = 1;
            pnlMiddle.CornerRadius = 10;
            pnlMiddle.Location = new Point(215, 105);
            pnlMiddle.Name = "pnlMiddle";
            pnlMiddle.Size = new Size(170, 44);
            pnlMiddle.TabIndex = 4;

            txtMiddle.BackColor = Theme.Field;
            txtMiddle.BorderStyle = BorderStyle.None;
            txtMiddle.Font = new Font("Segoe UI", 10.5F);
            txtMiddle.Location = new Point(14, 12);
            txtMiddle.Name = "txtMiddle";
            txtMiddle.Size = new Size(140, 20);
            txtMiddle.TabIndex = 0;

            pnlMiddle.Controls.Add(txtMiddle);

            // Last name
            lblLast.AutoSize = true;
            lblLast.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLast.ForeColor = Color.FromArgb(80, 80, 80);
            lblLast.Location = new Point(398, 85);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(75, 15);
            lblLast.TabIndex = 5;
            lblLast.Text = "Last Name *";

            pnlLast.BackColor = Theme.Field;
            pnlLast.BorderColor = Theme.Border;
            pnlLast.BorderThickness = 1;
            pnlLast.CornerRadius = 10;
            pnlLast.Location = new Point(395, 105);
            pnlLast.Name = "pnlLast";
            pnlLast.Size = new Size(170, 44);
            pnlLast.TabIndex = 6;

            txtLast.BackColor = Theme.Field;
            txtLast.BorderStyle = BorderStyle.None;
            txtLast.Font = new Font("Segoe UI", 10.5F);
            txtLast.Location = new Point(14, 12);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(140, 20);
            txtLast.TabIndex = 0;

            pnlLast.Controls.Add(txtLast);

            // Contact
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(80, 80, 80);
            lblContact.Location = new Point(38, 170);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(100, 15);
            lblContact.TabIndex = 7;
            lblContact.Text = "Contact Number *";

            pnlContact.BackColor = Theme.Field;
            pnlContact.BorderColor = Theme.Border;
            pnlContact.BorderThickness = 1;
            pnlContact.CornerRadius = 10;
            pnlContact.Location = new Point(35, 190);
            pnlContact.Name = "pnlContact";
            pnlContact.Size = new Size(240, 44);
            pnlContact.TabIndex = 8;

            txtContact.BackColor = Theme.Field;
            txtContact.BorderStyle = BorderStyle.None;
            txtContact.Font = new Font("Segoe UI", 10.5F);
            txtContact.Location = new Point(14, 12);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(210, 20);
            txtContact.TabIndex = 0;

            pnlContact.Controls.Add(txtContact);

            // Email
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(80, 80, 80);
            lblEmail.Location = new Point(290, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(40, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";

            pnlEmail.BackColor = Theme.Field;
            pnlEmail.BorderColor = Theme.Border;
            pnlEmail.BorderThickness = 1;
            pnlEmail.CornerRadius = 10;
            pnlEmail.Location = new Point(287, 190);
            pnlEmail.Name = "pnlEmail";
            pnlEmail.Size = new Size(278, 44);
            pnlEmail.TabIndex = 10;

            txtEmail.BackColor = Theme.Field;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.Location = new Point(14, 12);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(248, 20);
            txtEmail.TabIndex = 0;

            pnlEmail.Controls.Add(txtEmail);

            // Address
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(80, 80, 80);
            lblAddress.Location = new Point(38, 255);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(55, 15);
            lblAddress.TabIndex = 11;
            lblAddress.Text = "Address";

            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(35, 275);
            txtAddress.Multiline = true;
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(530, 90);
            txtAddress.TabIndex = 12;

            // Save
            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 395);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(265, 50);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;

            // Cancel
            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(310, 395);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(255, 50);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            // Status
            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(35, 460);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(530, 55);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "";

            Controls.Add(lblHeading);
            Controls.Add(lblFirst);
            Controls.Add(pnlFirst);
            Controls.Add(lblMiddle);
            Controls.Add(pnlMiddle);
            Controls.Add(lblLast);
            Controls.Add(pnlLast);
            Controls.Add(lblContact);
            Controls.Add(pnlContact);
            Controls.Add(lblEmail);
            Controls.Add(pnlEmail);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);

            pnlFirst.ResumeLayout(false);
            pnlFirst.PerformLayout();
            pnlMiddle.ResumeLayout(false);
            pnlMiddle.PerformLayout();
            pnlLast.ResumeLayout(false);
            pnlLast.PerformLayout();
            pnlContact.ResumeLayout(false);
            pnlContact.PerformLayout();
            pnlEmail.ResumeLayout(false);
            pnlEmail.PerformLayout();

            ResumeLayout(false);
        }
    }
}