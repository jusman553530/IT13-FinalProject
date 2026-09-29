#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class CollectPaymentForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblSummary = null!;

        private Label lblAmount = null!;
        private RoundedPanel pnlAmount = null!;
        private TextBox txtAmount = null!;

        private Label lblMethod = null!;
        private ComboBox cmbMethod = null!;

        private Label lblNotes = null!;
        private TextBox txtNotes = null!;

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
            lblSummary = new Label();
            lblAmount = new Label();
            pnlAmount = new RoundedPanel();
            txtAmount = new TextBox();
            lblMethod = new Label();
            cmbMethod = new ComboBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnSave = new RoundedButton();
            btnCancel = new RoundedButton();
            lblStatus = new Label();

            pnlAmount.SuspendLayout();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 540);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CollectPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Collect Payment";

            // -----------------------------------------------------
            // HEADING
            // -----------------------------------------------------

            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(35, 25);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Collect Payment";

            // -----------------------------------------------------
            // SUMMARY
            // -----------------------------------------------------

            lblSummary.AutoSize = false;
            lblSummary.Font = new Font("Segoe UI", 10F);
            lblSummary.ForeColor = Color.Gray;
            lblSummary.Location = new Point(38, 65);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(450, 60);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "";

            // -----------------------------------------------------
            // AMOUNT
            // -----------------------------------------------------

            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(80, 80, 80);
            lblAmount.Location = new Point(38, 140);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(90, 15);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount (₱) *";

            pnlAmount.BackColor = Theme.Field;
            pnlAmount.BorderColor = Theme.Border;
            pnlAmount.BorderThickness = 1;
            pnlAmount.CornerRadius = 10;
            pnlAmount.Location = new Point(35, 160);
            pnlAmount.Name = "pnlAmount";
            pnlAmount.Size = new Size(450, 44);
            pnlAmount.TabIndex = 3;

            txtAmount.BackColor = Theme.Field;
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Font = new Font("Segoe UI", 11F);
            txtAmount.Location = new Point(14, 12);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(420, 20);
            txtAmount.TabIndex = 0;

            pnlAmount.Controls.Add(txtAmount);

            // -----------------------------------------------------
            // METHOD
            // -----------------------------------------------------

            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMethod.ForeColor = Color.FromArgb(80, 80, 80);
            lblMethod.Location = new Point(38, 220);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(55, 15);
            lblMethod.TabIndex = 4;
            lblMethod.Text = "Method";

            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.Font = new Font("Segoe UI", 10.5F);
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Location = new Point(35, 240);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(450, 27);
            cmbMethod.TabIndex = 5;

            // -----------------------------------------------------
            // NOTES
            // -----------------------------------------------------

            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.ForeColor = Color.FromArgb(80, 80, 80);
            lblNotes.Location = new Point(38, 290);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(42, 15);
            lblNotes.TabIndex = 6;
            lblNotes.Text = "Notes";

            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(35, 310);
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(450, 80);
            txtNotes.TabIndex = 7;

            // -----------------------------------------------------
            // SAVE
            // -----------------------------------------------------

            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(260, 50);
            btnSave.TabIndex = 8;
            btnSave.Text = "Record Payment";
            btnSave.UseVisualStyleBackColor = false;

            // -----------------------------------------------------
            // CANCEL
            // -----------------------------------------------------

            btnCancel.NormalColor = Theme.Field;
            btnCancel.HoverColor = Theme.Tint;
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancel.Location = new Point(310, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 50);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            // -----------------------------------------------------
            // STATUS
            // -----------------------------------------------------

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point(35, 475);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(450, 50);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "";

            // -----------------------------------------------------
            // ADD CONTROLS
            // -----------------------------------------------------

            Controls.Add(lblHeading);
            Controls.Add(lblSummary);
            Controls.Add(lblAmount);
            Controls.Add(pnlAmount);
            Controls.Add(lblMethod);
            Controls.Add(cmbMethod);
            Controls.Add(lblNotes);
            Controls.Add(txtNotes);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);

            pnlAmount.ResumeLayout(false);
            pnlAmount.PerformLayout();

            ResumeLayout(false);
        }
    }
}