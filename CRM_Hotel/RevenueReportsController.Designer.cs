#nullable enable

using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CRM.winforms
{
    partial class RevenueReportsControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblRange = null!;

        // Filter row
        private Label lblPreset = null!;
        private ComboBox cmbPreset = null!;
        private Label lblFrom = null!;
        private DateTimePicker dtpFrom = null!;
        private Label lblTo = null!;
        private DateTimePicker dtpTo = null!;
        private Label lblRoomType = null!;
        private ComboBox cmbRoomType = null!;
        private RoundedButton btnApply = null!;

        // KPI cards
        private RoundedPanel pnlKpi1 = null!;
        private Label lblKpi1Value = null!;
        private Label lblKpi1Caption = null!;

        private RoundedPanel pnlKpi2 = null!;
        private Label lblKpi2Value = null!;
        private Label lblKpi2Caption = null!;

        private RoundedPanel pnlKpi3 = null!;
        private Label lblKpi3Value = null!;
        private Label lblKpi3Caption = null!;

        private RoundedPanel pnlKpi4 = null!;
        private Label lblKpi4Value = null!;
        private Label lblKpi4Caption = null!;

        private RoundedPanel pnlKpi5 = null!;
        private Label lblKpi5Value = null!;
        private Label lblKpi5Caption = null!;

        // Mid panels
        private RoundedPanel pnlByRoomType = null!;
        private Label lblByRoomTypeHeading = null!;
        private DataGridView dgvByRoomType = null!;

        private RoundedPanel pnlPaymentStatus = null!;
        private Label lblPaymentStatusHeading = null!;
        private DataGridView dgvPaymentStatus = null!;

        // Bottom panel
        private RoundedPanel pnlTopGuests = null!;
        private Label lblTopGuestsHeading = null!;
        private DataGridView dgvTopGuests = null!;

        // Footer
        private RoundedButton btnRefresh = null!;
        private RoundedButton btnExport = null!;
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
            lblRange = new Label();

            lblPreset = new Label();
            cmbPreset = new ComboBox();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            btnApply = new RoundedButton();

            pnlKpi1 = new RoundedPanel();
            lblKpi1Value = new Label();
            lblKpi1Caption = new Label();

            pnlKpi2 = new RoundedPanel();
            lblKpi2Value = new Label();
            lblKpi2Caption = new Label();

            pnlKpi3 = new RoundedPanel();
            lblKpi3Value = new Label();
            lblKpi3Caption = new Label();

            pnlKpi4 = new RoundedPanel();
            lblKpi4Value = new Label();
            lblKpi4Caption = new Label();

            pnlKpi5 = new RoundedPanel();
            lblKpi5Value = new Label();
            lblKpi5Caption = new Label();

            pnlByRoomType = new RoundedPanel();
            lblByRoomTypeHeading = new Label();
            dgvByRoomType = new DataGridView();

            pnlPaymentStatus = new RoundedPanel();
            lblPaymentStatusHeading = new Label();
            dgvPaymentStatus = new DataGridView();

            pnlTopGuests = new RoundedPanel();
            lblTopGuestsHeading = new Label();
            dgvTopGuests = new DataGridView();

            btnRefresh = new RoundedButton();
            btnExport = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlKpi1.SuspendLayout();
            pnlKpi2.SuspendLayout();
            pnlKpi3.SuspendLayout();
            pnlKpi4.SuspendLayout();
            pnlKpi5.SuspendLayout();
            pnlByRoomType.SuspendLayout();
            pnlPaymentStatus.SuspendLayout();
            pnlTopGuests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvByRoomType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopGuests).BeginInit();

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
            lblTitle.Size = new Size(320, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Revenue Reports";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Revenue, occupancy, and payment analysis";

            lblRange.AutoSize = false;
            lblRange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRange.ForeColor = Theme.Tint;
            lblRange.Location = new Point(630, 40);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(310, 30);
            lblRange.TabIndex = 2;
            lblRange.Text = "";
            lblRange.TextAlign = ContentAlignment.MiddleRight;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblRange);

            // =====================================================
            // FILTER ROW
            // =====================================================

            lblPreset.AutoSize = true;
            lblPreset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreset.ForeColor = Theme.TextDark;
            lblPreset.Location = new Point(35, 130);
            lblPreset.Name = "lblPreset";
            lblPreset.Size = new Size(42, 15);
            lblPreset.TabIndex = 1;
            lblPreset.Text = "Range";

            cmbPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreset.Font = new Font("Segoe UI", 9.5F);
            cmbPreset.FormattingEnabled = true;
            cmbPreset.Location = new Point(35, 150);
            cmbPreset.Name = "cmbPreset";
            cmbPreset.Size = new Size(160, 25);
            cmbPreset.TabIndex = 2;

            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFrom.ForeColor = Theme.TextDark;
            lblFrom.Location = new Point(215, 130);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(35, 15);
            lblFrom.TabIndex = 3;
            lblFrom.Text = "From";

            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(215, 150);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(130, 23);
            dtpFrom.TabIndex = 4;

            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTo.ForeColor = Theme.TextDark;
            lblTo.Location = new Point(360, 130);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(20, 15);
            lblTo.TabIndex = 5;
            lblTo.Text = "To";

            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(360, 150);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(130, 23);
            dtpTo.TabIndex = 6;

            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomType.ForeColor = Theme.TextDark;
            lblRoomType.Location = new Point(505, 130);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(70, 15);
            lblRoomType.TabIndex = 7;
            lblRoomType.Text = "Room Type";

            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 9.5F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(505, 150);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(180, 25);
            cmbRoomType.TabIndex = 8;

            btnApply.NormalColor = Theme.Accent;
            btnApply.HoverColor = Color.FromArgb(210, 90, 30);
            btnApply.CornerRadius = 10;
            btnApply.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(700, 145);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 34);
            btnApply.TabIndex = 9;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;

            // =====================================================
            // KPI CARDS
            // =====================================================

            ConfigureKpiCard(pnlKpi1, lblKpi1Value, lblKpi1Caption, "Expected Revenue", 35);
            ConfigureKpiCard(pnlKpi2, lblKpi2Value, lblKpi2Caption, "Realized Revenue", 210);
            ConfigureKpiCard(pnlKpi3, lblKpi3Value, lblKpi3Caption, "Outstanding", 385);
            ConfigureKpiCard(pnlKpi4, lblKpi4Value, lblKpi4Caption, "ADR", 560);
            ConfigureKpiCard(pnlKpi5, lblKpi5Value, lblKpi5Caption, "Occupancy", 735);

            // =====================================================
            // BY ROOM TYPE PANEL
            // =====================================================

            pnlByRoomType.BackColor = Theme.Card;
            pnlByRoomType.BorderColor = Theme.Border;
            pnlByRoomType.BorderThickness = 1;
            pnlByRoomType.CornerRadius = 14;
            pnlByRoomType.Location = new Point(35, 300);
            pnlByRoomType.Name = "pnlByRoomType";
            pnlByRoomType.Size = new Size(430, 240);
            pnlByRoomType.TabIndex = 15;

            lblByRoomTypeHeading.AutoSize = true;
            lblByRoomTypeHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblByRoomTypeHeading.ForeColor = Theme.TextDark;
            lblByRoomTypeHeading.Location = new Point(20, 15);
            lblByRoomTypeHeading.Name = "lblByRoomTypeHeading";
            lblByRoomTypeHeading.Size = new Size(180, 20);
            lblByRoomTypeHeading.TabIndex = 0;
            lblByRoomTypeHeading.Text = "Revenue by Room Type";

            ConfigureInnerGrid(dgvByRoomType);
            dgvByRoomType.Location = new Point(15, 45);
            dgvByRoomType.Size = new Size(400, 180);

            pnlByRoomType.Controls.Add(lblByRoomTypeHeading);
            pnlByRoomType.Controls.Add(dgvByRoomType);

            // =====================================================
            // PAYMENT STATUS PANEL
            // =====================================================

            pnlPaymentStatus.BackColor = Theme.Card;
            pnlPaymentStatus.BorderColor = Theme.Border;
            pnlPaymentStatus.BorderThickness = 1;
            pnlPaymentStatus.CornerRadius = 14;
            pnlPaymentStatus.Location = new Point(485, 300);
            pnlPaymentStatus.Name = "pnlPaymentStatus";
            pnlPaymentStatus.Size = new Size(450, 240);
            pnlPaymentStatus.TabIndex = 16;

            lblPaymentStatusHeading.AutoSize = true;
            lblPaymentStatusHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPaymentStatusHeading.ForeColor = Theme.TextDark;
            lblPaymentStatusHeading.Location = new Point(20, 15);
            lblPaymentStatusHeading.Name = "lblPaymentStatusHeading";
            lblPaymentStatusHeading.Size = new Size(200, 20);
            lblPaymentStatusHeading.TabIndex = 0;
            lblPaymentStatusHeading.Text = "Payment Status Breakdown";

            ConfigureInnerGrid(dgvPaymentStatus);
            dgvPaymentStatus.Location = new Point(15, 45);
            dgvPaymentStatus.Size = new Size(420, 180);

            pnlPaymentStatus.Controls.Add(lblPaymentStatusHeading);
            pnlPaymentStatus.Controls.Add(dgvPaymentStatus);

            // =====================================================
            // TOP GUESTS PANEL
            // =====================================================

            pnlTopGuests.BackColor = Theme.Card;
            pnlTopGuests.BorderColor = Theme.Border;
            pnlTopGuests.BorderThickness = 1;
            pnlTopGuests.CornerRadius = 14;
            pnlTopGuests.Location = new Point(35, 560);
            pnlTopGuests.Name = "pnlTopGuests";
            pnlTopGuests.Size = new Size(900, 220);
            pnlTopGuests.TabIndex = 17;

            lblTopGuestsHeading.AutoSize = true;
            lblTopGuestsHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTopGuestsHeading.ForeColor = Theme.TextDark;
            lblTopGuestsHeading.Location = new Point(20, 15);
            lblTopGuestsHeading.Name = "lblTopGuestsHeading";
            lblTopGuestsHeading.Size = new Size(220, 20);
            lblTopGuestsHeading.TabIndex = 0;
            lblTopGuestsHeading.Text = "Top Guests by Revenue";

            ConfigureInnerGrid(dgvTopGuests);
            dgvTopGuests.Location = new Point(15, 45);
            dgvTopGuests.Size = new Size(870, 160);

            pnlTopGuests.Controls.Add(lblTopGuestsHeading);
            pnlTopGuests.Controls.Add(dgvTopGuests);

            // =====================================================
            // FOOTER
            // =====================================================

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(815, 800);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            btnExport.NormalColor = Theme.Primary;
            btnExport.HoverColor = Theme.PrimaryHover;
            btnExport.CornerRadius = 10;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(675, 800);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(130, 40);
            btnExport.TabIndex = 19;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(35, 808);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(620, 25);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "RevenueReportsControl";
            Size = new Size(970, 860);

            Controls.Add(pnlHeader);
            Controls.Add(lblPreset);
            Controls.Add(cmbPreset);
            Controls.Add(lblFrom);
            Controls.Add(dtpFrom);
            Controls.Add(lblTo);
            Controls.Add(dtpTo);
            Controls.Add(lblRoomType);
            Controls.Add(cmbRoomType);
            Controls.Add(btnApply);
            Controls.Add(pnlKpi1);
            Controls.Add(pnlKpi2);
            Controls.Add(pnlKpi3);
            Controls.Add(pnlKpi4);
            Controls.Add(pnlKpi5);
            Controls.Add(pnlByRoomType);
            Controls.Add(pnlPaymentStatus);
            Controls.Add(pnlTopGuests);
            Controls.Add(btnExport);
            Controls.Add(btnRefresh);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlKpi1.ResumeLayout(false);
            pnlKpi2.ResumeLayout(false);
            pnlKpi3.ResumeLayout(false);
            pnlKpi4.ResumeLayout(false);
            pnlKpi5.ResumeLayout(false);

            pnlByRoomType.ResumeLayout(false);
            pnlPaymentStatus.ResumeLayout(false);
            pnlTopGuests.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvByRoomType).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopGuests).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureKpiCard(
            RoundedPanel card,
            Label valueLabel,
            Label captionLabel,
            string caption,
            int x)
        {
            card.BackColor = Theme.Card;
            card.BorderColor = Theme.Border;
            card.BorderThickness = 1;
            card.CornerRadius = 14;
            card.Location = new Point(x, 200);
            card.Name = "pnlKpi";
            card.Size = new Size(160, 85);
            card.TabIndex = 10;

            valueLabel.AutoSize = false;
            valueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            valueLabel.ForeColor = Theme.TextDark;
            valueLabel.Location = new Point(15, 15);
            valueLabel.Name = "lblKpiValue";
            valueLabel.Size = new Size(130, 30);
            valueLabel.TabIndex = 0;
            valueLabel.Text = "0";
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            captionLabel.AutoSize = false;
            captionLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            captionLabel.ForeColor = Color.Gray;
            captionLabel.Location = new Point(15, 50);
            captionLabel.Name = "lblKpiCaption";
            captionLabel.Size = new Size(130, 25);
            captionLabel.TabIndex = 1;
            captionLabel.Text = caption;
            captionLabel.TextAlign = ContentAlignment.MiddleLeft;

            card.Controls.Add(valueLabel);
            card.Controls.Add(captionLabel);
        }

        private void ConfigureInnerGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = Theme.Card;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };

            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };

            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Theme.Border;
            grid.Margin = new Padding(0);
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 30;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}