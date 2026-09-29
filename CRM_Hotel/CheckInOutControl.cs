using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class CheckInOutControl : UserControl
    {
        private int _currentRoomId = 0;
        private decimal _currentRate = 0m;
        private int _currentNights = 0;
        private decimal _currentSubtotal = 0m;
        private decimal _currentTotal = 0m;

        private bool _suppressRecalc = false;

        public CheckInOutControl()
        {
            InitializeComponent();
            WireEvents();
            LoadRoomTypes();
            LoadActiveCheckOuts();
            Recalculate();
        }

        public void ReloadData()
        {
            LoadRoomTypes();
            LoadActiveCheckOuts();
            Recalculate();
        }

        private void WireEvents()
        {
            cmbRoomType.SelectedIndexChanged += (s, e) => Recalculate();
            dtpCheckIn.ValueChanged += (s, e) => Recalculate();
            dtpCheckOut.ValueChanged += (s, e) => Recalculate();
            nudGuests.ValueChanged += (s, e) => Recalculate();
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckOut.Click += btnCheckOut_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void btnTabCheckIn_Click(object? sender, EventArgs e)
        {
            ShowTab(checkIn: true);
        }

        private void btnTabCheckOuts_Click(object? sender, EventArgs e)
        {
            ShowTab(checkIn: false);
        }

        private void ShowTab(bool checkIn)
        {
            pnlCheckInTab.Visible = checkIn;
            pnlCheckOutTab.Visible = !checkIn;

            if (checkIn)
            {
                btnTabCheckIn.NormalColor = Theme.Primary;
                btnTabCheckIn.HoverColor = Theme.PrimaryHover;
                btnTabCheckOuts.NormalColor = Theme.Field;
                btnTabCheckOuts.HoverColor = Theme.Tint;
            }
            else
            {
                btnTabCheckOuts.NormalColor = Theme.Primary;
                btnTabCheckOuts.HoverColor = Theme.PrimaryHover;
                btnTabCheckIn.NormalColor = Theme.Field;
                btnTabCheckIn.HoverColor = Theme.Tint;
                LoadActiveCheckOuts();
            }
        }

        private void LoadRoomTypes()
        {
            try
            {
                _suppressRecalc = true;

                using (var db = new HotelDbContext())
                {
                    var types = db.Rooms
                        .Where(r => r.Status == "Available")
                        .Select(r => r.RoomType)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();

                    cmbRoomType.DataSource = types;
                    cmbRoomType.SelectedIndex = -1;
                }

                _suppressRecalc = false;
                ClearSummary();
            }
            catch (Exception ex)
            {
                _suppressRecalc = false;
                ShowDbError("Unable to load room types.", ex);
            }
        }

        private void Recalculate()
        {
            if (_suppressRecalc) return;

            try
            {
                _currentRoomId = 0;
                _currentRate = 0m;
                _currentNights = 0;
                _currentSubtotal = 0m;
                _currentTotal = 0m;

                if (cmbRoomType.SelectedItem is not string roomType)
                {
                    ClearSummary();
                    return;
                }

                int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                if (nights <= 0)
                {
                    ClearSummary("Check-out must be after check-in.");
                    return;
                }

                using (var db = new HotelDbContext())
                {
                    var room = db.Rooms
                        .Where(r => r.RoomType == roomType && r.Status == "Available")
                        .OrderBy(r => r.RoomNumber)
                        .FirstOrDefault();

                    if (room == null)
                    {
                        ClearSummary("No available room for this type.");
                        return;
                    }

                    _currentRoomId = room.RoomId;
                    _currentRate = room.Price;
                    _currentNights = nights;
                    _currentSubtotal = _currentRate * _currentNights;
                    _currentTotal = _currentSubtotal;

                    lblSummaryRoomNumber.Text = room.RoomNumber;
                    lblSummaryRoomType.Text = room.RoomType;
                    lblSummaryRate.Text = "₱" + _currentRate.ToString("N2");
                    lblSummaryNights.Text = _currentNights + " night(s)";
                    lblSummarySubtotal.Text = "₱" + _currentSubtotal.ToString("N2");
                    lblSummaryTotal.Text = "₱" + _currentTotal.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to calculate summary.", ex);
            }
        }

        private void ClearSummary(string? message = null)
        {
            lblSummaryRoomNumber.Text = "—";
            lblSummaryRoomType.Text = "—";
            lblSummaryRate.Text = "—";
            lblSummaryNights.Text = "—";
            lblSummarySubtotal.Text = "₱0.00";
            lblSummaryTotal.Text = "₱0.00";

            if (!string.IsNullOrEmpty(message))
                SetStatus(message);
        }

        private void btnCheckIn_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                Warn("First name and last name are required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                Warn("Contact number is required.");
                return;
            }

            if (cmbRoomType.SelectedItem is not string roomType)
            {
                Warn("Please select a room type.");
                return;
            }

            if (nudGuests.Value < 1)
            {
                Warn("Number of guests must be at least 1.");
                return;
            }

            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            {
                Warn("Check-out must be after check-in.");
                return;
            }

            int reservationId = 0;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var room = db.Rooms
                        .Where(r => r.RoomType == roomType && r.Status == "Available")
                        .OrderBy(r => r.RoomNumber)
                        .FirstOrDefault();

                    if (room == null)
                    {
                        Warn("No available room for this type.");
                        return;
                    }

                    string contact = txtContactNumber.Text.Trim();
                    string first = txtFirstName.Text.Trim();
                    string last = txtLastName.Text.Trim();

                    var customer = db.Customers.FirstOrDefault(c =>
                        c.ContactNumber == contact);

                    if (customer == null)
                    {
                        customer = db.Customers.FirstOrDefault(c =>
                            c.FirstName == first && c.LastName == last);
                    }

                    bool newCustomer = false;
                    if (customer == null)
                    {
                        customer = new Customer
                        {
                            FirstName = first,
                            MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text)
                                            ? null
                                            : txtMiddleName.Text.Trim(),
                            LastName = last,
                            ContactNumber = contact,
                            Email = string.IsNullOrWhiteSpace(txtEmail.Text)
                                            ? null
                                            : txtEmail.Text.Trim(),
                            Address = string.IsNullOrWhiteSpace(txtAddress.Text)
                                            ? null
                                            : txtAddress.Text.Trim(),
                            IsArchived = false
                        };

                        db.Customers.Add(customer);
                        db.SaveChanges();
                        newCustomer = true;
                    }

                    int nights = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                    if (nights < 1) nights = 1;

                    decimal subtotal = room.Price * nights;

                    var reservation = new Reservation
                    {
                        CustomerId = customer.CustomerId,
                        RoomId = room.RoomId,
                        CheckInDate = dtpCheckIn.Value.Date,
                        CheckOutDate = dtpCheckOut.Value.Date,
                        NumberOfGuests = Convert.ToInt32(nudGuests.Value),
                        Status = "Checked-In",
                        SpecialRequests = string.IsNullOrWhiteSpace(txtSpecialRequests.Text)
                                            ? null
                                            : txtSpecialRequests.Text.Trim(),
                        CreatedAt = DateTime.Now,
                        ActualCheckInTime = DateTime.Now,
                        TotalAmount = subtotal,
                        FinalAmount = subtotal,
                        DiscountAmount = 0m,
                        DownPayment = 0m,
                        PaymentStatus = "Unpaid",
                        PaidAt = null
                    };

                    db.Reservations.Add(reservation);

                    room.Status = "Occupied";
                    db.SaveChanges();

                    reservationId = reservation.ReservationId;

                    SetStatus(
                        (newCustomer ? "New customer added. " : "") +
                        "Checked in to Room " + room.RoomNumber + ". Total: ₱" +
                        subtotal.ToString("N2"));
                }

                using (var db2 = new HotelDbContext())
                {
                    var saved = db2.Reservations
                        .FirstOrDefault(r => r.ReservationId == reservationId);

                    if (saved != null &&
                        saved.PaymentStatus != "Paid" &&
                        saved.PaymentStatus != "Refunded")
                    {
                        using (var payDlg = new CollectPaymentForm(saved))
                        {
                            payDlg.ShowDialog(this);
                        }
                    }
                }

                ClearCheckInForm();
                LoadRoomTypes();
                LoadActiveCheckOuts();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to check in.", ex);
            }
        }

        private void ClearCheckInForm()
        {
            _suppressRecalc = true;

            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtSpecialRequests.Clear();

            cmbRoomType.SelectedIndex = -1;
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);
            nudGuests.Value = 1;

            _suppressRecalc = false;

            ClearSummary();
        }

        private void LoadActiveCheckOuts()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var rows =
                        (from r in db.Reservations
                         join c in db.Customers on r.CustomerId equals c.CustomerId
                         join room in db.Rooms on r.RoomId equals room.RoomId
                         where r.Status == "Checked-In"
                         orderby r.CheckOutDate
                         select new CheckOutRow
                         {
                             ReservationId = r.ReservationId,
                             Customer = c.FirstName + " " + c.LastName,
                             Contact = c.ContactNumber,
                             Room = room.RoomNumber,
                             CheckInDate = r.CheckInDate,
                             CheckOutDate = r.CheckOutDate,
                             Guests = r.NumberOfGuests,
                             TotalAmount = r.FinalAmount,
                             PaymentStatus = r.PaymentStatus
                         }).ToList();

                    dgvActiveCheckOuts.DataSource = rows;
                    ConfigureCheckOutColumns();
                    lblCheckOutStatus.Text = rows.Count + " guest(s) currently checked in.";
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load active check-outs.", ex);
            }
        }

        private void ConfigureCheckOutColumns()
        {
            if (dgvActiveCheckOuts.Columns.Count == 0) return;

            dgvActiveCheckOuts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader(dgvActiveCheckOuts, "ReservationId", "ID");
            SetHeader(dgvActiveCheckOuts, "Customer", "Customer");
            SetHeader(dgvActiveCheckOuts, "Contact", "Contact");
            SetHeader(dgvActiveCheckOuts, "Room", "Room");
            SetHeader(dgvActiveCheckOuts, "CheckInDate", "Check In");
            SetHeader(dgvActiveCheckOuts, "CheckOutDate", "Check Out");
            SetHeader(dgvActiveCheckOuts, "Guests", "Guests");
            SetHeader(dgvActiveCheckOuts, "TotalAmount", "Total");
            SetHeader(dgvActiveCheckOuts, "PaymentStatus", "Payment");

            SetWeight(dgvActiveCheckOuts, "ReservationId", 40);
            SetWeight(dgvActiveCheckOuts, "Customer", 140);
            SetWeight(dgvActiveCheckOuts, "Contact", 110);
            SetWeight(dgvActiveCheckOuts, "Room", 60);
            SetWeight(dgvActiveCheckOuts, "CheckInDate", 80);
            SetWeight(dgvActiveCheckOuts, "CheckOutDate", 80);
            SetWeight(dgvActiveCheckOuts, "Guests", 55);
            SetWeight(dgvActiveCheckOuts, "TotalAmount", 75);
            SetWeight(dgvActiveCheckOuts, "PaymentStatus", 80);

            if (dgvActiveCheckOuts.Columns.Contains("TotalAmount"))
                dgvActiveCheckOuts.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
        }

        private void btnCheckOut_Click(object? sender, EventArgs e)
        {
            if (dgvActiveCheckOuts.CurrentRow == null)
            {
                Warn("Please select a guest to check out.");
                return;
            }

            var cell = dgvActiveCheckOuts.CurrentRow.Cells["ReservationId"].Value;
            if (cell == null)
            {
                Warn("Unable to identify the selected reservation.");
                return;
            }

            int reservationId = Convert.ToInt32(cell);

            try
            {
                using (var db = new HotelDbContext())
                {
                    var reservation = db.Reservations
                        .FirstOrDefault(r => r.ReservationId == reservationId);

                    if (reservation == null)
                    {
                        Warn("Reservation not found.");
                        return;
                    }

                    if (reservation.PaymentStatus != "Paid" &&
                        reservation.PaymentStatus != "Refunded")
                    {
                        using (var payDlg = new CollectPaymentForm(reservation))
                        {
                            payDlg.ShowDialog(this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to process payment.", ex);
                return;
            }

            var confirm = MessageBox.Show(
                "Check out this guest?",
                "Confirm Check Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var reservation = db.Reservations
                        .FirstOrDefault(r => r.ReservationId == reservationId);

                    if (reservation == null)
                    {
                        Warn("Reservation not found.");
                        return;
                    }

                    if (reservation.Status != "Checked-In")
                    {
                        Warn("Only checked-in reservations can be checked out.");
                        return;
                    }

                    var room = db.Rooms
                        .FirstOrDefault(r => r.RoomId == reservation.RoomId);

                    reservation.Status = "Checked-Out";
                    reservation.ActualCheckOutTime = DateTime.Now;

                    if (room != null &&
                        !string.Equals(room.Status, "Maintenance",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        room.Status = "Available";
                    }

                    db.SaveChanges();
                }

                LoadActiveCheckOuts();
                LoadRoomTypes();
                SetStatus("Checked out successfully.");
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to check out.", ex);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadRoomTypes();
            LoadActiveCheckOuts();
            Recalculate();
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private static void SetHeader(DataGridView grid, string column, string text)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].HeaderText = text;
        }

        private static void SetWeight(DataGridView grid, string column, float weight)
        {
            if (grid.Columns.Contains(column))
                grid.Columns[column].FillWeight = weight;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Check In / Out",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void ShowDbError(string message, Exception ex)
        {
            MessageBox.Show(
                message + "\n\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private class CheckOutRow
        {
            public int ReservationId { get; set; }
            public string Customer { get; set; } = "";
            public string Contact { get; set; } = "";
            public string Room { get; set; } = "";
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public int Guests { get; set; }
            public decimal TotalAmount { get; set; }
            public string PaymentStatus { get; set; } = "";
        }
    }
}