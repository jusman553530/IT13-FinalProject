using CRM.domain;
using CRM.infrastructure;
using System;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show(
                    "Please enter a room number.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtRoomNumber.Focus();
                return;
            }

            if (cmbRoomType.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a room type.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbRoomType.Focus();
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a room status.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show(
                    "Please enter a valid room price.",
                    "Invalid Price",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrice.Focus();
                return;
            }

            if (price < 0)
            {
                MessageBox.Show(
                    "Room price cannot be negative.",
                    "Invalid Price",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrice.Focus();
                return;
            }

            try
            {
                using (HotelDbContext db = new HotelDbContext())
                {
                    Room room = new Room
                    {
                        RoomNumber = txtRoomNumber.Text.Trim(),
                        RoomType = cmbRoomType.Text,
                        Status = cmbStatus.Text,
                        Price = price
                    };

                    db.Rooms.Add(room);
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Room added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to add room.\n\n" + ex.Message,
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