using CRM.domain;
using CRM.infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class CollectPaymentForm : Form
    {
        private readonly Reservation _reservation;

        public CollectPaymentForm(Reservation reservation)
        {
            InitializeComponent();

            _reservation = reservation;

            cmbMethod.Items.Clear();
            cmbMethod.Items.AddRange(new object[]
            {
                "Cash", "Card", "GCash", "Bank", "Other"
            });
            cmbMethod.SelectedIndex = 0;

            RefreshSummary();

            txtAmount.TextChanged += (s, e) => RefreshSummary();

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            // Prefill with the remaining balance
            decimal remaining = BalanceRemaining();
            if (remaining > 0)
                txtAmount.Text = remaining.ToString("0.00");
        }

        private decimal BalanceRemaining()
        {
            decimal alreadyPaid = _reservation.DownPayment + AlreadyPaidSum();
            decimal remaining = _reservation.TotalAmount - alreadyPaid;
            return remaining < 0 ? 0 : remaining;
        }

        private decimal AlreadyPaidSum()
        {
            // Sum extra payments logged in the Payments table for this reservation
            using (var db = new HotelDbContext())
            {
                var list = db.Payments
                    .Where(p => p.ReservationId == _reservation.ReservationId)
                    .ToList();

                decimal total = 0m;
                foreach (var p in list) total += p.Amount;
                return total;
            }
        }

        private void RefreshSummary()
        {
            decimal total = _reservation.TotalAmount;
            decimal paid = _reservation.DownPayment + AlreadyPaidSum();

            decimal typed = 0m;
            decimal.TryParse(txtAmount.Text, out typed);

            decimal newPaid = paid + typed;
            decimal remaining = total - newPaid;

            lblSummary.Text =
                "Total: ₱" + total.ToString("N2") +
                "   ·   Paid so far: ₱" + paid.ToString("N2") +
                "   ·   Remaining: ₱" +
                (remaining < 0 ? 0m : remaining).ToString("N2");
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                lblStatus.Text = "Please enter a valid amount greater than zero.";
                return;
            }

            string method = cmbMethod.SelectedItem?.ToString() ?? "Cash";
            string notes = txtNotes.Text.Trim();

            try
            {
                using (var db = new HotelDbContext())
                {
                    var reservation = db.Reservations
                        .FirstOrDefault(r => r.ReservationId == _reservation.ReservationId);

                    if (reservation == null)
                    {
                        lblStatus.Text = "Reservation not found.";
                        return;
                    }

                    // 1. Log the payment
                    var payment = new Payment
                    {
                        ReservationId = reservation.ReservationId,
                        Amount = amount,
                        Method = method,
                        Notes = string.IsNullOrWhiteSpace(notes) ? null : notes,
                        PaidAt = DateTime.Now,
                        RecordedBy = CurrentUser.Username
                    };

                    db.Payments.Add(payment);

                    // 2. Recompute payment status
                    var payments = db.Payments
                        .Where(p => p.ReservationId == reservation.ReservationId)
                        .ToList();

                    decimal extraPaid = 0m;
                    foreach (var p in payments) extraPaid += p.Amount;

                    decimal totalPaid = reservation.DownPayment + extraPaid + amount;
                    // Note: the just-added `payment` isn't in `payments` yet,
                    // so we add its amount separately above.

                    if (totalPaid <= 0m)
                    {
                        reservation.PaymentStatus = "Unpaid";
                    }
                    else if (totalPaid < reservation.TotalAmount)
                    {
                        reservation.PaymentStatus = "Partial";
                    }
                    else
                    {
                        reservation.PaymentStatus = "Paid";
                    }

                    if (reservation.PaidAt == null)
                        reservation.PaidAt = DateTime.Now;

                    db.SaveChanges();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unable to record payment. " + ex.Message;
            }
        }
    }
}