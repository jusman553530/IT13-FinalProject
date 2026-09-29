using CRM.domain;
using CRM.infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class GuestEditForm : Form
    {
        private readonly Customer? _existing;

        public GuestEditForm(Customer? existing = null)
        {
            InitializeComponent();

            _existing = existing;

            if (_existing == null)
            {
                lblHeading.Text = "Add Guest";
            }
            else
            {
                lblHeading.Text = "Edit Guest";
                txtFirst.Text = _existing.FirstName;
                txtMiddle.Text = _existing.MiddleName ?? "";
                txtLast.Text = _existing.LastName;
                txtContact.Text = _existing.ContactNumber;
                txtEmail.Text = _existing.Email ?? "";
                txtAddress.Text = _existing.Address ?? "";
            }

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = "";

            string first = txtFirst.Text.Trim();
            string middle = txtMiddle.Text.Trim();
            string last = txtLast.Text.Trim();
            string contact = txtContact.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(first))
            {
                lblStatus.Text = "First name is required."; return;
            }

            if (string.IsNullOrWhiteSpace(last))
            {
                lblStatus.Text = "Last name is required."; return;
            }

            if (string.IsNullOrWhiteSpace(contact))
            {
                lblStatus.Text = "Contact number is required."; return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    if (_existing == null)
                    {
                        // Add
                        bool duplicate = db.Customers.Any(c =>
                            c.ContactNumber == contact);

                        if (duplicate)
                        {
                            lblStatus.Text = "A customer with that contact number already exists.";
                            return;
                        }

                        var customer = new Customer
                        {
                            FirstName = first,
                            MiddleName = string.IsNullOrWhiteSpace(middle) ? null : middle,
                            LastName = last,
                            ContactNumber = contact,
                            Email = string.IsNullOrWhiteSpace(email) ? null : email,
                            Address = string.IsNullOrWhiteSpace(address) ? null : address,
                            IsArchived = false
                        };

                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Edit
                        var customer = db.Customers
                            .FirstOrDefault(c => c.CustomerId == _existing.CustomerId);

                        if (customer == null)
                        {
                            lblStatus.Text = "Customer not found."; return;
                        }

                        // Allow same contact only if it's this customer
                        bool taken = db.Customers.Any(c =>
                            c.ContactNumber == contact &&
                            c.CustomerId != customer.CustomerId);

                        if (taken)
                        {
                            lblStatus.Text = "Another customer already uses that contact number.";
                            return;
                        }

                        customer.FirstName = first;
                        customer.MiddleName = string.IsNullOrWhiteSpace(middle) ? null : middle;
                        customer.LastName = last;
                        customer.ContactNumber = contact;
                        customer.Email = string.IsNullOrWhiteSpace(email) ? null : email;
                        customer.Address = string.IsNullOrWhiteSpace(address) ? null : address;

                        db.SaveChanges();
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Unable to save. " + ex.Message;
            }
        }
    }
}