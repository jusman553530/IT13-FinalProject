using CRM.domain;
using CRM.infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class RoomEditForm : Form
    {
        private readonly Room? _existing;

        public RoomEditForm()
        {
            InitializeComponent();
            LoadRoomTypes();
            WireEvents();
            lblHeading.Text = "Add Room";
        }

        public RoomEditForm(Room existing)
        {
            InitializeComponent();
            _existing = existing;
            LoadRoomTypes();
            WireEvents();

            lblHeading.Text = "Edit Room";
            txtNumber.Text = existing.RoomNumber;

            // Select the current type
            if (cmbType.Items.Contains(existing.RoomType))
                cmbType.SelectedItem = existing.RoomType;
            else
                cmbType.SelectedIndex = 0;

            // Select the current status
            if (cmbStatus.Items.Contains(existing.Status))
                cmbStatus.SelectedItem = existing.Status;
            else
                cmbStatus.SelectedIndex = 0;

            txtPrice.Text = existing.Price.ToString("0.00");
        }

        private void WireEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        private void LoadRoomTypes()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new object[]
            {
                "Standard", "Deluxe", "Suite", "Presidential"
            });
            cmbType.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[]
            {
                "Available", "Occupied", "Maintenance"
            });
            cmbStatus.SelectedIndex = 0;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            lblStatusMsg.Text = "";

            string number = txtNumber.Text.Trim();
            string type = cmbType.SelectedItem?.ToString() ?? "";
            string status = cmbStatus.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(number))
            {
                lblStatusMsg.Text = "Room number is required.";
                return;
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                lblStatusMsg.Text = "Room type is required.";
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                lblStatusMsg.Text = "Please enter a valid price greater than zero.";
                return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    if (_existing == null)
                    {
                        // Add: check room number isn't taken
                        bool taken = db.Rooms.Any(r => r.RoomNumber == number);
                        if (taken)
                        {
                            lblStatusMsg.Text = "A room with that number already exists.";
                            return;
                        }

                        var room = new Room
                        {
                            RoomNumber = number,
                            RoomType = type,
                            Status = status,
                            Price = price
                        };

                        db.Rooms.Add(room);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Edit
                        var tracked = db.Rooms.FirstOrDefault(r => r.RoomId == _existing.RoomId);
                        if (tracked == null)
                        {
                            lblStatusMsg.Text = "Room not found.";
                            return;
                        }

                        bool taken = db.Rooms.Any(r =>
                            r.RoomNumber == number &&
                            r.RoomId != tracked.RoomId);

                        if (taken)
                        {
                            lblStatusMsg.Text = "Another room already uses that number.";
                            return;
                        }

                        tracked.RoomNumber = number;
                        tracked.RoomType = type;
                        tracked.Status = status;
                        tracked.Price = price;

                        db.SaveChanges();
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "Unable to save. " + ex.Message;
            }
        }
    }
}