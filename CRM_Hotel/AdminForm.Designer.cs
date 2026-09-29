#nullable enable

using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;



namespace CRM_Hotel
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlSidebar = null!;
        private Label lblLogo = null!;
        private Label lblTitle = null!;

        private RoundedButton btnDashboard = null!;
        private RoundedButton btnUserManagement = null!;
        private RoundedButton btnTerms = null!;
        private RoundedButton btnGuests = null!;
        private RoundedButton btnRevenue = null!;
        private RoundedButton btnRetention = null!;
        private RoundedButton btnRooms = null!;
        private RoundedButton btnDiscounts = null!;
        private RoundedButton btnFeedbacks = null!;

        private Panel pnlContent = null!;

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

            pnlSidebar = new Panel();
            lblLogo = new Label();
            lblTitle = new Label();

            btnDashboard = new RoundedButton();
            btnUserManagement = new RoundedButton();
            btnTerms = new RoundedButton();
            btnGuests = new RoundedButton();
            btnRevenue = new RoundedButton();
            btnRetention = new RoundedButton();
            btnRooms = new RoundedButton();
            btnDiscounts = new RoundedButton();
            btnFeedbacks = new RoundedButton();

            pnlContent = new Panel();

            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // SIDEBAR
            // =====================================================

            pnlSidebar.BackColor = Theme.Sidebar;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(240, 720);
            pnlSidebar.TabIndex = 0;

            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(lblTitle);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnUserManagement);
            pnlSidebar.Controls.Add(btnTerms);
            pnlSidebar.Controls.Add(btnGuests);
            pnlSidebar.Controls.Add(btnRevenue);
            pnlSidebar.Controls.Add(btnRetention);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnDiscounts);
            pnlSidebar.Controls.Add(btnFeedbacks);

            // Logo
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI Emoji", 22F, FontStyle.Regular);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 22);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(45, 40);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🛡️";

            // Title
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(75, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(140, 23);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "ADMIN";

            // Sidebar buttons
            ConfigureSidebarButton(btnDashboard, "Dashboard", 90, 0);
            ConfigureSidebarButton(btnUserManagement, "User Management", 140, 1);
            ConfigureSidebarButton(btnTerms, "Terms && Conditions", 190, 2);
            ConfigureSidebarButton(btnGuests, "Manage Guests Record", 240, 3);
            ConfigureSidebarButton(btnRevenue, "View Revenue Reports", 290, 4);
            ConfigureSidebarButton(btnRetention, "Customer Retention", 340, 5);
            ConfigureSidebarButton(btnRooms, "Manage Rooms", 390, 6);
            ConfigureSidebarButton(btnDiscounts, "Manage Discounts", 440, 7);
            ConfigureSidebarButton(btnFeedbacks, "Manage Customer Feedbacks", 490, 8);

            // =====================================================
            // CONTENT
            // =====================================================

            pnlContent.BackColor = Theme.Background;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(240, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(970, 720);
            pnlContent.TabIndex = 1;

            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            ClientSize = new Size(1210, 720);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel CRM — Admin Console";

            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();

            pnlContent.ResumeLayout(false);

            ResumeLayout(false);
        }

        private void ConfigureSidebarButton(RoundedButton btn, string text, int y, int index)
        {
            btn.BackColor = Theme.Sidebar;
            btn.NormalColor = Theme.Sidebar;
            btn.HoverColor = Theme.SidebarHover;
            btn.CornerRadius = 10;
            btn.LeftAlign = true;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Location = new Point(15, y);
            btn.Name = "btnAdmin" + index;
            btn.Size = new Size(210, 42);
            btn.TabIndex = 2 + index;
            btn.Text = text;
            btn.UseVisualStyleBackColor = false;
        }
    }
}