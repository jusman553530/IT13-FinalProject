#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ManageRoomsControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblCounter = null!;
        private RoundedButton btnAddRoom = null!;

        private Label lblSearch = null!;
        private RoundedPanel pnlSearch = null!;
        private TextBox txtSearch = null!;

        private Label lblTypeFilter = null!;
        private ComboBox cmbTypeFilter = null!;

        private Label lblStatusFilter = null!;
        private ComboBox cmbStatusFilter = null!;

        private RoundedPanel pnlTable = null!;
        private DataGridView dgvRooms = null!;

        private RoundedButton btnEdit = null!;
        private RoundedButton btnBulkPrice = null!;
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
            btnAddRoom = new RoundedButton();

            lblSearch = new Label();
            pnlSearch = new RoundedPanel();
            txtSearch = new TextBox();

            lblTypeFilter = new Label();
            cmbTypeFilter = new ComboBox();

            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();

            pnlTable = new RoundedPanel();
            dgvRooms = new DataGridView();

            btnEdit = new RoundedButton();
            btnBulkPrice = new RoundedButton();
            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();

            SuspendLayout();

            // HEADER
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
            lblTitle.Size = new Size(250, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Rooms";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Add rooms, adjust pricing, and control status";

            lblCounter.AutoSize = false;
            lblCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCounter.ForeColor = Theme.Tint;
            lblCounter.Location = new Point(650, 40);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(180, 30);
            lblCounter.TabIndex = 2;
            lblCounter.Text = "0 rooms";
            lblCounter.TextAlign = ContentAlignment.MiddleRight;

            btnAddRoom.NormalColor = Theme.Accent;
            btnAddRoom.HoverColor = Color.FromArgb(210, 90, 30);
            btnAddRoom.CornerRadius = 10;
            btnAddRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddRoom.ForeColor = Color.White;
            btnAddRoom.Location = new Point(840, 35);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(95, 40);
            btnAddRoom.TabIndex = 3;
            btnAddRoom.Text = "+ Add";
            btnAddRoom.UseVisualStyleBackColor = false;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblCounter);
            pnlHeader.Controls.Add(btnAddRoom);

            // FILTERS
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
            pnlSearch.Size = new Size(360, 44);
            pnlSearch.TabIndex = 2;

            txtSearch.BackColor = Theme.Field;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.Location = new Point(14, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search room number...";
            txtSearch.Size = new Size(330, 18);
            txtSearch.TabIndex = 0;

            pnlSearch.Controls.Add(txtSearch);

            lblTypeFilter.AutoSize = true;
            lblTypeFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTypeFilter.ForeColor = Theme.TextDark;
            lblTypeFilter.Location = new Point(415, 140);
            lblTypeFilter.Name = "lblTypeFilter";
            lblTypeFilter.Size = new Size(70, 15);
            lblTypeFilter.TabIndex = 3;
            lblTypeFilter.Text = "Room Type";

            cmbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeFilter.Font = new Font("Segoe UI", 10F);
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Location = new Point(415, 160);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(180, 25);
            cmbTypeFilter.TabIndex = 4;

            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusFilter.ForeColor = Theme.TextDark;
            lblStatusFilter.Location = new Point(615, 140);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(42, 15);
            lblStatusFilter.TabIndex = 5;
            lblStatusFilter.Text = "Status";

            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(615, 160);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(180, 25);
            cmbStatusFilter.TabIndex = 6;

            // TABLE
            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;
            pnlTable.Location = new Point(35, 220);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(900, 470);
            pnlTable.TabIndex = 7;

            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeRows = false;
            dgvRooms.BackgroundColor = Theme.Card;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRooms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRooms.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvRooms.ColumnHeadersHeight = 44;
            dgvRooms.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRooms.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.GridColor = Theme.Border;
            dgvRooms.Location = new Point(10, 10);
            dgvRooms.Margin = new Padding(0);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowTemplate.Height = 40;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(880, 450);
            dgvRooms.TabIndex = 0;
            dgvRooms.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            pnlTable.Controls.Add(dgvRooms);

            // BUTTONS
            btnEdit.NormalColor = Theme.Primary;
            btnEdit.HoverColor = Theme.PrimaryHover;
            btnEdit.CornerRadius = 10;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(35, 705);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(140, 44);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;

            btnBulkPrice.NormalColor = Theme.Accent;
            btnBulkPrice.HoverColor = Color.FromArgb(210, 90, 30);
            btnBulkPrice.CornerRadius = 10;
            btnBulkPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBulkPrice.ForeColor = Color.White;
            btnBulkPrice.Location = new Point(185, 705);
            btnBulkPrice.Name = "btnBulkPrice";
            btnBulkPrice.Size = new Size(180, 44);
            btnBulkPrice.TabIndex = 9;
            btnBulkPrice.Text = "Bulk Price Update";
            btnBulkPrice.UseVisualStyleBackColor = false;

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(815, 705);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 44);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(375, 715);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(430, 25);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // USER CONTROL
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "ManageRoomsControl";
            Size = new Size(970, 780);

            Controls.Add(pnlHeader);
            Controls.Add(lblSearch);
            Controls.Add(pnlSearch);
            Controls.Add(lblTypeFilter);
            Controls.Add(cmbTypeFilter);
            Controls.Add(lblStatusFilter);
            Controls.Add(cmbStatusFilter);
            Controls.Add(pnlTable);
            Controls.Add(btnEdit);
            Controls.Add(btnBulkPrice);
            Controls.Add(btnRefresh);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}