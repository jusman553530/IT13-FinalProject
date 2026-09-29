#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ReservationDetailForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private Label lblStatusPill = null!;

        private RoundedPanel pnlGuest = null!;
        private Label lblGuestHeading = null!;
        private Label lblGuestCaption = null!;
        private Label lblGuestValue = null!;

        private Label lblContactCaption = null!;
        private Label lblContactValue = null!;

        private Label lblEmailCaption = null!;
        private Label lblEmailValue = null!;

        private RoundedPanel pnlStay = null!;
        private Label lblStayHeading = null!;

        private Label lblRoomCaption = null!;
        private Label lblRoomValue = null!;

        private Label lblCheckInCaption = null!;
        private Label lblCheckInValue = null!;

        private Label lblCheckOutCaption = null!;
        private Label lblCheckOutValue = null!;

        private Label lblNightsCaption = null!;
        private Label lblNightsValue = null!;

        private Label lblGuestsCaption = null!;
        private Label lblGuestsValue = null!;

        private RoundedPanel pnlBilling = null!;
        private Label lblBillingHeading = null!;

        private Label lblTotalCaption = null!;
        private Label lblTotalValue = null!;

        private Label lblDiscountCaption = null!;
        private Label lblDiscountValue = null!;

        private Label lblFinalCaption = null!;
        private Label lblFinalValue = null!;

        private Label lblDownCaption = null!;
        private Label lblDownValue = null!;

        private Label lblPaymentCaption = null!;
        private Label lblPaymentValue = null!;

        private RoundedPanel pnlRequests = null!;
        private Label lblRequestsHeading = null!;
        private Label lblRequestsValue = null!;

        private Label lblCreatedCaption = null!;
        private Label lblCreatedValue = null!;

        private RoundedButton btnClose = null!;

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
            lblStatusPill = new Label();

            pnlGuest = new RoundedPanel();
            lblGuestHeading = new Label();
            lblGuestCaption = new Label();
            lblGuestValue = new Label();
            lblContactCaption = new Label();
            lblContactValue = new Label();
            lblEmailCaption = new Label();
            lblEmailValue = new Label();

            pnlStay = new RoundedPanel();
            lblStayHeading = new Label();
            lblRoomCaption = new Label();
            lblRoomValue = new Label();
            lblCheckInCaption = new Label();
            lblCheckInValue = new Label();
            lblCheckOutCaption = new Label();
            lblCheckOutValue = new Label();
            lblNightsCaption = new Label();
            lblNightsValue = new Label();
            lblGuestsCaption = new Label();
            lblGuestsValue = new Label();

            pnlBilling = new RoundedPanel();
            lblBillingHeading = new Label();
            lblTotalCaption = new Label();
            lblTotalValue = new Label();
            lblDiscountCaption = new Label();
            lblDiscountValue = new Label();
            lblFinalCaption = new Label();
            lblFinalValue = new Label();
            lblDownCaption = new Label();
            lblDownValue = new Label();
            lblPaymentCaption = new Label();
            lblPaymentValue = new Label();

            pnlRequests = new RoundedPanel();
            lblRequestsHeading = new Label();
            lblRequestsValue = new Label();

            lblCreatedCaption = new Label();
            lblCreatedValue = new Label();

            btnClose = new RoundedButton();

            pnlHeader.SuspendLayout();
            pnlGuest.SuspendLayout();
            pnlStay.SuspendLayout();
            pnlBilling.SuspendLayout();
            pnlRequests.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            ClientSize = new Size(760, 760);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservation Details";

            // =====================================================
            // HEADER
            // =====================================================

            pnlHeader.BackColor = Theme.Primary;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(760, 100);
            pnlHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reservation #";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(31, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(250, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Reservation details";

            lblStatusPill.AutoSize = false;
            lblStatusPill.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusPill.ForeColor = Color.White;
            lblStatusPill.BackColor = Color.SteelBlue;
            lblStatusPill.Location = new Point(590, 30);
            lblStatusPill.Name = "lblStatusPill";
            lblStatusPill.Size = new Size(140, 30);
            lblStatusPill.TabIndex = 2;
            lblStatusPill.Text = "PENDING";
            lblStatusPill.TextAlign = ContentAlignment.MiddleCenter;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblStatusPill);

            // =====================================================
            // GUEST PANEL
            // =====================================================

            pnlGuest.BackColor = Theme.Card;
            pnlGuest.BorderColor = Theme.Border;
            pnlGuest.BorderThickness = 1;
            pnlGuest.CornerRadius = 14;
            pnlGuest.Location = new Point(25, 120);
            pnlGuest.Name = "pnlGuest";
            pnlGuest.Size = new Size(710, 130);
            pnlGuest.TabIndex = 1;

            lblGuestHeading.AutoSize = true;
            lblGuestHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGuestHeading.ForeColor = Theme.TextDark;
            lblGuestHeading.Location = new Point(20, 12);
            lblGuestHeading.Name = "lblGuestHeading";
            lblGuestHeading.Size = new Size(160, 20);
            lblGuestHeading.TabIndex = 0;
            lblGuestHeading.Text = "Guest Information";

            // Guest Name
            lblGuestCaption.AutoSize = true;
            lblGuestCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblGuestCaption.ForeColor = Color.Gray;
            lblGuestCaption.Location = new Point(22, 45);
            lblGuestCaption.Name = "lblGuestCaption";
            lblGuestCaption.Size = new Size(70, 15);
            lblGuestCaption.TabIndex = 1;
            lblGuestCaption.Text = "Guest Name";

            lblGuestValue.AutoSize = true;
            lblGuestValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGuestValue.ForeColor = Theme.TextDark;
            lblGuestValue.Location = new Point(22, 63);
            lblGuestValue.Name = "lblGuestValue";
            lblGuestValue.Size = new Size(80, 20);
            lblGuestValue.TabIndex = 2;
            lblGuestValue.Text = "—";

            // Contact
            lblContactCaption.AutoSize = true;
            lblContactCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblContactCaption.ForeColor = Color.Gray;
            lblContactCaption.Location = new Point(280, 45);
            lblContactCaption.Name = "lblContactCaption";
            lblContactCaption.Size = new Size(50, 15);
            lblContactCaption.TabIndex = 3;
            lblContactCaption.Text = "Contact";

            lblContactValue.AutoSize = true;
            lblContactValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContactValue.ForeColor = Theme.TextDark;
            lblContactValue.Location = new Point(280, 63);
            lblContactValue.Name = "lblContactValue";
            lblContactValue.Size = new Size(80, 20);
            lblContactValue.TabIndex = 4;
            lblContactValue.Text = "—";

            // Email
            lblEmailCaption.AutoSize = true;
            lblEmailCaption.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblEmailCaption.ForeColor = Color.Gray;
            lblEmailCaption.Location = new Point(480, 45);
            lblEmailCaption.Name = "lblEmailCaption";
            lblEmailCaption.Size = new Size(40, 15);
            lblEmailCaption.TabIndex = 5;
            lblEmailCaption.Text = "Email";

            lblEmailValue.AutoSize = true;
            lblEmailValue.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblEmailValue.ForeColor = Theme.TextDark;
            lblEmailValue.Location = new Point(480, 65);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(80, 17);
            lblEmailValue.TabIndex = 6;
            lblEmailValue.Text = "—";

            pnlGuest.Controls.Add(lblGuestHeading);
            pnlGuest.Controls.Add(lblGuestCaption);
            pnlGuest.Controls.Add(lblGuestValue);
            pnlGuest.Controls.Add(lblContactCaption);
            pnlGuest.Controls.Add(lblContactValue);
            pnlGuest.Controls.Add(lblEmailCaption);
            pnlGuest.Controls.Add(lblEmailValue);

            // =====================================================
            // STAY PANEL
            // =====================================================

            pnlStay.BackColor = Theme.Card;
            pnlStay.BorderColor = Theme.Border;
            pnlStay.BorderThickness = 1;
            pnlStay.CornerRadius = 14;
            pnlStay.Location = new Point(25, 265);
            pnlStay.Name = "pnlStay";
            pnlStay.Size = new Size(710, 130);
            pnlStay.TabIndex = 2;

            lblStayHeading.AutoSize = true;
            lblStayHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStayHeading.ForeColor = Theme.TextDark;
            lblStayHeading.Location = new Point(20, 12);
            lblStayHeading.Name = "lblStayHeading";
            lblStayHeading.Size = new Size(140, 20);
            lblStayHeading.TabIndex = 0;
            lblStayHeading.Text = "Stay Details";

            lblRoomCaption.AutoSize = true;
            lblRoomCaption.Font = new Font("Segoe UI", 8.5F);
            lblRoomCaption.ForeColor = Color.Gray;
            lblRoomCaption.Location = new Point(22, 45);
            lblRoomCaption.Name = "lblRoomCaption";
            lblRoomCaption.Size = new Size(40, 15);
            lblRoomCaption.TabIndex = 1;
            lblRoomCaption.Text = "Room";

            lblRoomValue.AutoSize = true;
            lblRoomValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRoomValue.ForeColor = Theme.TextDark;
            lblRoomValue.Location = new Point(22, 63);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(80, 20);
            lblRoomValue.TabIndex = 2;
            lblRoomValue.Text = "—";

            lblCheckInCaption.AutoSize = true;
            lblCheckInCaption.Font = new Font("Segoe UI", 8.5F);
            lblCheckInCaption.ForeColor = Color.Gray;
            lblCheckInCaption.Location = new Point(200, 45);
            lblCheckInCaption.Name = "lblCheckInCaption";
            lblCheckInCaption.Size = new Size(55, 15);
            lblCheckInCaption.TabIndex = 3;
            lblCheckInCaption.Text = "Check In";

            lblCheckInValue.AutoSize = true;
            lblCheckInValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCheckInValue.ForeColor = Theme.TextDark;
            lblCheckInValue.Location = new Point(200, 63);
            lblCheckInValue.Name = "lblCheckInValue";
            lblCheckInValue.Size = new Size(80, 20);
            lblCheckInValue.TabIndex = 4;
            lblCheckInValue.Text = "—";

            lblCheckOutCaption.AutoSize = true;
            lblCheckOutCaption.Font = new Font("Segoe UI", 8.5F);
            lblCheckOutCaption.ForeColor = Color.Gray;
            lblCheckOutCaption.Location = new Point(360, 45);
            lblCheckOutCaption.Name = "lblCheckOutCaption";
            lblCheckOutCaption.Size = new Size(65, 15);
            lblCheckOutCaption.TabIndex = 5;
            lblCheckOutCaption.Text = "Check Out";

            lblCheckOutValue.AutoSize = true;
            lblCheckOutValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCheckOutValue.ForeColor = Theme.TextDark;
            lblCheckOutValue.Location = new Point(360, 63);
            lblCheckOutValue.Name = "lblCheckOutValue";
            lblCheckOutValue.Size = new Size(80, 20);
            lblCheckOutValue.TabIndex = 6;
            lblCheckOutValue.Text = "—";

            lblNightsCaption.AutoSize = true;
            lblNightsCaption.Font = new Font("Segoe UI", 8.5F);
            lblNightsCaption.ForeColor = Color.Gray;
            lblNightsCaption.Location = new Point(530, 45);
            lblNightsCaption.Name = "lblNightsCaption";
            lblNightsCaption.Size = new Size(40, 15);
            lblNightsCaption.TabIndex = 7;
            lblNightsCaption.Text = "Nights";

            lblNightsValue.AutoSize = true;
            lblNightsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNightsValue.ForeColor = Theme.TextDark;
            lblNightsValue.Location = new Point(530, 63);
            lblNightsValue.Name = "lblNightsValue";
            lblNightsValue.Size = new Size(80, 20);
            lblNightsValue.TabIndex = 8;
            lblNightsValue.Text = "—";

            lblGuestsCaption.AutoSize = true;
            lblGuestsCaption.Font = new Font("Segoe UI", 8.5F);
            lblGuestsCaption.ForeColor = Color.Gray;
            lblGuestsCaption.Location = new Point(620, 45);
            lblGuestsCaption.Name = "lblGuestsCaption";
            lblGuestsCaption.Size = new Size(45, 15);
            lblGuestsCaption.TabIndex = 9;
            lblGuestsCaption.Text = "Guests";

            lblGuestsValue.AutoSize = true;
            lblGuestsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGuestsValue.ForeColor = Theme.TextDark;
            lblGuestsValue.Location = new Point(620, 63);
            lblGuestsValue.Name = "lblGuestsValue";
            lblGuestsValue.Size = new Size(80, 20);
            lblGuestsValue.TabIndex = 10;
            lblGuestsValue.Text = "—";

            pnlStay.Controls.Add(lblStayHeading);
            pnlStay.Controls.Add(lblRoomCaption);
            pnlStay.Controls.Add(lblRoomValue);
            pnlStay.Controls.Add(lblCheckInCaption);
            pnlStay.Controls.Add(lblCheckInValue);
            pnlStay.Controls.Add(lblCheckOutCaption);
            pnlStay.Controls.Add(lblCheckOutValue);
            pnlStay.Controls.Add(lblNightsCaption);
            pnlStay.Controls.Add(lblNightsValue);
            pnlStay.Controls.Add(lblGuestsCaption);
            pnlStay.Controls.Add(lblGuestsValue);

            // =====================================================
            // BILLING PANEL
            // =====================================================

            pnlBilling.BackColor = Theme.Card;
            pnlBilling.BorderColor = Theme.Border;
            pnlBilling.BorderThickness = 1;
            pnlBilling.CornerRadius = 14;
            pnlBilling.Location = new Point(25, 410);
            pnlBilling.Name = "pnlBilling";
            pnlBilling.Size = new Size(710, 160);
            pnlBilling.TabIndex = 3;

            lblBillingHeading.AutoSize = true;
            lblBillingHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBillingHeading.ForeColor = Theme.TextDark;
            lblBillingHeading.Location = new Point(20, 12);
            lblBillingHeading.Name = "lblBillingHeading";
            lblBillingHeading.Size = new Size(120, 20);
            lblBillingHeading.TabIndex = 0;
            lblBillingHeading.Text = "Billing Summary";

            // Total
            lblTotalCaption.AutoSize = true;
            lblTotalCaption.Font = new Font("Segoe UI", 8.5F);
            lblTotalCaption.ForeColor = Color.Gray;
            lblTotalCaption.Location = new Point(22, 45);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Size = new Size(100, 15);
            lblTotalCaption.TabIndex = 1;
            lblTotalCaption.Text = "Total (pre-discount)";

            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTotalValue.ForeColor = Theme.TextDark;
            lblTotalValue.Location = new Point(22, 63);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(80, 20);
            lblTotalValue.TabIndex = 2;
            lblTotalValue.Text = "—";

            // Discount
            lblDiscountCaption.AutoSize = true;
            lblDiscountCaption.Font = new Font("Segoe UI", 8.5F);
            lblDiscountCaption.ForeColor = Color.Gray;
            lblDiscountCaption.Location = new Point(200, 45);
            lblDiscountCaption.Name = "lblDiscountCaption";
            lblDiscountCaption.Size = new Size(80, 15);
            lblDiscountCaption.TabIndex = 3;
            lblDiscountCaption.Text = "Tier Discount";

            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDiscountValue.ForeColor = Theme.Accent;
            lblDiscountValue.Location = new Point(200, 63);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(80, 20);
            lblDiscountValue.TabIndex = 4;
            lblDiscountValue.Text = "—";

            // Final
            lblFinalCaption.AutoSize = true;
            lblFinalCaption.Font = new Font("Segoe UI", 8.5F);
            lblFinalCaption.ForeColor = Color.Gray;
            lblFinalCaption.Location = new Point(380, 45);
            lblFinalCaption.Name = "lblFinalCaption";
            lblFinalCaption.Size = new Size(60, 15);
            lblFinalCaption.TabIndex = 5;
            lblFinalCaption.Text = "Final Total";

            lblFinalValue.AutoSize = true;
            lblFinalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFinalValue.ForeColor = Theme.Primary;
            lblFinalValue.Location = new Point(380, 61);
            lblFinalValue.Name = "lblFinalValue";
            lblFinalValue.Size = new Size(80, 25);
            lblFinalValue.TabIndex = 6;
            lblFinalValue.Text = "—";

            // Down Payment
            lblDownCaption.AutoSize = true;
            lblDownCaption.Font = new Font("Segoe UI", 8.5F);
            lblDownCaption.ForeColor = Color.Gray;
            lblDownCaption.Location = new Point(22, 100);
            lblDownCaption.Name = "lblDownCaption";
            lblDownCaption.Size = new Size(80, 15);
            lblDownCaption.TabIndex = 7;
            lblDownCaption.Text = "Down Payment";

            lblDownValue.AutoSize = true;
            lblDownValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDownValue.ForeColor = Theme.TextDark;
            lblDownValue.Location = new Point(22, 118);
            lblDownValue.Name = "lblDownValue";
            lblDownValue.Size = new Size(80, 20);
            lblDownValue.TabIndex = 8;
            lblDownValue.Text = "—";

            // Payment Status
            lblPaymentCaption.AutoSize = true;
            lblPaymentCaption.Font = new Font("Segoe UI", 8.5F);
            lblPaymentCaption.ForeColor = Color.Gray;
            lblPaymentCaption.Location = new Point(230, 100);
            lblPaymentCaption.Name = "lblPaymentCaption";
            lblPaymentCaption.Size = new Size(90, 15);
            lblPaymentCaption.TabIndex = 9;
            lblPaymentCaption.Text = "Payment Status";

            lblPaymentValue.AutoSize = true;
            lblPaymentValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPaymentValue.ForeColor = Theme.TextDark;
            lblPaymentValue.Location = new Point(230, 118);
            lblPaymentValue.Name = "lblPaymentValue";
            lblPaymentValue.Size = new Size(80, 20);
            lblPaymentValue.TabIndex = 10;
            lblPaymentValue.Text = "—";

            pnlBilling.Controls.Add(lblBillingHeading);
            pnlBilling.Controls.Add(lblTotalCaption);
            pnlBilling.Controls.Add(lblTotalValue);
            pnlBilling.Controls.Add(lblDiscountCaption);
            pnlBilling.Controls.Add(lblDiscountValue);
            pnlBilling.Controls.Add(lblFinalCaption);
            pnlBilling.Controls.Add(lblFinalValue);
            pnlBilling.Controls.Add(lblDownCaption);
            pnlBilling.Controls.Add(lblDownValue);
            pnlBilling.Controls.Add(lblPaymentCaption);
            pnlBilling.Controls.Add(lblPaymentValue);

            // =====================================================
            // REQUESTS PANEL
            // =====================================================

            pnlRequests.BackColor = Theme.Card;
            pnlRequests.BorderColor = Theme.Border;
            pnlRequests.BorderThickness = 1;
            pnlRequests.CornerRadius = 14;
            pnlRequests.Location = new Point(25, 585);
            pnlRequests.Name = "pnlRequests";
            pnlRequests.Size = new Size(710, 90);
            pnlRequests.TabIndex = 4;

            lblRequestsHeading.AutoSize = true;
            lblRequestsHeading.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRequestsHeading.ForeColor = Theme.TextDark;
            lblRequestsHeading.Location = new Point(20, 10);
            lblRequestsHeading.Name = "lblRequestsHeading";
            lblRequestsHeading.Size = new Size(130, 20);
            lblRequestsHeading.TabIndex = 0;
            lblRequestsHeading.Text = "Special Requests";

            lblRequestsValue.AutoSize = false;
            lblRequestsValue.Font = new Font("Segoe UI", 9.5F);
            lblRequestsValue.ForeColor = Theme.TextDark;
            lblRequestsValue.Location = new Point(22, 35);
            lblRequestsValue.Name = "lblRequestsValue";
            lblRequestsValue.Size = new Size(670, 45);
            lblRequestsValue.TabIndex = 1;
            lblRequestsValue.Text = "—";

            pnlRequests.Controls.Add(lblRequestsHeading);
            pnlRequests.Controls.Add(lblRequestsValue);

            // =====================================================
            // CREATED
            // =====================================================

            lblCreatedCaption.AutoSize = true;
            lblCreatedCaption.Font = new Font("Segoe UI", 8.5F);
            lblCreatedCaption.ForeColor = Color.Gray;
            lblCreatedCaption.Location = new Point(28, 690);
            lblCreatedCaption.Name = "lblCreatedCaption";
            lblCreatedCaption.Size = new Size(80, 15);
            lblCreatedCaption.TabIndex = 5;
            lblCreatedCaption.Text = "Created:";

            lblCreatedValue.AutoSize = true;
            lblCreatedValue.Font = new Font("Segoe UI", 9.5F);
            lblCreatedValue.ForeColor = Theme.TextDark;
            lblCreatedValue.Location = new Point(90, 690);
            lblCreatedValue.Name = "lblCreatedValue";
            lblCreatedValue.Size = new Size(120, 17);
            lblCreatedValue.TabIndex = 6;
            lblCreatedValue.Text = "—";

            // =====================================================
            // CLOSE
            // =====================================================

            btnClose.NormalColor = Theme.Primary;
            btnClose.HoverColor = Theme.PrimaryHover;
            btnClose.CornerRadius = 10;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(590, 710);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(145, 42);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;

            // =====================================================
            // ADD CONTROLS
            // =====================================================

            Controls.Add(pnlHeader);
            Controls.Add(pnlGuest);
            Controls.Add(pnlStay);
            Controls.Add(pnlBilling);
            Controls.Add(pnlRequests);
            Controls.Add(lblCreatedCaption);
            Controls.Add(lblCreatedValue);
            Controls.Add(btnClose);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlGuest.ResumeLayout(false);
            pnlGuest.PerformLayout();

            pnlStay.ResumeLayout(false);
            pnlStay.PerformLayout();

            pnlBilling.ResumeLayout(false);
            pnlBilling.PerformLayout();

            pnlRequests.ResumeLayout(false);
            pnlRequests.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}