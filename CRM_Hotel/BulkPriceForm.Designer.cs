#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class BulkPriceForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblIntro = null!;

        private Label lblType = null!;
        private ComboBox cmbType = null!;

        private Label lblPrice = null!;
        private RoundedPanel pnlPrice = null!;
        private TextBox txtPrice = null!;

        private Label lblAffected = null!;

        private RoundedButton btnApply = null!;
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
            lblIntro = new Label();
            lblType = new Label();
            cmbType = new ComboBox();
            lblPrice = new Label();
            pnlPrice = new RoundedPanel();
            txtPrice = new TextBox();
            lblAffected = new Label();
            btnApply = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatusMsg = new Label();

            pnlPrice.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 460);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BulkPriceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bulk Price Update";

            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(250, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Bulk Price Update";

            lblIntro.AutoSize = false;
            lblIntro.Font = new Font("Segoe UI", 9.5F);
            lblIntro.ForeColor = Color.Gray;
            lblIntro.Location = new Point(38, 65);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(430, 45);
            lblIntro.TabIndex = 1;
            lblIntro.Text = "Set a new nightly rate for all rooms of a selected type.";

            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblType.ForeColor = Color.FromArgb(80, 80, 80);
            lblType.Location = new Point(38, 120);
            lblType.Name = "lblType";
            lblType.Size = new Size(80, 15);
            lblType.TabIndex = 2;
            lblType.Text = "Room Type";

            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Segoe UI", 10.5F);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(35, 140);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(430, 27);
            cmbType.TabIndex = 3;

            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(80, 80, 80);
            lblPrice.Location = new Point(38, 190);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(110, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "New Price (₱) *";

            pnlPrice.BackColor = Theme.Field;
            pnlPrice.BorderColor = Theme.Border;
            pnlPrice.BorderThickness = 1;
            pnlPrice.CornerRadius = 10;
            pnlPrice.Location = new Point(35, 210);
            pnlPrice.Name = "pnlPrice";
            pnlPrice.Size = new Size(430, 44);
            pnlPrice.TabIndex = 5;

            txtPrice.BackColor = Theme.Field;
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Font = new Font("Segoe UI", 10.5F);
            txtPrice.Location = new Point(14, 12);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(400, 20);
            txtPrice.TabIndex = 0;

            pnlPrice.Controls.Add(txtPrice);

            lblAffected.AutoSize = false;
            lblAffected.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblAffected.ForeColor = Color.DarkOrange;
            lblAffected.Location = new Point(38, 270);
            lblAffected.Name = "lblAffected";
            lblAffected.Size = new Size(430, 20);
            lblAffected.TabIndex = 6;
            lblAffected.Text = "—";

            btnApply.NormalColor = Theme.Accent;
            btnApply.HoverColor = Color.FromArgb(210, 90, 30);
            btnApply.CornerRadius = 10;
            btnApply.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(35, 305);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(220, 50);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply to All";
            btnApply.UseVisualStyleBackColor = false;

            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(265, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            lblStatusMsg.AutoSize = false;
            lblStatusMsg.Font = new Font("Segoe UI", 9F);
            lblStatusMsg.ForeColor = Color.IndianRed;
            lblStatusMsg.Location = new Point(35, 365);
            lblStatusMsg.Name = "lblStatusMsg";
            lblStatusMsg.Size = new Size(430, 60);
            lblStatusMsg.TabIndex = 9;
            lblStatusMsg.Text = "";

            Controls.Add(lblHeading);
            Controls.Add(lblIntro);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(lblPrice);
            Controls.Add(pnlPrice);
            Controls.Add(lblAffected);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(lblStatusMsg);

            pnlPrice.ResumeLayout(false);
            pnlPrice.PerformLayout();

            ResumeLayout(false);
        }
    }
}