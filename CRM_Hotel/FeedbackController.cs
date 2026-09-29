using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class FeedbackControl : UserControl
    {
        private int _selectedRating = 0;

        public FeedbackControl()
        {
            InitializeComponent();
            WireEvents();
            LoadCustomers();
            LoadFeedback();
            UpdateStarDisplay();
        }

        public void ReloadData()
        {
            LoadCustomers();
            LoadFeedback();
        }

        private void WireEvents()
        {
            star1.Click += (s, e) => SetRating(1);
            star2.Click += (s, e) => SetRating(2);
            star3.Click += (s, e) => SetRating(3);
            star4.Click += (s, e) => SetRating(4);
            star5.Click += (s, e) => SetRating(5);

            btnSubmit.Click += btnSubmit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        // =========================================================
        // RATING STARS
        // =========================================================
        private void SetRating(int value)
        {
            _selectedRating = value;
            UpdateStarDisplay();
        }

        private void UpdateStarDisplay()
        {
            Label[] stars = { star1, star2, star3, star4, star5 };

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Text = (i < _selectedRating) ? "★" : "☆";
                stars[i].ForeColor = (i < _selectedRating)
                    ? Theme.Accent
                    : System.Drawing.Color.Gray;
            }
        }

        // =========================================================
        // CUSTOMER DROPDOWN
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
                        .Select(c => new CustomerItem
                        {
                            CustomerId = c.CustomerId,
                            Display =
                                c.FirstName + " " +
                                (c.MiddleName == null ? "" : c.MiddleName + " ") +
                                c.LastName
                        })
                        .ToList();

                    // Prepend Anonymous option
                    customers.Insert(0, new CustomerItem
                    {
                        CustomerId = -1,
                        Display = "— Anonymous —"
                    });

                    cmbCustomer.DataSource = customers;
                    cmbCustomer.DisplayMember = "Display";
                    cmbCustomer.ValueMember = "CustomerId";
                    cmbCustomer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load customers.", ex);
            }
        }

        // =========================================================
        // SUBMIT
        // =========================================================
        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (_selectedRating < 1 || _selectedRating > 5)
            {
                Warn("Please select a rating (1 to 5 stars).");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComments.Text))
            {
                Warn("Please enter your comments.");
                return;
            }

            try
            {
                int? customerId = null;

                if (cmbCustomer.SelectedItem is CustomerItem item &&
                    item.CustomerId > 0)
                {
                    customerId = item.CustomerId;
                }

                using (var db = new HotelDbContext())
                {
                    var feedback = new Feedback
                    {
                        CustomerId = customerId,
                        Rating = _selectedRating,
                        Comments = txtComments.Text.Trim(),
                        SubmittedAt = DateTime.Now
                    };

                    db.Feedbacks.Add(feedback);
                    db.SaveChanges();
                }

                SetStatus("Feedback submitted. Thank you!");

                // Reset form
                _selectedRating = 0;
                UpdateStarDisplay();
                txtComments.Clear();
                cmbCustomer.SelectedIndex = 0;

                LoadFeedback();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to submit feedback.", ex);
            }
        }

        // =========================================================
        // LOAD FEEDBACK
        // =========================================================
        private void LoadFeedback()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var rows =
                        (from f in db.Feedbacks
                         join c in db.Customers on f.CustomerId equals c.CustomerId into gj
                         from c in gj.DefaultIfEmpty()
                         orderby f.SubmittedAt descending
                         select new FeedbackRow
                         {
                             FeedbackId = f.FeedbackId,
                             Customer = c == null
                                 ? "Anonymous"
                                 : (c.FirstName + " " + c.LastName),
                             RatingValue = f.Rating,
                             Rating = StarsFor(f.Rating),
                             Comments = f.Comments,
                             SubmittedAt = f.SubmittedAt
                         }).ToList();

                    dgvFeedback.DataSource = rows;
                    ConfigureGrid();
                    lblFeedbackCount.Text = rows.Count + " record(s)";
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load feedback.", ex);
            }
        }

        private static string StarsFor(int rating)
        {
            rating = Math.Max(0, Math.Min(5, rating));
            return new string('★', rating) + new string('☆', 5 - rating);
        }

        private void ConfigureGrid()
        {
            if (dgvFeedback.Columns.Count == 0) return;

            dgvFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader("FeedbackId", "ID");
            SetHeader("Customer", "Customer");
            SetHeader("Rating", "Rating");
            SetHeader("Comments", "Comments");
            SetHeader("SubmittedAt", "Submitted");

            SetWeight("FeedbackId", 40);
            SetWeight("Customer", 140);
            SetWeight("Rating", 110);
            SetWeight("Comments", 350);
            SetWeight("SubmittedAt", 120);

            if (dgvFeedback.Columns.Contains("SubmittedAt"))
                dgvFeedback.Columns["SubmittedAt"].DefaultCellStyle.Format = "MMM dd, yyyy HH:mm";

            if (dgvFeedback.Columns.Contains("Rating"))
                dgvFeedback.Columns["Rating"].DefaultCellStyle.ForeColor = Theme.Accent;

            // Hide the raw numeric rating column, if you want to keep the grid clean
            if (dgvFeedback.Columns.Contains("RatingValue"))
                dgvFeedback.Columns["RatingValue"].Visible = false;
        }

        private void SetHeader(string column, string text)
        {
            if (dgvFeedback.Columns.Contains(column))
                dgvFeedback.Columns[column].HeaderText = text;
        }

        private void SetWeight(string column, float weight)
        {
            if (dgvFeedback.Columns.Contains(column))
                dgvFeedback.Columns[column].FillWeight = weight;
        }

        // =========================================================
        // DELETE
        // =========================================================
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvFeedback.CurrentRow == null)
            {
                Warn("Please select a feedback record first.");
                return;
            }

            var cell = dgvFeedback.CurrentRow.Cells["FeedbackId"].Value;
            if (cell == null)
            {
                Warn("Unable to identify the selected record.");
                return;
            }

            int feedbackId = Convert.ToInt32(cell);

            var confirm = MessageBox.Show(
                "Delete this feedback record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var feedback = db.Feedbacks
                        .FirstOrDefault(f => f.FeedbackId == feedbackId);

                    if (feedback == null)
                    {
                        Warn("Record not found.");
                        return;
                    }

                    db.Feedbacks.Remove(feedback);
                    db.SaveChanges();
                }

                SetStatus("Feedback deleted.");
                LoadFeedback();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to delete feedback.", ex);
            }
        }

        // =========================================================
        // REFRESH
        // =========================================================
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadFeedback();
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "Feedback",
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

        // =========================================================
        // ROW DTOs
        // =========================================================
        private class CustomerItem
        {
            public int CustomerId { get; set; }
            public string Display { get; set; } = "";
        }

        private class FeedbackRow
        {
            public int FeedbackId { get; set; }
            public string Customer { get; set; } = "";
            public string Rating { get; set; } = "";
            public int RatingValue { get; set; }
            public string Comments { get; set; } = "";
            public DateTime SubmittedAt { get; set; }
        }
    }
}