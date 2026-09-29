using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ReservationDetailForm : Form
    {
        public ReservationDetailForm(Reservation reservation)
        {
            InitializeComponent();

            btnClose.Click += (s, e) => Close();

            LoadDetail(reservation);
        }

        private void LoadDetail(Reservation reservation)
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var customer = db.Customers
                        .FirstOrDefault(c => c.CustomerId == reservation.CustomerId);

                    var room = db.Rooms
                        .FirstOrDefault(r => r.RoomId == reservation.RoomId);

                    // Header
                    lblTitle.Text = "Reservation #" + reservation.ReservationId;
                    lblSubtitle.Text =
                        "Created " + reservation.CreatedAt.ToString("MMM dd, yyyy HH:mm");

                    // Status pill
                    lblStatusPill.Text = reservation.Status.ToUpperInvariant();
                    lblStatusPill.BackColor = StatusColor(reservation.Status);

                    // Guest
                    lblGuestValue.Text = customer == null
                        ? "(unknown)"
                        : customer.FirstName + " " +
                          (customer.MiddleName == null ? "" : customer.MiddleName + " ") +
                          customer.LastName;

                    lblContactValue.Text = customer?.ContactNumber ?? "—";
                    lblEmailValue.Text = string.IsNullOrWhiteSpace(customer?.Email)
                        ? "—"
                        : customer!.Email!;

                    // Stay
                    lblRoomValue.Text = room == null
                        ? "—"
                        : room.RoomNumber + " · " + room.RoomType;

                    lblCheckInValue.Text = reservation.CheckInDate.ToString("MMM dd, yyyy");
                    lblCheckOutValue.Text = reservation.CheckOutDate.ToString("MMM dd, yyyy");

                    int nights = (reservation.CheckOutDate.Date -
                                  reservation.CheckInDate.Date).Days;
                    if (nights < 1) nights = 1;
                    lblNightsValue.Text = nights + " night" + (nights == 1 ? "" : "s");

                    lblGuestsValue.Text = reservation.NumberOfGuests.ToString();

                    // Billing
                    lblTotalValue.Text = "₱" + reservation.TotalAmount.ToString("N2");

                    if (reservation.DiscountAmount > 0m)
                    {
                        decimal pct = reservation.TotalAmount > 0
                            ? (reservation.DiscountAmount / reservation.TotalAmount) * 100m
                            : 0m;

                        lblDiscountValue.Text =
                            "− ₱" + reservation.DiscountAmount.ToString("N2") +
                            "  (" + pct.ToString("0.##") + "%)";
                        lblDiscountValue.ForeColor = Theme.Accent;
                    }
                    else
                    {
                        lblDiscountValue.Text = "—";
                        lblDiscountValue.ForeColor = Color.Gray;
                    }

                    lblFinalValue.Text = "₱" + reservation.FinalAmount.ToString("N2");

                    lblDownValue.Text = "₱" + reservation.DownPayment.ToString("N2");

                    lblPaymentValue.Text = reservation.PaymentStatus;
                    lblPaymentValue.ForeColor = PaymentColor(reservation.PaymentStatus);

                    // Requests
                    lblRequestsValue.Text = string.IsNullOrWhiteSpace(reservation.SpecialRequests)
                        ? "(none)"
                        : reservation.SpecialRequests;

                    // Created
                    lblCreatedValue.Text = reservation.CreatedAt.ToString("MMM dd, yyyy HH:mm");

                    // If checked in or out, append the actual timestamps to the pill's tooltip
                    string tip = "";
                    if (reservation.ActualCheckInTime.HasValue)
                        tip += "Checked in: " +
                            reservation.ActualCheckInTime.Value.ToString("MMM dd, yyyy HH:mm") + "\n";
                    if (reservation.ActualCheckOutTime.HasValue)
                        tip += "Checked out: " +
                            reservation.ActualCheckOutTime.Value.ToString("MMM dd, yyyy HH:mm");

                    if (!string.IsNullOrEmpty(tip))
                    {
                        var tt = new ToolTip();
                        tt.SetToolTip(lblStatusPill, tip.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load reservation details.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Pending": return Color.SteelBlue;
                case "Confirmed": return Color.SeaGreen;
                case "Checked-In": return Color.DarkOrange;
                case "Checked-Out": return Color.Gray;
                case "Cancelled": return Color.IndianRed;
                default: return Color.SteelBlue;
            }
        }

        private static Color PaymentColor(string status)
        {
            switch (status)
            {
                case "Paid": return Color.SeaGreen;
                case "Partial": return Color.DarkOrange;
                case "Unpaid": return Color.IndianRed;
                case "Refunded": return Color.Gray;
                default: return Color.Gray;
            }
        }
    }
}