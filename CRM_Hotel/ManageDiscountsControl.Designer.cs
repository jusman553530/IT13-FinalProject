#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ManageDiscountsControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private RoundedPanel pnlIntro = null!;
        private Label lblIntro = null!;

        // Silver
        private RoundedPanel pnlSilver = null!;
        private Label lblSilverTier = null!;
        private Label lblSilverCaption = null!;
        private Label lblSilverRate = null!;
        private NumericUpDown nudSilverRate = null!;
        private CheckBox chkSilverActive = null!;

        // Gold
        private RoundedPanel pnlGold = null!;
        private Label lblGoldTier = null!;
        private Label lblGoldCaption = null!;
        private Label lblGoldRate = null!;
        private NumericUpDown nudGoldRate = null!;
        private CheckBox chkGoldActive = null!;

        // Platinum
        private RoundedPanel pnlPlatinum = null!;
        private Label lblPlatinumTier = null!;
        private Label lblPlatinumCaption = null!;
        private Label lblPlatinumRate = null!;
        private NumericUpDown nudPlatinumRate = null!;
        private CheckBox chkPlatinumActive = null!;

        private RoundedButton btnSave = null!;
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

            pnlIntro = new RoundedPanel();
            lblIntro = new Label();

            pnlSilver = new RoundedPanel();
            lblSilverTier = new Label();
            lblSilverCaption = new Label();
            lblSilverRate = new Label();
            nudSilverRate = new NumericUpDown();
            chkSilverActive = new CheckBox();

            pnlGold = new RoundedPanel();
            lblGoldTier = new Label();
            lblGoldCaption = new Label();
            lblGoldRate = new Label();
            nudGoldRate = new NumericUpDown();
            chkGoldActive = new CheckBox();

            pnlPlatinum = new RoundedPanel();
            lblPlatinumTier = new Label();
            lblPlatinumCaption = new Label();
            lblPlatinumRate = new Label();
            nudPlatinumRate = new NumericUpDown();
            chkPlatinumActive = new CheckBox();

            btnSave = new RoundedButton();
            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlIntro.SuspendLayout();
            pnlSilver.SuspendLayout();
            pnlGold.SuspendLayout();
            pnlPlatinum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSilverRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGoldRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPlatinumRate).BeginInit();

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
            lblTitle.Size = new Size(300, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Discounts";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(450, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Automatic tier discounts applied at booking time";

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            // =====================================================
            // INTRO PANEL
            // =====================================================

            pnlIntro.BackColor = Theme.Card;
            pnlIntro.BorderColor = Theme.Border;
            pnlIntro.BorderThickness = 1;
            pnlIntro.CornerRadius = 14;
            pnlIntro.Location = new Point(35, 135);
            pnlIntro.Name = "pnlIntro";
            pnlIntro.Size = new Size(900, 70);
            pnlIntro.TabIndex = 2;

            lblIntro.AutoSize = false;
            lblIntro.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblIntro.ForeColor = Color.Gray;
            lblIntro.Location = new Point(20, 15);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(860, 45);
            lblIntro.TabIndex = 0;
            lblIntro.Text =
                "Tier discounts are applied automatically when a reservation is created, " +
                "based on the guest's completed stay count. " +
                "Bronze guests (1–2 stays) receive no discount. " +
                "Changes take effect on the next booking and do not alter past reservations.";

            pnlIntro.Controls.Add(lblIntro);

            // =====================================================
            // SILVER
            // =====================================================

            ConfigureTierCard(pnlSilver, lblSilverTier, lblSilverCaption, lblSilverRate,
                nudSilverRate, chkSilverActive,
                "Silver", "3 – 4 completed stays",
                new Point(35, 225), 0);

            // =====================================================
            // GOLD
            // =====================================================

            ConfigureTierCard(pnlGold, lblGoldTier, lblGoldCaption, lblGoldRate,
                nudGoldRate, chkGoldActive,
                "Gold", "5 – 9 completed stays",
                new Point(35, 385), 1);

            // =====================================================
            // PLATINUM
            // =====================================================

            ConfigureTierCard(pnlPlatinum, lblPlatinumTier, lblPlatinumCaption, lblPlatinumRate,
                nudPlatinumRate, chkPlatinumActive,
                "Platinum", "10+ completed stays",
                new Point(35, 545), 2);

            // =====================================================
            // FOOTER BUTTONS
            // =====================================================

            btnSave.NormalColor = Theme.Accent;
            btnSave.HoverColor = Color.FromArgb(210, 90, 30);
            btnSave.CornerRadius = 10;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(35, 720);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 50);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(275, 720);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 50);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(430, 730);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(505, 30);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "ManageDiscountsControl";
            Size = new Size(970, 810);

            Controls.Add(pnlHeader);
            Controls.Add(pnlIntro);
            Controls.Add(pnlSilver);
            Controls.Add(pnlGold);
            Controls.Add(pnlPlatinum);
            Controls.Add(btnSave);
            Controls.Add(btnRefresh);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlIntro.ResumeLayout(false);

            pnlSilver.ResumeLayout(false);
            pnlSilver.PerformLayout();

            pnlGold.ResumeLayout(false);
            pnlGold.PerformLayout();

            pnlPlatinum.ResumeLayout(false);
            pnlPlatinum.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)nudSilverRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGoldRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPlatinumRate).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureTierCard(
            RoundedPanel card,
            Label tierLabel,
            Label captionLabel,
            Label rateCaption,
            NumericUpDown rateInput,
            CheckBox activeCheck,
            string tier,
            string caption,
            Point location,
            int tabOffset)
        {
            card.BackColor = Theme.Card;
            card.BorderColor = Theme.Border;
            card.BorderThickness = 1;
            card.CornerRadius = 14;
            card.Location = location;
            card.Name = "pnl" + tier;
            card.Size = new Size(900, 140);
            card.TabIndex = 3 + tabOffset;

            // Tier name
            tierLabel.AutoSize = true;
            tierLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            tierLabel.ForeColor = GetTierColor(tier);
            tierLabel.Location = new Point(25, 20);
            tierLabel.Name = "lbl" + tier + "Tier";
            tierLabel.Size = new Size(150, 32);
            tierLabel.TabIndex = 0;
            tierLabel.Text = tier;

            // Caption
            captionLabel.AutoSize = true;
            captionLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            captionLabel.ForeColor = Color.Gray;
            captionLabel.Location = new Point(28, 58);
            captionLabel.Name = "lbl" + tier + "Caption";
            captionLabel.Size = new Size(200, 17);
            captionLabel.TabIndex = 1;
            captionLabel.Text = caption;

            // Rate caption
            rateCaption.AutoSize = true;
            rateCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rateCaption.ForeColor = Theme.TextDark;
            rateCaption.Location = new Point(500, 30);
            rateCaption.Name = "lbl" + tier + "Rate";
            rateCaption.Size = new Size(120, 15);
            rateCaption.TabIndex = 2;
            rateCaption.Text = "Discount Rate (%)";

            // Rate input
            rateInput.DecimalPlaces = 2;
            rateInput.Font = new Font("Segoe UI", 11F);
            rateInput.Location = new Point(500, 55);
            rateInput.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            rateInput.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            rateInput.Name = "nud" + tier + "Rate";
            rateInput.Size = new Size(140, 27);
            rateInput.TabIndex = 3;
            rateInput.ThousandsSeparator = true;

            // Active checkbox
            activeCheck.AutoSize = true;
            activeCheck.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            activeCheck.ForeColor = Theme.TextDark;
            activeCheck.Location = new Point(680, 58);
            activeCheck.Name = "chk" + tier + "Active";
            activeCheck.Size = new Size(120, 23);
            activeCheck.TabIndex = 4;
            activeCheck.Text = "Active";
            activeCheck.UseVisualStyleBackColor = true;

            card.Controls.Add(tierLabel);
            card.Controls.Add(captionLabel);
            card.Controls.Add(rateCaption);
            card.Controls.Add(rateInput);
            card.Controls.Add(activeCheck);
        }

        private static Color GetTierColor(string tier)
        {
            switch (tier)
            {
                case "Platinum": return Color.FromArgb(80, 20, 120);
                case "Gold": return Color.DarkGoldenrod;
                case "Silver": return Color.SlateGray;
                default: return Theme.TextDark;
            }
        }
    }
}