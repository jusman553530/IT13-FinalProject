#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ManageUsersControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblCounter = null!;
        private RoundedButton btnAddUser = null!;

        private Label lblSearch = null!;
        private RoundedPanel pnlSearch = null!;
        private TextBox txtSearch = null!;

        private Label lblRoleFilter = null!;
        private ComboBox cmbRoleFilter = null!;

        private RoundedPanel pnlTable = null!;
        private DataGridView dgvUsers = null!;

        private RoundedButton btnEdit = null!;
        private RoundedButton btnResetPassword = null!;
        private RoundedButton btnToggleActive = null!;
        private RoundedButton btnRefresh = null!;

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

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblCounter = new Label();
            btnAddUser = new RoundedButton();

            lblSearch = new Label();
            pnlSearch = new RoundedPanel();
            txtSearch = new TextBox();

            lblRoleFilter = new Label();
            cmbRoleFilter = new ComboBox();

            pnlTable = new RoundedPanel();
            dgvUsers = new DataGridView();

            btnEdit = new RoundedButton();
            btnResetPassword = new RoundedButton();
            btnToggleActive = new RoundedButton();
            btnRefresh = new RoundedButton();

            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();

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
            lblTitle.Size = new Size(280, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User Management";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Add, edit, and manage staff accounts";

            lblCounter.AutoSize = false;
            lblCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCounter.ForeColor = Theme.Tint;
            lblCounter.Location = new Point(650, 40);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(180, 30);
            lblCounter.TabIndex = 2;
            lblCounter.Text = "0 users";
            lblCounter.TextAlign = ContentAlignment.MiddleRight;

            btnAddUser.NormalColor = Theme.Accent;
            btnAddUser.HoverColor = Color.FromArgb(210, 90, 30);
            btnAddUser.CornerRadius = 10;
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(840, 35);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(95, 40);
            btnAddUser.TabIndex = 3;
            btnAddUser.Text = "+ Add";
            btnAddUser.UseVisualStyleBackColor = false;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblCounter);
            pnlHeader.Controls.Add(btnAddUser);

            // =====================================================
            // SEARCH
            // =====================================================

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Theme.TextDark;
            lblSearch.Location = new Point(35, 140);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(47, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";

            pnlSearch.BackColor = Theme.Field;
            pnlSearch.BorderColor = Theme.Border;
            pnlSearch.BorderThickness = 1;
            pnlSearch.CornerRadius = 12;
            pnlSearch.Location = new Point(35, 160);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(400, 44);
            pnlSearch.TabIndex = 2;

            txtSearch.BackColor = Theme.Field;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.Location = new Point(14, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search username or full name...";
            txtSearch.Size = new Size(370, 18);
            txtSearch.TabIndex = 0;

            pnlSearch.Controls.Add(txtSearch);

            // Role filter
            lblRoleFilter.AutoSize = true;
            lblRoleFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoleFilter.ForeColor = Theme.TextDark;
            lblRoleFilter.Location = new Point(455, 140);
            lblRoleFilter.Name = "lblRoleFilter";
            lblRoleFilter.Size = new Size(30, 15);
            lblRoleFilter.TabIndex = 3;
            lblRoleFilter.Text = "Role";

            cmbRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoleFilter.Font = new Font("Segoe UI", 10F);
            cmbRoleFilter.FormattingEnabled = true;
            cmbRoleFilter.Location = new Point(455, 160);
            cmbRoleFilter.Name = "cmbRoleFilter";
            cmbRoleFilter.Size = new Size(180, 25);
            cmbRoleFilter.TabIndex = 4;

            // =====================================================
            // TABLE
            // =====================================================

            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;
            pnlTable.Location = new Point(35, 220);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(900, 470);
            pnlTable.TabIndex = 5;

            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.BackgroundColor = Theme.Card;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvUsers.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Theme.Primary,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    SelectionBackColor = Theme.Primary,
                    SelectionForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(8, 0, 8, 0)
                };

            dgvUsers.ColumnHeadersHeight = 44;
            dgvUsers.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsers.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Theme.Card,
                    ForeColor = Theme.TextDark,
                    SelectionBackColor = Theme.Tint,
                    SelectionForeColor = Theme.Primary,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    Padding = new Padding(8, 0, 8, 0)
                };

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Theme.Border;
            dgvUsers.Location = new Point(10, 10);
            dgvUsers.Margin = new Padding(0);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(880, 450);
            dgvUsers.TabIndex = 0;
            dgvUsers.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            pnlTable.Controls.Add(dgvUsers);

            // =====================================================
            // ACTION BUTTONS
            // =====================================================

            btnEdit.NormalColor = Theme.Primary;
            btnEdit.HoverColor = Theme.PrimaryHover;
            btnEdit.CornerRadius = 10;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(35, 705);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(140, 44);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;

            btnResetPassword.NormalColor = Theme.Accent;
            btnResetPassword.HoverColor = Color.FromArgb(210, 90, 30);
            btnResetPassword.CornerRadius = 10;
            btnResetPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(185, 705);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(180, 44);
            btnResetPassword.TabIndex = 7;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;

            btnToggleActive.NormalColor = Theme.Danger;
            btnToggleActive.HoverColor = Color.FromArgb(160, 40, 40);
            btnToggleActive.CornerRadius = 10;
            btnToggleActive.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnToggleActive.ForeColor = Color.White;
            btnToggleActive.Location = new Point(375, 705);
            btnToggleActive.Name = "btnToggleActive";
            btnToggleActive.Size = new Size(180, 44);
            btnToggleActive.TabIndex = 8;
            btnToggleActive.Text = "Deactivate";
            btnToggleActive.UseVisualStyleBackColor = false;

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(815, 705);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 44);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(565, 715);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(240, 25);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "ManageUsersControl";
            Size = new Size(970, 780);

            Controls.Add(pnlHeader);
            Controls.Add(lblSearch);
            Controls.Add(pnlSearch);
            Controls.Add(lblRoleFilter);
            Controls.Add(cmbRoleFilter);
            Controls.Add(pnlTable);
            Controls.Add(btnEdit);
            Controls.Add(btnResetPassword);
            Controls.Add(btnToggleActive);
            Controls.Add(btnRefresh);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();

            pnlTable.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}