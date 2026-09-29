#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class CustomerRetentionControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblRange = null!;

        // Filter row
        private Label lblWindow = null!;
        private ComboBox cmbWindow = null!;
        private Label lblChurn = null!;
        private ComboBox cmbChurn = null!;
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

        // Top returning guests
        private RoundedPanel pnlTopReturning = null!;
        private Label lblTopReturningHeading = null!;
        private DataGridView dgvTopReturning = null!;

        // Inactive
        private RoundedPanel pnlInactive = null!;
        private Label lblInactiveHeading = null!;
        private DataGridView dgvInactive = null!;

        // One-time
        private RoundedPanel pnlOneTime = null!;
        private Label lblOneTimeHeading = null!;
        private DataGridView dgvOneTime = null!;

        // Footer
        private RoundedButton btnViewHistory = null!;
        private RoundedButton btnExport = null!;
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
            lblRange = new Label();

            lblWindow = new Label();
            cmbWindow = new ComboBox();
            lblChurn = new Label();
            cmbChurn = new ComboBox();
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

            pnlTopReturning = new RoundedPanel();
            lblTopReturningHeading = new Label();
            dgvTopReturning = new DataGridView();

            pnlInactive = new RoundedPanel();
            lblInactiveHeading = new Label();
            dgvInactive = new DataGridView();

            pnlOneTime = new RoundedPanel();
            lblOneTimeHeading = new Label();
            dgvOneTime = new DataGridView();

            btnViewHistory = new RoundedButton();
            btnExport = new RoundedButton();
            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlKpi1.SuspendLayout();
            pnlKpi2.SuspendLayout();
            pnlKpi3.SuspendLayout();
            pnlKpi4.SuspendLayout();
            pnlKpi5.SuspendLayout();
            pnlTopReturning.SuspendLayout();
            pnlInactive.SuspendLayout();
            pnlOneTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopReturning).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInactive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOneTime).BeginInit();

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
            lblTitle.Size = new Size(360, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Retention";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Loyalty, repeat rate, and win-back lists";

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

            lblWindow.AutoSize = true;
            lblWindow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWindow.ForeColor = Theme.TextDark;
            lblWindow.Location = new Point(35, 130);
            lblWindow.Name = "lblWindow";
            lblWindow.Size = new Size(55, 15);
            lblWindow.TabIndex = 1;
            lblWindow.Text = "Window";

            cmbWindow.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWindow.Font = new Font("Segoe UI", 9.5F);
            cmbWindow.FormattingEnabled = true;
            cmbWindow.Location = new Point(35, 150);
            cmbWindow.Name = "cmbWindow";
            cmbWindow.Size = new Size(180, 25);
            cmbWindow.TabIndex = 2;

            lblChurn.AutoSize = true;
            lblChurn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChurn.ForeColor = Theme.TextDark;
            lblChurn.Location = new Point(235, 130);
            lblChurn.Name = "lblChurn";
            lblChurn.Size = new Size(120, 15);
            lblChurn.TabIndex = 3;
            lblChurn.Text = "Churn Threshold";

            cmbChurn.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChurn.Font = new Font("Segoe UI", 9.5F);
            cmbChurn.FormattingEnabled = true;
            cmbChurn.Location = new Point(235, 150);
            cmbChurn.Name = "cmbChurn";
            cmbChurn.Size = new Size(180, 25);
            cmbChurn.TabIndex = 4;

            btnApply.NormalColor = Theme.Accent;
            btnApply.HoverColor = Color.FromArgb(210, 90, 30);
            btnApply.CornerRadius = 10;
            btnApply.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(435, 145);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(100, 34);
            btnApply.TabIndex = 5;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;

            // =====================================================
            // KPI CARDS
            // =====================================================

            ConfigureKpiCard(pnlKpi1, lblKpi1Value, lblKpi1Caption, "Repeat Guests", 35);
            ConfigureKpiCard(pnlKpi2, lblKpi2Value, lblKpi2Caption, "Return Rate", 210);
            ConfigureKpiCard(pnlKpi3, lblKpi3Value, lblKpi3Caption, "Avg Visits", 385);
            ConfigureKpiCard(pnlKpi4, lblKpi4Value, lblKpi4Caption, "Avg Spend", 560);
            ConfigureKpiCard(pnlKpi5, lblKpi5Value, lblKpi5Caption, "Avg Days Since Last", 735);

            // =====================================================
            // TOP RETURNING PANEL
            // =====================================================

            pnlTopReturning.BackColor = Theme.Card;
            pnlTopReturning.BorderColor = Theme.Border;
            pnlTopReturning.BorderThickness = 1;
            pnlTopReturning.CornerRadius = 14;
            pnlTopReturning.Location = new Point(35, 300);
            pnlTopReturning.Name = "pnlTopReturning";
            pnlTopReturning.Size = new Size(900, 220);
            pnlTopReturning.TabIndex = 15;

            lblTopReturningHeading.AutoSize = true;
            lblTopReturningHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTopReturningHeading.ForeColor = Theme.TextDark;
            lblTopReturningHeading.Location = new Point(20, 15);
            lblTopReturningHeading.Name = "lblTopReturningHeading";
            lblTopReturningHeading.Size = new Size(230, 20);
            lblTopReturningHeading.TabIndex = 0;
            lblTopReturningHeading.Text = "Top Returning Guests";

            ConfigureInnerGrid(dgvTopReturning);
            dgvTopReturning.Location = new Point(15, 45);
            dgvTopReturning.Size = new Size(870, 160);
            dgvTopReturning.DoubleClick += (s, e) => ViewHistoryFromGrid(dgvTopReturning);

            pnlTopReturning.Controls.Add(lblTopReturningHeading);
            pnlTopReturning.Controls.Add(dgvTopReturning);

            // =====================================================
            // INACTIVE PANEL
            // =====================================================

            pnlInactive.BackColor = Theme.Card;
            pnlInactive.BorderColor = Theme.Border;
            pnlInactive.BorderThickness = 1;
            pnlInactive.CornerRadius = 14;
            pnlInactive.Location = new Point(35, 535);
            pnlInactive.Name = "pnlInactive";
            pnlInactive.Size = new Size(900, 200);
            pnlInactive.TabIndex = 16;

            lblInactiveHeading.AutoSize = true;
            lblInactiveHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInactiveHeading.ForeColor = Color.IndianRed;
            lblInactiveHeading.Location = new Point(20, 15);
            lblInactiveHeading.Name = "lblInactiveHeading";
            lblInactiveHeading.Size = new Size(260, 20);
            lblInactiveHeading.TabIndex = 0;
            lblInactiveHeading.Text = "Inactive Guests — Win-Back List";

            ConfigureInnerGrid(dgvInactive);
            dgvInactive.Location = new Point(15, 45);
            dgvInactive.Size = new Size(870, 140);
            dgvInactive.DoubleClick += (s, e) => ViewHistoryFromGrid(dgvInactive);

            pnlInactive.Controls.Add(lblInactiveHeading);
            pnlInactive.Controls.Add(dgvInactive);

            // =====================================================
            // ONE-TIME PANEL
            // =====================================================

            pnlOneTime.BackColor = Theme.Card;
            pnlOneTime.BorderColor = Theme.Border;
            pnlOneTime.BorderThickness = 1;
            pnlOneTime.CornerRadius = 14;
            pnlOneTime.Location = new Point(35, 750);
            pnlOneTime.Name = "pnlOneTime";
            pnlOneTime.Size = new Size(900, 200);
            pnlOneTime.TabIndex = 17;

            lblOneTimeHeading.AutoSize = true;
            lblOneTimeHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOneTimeHeading.ForeColor = Theme.TextDark;
            lblOneTimeHeading.Location = new Point(20, 15);
            lblOneTimeHeading.Name = "lblOneTimeHeading";
            lblOneTimeHeading.Size = new Size(260, 20);
            lblOneTimeHeading.TabIndex = 0;
            lblOneTimeHeading.Text = "One-Time Guests";

            ConfigureInnerGrid(dgvOneTime);
            dgvOneTime.Location = new Point(15, 45);
            dgvOneTime.Size = new Size(870, 140);
            dgvOneTime.DoubleClick += (s, e) => ViewHistoryFromGrid(dgvOneTime);

            pnlOneTime.Controls.Add(lblOneTimeHeading);
            pnlOneTime.Controls.Add(dgvOneTime);

            // =====================================================
            // FOOTER
            // =====================================================

            btnViewHistory.NormalColor = Theme.Primary;
            btnViewHistory.HoverColor = Theme.PrimaryHover;
            btnViewHistory.CornerRadius = 10;
            btnViewHistory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewHistory.ForeColor = Color.White;
            btnViewHistory.Location = new Point(35, 968);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(160, 40);
            btnViewHistory.TabIndex = 18;
            btnViewHistory.Text = "View History";
            btnViewHistory.UseVisualStyleBackColor = false;

            btnExport.NormalColor = Theme.Accent;
            btnExport.HoverColor = Color.FromArgb(210, 90, 30);
            btnExport.CornerRadius = 10;
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(205, 968);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(130, 40);
            btnExport.TabIndex = 19;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = false;

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(815, 968);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 20;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(345, 976);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(460, 25);
            lblStatus.TabIndex = 21;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "CustomerRetentionControl";
            Size = new Size(970, 1020);

            Controls.Add(pnlHeader);
            Controls.Add(lblWindow);
            Controls.Add(cmbWindow);
            Controls.Add(lblChurn);
            Controls.Add(cmbChurn);
            Controls.Add(btnApply);
            Controls.Add(pnlKpi1);
            Controls.Add(pnlKpi2);
            Controls.Add(pnlKpi3);
            Controls.Add(pnlKpi4);
            Controls.Add(pnlKpi5);
            Controls.Add(pnlTopReturning);
            Controls.Add(pnlInactive);
            Controls.Add(pnlOneTime);
            Controls.Add(btnViewHistory);
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

            pnlTopReturning.ResumeLayout(false);
            pnlInactive.ResumeLayout(false);
            pnlOneTime.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvTopReturning).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInactive).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOneTime).EndInit();

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