#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class InquiryControl
    {
        private System.ComponentModel.IContainer? components = null;

        // Header
        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblCounter = null!;
        private RoundedButton btnNew = null!;

        // Tabs
        private RoundedButton btnTabAll = null!;
        private RoundedButton btnTabNew = null!;
        private RoundedButton btnTabInProgress = null!;
        private RoundedButton btnTabAnswered = null!;
        private RoundedButton btnTabClosed = null!;

        // Left rail
        private Panel pnlRail = null!;
        private FlowLayoutPanel flpCards = null!;

        // Right pane (detail)
        private RoundedPanel pnlDetail = null!;

        private Label lblEmptyState = null!;

        private Panel pnlDetailInner = null!;
        private Label lblDetailSubject = null!;
        private Label lblDetailMeta = null!;
        private Label lblDetailPriority = null!;
        private Label lblDetailStatus = null!;
        private Label lblMessageCaption = null!;
        private TextBox txtDetailMessage = null!;
        private Label lblResponseCaption = null!;
        private TextBox txtDetailResponse = null!;
        private Label lblResponseHint = null!;

        // Detail action buttons
        private RoundedButton btnSaveResponse = null!;
        private RoundedButton btnAdvance = null!;
        private RoundedButton btnCancel = null!;
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
            btnNew = new RoundedButton();

            btnTabAll = new RoundedButton();
            btnTabNew = new RoundedButton();
            btnTabInProgress = new RoundedButton();
            btnTabAnswered = new RoundedButton();
            btnTabClosed = new RoundedButton();

            pnlRail = new Panel();
            flpCards = new FlowLayoutPanel();

            pnlDetail = new RoundedPanel();
            lblEmptyState = new Label();
            pnlDetailInner = new Panel();
            lblDetailSubject = new Label();
            lblDetailMeta = new Label();
            lblDetailPriority = new Label();
            lblDetailStatus = new Label();
            lblMessageCaption = new Label();
            txtDetailMessage = new TextBox();
            lblResponseCaption = new Label();
            txtDetailResponse = new TextBox();
            lblResponseHint = new Label();

            btnSaveResponse = new RoundedButton();
            btnAdvance = new RoundedButton();
            btnCancel = new RoundedButton();
            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlRail.SuspendLayout();
            pnlDetail.SuspendLayout();
            pnlDetailInner.SuspendLayout();

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
            lblTitle.Size = new Size(180, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inquiries";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Log and answer guest questions";

            lblCounter.AutoSize = false;
            lblCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCounter.ForeColor = Theme.Tint;
            lblCounter.Location = new Point(650, 40);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(180, 30);
            lblCounter.TabIndex = 2;
            lblCounter.Text = "0 open";
            lblCounter.TextAlign = ContentAlignment.MiddleRight;

            btnNew.NormalColor = Theme.Accent;
            btnNew.HoverColor = Color.FromArgb(210, 90, 30);
            btnNew.CornerRadius = 10;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(840, 35);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(95, 40);
            btnNew.TabIndex = 3;
            btnNew.Text = "+ New";
            btnNew.UseVisualStyleBackColor = false;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblCounter);
            pnlHeader.Controls.Add(btnNew);

            // =====================================================
            // TABS
            // =====================================================

            ConfigureTab(btnTabAll, "All", 35, 0);
            ConfigureTab(btnTabNew, "New", 115, 1);
            ConfigureTab(btnTabInProgress, "In Progress", 195, 2);
            ConfigureTab(btnTabAnswered, "Answered", 315, 3);
            ConfigureTab(btnTabClosed, "Closed", 435, 4);

            // =====================================================
            // LEFT RAIL (card list)
            // =====================================================

            pnlRail.BackColor = Color.White;
            pnlRail.Location = new Point(35, 175);
            pnlRail.Name = "pnlRail";
            pnlRail.Size = new Size(320, 600);
            pnlRail.TabIndex = 5;

            flpCards.AutoScroll = true;
            flpCards.BackColor = Color.White;
            flpCards.Dock = DockStyle.Fill;
            flpCards.FlowDirection = FlowDirection.TopDown;
            flpCards.WrapContents = false;
            flpCards.Padding = new Padding(10);
            flpCards.Name = "flpCards";
            flpCards.TabIndex = 0;

            pnlRail.Controls.Add(flpCards);

            // =====================================================
            // RIGHT PANE (detail)
            // =====================================================

            pnlDetail.BackColor = Theme.Card;
            pnlDetail.BorderColor = Theme.Border;
            pnlDetail.BorderThickness = 1;
            pnlDetail.CornerRadius = 14;
            pnlDetail.Location = new Point(375, 175);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(560, 600);
            pnlDetail.TabIndex = 6;

            // Empty state
            lblEmptyState.AutoSize = false;
            lblEmptyState.Dock = DockStyle.Fill;
            lblEmptyState.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblEmptyState.ForeColor = Color.Gray;
            lblEmptyState.Name = "lblEmptyState";
            lblEmptyState.TabIndex = 0;
            lblEmptyState.Text = "Select an inquiry to view it here";
            lblEmptyState.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyState.Visible = true;

            // Inner detail panel
            pnlDetailInner.Dock = DockStyle.Fill;
            pnlDetailInner.BackColor = Theme.Card;
            pnlDetailInner.Name = "pnlDetailInner";
            pnlDetailInner.Padding = new Padding(25, 20, 25, 20);
            pnlDetailInner.TabIndex = 1;
            pnlDetailInner.Visible = false;

            // Subject
            lblDetailSubject.AutoSize = false;
            lblDetailSubject.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblDetailSubject.ForeColor = Theme.TextDark;
            lblDetailSubject.Location = new Point(25, 20);
            lblDetailSubject.Name = "lblDetailSubject";
            lblDetailSubject.Size = new Size(400, 30);
            lblDetailSubject.TabIndex = 0;
            lblDetailSubject.Text = "—";

            // Priority tag (top-right)
            lblDetailPriority.AutoSize = false;
            lblDetailPriority.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDetailPriority.ForeColor = Color.White;
            lblDetailPriority.BackColor = Color.DarkOrange;
            lblDetailPriority.Location = new Point(455, 25);
            lblDetailPriority.Name = "lblDetailPriority";
            lblDetailPriority.Size = new Size(75, 22);
            lblDetailPriority.TabIndex = 1;
            lblDetailPriority.Text = "NORMAL";
            lblDetailPriority.TextAlign = ContentAlignment.MiddleCenter;

            // Meta line
            lblDetailMeta.AutoSize = false;
            lblDetailMeta.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblDetailMeta.ForeColor = Color.Gray;
            lblDetailMeta.Location = new Point(25, 55);
            lblDetailMeta.Name = "lblDetailMeta";
            lblDetailMeta.Size = new Size(505, 20);
            lblDetailMeta.TabIndex = 2;
            lblDetailMeta.Text = "—";

            // Status pill
            lblDetailStatus.AutoSize = false;
            lblDetailStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDetailStatus.ForeColor = Color.White;
            lblDetailStatus.BackColor = Color.SteelBlue;
            lblDetailStatus.Location = new Point(25, 85);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Size = new Size(90, 22);
            lblDetailStatus.TabIndex = 3;
            lblDetailStatus.Text = "NEW";
            lblDetailStatus.TextAlign = ContentAlignment.MiddleCenter;

            // Message caption
            lblMessageCaption.AutoSize = true;
            lblMessageCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMessageCaption.ForeColor = Theme.TextDark;
            lblMessageCaption.Location = new Point(25, 130);
            lblMessageCaption.Name = "lblMessageCaption";
            lblMessageCaption.Size = new Size(130, 15);
            lblMessageCaption.TabIndex = 4;
            lblMessageCaption.Text = "Guest Message";

            // Message body
            txtDetailMessage.BackColor = Theme.Field;
            txtDetailMessage.BorderStyle = BorderStyle.None;
            txtDetailMessage.Font = new Font("Segoe UI", 10F);
            txtDetailMessage.ForeColor = Theme.TextDark;
            txtDetailMessage.Location = new Point(25, 152);
            txtDetailMessage.Multiline = true;
            txtDetailMessage.ReadOnly = true;
            txtDetailMessage.ScrollBars = ScrollBars.Vertical;
            txtDetailMessage.Name = "txtDetailMessage";
            txtDetailMessage.Size = new Size(505, 130);
            txtDetailMessage.TabIndex = 5;
            txtDetailMessage.Padding = new Padding(10);

            // Response caption
            lblResponseCaption.AutoSize = true;
            lblResponseCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResponseCaption.ForeColor = Theme.TextDark;
            lblResponseCaption.Location = new Point(25, 300);
            lblResponseCaption.Name = "lblResponseCaption";
            lblResponseCaption.Size = new Size(100, 15);
            lblResponseCaption.TabIndex = 6;
            lblResponseCaption.Text = "Your Response";

            // Response body
            txtDetailResponse.Font = new Font("Segoe UI", 10F);
            txtDetailResponse.Location = new Point(25, 322);
            txtDetailResponse.Multiline = true;
            txtDetailResponse.ScrollBars = ScrollBars.Vertical;
            txtDetailResponse.Name = "txtDetailResponse";
            txtDetailResponse.Size = new Size(505, 150);
            txtDetailResponse.TabIndex = 7;

            // Hint
            lblResponseHint.AutoSize = false;
            lblResponseHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblResponseHint.ForeColor = Color.Gray;
            lblResponseHint.Location = new Point(25, 478);
            lblResponseHint.Name = "lblResponseHint";
            lblResponseHint.Size = new Size(505, 18);
            lblResponseHint.TabIndex = 8;
            lblResponseHint.Text = "Saving a response marks the inquiry as Answered.";

            // Buttons inside detail pane
            btnSaveResponse.NormalColor = Theme.Accent;
            btnSaveResponse.HoverColor = Color.FromArgb(210, 90, 30);
            btnSaveResponse.CornerRadius = 10;
            btnSaveResponse.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSaveResponse.ForeColor = Color.White;
            btnSaveResponse.Location = new Point(25, 510);
            btnSaveResponse.Name = "btnSaveResponse";
            btnSaveResponse.Size = new Size(160, 45);
            btnSaveResponse.TabIndex = 9;
            btnSaveResponse.Text = "Save Response";
            btnSaveResponse.UseVisualStyleBackColor = false;

            btnAdvance.NormalColor = Theme.Primary;
            btnAdvance.HoverColor = Theme.PrimaryHover;
            btnAdvance.CornerRadius = 10;
            btnAdvance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAdvance.ForeColor = Color.White;
            btnAdvance.Location = new Point(195, 510);
            btnAdvance.Name = "btnAdvance";
            btnAdvance.Size = new Size(150, 45);
            btnAdvance.TabIndex = 10;
            btnAdvance.Text = "Advance Status";
            btnAdvance.UseVisualStyleBackColor = false;

            btnCancel.NormalColor = Theme.Danger;
            btnCancel.HoverColor = Color.FromArgb(160, 40, 40);
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(355, 510);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel Inquiry";
            btnCancel.UseVisualStyleBackColor = false;

            pnlDetailInner.Controls.Add(lblDetailSubject);
            pnlDetailInner.Controls.Add(lblDetailPriority);
            pnlDetailInner.Controls.Add(lblDetailMeta);
            pnlDetailInner.Controls.Add(lblDetailStatus);
            pnlDetailInner.Controls.Add(lblMessageCaption);
            pnlDetailInner.Controls.Add(txtDetailMessage);
            pnlDetailInner.Controls.Add(lblResponseCaption);
            pnlDetailInner.Controls.Add(txtDetailResponse);
            pnlDetailInner.Controls.Add(lblResponseHint);
            pnlDetailInner.Controls.Add(btnSaveResponse);
            pnlDetailInner.Controls.Add(btnAdvance);
            pnlDetailInner.Controls.Add(btnCancel);

            pnlDetail.Controls.Add(pnlDetailInner);
            pnlDetail.Controls.Add(lblEmptyState);

            // =====================================================
            // FOOTER
            // =====================================================

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(815, 790);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(35, 798);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(760, 22);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "InquiryControl";
            Size = new Size(970, 850);

            Controls.Add(pnlHeader);
            Controls.Add(btnTabAll);
            Controls.Add(btnTabNew);
            Controls.Add(btnTabInProgress);
            Controls.Add(btnTabAnswered);
            Controls.Add(btnTabClosed);
            Controls.Add(pnlRail);
            Controls.Add(pnlDetail);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlRail.ResumeLayout(false);

            pnlDetail.ResumeLayout(false);
            pnlDetailInner.ResumeLayout(false);
            pnlDetailInner.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureTab(RoundedButton tab, string text, int x, int index)
        {
            tab.NormalColor = index == 0 ? Theme.Primary : Theme.Field;
            tab.HoverColor = index == 0 ? Theme.PrimaryHover : Theme.Tint;
            tab.CornerRadius = 10;
            tab.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tab.ForeColor = index == 0 ? Color.White : Theme.TextDark;
            tab.Location = new Point(x, 125);
            tab.Name = "btnTab" + text.Replace(" ", "");
            tab.Size = new Size(75, 36);
            tab.TabIndex = 4 + index;
            tab.Text = text;
            tab.UseVisualStyleBackColor = false;
        }
    }
}