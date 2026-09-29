#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class ReservationManagementControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        private Label lblRecords = null!;
        private Label lblSearch = null!;

        private RoundedPanel pnlSearch = null!;
        private TextBox txtSearch = null!;

        private Label lblCustomer = null!;
        private ComboBox cmbCustomer = null!;

        private Label lblRoom = null!;
        private ComboBox cmbRoom = null!;

        private Label lblCheckIn = null!;
        private DateTimePicker dtpCheckIn = null!;

        private Label lblCheckOut = null!;
        private DateTimePicker dtpCheckOut = null!;

        private Label lblGuests = null!;
        private NumericUpDown nudGuests = null!;

        private Label lblSpecialRequests = null!;
        private TextBox txtSpecialRequests = null!;

        private Label lblDownPayment = null!;
        private NumericUpDown nudDownPayment = null!;

        private Label lblDiscountCaption = null!;
        private Label lblDiscountValue = null!;
        private Label lblFinalCaption = null!;
        private Label lblFinalValue = null!;

        private RoundedButton btnNewReservation = null!;
        private RoundedButton btnUpdate = null!;
        private RoundedButton btnCancel = null!;

        private RoundedPanel pnlTable = null!;
        private DataGridView dgvReservations = null!;

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

            lblRecords = new Label();
            lblSearch = new Label();

            pnlSearch = new RoundedPanel();
            txtSearch = new TextBox();

            lblCustomer = new Label();
            cmbCustomer = new ComboBox();

            lblRoom = new Label();
            cmbRoom = new ComboBox();

            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();

            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();

            lblGuests = new Label();
            nudGuests = new NumericUpDown();

            lblSpecialRequests = new Label();
            txtSpecialRequests = new TextBox();

            lblDownPayment = new Label();
            nudDownPayment = new NumericUpDown();

            lblDiscountCaption = new Label();
            lblDiscountValue = new Label();
            lblFinalCaption = new Label();
            lblFinalValue = new Label();

            btnNewReservation = new RoundedButton();
            btnUpdate = new RoundedButton();
            btnCancel = new RoundedButton();

            pnlTable = new RoundedPanel();
            dgvReservations = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGuests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDownPayment).BeginInit();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();

            SuspendLayout();

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

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reservations";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 72);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(300, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage hotel reservations";

            // =====================================================
            // RECORDS
            // =====================================================

            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblRecords.ForeColor = Theme.TextDark;
            lblRecords.Location = new Point(35, 140);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(95, 31);
            lblRecords.TabIndex = 2;
            lblRecords.Text = "Records";

            // =====================================================
            // SEARCH LABEL
            // =====================================================

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Theme.TextDark;
            lblSearch.Location = new Point(35, 182);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(47, 15);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search";

            // =====================================================
            // SEARCH PANEL
            // =====================================================

            pnlSearch.BackColor = Theme.Field;
            pnlSearch.BorderColor = Theme.Border;
            pnlSearch.BorderThickness = 1;
            pnlSearch.CornerRadius = 12;
            pnlSearch.Location = new Point(35, 205);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(400, 44);
            pnlSearch.TabIndex = 4;

            txtSearch.BackColor = Theme.Field;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.Location = new Point(14, 12);
            txtSearch.Margin = new Padding(0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search customer, room, status...";
            txtSearch.Size = new Size(370, 18);
            txtSearch.TabIndex = 0;

            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

            pnlSearch.Controls.Add(txtSearch);

            // =====================================================
            // CUSTOMER
            // =====================================================

            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomer.ForeColor = Theme.TextDark;
            lblCustomer.Location = new Point(35, 270);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 5;
            lblCustomer.Text = "Customer";

            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(35, 292);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(250, 25);
            cmbCustomer.TabIndex = 6;

            // =====================================================
            // ROOM
            // =====================================================

            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoom.ForeColor = Theme.TextDark;
            lblRoom.Location = new Point(305, 270);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(38, 15);
            lblRoom.TabIndex = 7;
            lblRoom.Text = "Room";

            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Font = new Font("Segoe UI", 9.5F);
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(305, 292);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(180, 25);
            cmbRoom.TabIndex = 8;

            // =====================================================
            // CHECK IN
            // =====================================================

            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckIn.ForeColor = Theme.TextDark;
            lblCheckIn.Location = new Point(505, 270);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(57, 15);
            lblCheckIn.TabIndex = 9;
            lblCheckIn.Text = "Check In";

            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(505, 292);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(120, 23);
            dtpCheckIn.TabIndex = 10;
            dtpCheckIn.Value = DateTime.Today;

            // =====================================================
            // CHECK OUT
            // =====================================================

            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckOut.ForeColor = Theme.TextDark;
            lblCheckOut.Location = new Point(645, 270);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(67, 15);
            lblCheckOut.TabIndex = 11;
            lblCheckOut.Text = "Check Out";

            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(645, 292);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(120, 23);
            dtpCheckOut.TabIndex = 12;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            // =====================================================
            // GUESTS
            // =====================================================

            lblGuests.AutoSize = true;
            lblGuests.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGuests.ForeColor = Theme.TextDark;
            lblGuests.Location = new Point(785, 270);
            lblGuests.Name = "lblGuests";
            lblGuests.Size = new Size(43, 15);
            lblGuests.TabIndex = 13;
            lblGuests.Text = "Guests";

            nudGuests.Location = new Point(785, 292);
            nudGuests.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudGuests.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGuests.Name = "nudGuests";
            nudGuests.Size = new Size(80, 23);
            nudGuests.TabIndex = 14;
            nudGuests.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // =====================================================
            // SPECIAL REQUESTS
            // =====================================================

            lblSpecialRequests.AutoSize = true;
            lblSpecialRequests.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSpecialRequests.ForeColor = Theme.TextDark;
            lblSpecialRequests.Location = new Point(35, 335);
            lblSpecialRequests.Name = "lblSpecialRequests";
            lblSpecialRequests.Size = new Size(102, 15);
            lblSpecialRequests.TabIndex = 15;
            lblSpecialRequests.Text = "Special Requests";

            txtSpecialRequests.Font = new Font("Segoe UI", 9.5F);
            txtSpecialRequests.Location = new Point(35, 357);
            txtSpecialRequests.Multiline = true;
            txtSpecialRequests.Name = "txtSpecialRequests";
            txtSpecialRequests.ScrollBars = ScrollBars.Vertical;
            txtSpecialRequests.Size = new Size(450, 55);
            txtSpecialRequests.TabIndex = 16;

            // =====================================================
            // DOWN PAYMENT
            // =====================================================

            lblDownPayment.AutoSize = true;
            lblDownPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDownPayment.ForeColor = Theme.TextDark;
            lblDownPayment.Location = new Point(505, 335);
            lblDownPayment.Name = "lblDownPayment";
            lblDownPayment.Size = new Size(110, 15);
            lblDownPayment.TabIndex = 17;
            lblDownPayment.Text = "Down Payment (₱)";

            nudDownPayment.DecimalPlaces = 2;
            nudDownPayment.Location = new Point(505, 357);
            nudDownPayment.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudDownPayment.Name = "nudDownPayment";
            nudDownPayment.Size = new Size(360, 23);
            nudDownPayment.TabIndex = 18;
            nudDownPayment.ThousandsSeparator = true;

            // =====================================================
            // DISCOUNT + FINAL (read-only summary)
            // =====================================================

            lblDiscountCaption.AutoSize = true;
            lblDiscountCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiscountCaption.ForeColor = Theme.TextDark;
            lblDiscountCaption.Location = new Point(505, 400);
            lblDiscountCaption.Name = "lblDiscountCaption";
            lblDiscountCaption.Size = new Size(80, 15);
            lblDiscountCaption.TabIndex = 19;
            lblDiscountCaption.Text = "Tier Discount";

            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscountValue.ForeColor = Theme.Accent;
            lblDiscountValue.Location = new Point(630, 398);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(90, 17);
            lblDiscountValue.TabIndex = 20;
            lblDiscountValue.Text = "—";

            lblFinalCaption.AutoSize = true;
            lblFinalCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFinalCaption.ForeColor = Theme.TextDark;
            lblFinalCaption.Location = new Point(505, 425);
            lblFinalCaption.Name = "lblFinalCaption";
            lblFinalCaption.Size = new Size(80, 15);
            lblFinalCaption.TabIndex = 21;
            lblFinalCaption.Text = "Final Total";

            lblFinalValue.AutoSize = true;
            lblFinalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinalValue.ForeColor = Theme.Primary;
            lblFinalValue.Location = new Point(630, 422);
            lblFinalValue.Name = "lblFinalValue";
            lblFinalValue.Size = new Size(90, 21);
            lblFinalValue.TabIndex = 22;
            lblFinalValue.Text = "—";

            // =====================================================
            // NEW RESERVATION
            // =====================================================

            btnNewReservation.NormalColor = Theme.Primary;
            btnNewReservation.HoverColor = Theme.PrimaryHover;
            btnNewReservation.CornerRadius = 10;
            btnNewReservation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNewReservation.ForeColor = Color.White;
            btnNewReservation.Location = new Point(505, 465);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(155, 55);
            btnNewReservation.TabIndex = 23;
            btnNewReservation.Text = "+ New Reservation";
            btnNewReservation.UseVisualStyleBackColor = false;

            btnNewReservation.Click += new EventHandler(btnNewReservation_Click);

            // =====================================================
            // UPDATE
            // =====================================================

            btnUpdate.NormalColor = Theme.Accent;
            btnUpdate.HoverColor = Theme.PrimaryHover;
            btnUpdate.CornerRadius = 10;
            btnUpdate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(670, 465);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(115, 55);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;

            btnUpdate.Click += new EventHandler(btnUpdate_Click);

            // =====================================================
            // CANCEL
            // =====================================================

            btnCancel.NormalColor = Theme.Danger;
            btnCancel.HoverColor = Color.FromArgb(160, 40, 40);
            btnCancel.CornerRadius = 10;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(795, 465);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 55);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            btnCancel.Click += new EventHandler(btnCancel_Click);

            // =====================================================
            // TABLE PANEL
            // =====================================================

            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;
            pnlTable.Location = new Point(35, 540);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(895, 215);
            pnlTable.TabIndex = 26;
            pnlTable.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            pnlTable.Controls.Add(dgvReservations);

            // =====================================================
            // RESERVATION TABLE
            // =====================================================

            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AllowUserToResizeRows = false;
            dgvReservations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReservations.BackgroundColor = Theme.Card;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvReservations.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };

            dgvReservations.ColumnHeadersHeight = 44;
            dgvReservations.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvReservations.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };

            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.GridColor = Theme.Border;
            dgvReservations.Location = new Point(10, 10);
            dgvReservations.Margin = new Padding(0);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowTemplate.Height = 40;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(875, 195);
            dgvReservations.TabIndex = 27;
            dgvReservations.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "ReservationManagementControl";
            Size = new Size(970, 790);

            Controls.Add(pnlHeader);
            Controls.Add(lblRecords);
            Controls.Add(lblSearch);
            Controls.Add(pnlSearch);
            Controls.Add(lblCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(lblRoom);
            Controls.Add(cmbRoom);
            Controls.Add(lblCheckIn);
            Controls.Add(dtpCheckIn);
            Controls.Add(lblCheckOut);
            Controls.Add(dtpCheckOut);
            Controls.Add(lblGuests);
            Controls.Add(nudGuests);
            Controls.Add(lblSpecialRequests);
            Controls.Add(txtSpecialRequests);
            Controls.Add(lblDownPayment);
            Controls.Add(nudDownPayment);
            Controls.Add(lblDiscountCaption);
            Controls.Add(lblDiscountValue);
            Controls.Add(lblFinalCaption);
            Controls.Add(lblFinalValue);
            Controls.Add(btnNewReservation);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(pnlTable);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)nudGuests).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDownPayment).EndInit();

            pnlTable.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}