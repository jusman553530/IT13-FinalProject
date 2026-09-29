#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRM.winforms
{
    partial class InquiryCard
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlStripe = null!;
        private Label lblGuest = null!;
        private Label lblTimeAgo = null!;
        private Label lblSubject = null!;
        private Label lblPriority = null!;
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

            pnlStripe = new Panel();
            lblGuest = new Label();
            lblTimeAgo = new Label();
            lblSubject = new Label();
            lblPriority = new Label();
            lblStatus = new Label();

            SuspendLayout();

            // =====================================================
            // CARD
            // =====================================================

            BackColor = Color.White;
            Margin = new Padding(0, 0, 0, 8);
            Name = "InquiryCard";
            Size = new Size(300, 92);
            Cursor = Cursors.Hand;
            Padding = new Padding(0);

            // =====================================================
            // PRIORITY STRIPE (left edge)
            // =====================================================

            pnlStripe.BackColor = Color.Gray;
            pnlStripe.Dock = DockStyle.Left;
            pnlStripe.Location = new Point(0, 0);
            pnlStripe.Name = "pnlStripe";
            pnlStripe.Size = new Size(5, 92);
            pnlStripe.TabIndex = 0;

            // =====================================================
            // GUEST
            // =====================================================

            lblGuest.AutoSize = true;
            lblGuest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuest.ForeColor = Color.FromArgb(30, 30, 30);
            lblGuest.Location = new Point(18, 12);
            lblGuest.Name = "lblGuest";
            lblGuest.Size = new Size(90, 17);
            lblGuest.TabIndex = 1;
            lblGuest.Text = "Guest";

            // =====================================================
            // TIME AGO
            // =====================================================

            lblTimeAgo.AutoSize = false;
            lblTimeAgo.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            lblTimeAgo.ForeColor = Color.Gray;
            lblTimeAgo.Location = new Point(180, 15);
            lblTimeAgo.Name = "lblTimeAgo";
            lblTimeAgo.Size = new Size(105, 15);
            lblTimeAgo.TabIndex = 2;
            lblTimeAgo.Text = "now";
            lblTimeAgo.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // SUBJECT
            // =====================================================

            lblSubject.AutoSize = false;
            lblSubject.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSubject.ForeColor = Color.FromArgb(80, 80, 80);
            lblSubject.Location = new Point(18, 36);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(230, 17);
            lblSubject.TabIndex = 3;
            lblSubject.Text = "Subject";

            // =====================================================
            // PRIORITY (right edge of subject line)
            // =====================================================

            lblPriority.AutoSize = false;
            lblPriority.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblPriority.ForeColor = Color.Orange;
            lblPriority.Location = new Point(250, 36);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(40, 17);
            lblPriority.TabIndex = 4;
            lblPriority.Text = "HIGH";
            lblPriority.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // STATUS PILL
            // =====================================================

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatus.ForeColor = Color.White;
            lblStatus.BackColor = Color.SteelBlue;
            lblStatus.Location = new Point(18, 62);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "NEW";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            Controls.Add(lblGuest);
            Controls.Add(lblTimeAgo);
            Controls.Add(lblSubject);
            Controls.Add(lblPriority);
            Controls.Add(lblStatus);
            Controls.Add(pnlStripe);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}