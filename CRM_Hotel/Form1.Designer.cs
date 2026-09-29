#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM_Hotel
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlSidebar = null!;
        private Label lblLogo = null!;
        private Label lblHotel = null!;

        private RoundedButton btnCustomers = null!;
        private RoundedButton btnReservations = null!;
        private RoundedButton btnRooms = null!;
        private RoundedButton btnCheckInOut = null!;
        private RoundedButton btnFeedback = null!;
        private RoundedButton btnInquiries = null!;

        private Panel pnlContent = null!;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private Label lblRecords = null!;
        private Label lblSearch = null!;
        private RoundedPanel pnlSearch = null!;
        private TextBox txtSearch = null!;

        private RoundedButton btnRegister = null!;
        private RoundedButton btnUpdate = null!;
        private RoundedButton btnArchive = null!;

        private RoundedPanel pnlTable = null!;
        private DataGridView dgvCustomers = null!;

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
            lblHotel = new Label();

            btnCustomers = new RoundedButton();
            btnReservations = new RoundedButton();
            btnRooms = new RoundedButton();
            btnCheckInOut = new RoundedButton();
            btnFeedback = new RoundedButton();
            btnInquiries = new RoundedButton();

            pnlContent = new Panel();

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            lblRecords = new Label();
            lblSearch = new Label();

            pnlSearch = new RoundedPanel();
            txtSearch = new TextBox();

            btnRegister = new RoundedButton();
            btnUpdate = new RoundedButton();
            btnArchive = new RoundedButton();

            pnlTable = new RoundedPanel();
            dgvCustomers = new DataGridView();

            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlTable.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();

            SuspendLayout();

            // =====================================================
            // SIDEBAR
            // =====================================================

            pnlSidebar.BackColor = Theme.Sidebar;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 700);
            pnlSidebar.TabIndex = 0;

            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(lblHotel);
            pnlSidebar.Controls.Add(btnCustomers);
            pnlSidebar.Controls.Add(btnReservations);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnCheckInOut);
            pnlSidebar.Controls.Add(btnFeedback);
            pnlSidebar.Controls.Add(btnInquiries);

            // =====================================================
            // LOGO
            // =====================================================

            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI Emoji", 25F, FontStyle.Regular);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(50, 45);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🏨";

            // =====================================================
            // HOTEL NAME
            // =====================================================

            lblHotel.AutoSize = true;
            lblHotel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHotel.ForeColor = Color.White;
            lblHotel.Location = new Point(80, 34);
            lblHotel.Name = "lblHotel";
            lblHotel.Size = new Size(119, 28);
            lblHotel.TabIndex = 1;
            lblHotel.Text = "HOTEL CRM";

            // =====================================================
            // CUSTOMERS
            // =====================================================

            btnCustomers.BackColor = Theme.Primary;
            btnCustomers.NormalColor = Theme.Primary;
            btnCustomers.HoverColor = Theme.PrimaryHover;
            btnCustomers.CornerRadius = 10;
            btnCustomers.LeftAlign = true;
            btnCustomers.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Location = new Point(15, 120);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(200, 48);
            btnCustomers.TabIndex = 2;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += new EventHandler(btnCustomers_Click);

            // =====================================================
            // RESERVATIONS
            // =====================================================

            btnReservations.BackColor = Theme.Sidebar;
            btnReservations.NormalColor = Theme.Sidebar;
            btnReservations.HoverColor = Theme.SidebarHover;
            btnReservations.CornerRadius = 10;
            btnReservations.LeftAlign = true;
            btnReservations.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnReservations.ForeColor = Color.White;
            btnReservations.Location = new Point(15, 175);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(200, 48);
            btnReservations.TabIndex = 3;
            btnReservations.Text = "Reservations";
            btnReservations.UseVisualStyleBackColor = false;
            btnReservations.Click += new EventHandler(btnReservations_Click);

            // =====================================================
            // ROOMS
            // =====================================================

            btnRooms.BackColor = Theme.Sidebar;
            btnRooms.NormalColor = Theme.Sidebar;
            btnRooms.HoverColor = Theme.SidebarHover;
            btnRooms.CornerRadius = 10;
            btnRooms.LeftAlign = true;
            btnRooms.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnRooms.ForeColor = Color.White;
            btnRooms.Location = new Point(15, 230);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(200, 48);
            btnRooms.TabIndex = 4;
            btnRooms.Text = "Rooms";
            btnRooms.UseVisualStyleBackColor = false;
            btnRooms.Click += new EventHandler(btnRooms_Click);

            // =====================================================
            // CHECK IN / OUT
            // =====================================================

            btnCheckInOut.BackColor = Theme.Sidebar;
            btnCheckInOut.NormalColor = Theme.Sidebar;
            btnCheckInOut.HoverColor = Theme.SidebarHover;
            btnCheckInOut.CornerRadius = 10;
            btnCheckInOut.LeftAlign = true;
            btnCheckInOut.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCheckInOut.ForeColor = Color.White;
            btnCheckInOut.Location = new Point(15, 285);
            btnCheckInOut.Name = "btnCheckInOut";
            btnCheckInOut.Size = new Size(200, 48);
            btnCheckInOut.TabIndex = 5;
            btnCheckInOut.Text = "Check In / Out";
            btnCheckInOut.UseVisualStyleBackColor = false;
            btnCheckInOut.Click += new EventHandler(btnCheckInOut_Click);

            // =====================================================
            // FEEDBACK
            // =====================================================

            btnFeedback.BackColor = Theme.Sidebar;
            btnFeedback.NormalColor = Theme.Sidebar;
            btnFeedback.HoverColor = Theme.SidebarHover;
            btnFeedback.CornerRadius = 10;
            btnFeedback.LeftAlign = true;
            btnFeedback.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnFeedback.ForeColor = Color.White;
            btnFeedback.Location = new Point(15, 340);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.Size = new Size(200, 48);
            btnFeedback.TabIndex = 6;
            btnFeedback.Text = "Feedback";
            btnFeedback.UseVisualStyleBackColor = false;
            btnFeedback.Click += new EventHandler(btnFeedback_Click);

            // =====================================================
            // INQUIRIES
            // =====================================================

            btnInquiries.BackColor = Theme.Sidebar;
            btnInquiries.NormalColor = Theme.Sidebar;
            btnInquiries.HoverColor = Theme.SidebarHover;
            btnInquiries.CornerRadius = 10;
            btnInquiries.LeftAlign = true;
            btnInquiries.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnInquiries.ForeColor = Color.White;
            btnInquiries.Location = new Point(15, 395);
            btnInquiries.Name = "btnInquiries";
            btnInquiries.Size = new Size(200, 48);
            btnInquiries.TabIndex = 7;
            btnInquiries.Text = "Inquiries";
            btnInquiries.UseVisualStyleBackColor = false;
            btnInquiries.Click += new EventHandler(btnInquiries_Click);

            // =====================================================
            // CONTENT
            // =====================================================

            pnlContent.BackColor = Theme.Background;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(230, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(970, 700);
            pnlContent.TabIndex = 1;

            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Controls.Add(lblRecords);
            pnlContent.Controls.Add(lblSearch);
            pnlContent.Controls.Add(pnlSearch);
            pnlContent.Controls.Add(btnRegister);
            pnlContent.Controls.Add(btnUpdate);
            pnlContent.Controls.Add(btnArchive);
            pnlContent.Controls.Add(pnlTable);

            // =====================================================
            // HEADER
            // =====================================================

            pnlHeader.BackColor = Theme.Primary;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(970, 120);
            pnlHeader.TabIndex = 0;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // =====================================================
            // TITLE
            // =====================================================

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customers";

            // =====================================================
            // SUBTITLE
            // =====================================================

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 72);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(260, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage hotel customer information";

            // =====================================================
            // RECORDS
            // =====================================================

            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblRecords.ForeColor = Theme.TextDark;
            lblRecords.Location = new Point(35, 150);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(95, 31);
            lblRecords.TabIndex = 5;
            lblRecords.Text = "Records";

            // =====================================================
            // SEARCH LABEL
            // =====================================================

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Theme.TextDark;
            lblSearch.Location = new Point(35, 195);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(47, 15);
            lblSearch.TabIndex = 6;
            lblSearch.Text = "Search";

            // =====================================================
            // SEARCH PANEL
            // =====================================================

            pnlSearch.BackColor = Theme.Field;
            pnlSearch.BorderColor = Theme.Border;
            pnlSearch.BorderThickness = 1;
            pnlSearch.CornerRadius = 12;
            pnlSearch.Location = new Point(35, 218);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(400, 44);
            pnlSearch.TabIndex = 7;

            // =====================================================
            // SEARCH TEXTBOX
            // =====================================================

            txtSearch.BackColor = Theme.Field;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.Location = new Point(14, 12);
            txtSearch.Margin = new Padding(0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search customer...";
            txtSearch.Size = new Size(370, 18);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

            pnlSearch.Controls.Add(txtSearch);

            // =====================================================
            // REGISTER BUTTON
            // =====================================================

            btnRegister.NormalColor = Theme.Primary;
            btnRegister.HoverColor = Theme.PrimaryHover;
            btnRegister.CornerRadius = 10;
            btnRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(455, 218);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(145, 44);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "+ Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += new EventHandler(btnRegister_Click);

            // =====================================================
            // UPDATE BUTTON
            // =====================================================

            btnUpdate.NormalColor = Theme.Accent;
            btnUpdate.HoverColor = Theme.PrimaryHover;
            btnUpdate.CornerRadius = 10;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(610, 218);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 44);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += new EventHandler(btnUpdate_Click);

            // =====================================================
            // ARCHIVE BUTTON
            // =====================================================

            btnArchive.NormalColor = Theme.Danger;
            btnArchive.HoverColor = Color.FromArgb(160, 40, 40);
            btnArchive.CornerRadius = 10;
            btnArchive.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnArchive.ForeColor = Color.White;
            btnArchive.Location = new Point(755, 218);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(175, 44);
            btnArchive.TabIndex = 10;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = false;
            btnArchive.Click += new EventHandler(btnArchive_Click);

            // =====================================================
            // TABLE PANEL
            // =====================================================

            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;
            pnlTable.Location = new Point(35, 285);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(895, 365);
            pnlTable.TabIndex = 11;

            pnlTable.Controls.Add(dgvCustomers);

            // =====================================================
            // CUSTOMER TABLE
            // =====================================================

            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvCustomers.BackgroundColor = Theme.Card;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvCustomers.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };

            dgvCustomers.ColumnHeadersHeight = 44;
            dgvCustomers.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvCustomers.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };

            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Theme.Border;
            dgvCustomers.Location = new Point(10, 10);
            dgvCustomers.Margin = new Padding(0);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowTemplate.Height = 40;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(875, 345);
            dgvCustomers.TabIndex = 12;

            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel CRM";

            // =====================================================
            // RESUME
            // =====================================================

            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();

            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();

            pnlTable.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();

            ResumeLayout(false);
        }
    }
}