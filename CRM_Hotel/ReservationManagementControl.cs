using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ReservationManagementControl : UserControl
    {
        private bool _isInitializing = false;

        // Current computed values for the pending reservation form
        private decimal _currentRoomPrice = 0m;
        private int _currentNights = 0;
        private decimal _currentTotal = 0m;         // room × nights
        private decimal _currentDiscountRate = 0m;  // 0.02 / 0.05 / 0.10 / 0
        private decimal _currentDiscountAmount = 0m;
        private decimal _currentFinal = 0m;
        private string _currentTier = "";

        public ReservationManagementControl()
        {
            _isInitializing = true;

            InitializeComponent();
            ConfigureTheme();
            WireAdditionalEvents();

            _isInitializing = false;

            LoadCustomers();
            LoadRooms();
            LoadReservations();
            RecalculateTotals();
        }

        public void ReloadData()
        {
            LoadCustomers();
            LoadRooms();
            LoadReservations();
        }

        private void DgvReservations_CellDoubleClick(
    object? sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var idCell = dgvReservations.Rows[e.RowIndex]
                .Cells["ReservationId"].Value;

            if (idCell == null) return;

            int reservationId = Convert.ToInt32(idCell);

            try
            {
                using (var db = new HotelDbContext())
                {
                    var reservation = db.Reservations
                        .FirstOrDefault(r => r.ReservationId == reservationId);

                    if (reservation == null)
                    {
                        MessageBox.Show(
                            "Reservation not found.",
                            "Reservations",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    using (var dlg = new ReservationDetailForm(reservation))
                    {
                        dlg.ShowDialog(this);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to open reservation detail.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void WireAdditionalEvents()
        {
            // Recalculate whenever anything that affects the total changes
            cmbCustomer.SelectedIndexChanged += (s, e) => RecalculateTotals();
            cmbRoom.SelectedIndexChanged += (s, e) => RecalculateTotals();
            dtpCheckIn.ValueChanged += (s, e) => RecalculateTotals();
            dtpCheckOut.ValueChanged += (s, e) => RecalculateTotals();
        }

        private void ConfigureTheme()
        {
            BackColor = Theme.Background;

            pnlHeader.BackColor = Theme.Primary;

            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Theme.Tint;

            lblRecords.ForeColor = Theme.TextDark;
            lblSearch.ForeColor = Theme.TextDark;

            pnlSearch.BackColor = Theme.Field;
            pnlSearch.BorderColor = Theme.Border;
            pnlSearch.BorderThickness = 1;
            pnlSearch.CornerRadius = 12;

            txtSearch.BackColor = Theme.Field;
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.BorderStyle = BorderStyle.None;

            btnNewReservation.NormalColor = Theme.Primary;
            btnNewReservation.HoverColor = Theme.PrimaryHover;
            btnNewReservation.CornerRadius = 10;

            btnUpdate.NormalColor = Theme.Accent;
            btnUpdate.HoverColor = Theme.PrimaryHover;
            btnUpdate.CornerRadius = 10;

            btnCancel.NormalColor = Theme.Danger;
            btnCancel.HoverColor = Color.FromArgb(160, 40, 40);
            btnCancel.CornerRadius = 10;

            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;

            dgvReservations.BackgroundColor = Theme.Card;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.GridColor = Theme.Border;
            dgvReservations.EnableHeadersVisualStyles = false;

            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Theme.Primary;
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReservations.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Primary;
            dgvReservations.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvReservations.DefaultCellStyle.BackColor = Theme.Card;
            dgvReservations.DefaultCellStyle.ForeColor = Theme.TextDark;
            dgvReservations.DefaultCellStyle.SelectionBackColor = Theme.Tint;
            dgvReservations.DefaultCellStyle.SelectionForeColor = Theme.Primary;
            dgvReservations.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvReservations.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvReservations.ColumnHeadersHeight = 44;
            dgvReservations.RowTemplate.Height = 40;

            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AllowUserToResizeRows = false;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.MultiSelect = false;
            dgvReservations.ReadOnly = true;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReservations.CellDoubleClick += DgvReservations_CellDoubleClick;

        }

        // =========================================================
        // TIER LOGIC
        // =========================================================
        private static string TierFor(int stays)
        {
            if (stays >= 10) return "Platinum";
            if (stays >= 5) return "Gold";
            if (stays >= 3) return "Silver";
            return "Bronze";
        }

        private int GetCompletedStays(int customerId)
        {
            using (var db = new HotelDbContext())
            {
                return db.Reservations
                    .Count(r => r.CustomerId == customerId &&
                                r.Status == "Checked-Out");
            }
        }

        private decimal GetDiscountRateForTier(string tier)
        {
            if (tier == "Bronze" || string.IsNullOrEmpty(tier))
                return 0m;

            using (var db = new HotelDbContext())
            {
                var d = db.Discounts
                    .FirstOrDefault(x => x.Tier == tier && x.IsActive);

                return d?.Rate ?? 0m;
            }
        }

        // =========================================================
        // RECALCULATE
        // =========================================================
        private void RecalculateTotals()
        {
            if (_isInitializing) return;

            try
            {
                _currentRoomPrice = 0m;
                _currentNights = 0;
                _currentTotal = 0m;
                _currentDiscountRate = 0m;
                _currentDiscountAmount = 0m;
                _currentFinal = 0m;
                _currentTier = "";

                // Room price
                if (cmbRoom.SelectedValue is int roomId)
                {
                    using (var db = new HotelDbContext())
                    {
                        var room = db.Rooms.FirstOrDefault(r => r.RoomId == roomId);
                        if (room != null)
                            _currentRoomPrice = room.Price;
                    }
                }

                // Nights
                int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                if (nights < 1) nights = 1;
                _currentNights = nights;

                _currentTotal = _currentRoomPrice * _currentNights;

                // Tier + discount rate
                if (cmbCustomer.SelectedValue is int customerId)
                {
                    int stays = GetCompletedStays(customerId);
                    _currentTier = TierFor(stays);
                    _currentDiscountRate = GetDiscountRateForTier(_currentTier);
                }

                _currentDiscountAmount = Math.Round(
                    _currentTotal * _currentDiscountRate, 2);

                _currentFinal = _currentTotal - _currentDiscountAmount;

                // Update labels
                if (string.IsNullOrEmpty(_currentTier) || _currentTier == "Bronze")
                {
                    lblDiscountValue.Text = "No tier discount";
                    lblDiscountValue.ForeColor = Color.Gray;
                }
                else
                {
                    lblDiscountValue.Text = _currentTier + " — " +
                        (_currentDiscountRate * 100m).ToString("0.##") + "% off (₱" +
                        _currentDiscountAmount.ToString("N2") + ")";
                    lblDiscountValue.ForeColor = Theme.Accent;
                }

                lblFinalValue.Text = "₱" + _currentFinal.ToString("N2");
            }
            catch
            {
                // Silent — recalculation is best-effort
            }
        }

        // =========================================================
        // LOAD CUSTOMERS
        // =========================================================
        private void LoadCustomers()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var customers = db.Customers
                        .Where(c => !c.IsArchived)
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .Select(c => new
                        {
                            c.CustomerId,
                            FullName =
                                c.FirstName + " " +
                                (c.MiddleName == null ? "" : c.MiddleName + " ") +
                                c.LastName
                        })
                        .ToList();

                    cmbCustomer.DataSource = customers;
                    cmbCustomer.DisplayMember = "FullName";
                    cmbCustomer.ValueMember = "CustomerId";
                    cmbCustomer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load customers.", ex);
            }
        }

        // =========================================================
        // LOAD ROOMS
        // =========================================================
        private void LoadRooms()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var rooms = db.Rooms
                        .Where(r => r.Status == "Available")
                        .OrderBy(r => r.RoomNumber)
                        .Select(r => new
                        {
                            r.RoomId,
                            RoomDisplay = r.RoomNumber + " - " + r.RoomType
                        })
                        .ToList();

                    cmbRoom.DataSource = rooms;
                    cmbRoom.DisplayMember = "RoomDisplay";
                    cmbRoom.ValueMember = "RoomId";
                    cmbRoom.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load rooms.", ex);
            }
        }

        // =========================================================
        // LOAD RESERVATIONS
        // =========================================================
        private void LoadReservations()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var data = QueryReservations(db, null);

                    dgvReservations.DataSource = data;
                    SetColumnWidths();

                    lblRecords.Text = data.Count + " reservation" +
                                      (data.Count == 1 ? "" : "s");
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load reservations.", ex);
            }
        }

        private static List<ReservationRow> QueryReservations(HotelDbContext db, string? searchText)
        {
            var query =
                from r in db.Reservations
                join c in db.Customers on r.CustomerId equals c.CustomerId
                join room in db.Rooms on r.RoomId equals room.RoomId
                select new ReservationRow
                {
                    ReservationId = r.ReservationId,
                    Customer = c.FirstName + " " + c.LastName,
                    Room = room.RoomNumber,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    NumberOfGuests = r.NumberOfGuests,
                    Status = r.Status,
                    TotalAmount = r.TotalAmount,
                    DiscountAmount = r.DiscountAmount,
                    FinalAmount = r.FinalAmount,
                    DownPayment = r.DownPayment,
                    PaymentStatus = r.PaymentStatus,
                    SpecialRequests = r.SpecialRequests,
                    CreatedAt = r.CreatedAt
                };

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(x =>
                    x.Customer.Contains(searchText) ||
                    x.Room.Contains(searchText) ||
                    x.Status.Contains(searchText));
            }

            return query
                .OrderByDescending(x => x.ReservationId)
                .ToList();
        }

        private class ReservationRow
        {
            public int ReservationId { get; set; }
            public string Customer { get; set; } = "";
            public string Room { get; set; } = "";
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int NumberOfGuests { get; set; }
            public string Status { get; set; } = "";
            public decimal TotalAmount { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal FinalAmount { get; set; }
            public decimal DownPayment { get; set; }
            public string PaymentStatus { get; set; } = "";
            public string? SpecialRequests { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        // =========================================================
        // COLUMN WIDTHS
        // =========================================================
        private void SetColumnWidths()
        {
            if (dgvReservations.Columns.Count == 0)
                return;

            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Headers for the columns we keep
            SetHeader("ReservationId", "ID");
            SetHeader("Customer", "Customer");
            SetHeader("Room", "Room");
            SetHeader("CheckInDate", "Check In");
            SetHeader("CheckOutDate", "Check Out");
            SetHeader("NumberOfGuests", "Guests");
            SetHeader("Status", "Status");
            SetHeader("FinalAmount", "Final");
            SetHeader("PaymentStatus", "Payment");

            // Fill weights for visible columns
            SetFillWeight("ReservationId", 40);
            SetFillWeight("Customer", 180);
            SetFillWeight("Room", 70);
            SetFillWeight("CheckInDate", 95);
            SetFillWeight("CheckOutDate", 95);
            SetFillWeight("NumberOfGuests", 65);
            SetFillWeight("Status", 100);
            SetFillWeight("FinalAmount", 100);
            SetFillWeight("PaymentStatus", 95);

            // Hide the columns that aren't useful at a glance
            HideIfPresent("TotalAmount");
            HideIfPresent("DiscountAmount");
            HideIfPresent("DownPayment");
            HideIfPresent("SpecialRequests");
            HideIfPresent("CreatedAt");

            // Format the money column
            if (dgvReservations.Columns.Contains("FinalAmount"))
                dgvReservations.Columns["FinalAmount"].DefaultCellStyle.Format = "N2";

            // Format date columns
            if (dgvReservations.Columns.Contains("CheckInDate"))
                dgvReservations.Columns["CheckInDate"].DefaultCellStyle.Format = "MMM dd";

            if (dgvReservations.Columns.Contains("CheckOutDate"))
                dgvReservations.Columns["CheckOutDate"].DefaultCellStyle.Format = "MMM dd";
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dgvReservations.Columns.Contains(columnName))
                dgvReservations.Columns[columnName].HeaderText = headerText;
        }

        private void SetFillWeight(string columnName, float weight)
        {
            if (dgvReservations.Columns.Contains(columnName))
                dgvReservations.Columns[columnName].FillWeight = weight;
        }

        // =========================================================
        // SEARCH
        // =========================================================

        private void HideIfPresent(string columnName)
        {
            if (dgvReservations.Columns.Contains(columnName))
                dgvReservations.Columns[columnName].Visible = false;
        }
        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;

            string searchText = txtSearch.Text.Trim();

            try
            {
                using (var db = new HotelDbContext())
                {
                    var data = QueryReservations(db, searchText);
                    dgvReservations.DataSource = data;
                    SetColumnWidths();

                    lblRecords.Text = data.Count + " reservation" +
                                      (data.Count == 1 ? "" : "s");
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to search reservations.", ex);
            }
        }

        // =========================================================
        // NEW RESERVATION
        // =========================================================
        private void btnNewReservation_Click(object? sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1)
            {
                Warn("Please select a customer.");
                return;
            }

            if (cmbRoom.SelectedIndex == -1)
            {
                Warn("Please select a room.");
                return;
            }

            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            {
                Warn("Check-out date must be after the check-in date.");
                return;
            }

            if (nudGuests.Value < 1)
            {
                Warn("Number of guests must be at least 1.");
                return;
            }

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            int roomId = Convert.ToInt32(cmbRoom.SelectedValue);
            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            try
            {
                using (var db = new HotelDbContext())
                {
                    bool roomReserved = db.Reservations.Any(r =>
                        r.RoomId == roomId &&
                        r.Status != "Cancelled" &&
                        checkIn < r.CheckOutDate &&
                        checkOut > r.CheckInDate);

                    if (roomReserved)
                    {
                        Warn("The selected room is already reserved for the selected dates.");
                        return;
                    }

                    var roomEntity = db.Rooms.FirstOrDefault(r => r.RoomId == roomId);
                    if (roomEntity == null)
                    {
                        Warn("Room not found.");
                        return;
                    }

                    int nights = (checkOut - checkIn).Days;
                    if (nights < 1) nights = 1;

                    decimal total = roomEntity.Price * nights;

                    // Compute tier discount at booking time
                    int completedStays = db.Reservations
                        .Count(r => r.CustomerId == customerId &&
                                    r.Status == "Checked-Out");

                    string tier = TierFor(completedStays);

                    decimal rate = 0m;
                    if (tier != "Bronze")
                    {
                        var discount = db.Discounts
                            .FirstOrDefault(d => d.Tier == tier && d.IsActive);
                        rate = discount?.Rate ?? 0m;
                    }

                    decimal discountAmount = Math.Round(total * rate, 2);
                    decimal finalAmount = total - discountAmount;

                    decimal downPayment = nudDownPayment.Value;

                    // Cap the down payment at the final amount
                    if (downPayment > finalAmount)
                        downPayment = finalAmount;

                    string paymentStatus;
                    if (downPayment <= 0m)
                        paymentStatus = "Unpaid";
                    else if (downPayment < finalAmount)
                        paymentStatus = "Partial";
                    else
                        paymentStatus = "Paid";

                    var reservation = new Reservation
                    {
                        CustomerId = customerId,
                        RoomId = roomId,
                        CheckInDate = checkIn,
                        CheckOutDate = checkOut,
                        NumberOfGuests = Convert.ToInt32(nudGuests.Value),
                        Status = "Pending",
                        SpecialRequests = string.IsNullOrWhiteSpace(txtSpecialRequests.Text)
                                            ? null
                                            : txtSpecialRequests.Text.Trim(),
                        CreatedAt = DateTime.Now,
                        TotalAmount = total,
                        DiscountAmount = discountAmount,
                        FinalAmount = finalAmount,
                        DownPayment = downPayment,
                        PaymentStatus = paymentStatus,
                        PaidAt = downPayment > 0m ? DateTime.Now : (DateTime?)null
                    };

                    db.Reservations.Add(reservation);
                    db.SaveChanges();

                    if (downPayment > 0m)
                    {
                        db.Payments.Add(new Payment
                        {
                            ReservationId = reservation.ReservationId,
                            Amount = downPayment,
                            Method = "Cash",
                            Notes = "Down payment at booking",
                            PaidAt = DateTime.Now,
                            RecordedBy = "frontdesk"
                        });

                        db.SaveChanges();
                    }
                }

                string tierNote = _currentTier != "" && _currentTier != "Bronze"
                    ? " Tier: " + _currentTier + " (" +
                      (_currentDiscountRate * 100m).ToString("0.##") + "% off)."
                    : "";

                MessageBox.Show(
                    "Reservation created successfully." + tierNote,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearReservationFields();

                LoadRooms();
                LoadReservations();
                RecalculateTotals();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to create reservation.", ex);
            }
        }

        // =========================================================
        // UPDATE
        // =========================================================
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null)
            {
                Warn("Please select a reservation first.");
                return;
            }

            MessageBox.Show(
                "Update functionality will be added next.",
                "Update Reservation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // CANCEL RESERVATION
        // =========================================================
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null)
            {
                Warn("Please select a reservation first.");
                return;
            }

            object? idValue =
                dgvReservations.CurrentRow.Cells["ReservationId"].Value;

            if (idValue == null)
            {
                ShowDbError("Unable to identify the selected reservation.", null);
                return;
            }

            int reservationId = Convert.ToInt32(idValue);

            var result = MessageBox.Show(
                "Are you sure you want to cancel this reservation?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var reservation = db.Reservations
                        .FirstOrDefault(r => r.ReservationId == reservationId);

                    if (reservation == null)
                    {
                        ShowDbError("Reservation was not found.", null);
                        return;
                    }

                    reservation.Status = "Cancelled";
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Reservation cancelled successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadReservations();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to cancel reservation.", ex);
            }
        }

        // =========================================================
        // CLEAR FIELDS
        // =========================================================
        private void ClearReservationFields()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            nudGuests.Value = 1;
            nudDownPayment.Value = 0m;

            txtSpecialRequests.Clear();

            RecalculateTotals();
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Missing Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void ShowDbError(string message, Exception? ex)
        {
            string full = ex == null
                ? message
                : message + "\n\n" + ex.Message;

            MessageBox.Show(
                full,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}