#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class RoomEditForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;

        private Label lblNumber = null!;
        private RoundedPanel pnlNumber = null!;
        private TextBox txtNumber = null!;

        private Label lblType = null!;
        private ComboBox cmbType = null!;

        private Label lblPrice = null!;
        private RoundedPanel pnlPrice = null!;
        private TextBox txtPrice = null!;

        private Label lblStatus = null!;
        private ComboBox cmbStatus = null!;

        private RoundedButton btnSave = null!;
        private RoundedButton btnCancel = null!;
        private Label lblStatusMsg = null!;

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
            lblNumber = new Label();
            pnlNumber = new RoundedPanel();
            txtNumber = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            lblPrice = new Label();
            pnlPrice = new RoundedPanel();
            txtPrice = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatusMsg = new Label();

            pnlNumber.SuspendLayout();
            pnlPrice.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 540);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Room";

            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Add Room";

            // Room Number
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNumber.ForeColor = Color.FromArgb(80, 80, 80);
            lblNumber.Location = new Point(38, 85);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(100, 15);
            lblNumber.TabIndex = 1;
            lblNumber.Text = "Room Number *";

            pnlNumber.BackColor = Theme.Field;
            pnlNumber.BorderColor = Theme.Border;
            pnlNumber.BorderThickness = 1;
            pnlNumber.CornerRadius = 10;
            pnlNumber.Location = new Point(35, 105);
            pnlNumber.Name = "pnlNumber";
            pnlNumber.Size = new Size(430, 44);
            pnlNumber.TabIndex = 2;

            txtNumber.BackColor = Theme.Field;
            txtNumber.BorderStyle = BorderStyle.None;
            txtNumber.Font = new Font("Segoe UI", 10.5F);
            txtNumber.Location = new Point(14, 12);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(400, 20);
            txtNumber.TabIndex = 0;

            pnlNumber.Controls.Add(txtNumber);

            // Room Type
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblType.ForeColor = Color.FromArgb(80, 80, 80);
            lblType.Location = new Point(38, 165);
            lblType.Name = "lblType";
            lblType.Size = new Size(80, 15);
            lblType.TabIndex = 3;
            lblType.Text = "Room Type *";

            cmbType.DropDownStyle = ComboBoxStyle.DropDown;
            cmbType.Font = new Font("Segoe UI", 10.5F);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(35, 185);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(430, 27);
            cmbType.TabIndex = 4;

            // Price
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(80, 80, 80);
            lblPrice.Location = new Point(38, 235);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(110, 15);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price per Night (₱) *";

            pnlPrice.BackColor = Theme.Field;
            pnlPrice.BorderColor = Theme.Border;
            pnlPrice.BorderThickness = 1;
            pnlPrice.CornerRadius = 10;
            pnlPrice.Location = new Point(35, 255);
            pnlPrice.Name = "pnlPrice";
            pnlPrice.Size = new Size(430, 44);
            pnlPrice.TabIndex = 6;

            txtPrice.BackColor = Theme.Field;
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Font = new Font("Segoe UI", 10.5F);
            txtPrice.Location = new Point(14, 12);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(400, 20);
            txtPrice.TabIndex = 0;

            pnlPrice.Controls.Add(txtPrice);

            // Status
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(80, 80, 80);
            lblStatus.Location = new Point(38, 315);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10.5F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(35, 335);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(430, 27);
            cmbStatus.TabIndex = 8;

            // Save
            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 50);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;

            // Cancel
            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(265, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            // Status msg
            lblStatusMsg.AutoSize = false;
            lblStatusMsg.Font = new Font("Segoe UI", 9F);
            lblStatusMsg.ForeColor = Color.IndianRed;
            lblStatusMsg.Location = new Point(35, 460);
            lblStatusMsg.Name = "lblStatusMsg";
            lblStatusMsg.Size = new Size(430, 50);
            lblStatusMsg.TabIndex = 11;
            lblStatusMsg.Text = "";

            Controls.Add(lblHeading);
            Controls.Add(lblNumber);
            Controls.Add(pnlNumber);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(lblPrice);
            Controls.Add(pnlPrice);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblStatusMsg);

            pnlNumber.ResumeLayout(false);
            pnlNumber.PerformLayout();
            pnlPrice.ResumeLayout(false);
            pnlPrice.PerformLayout();

            ResumeLayout(false);
        }
    }
}