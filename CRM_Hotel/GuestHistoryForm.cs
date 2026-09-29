using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class GuestHistoryForm : Form
    {
        private readonly int _customerId;

        public GuestHistoryForm(Customer customer)
        {
            InitializeComponent();

            _customerId = customer.CustomerId;

            lblHeading.Text = customer.FirstName + " " + customer.LastName;
            lblSubheading.Text =
                customer.ContactNumber +
                (string.IsNullOrEmpty(customer.Email) ? "" : "  ·  " + customer.Email);

            btnTabReservations.Click += (s, e) => ShowTab("res");
            btnTabInquiries.Click += (s, e) => ShowTab("inq");
            btnTabFeedback.Click += (s, e) => ShowTab("fb");
            btnClose.Click += (s, e) => Close();

            LoadAll();
            ShowTab("res");
        }

        private void LoadAll()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    // Reservations
                    var reservations =
                        (from r in db.Reservations
                         join room in db.Rooms on r.RoomId equals room.RoomId
                         where r.CustomerId == _customerId
                         orderby r.CheckInDate descending
                         select new
                         {
                             r.ReservationId,
                             Room = room.RoomNumber,
                             r.CheckInDate,
                             r.CheckOutDate,
                             r.NumberOfGuests,
                             r.Status,
                             r.SpecialRequests
                         }).ToList();

                    dgvReservations.DataSource = reservations;

                    // Inquiries
                    var inquiries = db.Inquiries
                        .Where(i => i.CustomerId == _customerId)
                        .OrderByDescending(i => i.CreatedAt)
                        .Select(i => new
                        {
                            i.InquiryId,
                            i.Subject,
                            i.Status,
                            i.Priority,
                            i.Source,
                            i.CreatedAt,
                            i.ResponseMessage
                        })
                        .ToList();

                    dgvInquiries.DataSource = inquiries;

                    // Feedback
                    var feedback = db.Feedbacks
                        .Where(f => f.CustomerId == _customerId)
                        .OrderByDescending(f => f.SubmittedAt)
                        .Select(f => new
                        {
                            f.FeedbackId,
                            f.Rating,
                            f.Comments,
                            f.SubmittedAt
                        })
                        .ToList();

                    dgvFeedback.DataSource = feedback;
                }

                StyleGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load history.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void StyleGrids()
        {
            // Reservations
            if (dgvReservations.Columns.Count > 0)
            {
                dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SetHeader(dgvReservations, "ReservationId", "ID");
                SetHeader(dgvReservations, "Room", "Room");
                SetHeader(dgvReservations, "CheckInDate", "Check In");
                SetHeader(dgvReservations, "CheckOutDate", "Check Out");
                SetHeader(dgvReservations, "NumberOfGuests", "Guests");
                SetHeader(dgvReservations, "Status", "Status");
                SetHeader(dgvReservations, "SpecialRequests", "Requests");
                SetFormat(dgvReservations, "CheckInDate", "MMM dd, yyyy");
                SetFormat(dgvReservations, "CheckOutDate", "MMM dd, yyyy");
            }

            // Inquiries
            if (dgvInquiries.Columns.Count > 0)
            {
                dgvInquiries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SetHeader(dgvInquiries, "InquiryId", "ID");
                SetHeader(dgvInquiries, "Subject", "Subject");
                SetHeader(dgvInquiries, "Status", "Status");
                SetHeader(dgvInquiries, "Priority", "Priority");
                SetHeader(dgvInquiries, "Source", "Source");
                SetHeader(dgvInquiries, "CreatedAt", "Created");
                SetHeader(dgvInquiries, "ResponseMessage", "Response");
                SetFormat(dgvInquiries, "CreatedAt", "MMM dd, yyyy HH:mm");
            }

            // Feedback
            if (dgvFeedback.Columns.Count > 0)
            {
                dgvFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SetHeader(dgvFeedback, "FeedbackId", "ID");
                SetHeader(dgvFeedback, "Rating", "Rating");
                SetHeader(dgvFeedback, "Comments", "Comments");
                SetHeader(dgvFeedback, "SubmittedAt", "Submitted");
                SetFormat(dgvFeedback, "SubmittedAt", "MMM dd, yyyy HH:mm");
            }
        }

        private static void SetHeader(DataGridView grid, string col, string text)
        {
            if (grid.Columns.Contains(col))
                grid.Columns[col].HeaderText = text;
        }

        private static void SetFormat(DataGridView grid, string col, string format)
        {
            if (grid.Columns.Contains(col))
                grid.Columns[col].DefaultCellStyle.Format = format;
        }

        private void ShowTab(string which)
        {
            dgvReservations.Visible = which == "res";
            dgvInquiries.Visible = which == "inq";
            dgvFeedback.Visible = which == "fb";

            HighlightTab(btnTabReservations, which == "res");
            HighlightTab(btnTabInquiries, which == "inq");
            HighlightTab(btnTabFeedback, which == "fb");
        }

        private void HighlightTab(RoundedButton tab, bool active)
        {
            tab.NormalColor = active ? Theme.Primary : Theme.Field;
            tab.HoverColor = active ? Theme.PrimaryHover : Theme.Tint;
            tab.ForeColor = active ? Color.White : Theme.TextDark;
        }
    }
}