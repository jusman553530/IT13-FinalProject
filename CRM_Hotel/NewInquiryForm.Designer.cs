#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class NewInquiryForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblCustomer = null!;
        private ComboBox cmbCustomer = null!;
        private Label lblGuestName = null!;
        private TextBox txtGuestName = null!;
        private Label lblGuestContact = null!;
        private TextBox txtGuestContact = null!;
        private Label lblSource = null!;
        private ComboBox cmbSource = null!;
        private Label lblPriority = null!;
        private ComboBox cmbPriority = null!;
        private Label lblSubject = null!;
        private TextBox txtSubject = null!;
        private Label lblMessage = null!;
        private TextBox txtMessage = null!;
        private RoundedButton btnSave = null!;
        private RoundedButton btnCancel = null!;

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
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblGuestName = new Label();
            txtGuestName = new TextBox();
            lblGuestContact = new Label();
            txtGuestContact = new TextBox();
            lblSource = new Label();
            cmbSource = new ComboBox();
            lblPriority = new Label();
            cmbPriority = new ComboBox();
            lblSubject = new Label();
            txtSubject = new TextBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            ClientSize = new Size(560, 620);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewInquiryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Inquiry";

            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeading.ForeColor = Theme.TextDark;
            lblHeading.Location = new Point(25, 20);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 30);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Log New Inquiry";

            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomer.ForeColor = Theme.TextDark;
            lblCustomer.Location = new Point(25, 65);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer";

            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(25, 85);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(510, 25);
            cmbCustomer.TabIndex = 2;

            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGuestName.ForeColor = Theme.TextDark;
            lblGuestName.Location = new Point(25, 125);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(75, 15);
            lblGuestName.TabIndex = 3;
            lblGuestName.Text = "Guest Name *";

            txtGuestName.Font = new Font("Segoe UI", 9.5F);
            txtGuestName.Location = new Point(25, 145);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.Size = new Size(510, 24);
            txtGuestName.TabIndex = 4;

            lblGuestContact.AutoSize = true;
            lblGuestContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGuestContact.ForeColor = Theme.TextDark;
            lblGuestContact.Location = new Point(25, 185);
            lblGuestContact.Name = "lblGuestContact";
            lblGuestContact.Size = new Size(90, 15);
            lblGuestContact.TabIndex = 5;
            lblGuestContact.Text = "Guest Contact";

            txtGuestContact.Font = new Font("Segoe UI", 9.5F);
            txtGuestContact.Location = new Point(25, 205);
            txtGuestContact.Name = "txtGuestContact";
            txtGuestContact.Size = new Size(510, 24);
            txtGuestContact.TabIndex = 6;

            lblSource.AutoSize = true;
            lblSource.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSource.ForeColor = Theme.TextDark;
            lblSource.Location = new Point(25, 245);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(45, 15);
            lblSource.TabIndex = 7;
            lblSource.Text = "Source";

            cmbSource.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSource.Font = new Font("Segoe UI", 9.5F);
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(25, 265);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(245, 25);
            cmbSource.TabIndex = 8;

            lblPriority.AutoSize = true;
            lblPriority.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPriority.ForeColor = Theme.TextDark;
            lblPriority.Location = new Point(290, 245);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(50, 15);
            lblPriority.TabIndex = 9;
            lblPriority.Text = "Priority";

            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Font = new Font("Segoe UI", 9.5F);
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(290, 265);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(245, 25);
            cmbPriority.TabIndex = 10;

            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSubject.ForeColor = Theme.TextDark;
            lblSubject.Location = new Point(25, 305);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(55, 15);
            lblSubject.TabIndex = 11;
            lblSubject.Text = "Subject *";

            txtSubject.Font = new Font("Segoe UI", 9.5F);
            txtSubject.Location = new Point(25, 325);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(510, 24);
            txtSubject.TabIndex = 12;

            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMessage.ForeColor = Theme.TextDark;
            lblMessage.Location = new Point(25, 365);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(65, 15);
            lblMessage.TabIndex = 13;
            lblMessage.Text = "Message *";

            txtMessage.Font = new Font("Segoe UI", 9.5F);
            txtMessage.Location = new Point(25, 385);
            txtMessage.Multiline = true;
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(510, 140);
            txtMessage.TabIndex = 14;

            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(275, 545);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 45);
            btnSave.TabIndex = 15;
            btnSave.Text = "Log Inquiry";
            btnSave.UseVisualStyleBackColor = false;

            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Theme.TextDark;
            btnCancel.Location = new Point(415, 545);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            Controls.Add(lblHeading);
            Controls.Add(lblCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(lblGuestName);
            Controls.Add(txtGuestName);
            Controls.Add(lblGuestContact);
            Controls.Add(txtGuestContact);
            Controls.Add(lblSource);
            Controls.Add(cmbSource);
            Controls.Add(lblPriority);
            Controls.Add(cmbPriority);
            Controls.Add(lblSubject);
            Controls.Add(txtSubject);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}