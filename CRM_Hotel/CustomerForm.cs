using CRM.domain;
using CRM.infrastructure;
using System;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show(
                    "Please fill in the required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (HotelDbContext db = new HotelDbContext())
                {
                    Customer customer = new Customer
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        MiddleName = string.IsNullOrWhiteSpace(txtMiddleName.Text)
                            ? null
                            : txtMiddleName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        ContactNumber = txtContactNumber.Text.Trim(),
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
                }

                MessageBox.Show(
                    "Customer registered successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to register customer.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}