#nullable enable

using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace CRM.winforms
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblLastUpdated = null!;

        private Label lblRange = null!;
        private ComboBox cmbRange = null!;
        private RoundedButton btnRefresh = null!;

        // KPI cards (6)
        private RoundedPanel pnlKpi1 = null!;
        private Label lblKpi1Value = null!;
        private Label lblKpi1Caption = null!;
        private Label lblKpi1Arrow = null!;

        private RoundedPanel pnlKpi2 = null!;
        private Label lblKpi2Value = null!;
        private Label lblKpi2Caption = null!;
        private Label lblKpi2Arrow = null!;

        private RoundedPanel pnlKpi3 = null!;
        private Label lblKpi3Value = null!;
        private Label lblKpi3Caption = null!;
        private Label lblKpi3Arrow = null!;

        private RoundedPanel pnlKpi4 = null!;
        private Label lblKpi4Value = null!;
        private Label lblKpi4Caption = null!;
        private Label lblKpi4Arrow = null!;

        private RoundedPanel pnlKpi5 = null!;
        private Label lblKpi5Value = null!;
        private Label lblKpi5Caption = null!;
        private Label lblKpi5Arrow = null!;

        private RoundedPanel pnlKpi6 = null!;
        private Label lblKpi6Value = null!;
        private Label lblKpi6Caption = null!;
        private Label lblKpi6Arrow = null!;

        // Chart panels
        private RoundedPanel pnlChartRevenue = null!;
        private Label lblChartRevenueTitle = null!;
        private Chart chartRevenue = null!;

        private RoundedPanel pnlChartStatus = null!;
        private Label lblChartStatusTitle = null!;
        private Chart chartStatus = null!;

        private RoundedPanel pnlChartOccupancy = null!;
        private Label lblChartOccupancyTitle = null!;
        private Chart chartOccupancy = null!;

        private RoundedPanel pnlChartRoomTypes = null!;
        private Label lblChartRoomTypesTitle = null!;
        private Chart chartRoomTypes = null!;

        // Bottom panels
        private RoundedPanel pnlRecent = null!;
        private Label lblRecentTitle = null!;
        private DataGridView dgvRecent = null!;

        private RoundedPanel pnlTopGuests = null!;
        private Label lblTopGuestsTitle = null!;
        private DataGridView dgvTopGuests = null!;

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

            ChartArea caRevenue = new ChartArea();
            ChartArea caStatus = new ChartArea();
            ChartArea caOccupancy = new ChartArea();
            ChartArea caRoomTypes = new ChartArea();

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLastUpdated = new Label();

            lblRange = new Label();
            cmbRange = new ComboBox();
            btnRefresh = new RoundedButton();

            pnlKpi1 = new RoundedPanel();
            lblKpi1Value = new Label();
            lblKpi1Caption = new Label();
            lblKpi1Arrow = new Label();

            pnlKpi2 = new RoundedPanel();
            lblKpi2Value = new Label();
            lblKpi2Caption = new Label();
            lblKpi2Arrow = new Label();

            pnlKpi3 = new RoundedPanel();
            lblKpi3Value = new Label();
            lblKpi3Caption = new Label();
            lblKpi3Arrow = new Label();

            pnlKpi4 = new RoundedPanel();
            lblKpi4Value = new Label();
            lblKpi4Caption = new Label();
            lblKpi4Arrow = new Label();

            pnlKpi5 = new RoundedPanel();
            lblKpi5Value = new Label();
            lblKpi5Caption = new Label();
            lblKpi5Arrow = new Label();

            pnlKpi6 = new RoundedPanel();
            lblKpi6Value = new Label();
            lblKpi6Caption = new Label();
            lblKpi6Arrow = new Label();

            pnlChartRevenue = new RoundedPanel();
            lblChartRevenueTitle = new Label();
            chartRevenue = new Chart();

            pnlChartStatus = new RoundedPanel();
            lblChartStatusTitle = new Label();
            chartStatus = new Chart();

            pnlChartOccupancy = new RoundedPanel();
            lblChartOccupancyTitle = new Label();
            chartOccupancy = new Chart();

            pnlChartRoomTypes = new RoundedPanel();
            lblChartRoomTypesTitle = new Label();
            chartRoomTypes = new Chart();

            pnlRecent = new RoundedPanel();
            lblRecentTitle = new Label();
            dgvRecent = new DataGridView();

            pnlTopGuests = new RoundedPanel();
            lblTopGuestsTitle = new Label();
            dgvTopGuests = new DataGridView();

            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlKpi1.SuspendLayout();
            pnlKpi2.SuspendLayout();
            pnlKpi3.SuspendLayout();
            pnlKpi4.SuspendLayout();
            pnlKpi5.SuspendLayout();
            pnlKpi6.SuspendLayout();
            pnlChartRevenue.SuspendLayout();
            pnlChartStatus.SuspendLayout();
            pnlChartOccupancy.SuspendLayout();
            pnlChartRoomTypes.SuspendLayout();
            pnlRecent.SuspendLayout();
            pnlTopGuests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartRoomTypes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
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
            lblTitle.Size = new Size(340, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Business Intelligence";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Overview of all hotel operations";

            lblLastUpdated.AutoSize = false;
            lblLastUpdated.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblLastUpdated.ForeColor = Theme.Tint;
            lblLastUpdated.Location = new Point(630, 40);
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Size = new Size(310, 30);
            lblLastUpdated.TabIndex = 2;
            lblLastUpdated.Text = "";
            lblLastUpdated.TextAlign = ContentAlignment.MiddleRight;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblLastUpdated);

            // =====================================================
            // FILTER ROW
            // =====================================================

            lblRange.AutoSize = true;
            lblRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRange.ForeColor = Theme.TextDark;
            lblRange.Location = new Point(35, 130);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(42, 15);
            lblRange.TabIndex = 1;
            lblRange.Text = "Range";

            cmbRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRange.Font = new Font("Segoe UI", 9.5F);
            cmbRange.FormattingEnabled = true;
            cmbRange.Location = new Point(35, 150);
            cmbRange.Name = "cmbRange";
            cmbRange.Size = new Size(180, 25);
            cmbRange.TabIndex = 2;

            btnRefresh.NormalColor = Theme.Accent;
            btnRefresh.HoverColor = Color.FromArgb(210, 90, 30);
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(235, 145);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            // =====================================================
            // KPI CARDS
            // =====================================================

            ConfigureKpiCard(pnlKpi1, lblKpi1Value, lblKpi1Caption, lblKpi1Arrow, "Customers", 35, 0);
            ConfigureKpiCard(pnlKpi2, lblKpi2Value, lblKpi2Caption, lblKpi2Arrow, "Reservations", 210, 1);
            ConfigureKpiCard(pnlKpi3, lblKpi3Value, lblKpi3Caption, lblKpi3Arrow, "Expected Revenue", 385, 2);
            ConfigureKpiCard(pnlKpi4, lblKpi4Value, lblKpi4Caption, lblKpi4Arrow, "Realized Revenue", 560, 3);
            ConfigureKpiCard(pnlKpi5, lblKpi5Value, lblKpi5Caption, lblKpi5Arrow, "Open Inquiries", 735, 4);
            ConfigureKpiCard(pnlKpi6, lblKpi6Value, lblKpi6Caption, lblKpi6Arrow, "Occupancy", 910, 5);

            // =====================================================
            // CHART 1 — REVENUE (BAR)
            // =====================================================

            pnlChartRevenue.BackColor = Theme.Card;
            pnlChartRevenue.BorderColor = Theme.Border;
            pnlChartRevenue.BorderThickness = 1;
            pnlChartRevenue.CornerRadius = 14;
            pnlChartRevenue.Location = new Point(35, 300);
            pnlChartRevenue.Name = "pnlChartRevenue";
            pnlChartRevenue.Size = new Size(540, 280);
            pnlChartRevenue.TabIndex = 15;

            lblChartRevenueTitle.AutoSize = true;
            lblChartRevenueTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartRevenueTitle.ForeColor = Theme.TextDark;
            lblChartRevenueTitle.Location = new Point(20, 12);
            lblChartRevenueTitle.Name = "lblChartRevenueTitle";
            lblChartRevenueTitle.Size = new Size(220, 20);
            lblChartRevenueTitle.TabIndex = 0;
            lblChartRevenueTitle.Text = "Realized Revenue (12 months)";

            caRevenue.Name = "caRevenue";
            caRevenue.BackColor = Theme.Card;
            caRevenue.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caRevenue.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caRevenue.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            caRevenue.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            caRevenue.AxisX.LineColor = Color.LightGray;
            caRevenue.AxisY.LineColor = Color.LightGray;

            chartRevenue.ChartAreas.Add(caRevenue);
            chartRevenue.BackColor = Theme.Card;
            chartRevenue.Location = new Point(15, 40);
            chartRevenue.Name = "chartRevenue";
            chartRevenue.Size = new Size(510, 225);
            chartRevenue.TabIndex = 1;
            chartRevenue.Palette = ChartColorPalette.None;

            pnlChartRevenue.Controls.Add(lblChartRevenueTitle);
            pnlChartRevenue.Controls.Add(chartRevenue);

            // =====================================================
            // CHART 2 — STATUS (DOUGHNUT)
            // =====================================================

            pnlChartStatus.BackColor = Theme.Card;
            pnlChartStatus.BorderColor = Theme.Border;
            pnlChartStatus.BorderThickness = 1;
            pnlChartStatus.CornerRadius = 14;
            pnlChartStatus.Location = new Point(595, 300);
            pnlChartStatus.Name = "pnlChartStatus";
            pnlChartStatus.Size = new Size(340, 280);
            pnlChartStatus.TabIndex = 16;

            lblChartStatusTitle.AutoSize = true;
            lblChartStatusTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartStatusTitle.ForeColor = Theme.TextDark;
            lblChartStatusTitle.Location = new Point(20, 12);
            lblChartStatusTitle.Name = "lblChartStatusTitle";
            lblChartStatusTitle.Size = new Size(200, 20);
            lblChartStatusTitle.TabIndex = 0;
            lblChartStatusTitle.Text = "Reservations by Status";

            caStatus.Name = "caStatus";
            caStatus.BackColor = Theme.Card;

            chartStatus.ChartAreas.Add(caStatus);
            chartStatus.BackColor = Theme.Card;
            chartStatus.Location = new Point(15, 40);
            chartStatus.Name = "chartStatus";
            chartStatus.Size = new Size(310, 225);
            chartStatus.TabIndex = 1;

            pnlChartStatus.Controls.Add(lblChartStatusTitle);
            pnlChartStatus.Controls.Add(chartStatus);

            // =====================================================
            // CHART 3 — OCCUPANCY (LINE)
            // =====================================================

            pnlChartOccupancy.BackColor = Theme.Card;
            pnlChartOccupancy.BorderColor = Theme.Border;
            pnlChartOccupancy.BorderThickness = 1;
            pnlChartOccupancy.CornerRadius = 14;
            pnlChartOccupancy.Location = new Point(35, 595);
            pnlChartOccupancy.Name = "pnlChartOccupancy";
            pnlChartOccupancy.Size = new Size(540, 250);
            pnlChartOccupancy.TabIndex = 17;

            lblChartOccupancyTitle.AutoSize = true;
            lblChartOccupancyTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartOccupancyTitle.ForeColor = Theme.TextDark;
            lblChartOccupancyTitle.Location = new Point(20, 12);
            lblChartOccupancyTitle.Name = "lblChartOccupancyTitle";
            lblChartOccupancyTitle.Size = new Size(230, 20);
            lblChartOccupancyTitle.TabIndex = 0;
            lblChartOccupancyTitle.Text = "Occupancy Rate (12 months)";

            caOccupancy.Name = "caOccupancy";
            caOccupancy.BackColor = Theme.Card;
            caOccupancy.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caOccupancy.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caOccupancy.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            caOccupancy.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            caOccupancy.AxisX.LineColor = Color.LightGray;
            caOccupancy.AxisY.LineColor = Color.LightGray;

            chartOccupancy.ChartAreas.Add(caOccupancy);
            chartOccupancy.BackColor = Theme.Card;
            chartOccupancy.Location = new Point(15, 40);
            chartOccupancy.Name = "chartOccupancy";
            chartOccupancy.Size = new Size(510, 195);
            chartOccupancy.TabIndex = 1;

            pnlChartOccupancy.Controls.Add(lblChartOccupancyTitle);
            pnlChartOccupancy.Controls.Add(chartOccupancy);

            // =====================================================
            // CHART 4 — ROOM TYPES (HORIZONTAL BAR)
            // =====================================================

            pnlChartRoomTypes.BackColor = Theme.Card;
            pnlChartRoomTypes.BorderColor = Theme.Border;
            pnlChartRoomTypes.BorderThickness = 1;
            pnlChartRoomTypes.CornerRadius = 14;
            pnlChartRoomTypes.Location = new Point(595, 595);
            pnlChartRoomTypes.Name = "pnlChartRoomTypes";
            pnlChartRoomTypes.Size = new Size(340, 250);
            pnlChartRoomTypes.TabIndex = 18;

            lblChartRoomTypesTitle.AutoSize = true;
            lblChartRoomTypesTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartRoomTypesTitle.ForeColor = Theme.TextDark;
            lblChartRoomTypesTitle.Location = new Point(20, 12);
            lblChartRoomTypesTitle.Name = "lblChartRoomTypesTitle";
            lblChartRoomTypesTitle.Size = new Size(200, 20);
            lblChartRoomTypesTitle.TabIndex = 0;
            lblChartRoomTypesTitle.Text = "Room Type Popularity";

            caRoomTypes.Name = "caRoomTypes";
            caRoomTypes.BackColor = Theme.Card;
            caRoomTypes.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caRoomTypes.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            caRoomTypes.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            caRoomTypes.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            caRoomTypes.AxisX.LineColor = Color.LightGray;
            caRoomTypes.AxisY.LineColor = Color.LightGray;

            chartRoomTypes.ChartAreas.Add(caRoomTypes);
            chartRoomTypes.BackColor = Theme.Card;
            chartRoomTypes.Location = new Point(15, 40);
            chartRoomTypes.Name = "chartRoomTypes";
            chartRoomTypes.Size = new Size(310, 195);
            chartRoomTypes.TabIndex = 1;

            pnlChartRoomTypes.Controls.Add(lblChartRoomTypesTitle);
            pnlChartRoomTypes.Controls.Add(chartRoomTypes);

            // =====================================================
            // RECENT ACTIVITY
            // =====================================================

            pnlRecent.BackColor = Theme.Card;
            pnlRecent.BorderColor = Theme.Border;
            pnlRecent.BorderThickness = 1;
            pnlRecent.CornerRadius = 14;
            pnlRecent.Location = new Point(35, 860);
            pnlRecent.Name = "pnlRecent";
            pnlRecent.Size = new Size(540, 260);
            pnlRecent.TabIndex = 19;

            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRecentTitle.ForeColor = Theme.TextDark;
            lblRecentTitle.Location = new Point(20, 12);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(200, 20);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "Recent Reservations";

            ConfigureInnerGrid(dgvRecent);
            dgvRecent.Location = new Point(15, 40);
            dgvRecent.Size = new Size(510, 205);

            pnlRecent.Controls.Add(lblRecentTitle);
            pnlRecent.Controls.Add(dgvRecent);

            // =====================================================
            // TOP GUESTS
            // =====================================================

            pnlTopGuests.BackColor = Theme.Card;
            pnlTopGuests.BorderColor = Theme.Border;
            pnlTopGuests.BorderThickness = 1;
            pnlTopGuests.CornerRadius = 14;
            pnlTopGuests.Location = new Point(595, 860);
            pnlTopGuests.Name = "pnlTopGuests";
            pnlTopGuests.Size = new Size(340, 260);
            pnlTopGuests.TabIndex = 20;

            lblTopGuestsTitle.AutoSize = true;
            lblTopGuestsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTopGuestsTitle.ForeColor = Theme.TextDark;
            lblTopGuestsTitle.Location = new Point(20, 12);
            lblTopGuestsTitle.Name = "lblTopGuestsTitle";
            lblTopGuestsTitle.Size = new Size(200, 20);
            lblTopGuestsTitle.TabIndex = 0;
            lblTopGuestsTitle.Text = "Top Returning Guests";

            ConfigureInnerGrid(dgvTopGuests);
            dgvTopGuests.Location = new Point(15, 40);
            dgvTopGuests.Size = new Size(310, 205);

            pnlTopGuests.Controls.Add(lblTopGuestsTitle);
            pnlTopGuests.Controls.Add(dgvTopGuests);

            // =====================================================
            // STATUS LABEL
            // =====================================================

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(35, 1140);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(900, 25);
            lblStatus.TabIndex = 21;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "DashboardControl";
            Size = new Size(970, 1180);

            Controls.Add(pnlHeader);
            Controls.Add(lblRange);
            Controls.Add(cmbRange);
            Controls.Add(btnRefresh);
            Controls.Add(pnlKpi1);
            Controls.Add(pnlKpi2);
            Controls.Add(pnlKpi3);
            Controls.Add(pnlKpi4);
            Controls.Add(pnlKpi5);
            Controls.Add(pnlKpi6);
            Controls.Add(pnlChartRevenue);
            Controls.Add(pnlChartStatus);
            Controls.Add(pnlChartOccupancy);
            Controls.Add(pnlChartRoomTypes);
            Controls.Add(pnlRecent);
            Controls.Add(pnlTopGuests);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlKpi1.ResumeLayout(false);
            pnlKpi2.ResumeLayout(false);
            pnlKpi3.ResumeLayout(false);
            pnlKpi4.ResumeLayout(false);
            pnlKpi5.ResumeLayout(false);
            pnlKpi6.ResumeLayout(false);

            pnlChartRevenue.ResumeLayout(false);
            pnlChartRevenue.PerformLayout();
            pnlChartStatus.ResumeLayout(false);
            pnlChartStatus.PerformLayout();
            pnlChartOccupancy.ResumeLayout(false);
            pnlChartOccupancy.PerformLayout();
            pnlChartRoomTypes.ResumeLayout(false);
            pnlChartRoomTypes.PerformLayout();

            pnlRecent.ResumeLayout(false);
            pnlRecent.PerformLayout();
            pnlTopGuests.ResumeLayout(false);
            pnlTopGuests.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartRoomTypes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopGuests).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureKpiCard(
            RoundedPanel card,
            Label valueLabel,
            Label captionLabel,
            Label arrowLabel,
            string caption,
            int x,
            int tabIndex)
        {
            card.BackColor = Theme.Card;
            card.BorderColor = Theme.Border;
            card.BorderThickness = 1;
            card.CornerRadius = 14;
            card.Location = new Point(x, 200);
            card.Name = "pnlKpi" + tabIndex;
            card.Size = new Size(160, 90);
            card.TabIndex = 10 + tabIndex;
            card.Cursor = Cursors.Hand;

            valueLabel.AutoSize = false;
            valueLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            valueLabel.ForeColor = Theme.TextDark;
            valueLabel.Location = new Point(15, 12);
            valueLabel.Name = "lblKpi" + tabIndex + "Value";
            valueLabel.Size = new Size(130, 32);
            valueLabel.TabIndex = 0;
            valueLabel.Text = "0";
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            captionLabel.AutoSize = false;
            captionLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            captionLabel.ForeColor = Color.Gray;
            captionLabel.Location = new Point(15, 50);
            captionLabel.Name = "lblKpi" + tabIndex + "Caption";
            captionLabel.Size = new Size(130, 30);
            captionLabel.TabIndex = 1;
            captionLabel.Text = caption;
            captionLabel.TextAlign = ContentAlignment.MiddleLeft;

            arrowLabel.AutoSize = false;
            arrowLabel.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Regular);
            arrowLabel.ForeColor = Theme.Primary;
            arrowLabel.Location = new Point(125, 10);
            arrowLabel.Name = "lblKpi" + tabIndex + "Arrow";
            arrowLabel.Size = new Size(25, 25);
            arrowLabel.TabIndex = 2;
            arrowLabel.Text = "→";
            arrowLabel.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(valueLabel);
            card.Controls.Add(captionLabel);
            card.Controls.Add(arrowLabel);
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
            grid.RowTemplate.Height = 28;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}