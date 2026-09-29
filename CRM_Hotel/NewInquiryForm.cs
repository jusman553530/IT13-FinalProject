using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class NewInquiryForm : Form
    {
        private const int WalkInCustomerId = -1;

        public NewInquiryForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadCombos();
            WireEvents();
        }

        private void LoadCustomers()
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
                        Display = c.FirstName + " " +
                                  (c.MiddleName == null ? "" : c.MiddleName + " ") +
                                  c.LastName +
                                  " — " + c.ContactNumber
                    })
                    .ToList();

                customers.Insert(0, new
                {
                    CustomerId = WalkInCustomerId,
                    Display = "— Not in system / Walk-in —"
                });

                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Display";
                cmbCustomer.ValueMember = "CustomerId";
                cmbCustomer.SelectedIndex = 0;
            }
        }

        private void LoadCombos()
        {
            cmbSource.Items.Clear();
            cmbSource.Items.AddRange(new object[]
            {
                "Walk-In", "Phone", "Email", "Referral", "Other"
            });
            cmbSource.SelectedIndex = 0;

            cmbPriority.Items.Clear();
            cmbPriority.Items.AddRange(new object[]
            {
                "Low", "Normal", "High"
            });
            cmbPriority.SelectedIndex = 1;
        }

        private void WireEvents()
        {
            cmbCustomer.SelectedIndexChanged += (s, e) => UpdateWalkInFields();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            UpdateWalkInFields();
        }

        private void UpdateWalkInFields()
        {
            bool isWalkIn = cmbCustomer.SelectedValue is int id && id == WalkInCustomerId;

            lblGuestName.Visible = isWalkIn;
            txtGuestName.Visible = isWalkIn;
            lblGuestContact.Visible = isWalkIn;
            txtGuestContact.Visible = isWalkIn;

            if (!isWalkIn)
            {
                txtGuestName.Clear();
                txtGuestContact.Clear();
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                Warn("Please enter a subject."); return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                Warn("Please enter the message."); return;
            }

            bool isWalkIn = cmbCustomer.SelectedValue is int id && id == WalkInCustomerId;

            if (isWalkIn && string.IsNullOrWhiteSpace(txtGuestName.Text))
            {
                Warn("Please enter the guest's name."); return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    int? customerId = null;
                    string? guestName = null;
                    string? guestContact = null;

                    if (isWalkIn)
                    {
                        guestName = txtGuestName.Text.Trim();
                        guestContact = string.IsNullOrWhiteSpace(txtGuestContact.Text)
                            ? null
                            : txtGuestContact.Text.Trim();
                    }
                    else
                    {
                        customerId = (int)cmbCustomer.SelectedValue!;

                        var cust = db.Customers
                            .FirstOrDefault(c => c.CustomerId == customerId.Value);

                        if (cust != null)
                        {
                            guestName = cust.FirstName + " " + cust.LastName;
                            guestContact = cust.ContactNumber;
                        }
                    }

                    var inquiry = new Inquiry
                    {
                        CustomerId = customerId,
                        GuestName = guestName,
                        GuestContact = guestContact,
                        Subject = txtSubject.Text.Trim(),
                        Message = txtMessage.Text.Trim(),
                        Status = "New",
                        Priority = cmbPriority.SelectedItem?.ToString() ?? "Normal",
                        Source = cmbSource.SelectedItem?.ToString() ?? "Walk-In",
                        CreatedAt = DateTime.Now,
                        CreatedBy = "frontdesk"
                    };

                    db.Inquiries.Add(inquiry);
                    db.SaveChanges();
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to log the inquiry.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void Warn(string message)
        {
            MessageBox.Show(
                message,
                "New Inquiry",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}