#nullable enable

using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CRM.winforms
{
    partial class AdminPlaceholderControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblBody = null!;

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

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblBody = new Label();

            pnlHeader.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // HEADER
            // =====================================================

            pnlHeader.BackColor = Theme.Primary;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(970, 110);
            pnlHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Page";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(300, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Coming soon";

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // =====================================================
            // BODY
            // =====================================================

            lblBody.AutoSize = false;
            lblBody.Dock = DockStyle.Fill;
            lblBody.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            lblBody.ForeColor = Color.Gray;
            lblBody.Name = "lblBody";
            lblBody.TabIndex = 1;
            lblBody.Text = "Coming soon";
            lblBody.TextAlign = ContentAlignment.MiddleCenter;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            Name = "AdminPlaceholderControl";
            Size = new Size(970, 700);

            Controls.Add(lblBody);
            Controls.Add(pnlHeader);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            ResumeLayout(false);
        }
    }
}