#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class CheckInOutControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private RoundedButton btnTabCheckIn = null!;
        private RoundedButton btnTabCheckOuts = null!;

        private Panel pnlCheckInTab = null!;
        private Panel pnlCheckOutTab = null!;

        private RoundedPanel pnlLeft = null!;
        private RoundedPanel pnlRight = null!;

        private Label lblGuestSection = null!;
        private Label lblFirstName = null!;
        private TextBox txtFirstName = null!;
        private Label lblMiddleName = null!;
        private TextBox txtMiddleName = null!;
        private Label lblLastName = null!;
        private TextBox txtLastName = null!;
        private Label lblContact = null!;
        private TextBox txtContactNumber = null!;
        private Label lblEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblAddress = null!;
        private TextBox txtAddress = null!;

        private Label lblStaySection = null!;
        private Label lblRoomType = null!;
        private ComboBox cmbRoomType = null!;
        private Label lblCheckIn = null!;
        private DateTimePicker dtpCheckIn = null!;
        private Label lblCheckOut = null!;
        private DateTimePicker dtpCheckOut = null!;
        private Label lblGuests = null!;
        private NumericUpDown nudGuests = null!;
        private Label lblSpecialRequests = null!;
        private TextBox txtSpecialRequests = null!;

        private Label lblSummaryHeading = null!;
        private Label lblSummaryRoomNumberCaption = null!;
        private Label lblSummaryRoomNumber = null!;
        private Label lblSummaryRoomTypeCaption = null!;
        private Label lblSummaryRoomType = null!;
        private Label lblSummaryRateCaption = null!;
        private Label lblSummaryRate = null!;
        private Label lblSummaryNightsCaption = null!;
        private Label lblSummaryNights = null!;
        private Label lblDivider1 = null!;
        private Label lblSummarySubtotalCaption = null!;
        private Label lblSummarySubtotal = null!;
        private Label lblSummaryTotalCaption = null!;
        private Label lblSummaryTotal = null!;
        private RoundedButton btnCheckIn = null!;

        private RoundedPanel pnlCheckOutList = null!;
        private DataGridView dgvActiveCheckOuts = null!;
        private RoundedButton btnCheckOut = null!;
        private Label lblCheckOutStatus = null!;

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

            btnTabCheckIn = new RoundedButton();
            btnTabCheckOuts = new RoundedButton();

            pnlCheckInTab = new Panel();
            pnlCheckOutTab = new Panel();

            pnlLeft = new RoundedPanel();
            pnlRight = new RoundedPanel();

            lblGuestSection = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblContact = new Label();
            txtContactNumber = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();

            lblStaySection = new Label();
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();
            lblGuests = new Label();
            nudGuests = new NumericUpDown();
            lblSpecialRequests = new Label();
            txtSpecialRequests = new TextBox();

            lblSummaryHeading = new Label();
            lblSummaryRoomNumberCaption = new Label();
            lblSummaryRoomNumber = new Label();
            lblSummaryRoomTypeCaption = new Label();
            lblSummaryRoomType = new Label();
            lblSummaryRateCaption = new Label();
            lblSummaryRate = new Label();
            lblSummaryNightsCaption = new Label();
            lblSummaryNights = new Label();
            lblDivider1 = new Label();
            lblSummarySubtotalCaption = new Label();
            lblSummarySubtotal = new Label();
            lblSummaryTotalCaption = new Label();
            lblSummaryTotal = new Label();
            btnCheckIn = new RoundedButton();

            pnlCheckOutList = new RoundedPanel();
            dgvActiveCheckOuts = new DataGridView();
            btnCheckOut = new RoundedButton();
            lblCheckOutStatus = new Label();

            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlCheckInTab.SuspendLayout();
            pnlCheckOutTab.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlCheckOutList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGuests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveCheckOuts).BeginInit();

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

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(260, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Check In / Out";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Register a guest or check out an in-house guest";

            // =====================================================
            // TABS
            // =====================================================

            btnTabCheckIn.NormalColor = Theme.Primary;
            btnTabCheckIn.HoverColor = Theme.PrimaryHover;
            btnTabCheckIn.CornerRadius = 10;
            btnTabCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTabCheckIn.ForeColor = Color.White;
            btnTabCheckIn.Location = new Point(35, 125);
            btnTabCheckIn.Name = "btnTabCheckIn";
            btnTabCheckIn.Size = new Size(180, 44);
            btnTabCheckIn.TabIndex = 1;
            btnTabCheckIn.Text = "New Check-In";
            btnTabCheckIn.UseVisualStyleBackColor = false;
            btnTabCheckIn.Click += new EventHandler(btnTabCheckIn_Click);

            btnTabCheckOuts.NormalColor = Theme.Field;
            btnTabCheckOuts.HoverColor = Theme.Tint;
            btnTabCheckOuts.CornerRadius = 10;
            btnTabCheckOuts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTabCheckOuts.ForeColor = Theme.TextDark;
            btnTabCheckOuts.Location = new Point(225, 125);
            btnTabCheckOuts.Name = "btnTabCheckOuts";
            btnTabCheckOuts.Size = new Size(180, 44);
            btnTabCheckOuts.TabIndex = 2;
            btnTabCheckOuts.Text = "Active Check-Outs";
            btnTabCheckOuts.UseVisualStyleBackColor = false;
            btnTabCheckOuts.Click += new EventHandler(btnTabCheckOuts_Click);

            // =====================================================
            // CHECK-IN TAB
            // =====================================================

            pnlCheckInTab.BackColor = Theme.Background;
            pnlCheckInTab.Location = new Point(0, 180);
            pnlCheckInTab.Name = "pnlCheckInTab";
            pnlCheckInTab.Size = new Size(970, 580);
            pnlCheckInTab.TabIndex = 3;

            pnlCheckInTab.Controls.Add(pnlLeft);
            pnlCheckInTab.Controls.Add(pnlRight);

            // ---- LEFT PANEL ----

            pnlLeft.BackColor = Theme.Card;
            pnlLeft.BorderColor = Theme.Border;
            pnlLeft.BorderThickness = 1;
            pnlLeft.CornerRadius = 14;
            pnlLeft.Location = new Point(35, 10);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(540, 550);
            pnlLeft.TabIndex = 0;

            lblGuestSection.AutoSize = true;
            lblGuestSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGuestSection.ForeColor = Theme.TextDark;
            lblGuestSection.Location = new Point(25, 20);
            lblGuestSection.Name = "lblGuestSection";
            lblGuestSection.Size = new Size(160, 21);
            lblGuestSection.TabIndex = 0;
            lblGuestSection.Text = "Guest Information";

            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirstName.ForeColor = Theme.TextDark;
            lblFirstName.Location = new Point(25, 55);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(70, 15);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name *";

            txtFirstName.Font = new Font("Segoe UI", 9.5F);
            txtFirstName.Location = new Point(25, 75);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(155, 24);
            txtFirstName.TabIndex = 2;

            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMiddleName.ForeColor = Theme.TextDark;
            lblMiddleName.Location = new Point(192, 55);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(80, 15);
            lblMiddleName.TabIndex = 3;
            lblMiddleName.Text = "Middle Name";

            txtMiddleName.Font = new Font("Segoe UI", 9.5F);
            txtMiddleName.Location = new Point(192, 75);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(155, 24);
            txtMiddleName.TabIndex = 4;

            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLastName.ForeColor = Theme.TextDark;
            lblLastName.Location = new Point(359, 55);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(70, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Last Name *";

            txtLastName.Font = new Font("Segoe UI", 9.5F);
            txtLastName.Location = new Point(359, 75);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(155, 24);
            txtLastName.TabIndex = 6;

            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContact.ForeColor = Theme.TextDark;
            lblContact.Location = new Point(25, 115);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(100, 15);
            lblContact.TabIndex = 7;
            lblContact.Text = "Contact Number *";

            txtContactNumber.Font = new Font("Segoe UI", 9.5F);
            txtContactNumber.Location = new Point(25, 135);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(200, 24);
            txtContactNumber.TabIndex = 8;

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Theme.TextDark;
            lblEmail.Location = new Point(237, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(40, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";

            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(237, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(277, 24);
            txtEmail.TabIndex = 10;

            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Theme.TextDark;
            lblAddress.Location = new Point(25, 175);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(55, 15);
            lblAddress.TabIndex = 11;
            lblAddress.Text = "Address";

            txtAddress.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Location = new Point(25, 195);
            txtAddress.Multiline = true;
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(489, 55);
            txtAddress.TabIndex = 12;

            lblStaySection.AutoSize = true;
            lblStaySection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStaySection.ForeColor = Theme.TextDark;
            lblStaySection.Location = new Point(25, 270);
            lblStaySection.Name = "lblStaySection";
            lblStaySection.Size = new Size(130, 21);
            lblStaySection.TabIndex = 13;
            lblStaySection.Text = "Stay Details";

            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoomType.ForeColor = Theme.TextDark;
            lblRoomType.Location = new Point(25, 305);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(80, 15);
            lblRoomType.TabIndex = 14;
            lblRoomType.Text = "Room Type *";

            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 9.5F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(25, 325);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(230, 25);
            cmbRoomType.TabIndex = 15;

            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckIn.ForeColor = Theme.TextDark;
            lblCheckIn.Location = new Point(270, 305);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(60, 15);
            lblCheckIn.TabIndex = 16;
            lblCheckIn.Text = "Check In";

            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(270, 325);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(115, 23);
            dtpCheckIn.TabIndex = 17;
            dtpCheckIn.Value = DateTime.Today;

            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckOut.ForeColor = Theme.TextDark;
            lblCheckOut.Location = new Point(395, 305);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(65, 15);
            lblCheckOut.TabIndex = 18;
            lblCheckOut.Text = "Check Out";

            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(395, 325);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(115, 23);
            dtpCheckOut.TabIndex = 19;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            lblGuests.AutoSize = true;
            lblGuests.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGuests.ForeColor = Theme.TextDark;
            lblGuests.Location = new Point(25, 365);
            lblGuests.Name = "lblGuests";
            lblGuests.Size = new Size(50, 15);
            lblGuests.TabIndex = 20;
            lblGuests.Text = "Guests";

            nudGuests.Location = new Point(25, 385);
            nudGuests.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudGuests.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGuests.Name = "nudGuests";
            nudGuests.Size = new Size(80, 23);
            nudGuests.TabIndex = 21;
            nudGuests.Value = new decimal(new int[] { 1, 0, 0, 0 });

            lblSpecialRequests.AutoSize = true;
            lblSpecialRequests.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSpecialRequests.ForeColor = Theme.TextDark;
            lblSpecialRequests.Location = new Point(130, 365);
            lblSpecialRequests.Name = "lblSpecialRequests";
            lblSpecialRequests.Size = new Size(105, 15);
            lblSpecialRequests.TabIndex = 22;
            lblSpecialRequests.Text = "Special Requests";

            txtSpecialRequests.Font = new Font("Segoe UI", 9.5F);
            txtSpecialRequests.Location = new Point(130, 385);
            txtSpecialRequests.Multiline = true;
            txtSpecialRequests.ScrollBars = ScrollBars.Vertical;
            txtSpecialRequests.Name = "txtSpecialRequests";
            txtSpecialRequests.Size = new Size(384, 55);
            txtSpecialRequests.TabIndex = 23;

            pnlLeft.Controls.Add(lblGuestSection);
            pnlLeft.Controls.Add(lblFirstName);
            pnlLeft.Controls.Add(txtFirstName);
            pnlLeft.Controls.Add(lblMiddleName);
            pnlLeft.Controls.Add(txtMiddleName);
            pnlLeft.Controls.Add(lblLastName);
            pnlLeft.Controls.Add(txtLastName);
            pnlLeft.Controls.Add(lblContact);
            pnlLeft.Controls.Add(txtContactNumber);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblAddress);
            pnlLeft.Controls.Add(txtAddress);
            pnlLeft.Controls.Add(lblStaySection);
            pnlLeft.Controls.Add(lblRoomType);
            pnlLeft.Controls.Add(cmbRoomType);
            pnlLeft.Controls.Add(lblCheckIn);
            pnlLeft.Controls.Add(dtpCheckIn);
            pnlLeft.Controls.Add(lblCheckOut);
            pnlLeft.Controls.Add(dtpCheckOut);
            pnlLeft.Controls.Add(lblGuests);
            pnlLeft.Controls.Add(nudGuests);
            pnlLeft.Controls.Add(lblSpecialRequests);
            pnlLeft.Controls.Add(txtSpecialRequests);

            // ---- RIGHT PANEL ----

            pnlRight.BackColor = Theme.Card;
            pnlRight.BorderColor = Theme.Border;
            pnlRight.BorderThickness = 1;
            pnlRight.CornerRadius = 14;
            pnlRight.Location = new Point(595, 10);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(340, 550);
            pnlRight.TabIndex = 1;

            lblSummaryHeading.AutoSize = true;
            lblSummaryHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSummaryHeading.ForeColor = Theme.TextDark;
            lblSummaryHeading.Location = new Point(25, 20);
            lblSummaryHeading.Name = "lblSummaryHeading";
            lblSummaryHeading.Size = new Size(150, 23);
            lblSummaryHeading.TabIndex = 0;
            lblSummaryHeading.Text = "Order Summary";

            lblSummaryRoomNumberCaption.AutoSize = true;
            lblSummaryRoomNumberCaption.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSummaryRoomNumberCaption.ForeColor = Color.Gray;
            lblSummaryRoomNumberCaption.Location = new Point(25, 65);
            lblSummaryRoomNumberCaption.Name = "lblSummaryRoomNumberCaption";
            lblSummaryRoomNumberCaption.Size = new Size(90, 15);
            lblSummaryRoomNumberCaption.TabIndex = 1;
            lblSummaryRoomNumberCaption.Text = "Room Number";

            lblSummaryRoomNumber.AutoSize = true;
            lblSummaryRoomNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummaryRoomNumber.ForeColor = Theme.TextDark;
            lblSummaryRoomNumber.Location = new Point(25, 82);
            lblSummaryRoomNumber.Name = "lblSummaryRoomNumber";
            lblSummaryRoomNumber.Size = new Size(20, 17);
            lblSummaryRoomNumber.TabIndex = 2;
            lblSummaryRoomNumber.Text = "—";

            lblSummaryRoomTypeCaption.AutoSize = true;
            lblSummaryRoomTypeCaption.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSummaryRoomTypeCaption.ForeColor = Color.Gray;
            lblSummaryRoomTypeCaption.Location = new Point(195, 65);
            lblSummaryRoomTypeCaption.Name = "lblSummaryRoomTypeCaption";
            lblSummaryRoomTypeCaption.Size = new Size(70, 15);
            lblSummaryRoomTypeCaption.TabIndex = 3;
            lblSummaryRoomTypeCaption.Text = "Room Type";

            lblSummaryRoomType.AutoSize = true;
            lblSummaryRoomType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummaryRoomType.ForeColor = Theme.TextDark;
            lblSummaryRoomType.Location = new Point(195, 82);
            lblSummaryRoomType.Name = "lblSummaryRoomType";
            lblSummaryRoomType.Size = new Size(20, 17);
            lblSummaryRoomType.TabIndex = 4;
            lblSummaryRoomType.Text = "—";

            lblSummaryRateCaption.AutoSize = true;
            lblSummaryRateCaption.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSummaryRateCaption.ForeColor = Color.Gray;
            lblSummaryRateCaption.Location = new Point(25, 120);
            lblSummaryRateCaption.Name = "lblSummaryRateCaption";
            lblSummaryRateCaption.Size = new Size(80, 15);
            lblSummaryRateCaption.TabIndex = 5;
            lblSummaryRateCaption.Text = "Rate / Night";

            lblSummaryRate.AutoSize = true;
            lblSummaryRate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummaryRate.ForeColor = Theme.TextDark;
            lblSummaryRate.Location = new Point(25, 137);
            lblSummaryRate.Name = "lblSummaryRate";
            lblSummaryRate.Size = new Size(20, 17);
            lblSummaryRate.TabIndex = 6;
            lblSummaryRate.Text = "—";

            lblSummaryNightsCaption.AutoSize = true;
            lblSummaryNightsCaption.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSummaryNightsCaption.ForeColor = Color.Gray;
            lblSummaryNightsCaption.Location = new Point(195, 120);
            lblSummaryNightsCaption.Name = "lblSummaryNightsCaption";
            lblSummaryNightsCaption.Size = new Size(40, 15);
            lblSummaryNightsCaption.TabIndex = 7;
            lblSummaryNightsCaption.Text = "Nights";

            lblSummaryNights.AutoSize = true;
            lblSummaryNights.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummaryNights.ForeColor = Theme.TextDark;
            lblSummaryNights.Location = new Point(195, 137);
            lblSummaryNights.Name = "lblSummaryNights";
            lblSummaryNights.Size = new Size(20, 17);
            lblSummaryNights.TabIndex = 8;
            lblSummaryNights.Text = "—";

            lblDivider1.AutoSize = false;
            lblDivider1.BackColor = Theme.Border;
            lblDivider1.Location = new Point(25, 175);
            lblDivider1.Name = "lblDivider1";
            lblDivider1.Size = new Size(290, 1);
            lblDivider1.TabIndex = 9;

            lblSummarySubtotalCaption.AutoSize = true;
            lblSummarySubtotalCaption.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblSummarySubtotalCaption.ForeColor = Color.Gray;
            lblSummarySubtotalCaption.Location = new Point(25, 195);
            lblSummarySubtotalCaption.Name = "lblSummarySubtotalCaption";
            lblSummarySubtotalCaption.Size = new Size(60, 17);
            lblSummarySubtotalCaption.TabIndex = 10;
            lblSummarySubtotalCaption.Text = "Sub-total";

            lblSummarySubtotal.AutoSize = true;
            lblSummarySubtotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummarySubtotal.ForeColor = Theme.TextDark;
            lblSummarySubtotal.Location = new Point(235, 195);
            lblSummarySubtotal.Name = "lblSummarySubtotal";
            lblSummarySubtotal.Size = new Size(60, 17);
            lblSummarySubtotal.TabIndex = 11;
            lblSummarySubtotal.Text = "₱0.00";
            lblSummarySubtotal.TextAlign = ContentAlignment.MiddleRight;

            lblSummaryTotalCaption.AutoSize = true;
            lblSummaryTotalCaption.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSummaryTotalCaption.ForeColor = Theme.TextDark;
            lblSummaryTotalCaption.Location = new Point(25, 400);
            lblSummaryTotalCaption.Name = "lblSummaryTotalCaption";
            lblSummaryTotalCaption.Size = new Size(60, 23);
            lblSummaryTotalCaption.TabIndex = 12;
            lblSummaryTotalCaption.Text = "Total";

            lblSummaryTotal.AutoSize = true;
            lblSummaryTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSummaryTotal.ForeColor = Theme.Accent;
            lblSummaryTotal.Location = new Point(195, 395);
            lblSummaryTotal.Name = "lblSummaryTotal";
            lblSummaryTotal.Size = new Size(100, 32);
            lblSummaryTotal.TabIndex = 13;
            lblSummaryTotal.Text = "₱0.00";
            lblSummaryTotal.TextAlign = ContentAlignment.MiddleRight;

            btnCheckIn.NormalColor = Theme.Accent;
            btnCheckIn.HoverColor = Color.FromArgb(210, 90, 30);
            btnCheckIn.CornerRadius = 10;
            btnCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(25, 455);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(290, 60);
            btnCheckIn.TabIndex = 14;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = false;

            pnlRight.Controls.Add(lblSummaryHeading);
            pnlRight.Controls.Add(lblSummaryRoomNumberCaption);
            pnlRight.Controls.Add(lblSummaryRoomNumber);
            pnlRight.Controls.Add(lblSummaryRoomTypeCaption);
            pnlRight.Controls.Add(lblSummaryRoomType);
            pnlRight.Controls.Add(lblSummaryRateCaption);
            pnlRight.Controls.Add(lblSummaryRate);
            pnlRight.Controls.Add(lblSummaryNightsCaption);
            pnlRight.Controls.Add(lblSummaryNights);
            pnlRight.Controls.Add(lblDivider1);
            pnlRight.Controls.Add(lblSummarySubtotalCaption);
            pnlRight.Controls.Add(lblSummarySubtotal);
            pnlRight.Controls.Add(lblSummaryTotalCaption);
            pnlRight.Controls.Add(lblSummaryTotal);
            pnlRight.Controls.Add(btnCheckIn);

            // =====================================================
            // CHECK-OUT TAB
            // =====================================================

            pnlCheckOutTab.BackColor = Theme.Background;
            pnlCheckOutTab.Location = new Point(0, 180);
            pnlCheckOutTab.Name = "pnlCheckOutTab";
            pnlCheckOutTab.Size = new Size(970, 580);
            pnlCheckOutTab.TabIndex = 4;
            pnlCheckOutTab.Visible = false;

            pnlCheckOutTab.Controls.Add(pnlCheckOutList);
            pnlCheckOutTab.Controls.Add(btnCheckOut);
            pnlCheckOutTab.Controls.Add(lblCheckOutStatus);

            pnlCheckOutList.BackColor = Theme.Card;
            pnlCheckOutList.BorderColor = Theme.Border;
            pnlCheckOutList.BorderThickness = 1;
            pnlCheckOutList.CornerRadius = 14;
            pnlCheckOutList.Location = new Point(35, 10);
            pnlCheckOutList.Name = "pnlCheckOutList";
            pnlCheckOutList.Size = new Size(900, 480);
            pnlCheckOutList.TabIndex = 0;

            pnlCheckOutList.Controls.Add(dgvActiveCheckOuts);

            dgvActiveCheckOuts.AllowUserToAddRows = false;
            dgvActiveCheckOuts.AllowUserToDeleteRows = false;
            dgvActiveCheckOuts.AllowUserToResizeRows = false;
            dgvActiveCheckOuts.BackgroundColor = Theme.Card;
            dgvActiveCheckOuts.BorderStyle = BorderStyle.None;
            dgvActiveCheckOuts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvActiveCheckOuts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvActiveCheckOuts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvActiveCheckOuts.ColumnHeadersHeight = 44;
            dgvActiveCheckOuts.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvActiveCheckOuts.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvActiveCheckOuts.EnableHeadersVisualStyles = false;
            dgvActiveCheckOuts.GridColor = Theme.Border;
            dgvActiveCheckOuts.Location = new Point(10, 10);
            dgvActiveCheckOuts.Margin = new Padding(0);
            dgvActiveCheckOuts.MultiSelect = false;
            dgvActiveCheckOuts.Name = "dgvActiveCheckOuts";
            dgvActiveCheckOuts.ReadOnly = true;
            dgvActiveCheckOuts.RowHeadersVisible = false;
            dgvActiveCheckOuts.RowTemplate.Height = 40;
            dgvActiveCheckOuts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActiveCheckOuts.Size = new Size(880, 400);
            dgvActiveCheckOuts.TabIndex = 0;
            dgvActiveCheckOuts.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            btnCheckOut.NormalColor = Theme.Accent;
            btnCheckOut.HoverColor = Color.FromArgb(210, 90, 30);
            btnCheckOut.CornerRadius = 10;
            btnCheckOut.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(35, 505);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(200, 55);
            btnCheckOut.TabIndex = 1;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = false;

            lblCheckOutStatus.AutoSize = false;
            lblCheckOutStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblCheckOutStatus.ForeColor = Theme.TextDark;
            lblCheckOutStatus.Location = new Point(255, 520);
            lblCheckOutStatus.Name = "lblCheckOutStatus";
            lblCheckOutStatus.Size = new Size(680, 25);
            lblCheckOutStatus.TabIndex = 2;
            lblCheckOutStatus.Text = "";
            lblCheckOutStatus.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // SHARED FOOTER
            // =====================================================

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(840, 770);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(35, 775);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(790, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "CheckInOutControl";
            Size = new Size(970, 830);

            Controls.Add(pnlHeader);
            Controls.Add(btnTabCheckIn);
            Controls.Add(btnTabCheckOuts);
            Controls.Add(pnlCheckInTab);
            Controls.Add(pnlCheckOutTab);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlCheckInTab.ResumeLayout(false);
            pnlCheckOutTab.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlCheckOutList.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)nudGuests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveCheckOuts).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}