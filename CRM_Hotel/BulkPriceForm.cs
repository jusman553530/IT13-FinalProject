using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class BulkPriceForm : Form
    {
        public BulkPriceForm()
        {
            InitializeComponent();
            LoadRoomTypes();
            WireEvents();
        }

        private void WireEvents()
        {
            btnApply.Click += BtnApply_Click;
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            cmbType.SelectedIndexChanged += (s, e) => UpdateAffectedLabel();
        }

        private void LoadRoomTypes()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var types = db.Rooms
                        .Select(r => r.RoomType)
                        .Distinct()
                        .OrderBy(t => t)
                        .ToList();

                    cmbType.DataSource = types;
                    cmbType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "Unable to load room types. " + ex.Message;
            }
        }

        private void UpdateAffectedLabel()
        {
            if (cmbType.SelectedItem is not string roomType)
            {
                lblAffected.Text = "—";
                return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    int count = db.Rooms.Count(r => r.RoomType == roomType);
                    lblAffected.Text = count + " room(s) will be updated.";
                }
            }
            catch
            {
                lblAffected.Text = "—";
            }
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            lblStatusMsg.Text = "";

            if (cmbType.SelectedItem is not string roomType)
            {
                lblStatusMsg.Text = "Please select a room type.";
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal newPrice) || newPrice <= 0)
            {
                lblStatusMsg.Text = "Please enter a valid price greater than zero.";
                return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    var rooms = db.Rooms.Where(r => r.RoomType == roomType).ToList();

                    if (rooms.Count == 0)
                    {
                        lblStatusMsg.Text = "No rooms of this type exist.";
                        return;
                    }

                    foreach (var room in rooms)
                    {
                        room.Price = newPrice;
                    }

                    db.SaveChanges();

                    MessageBox.Show(
                        "Updated " + rooms.Count + " room(s) to ₱" +
                        newPrice.ToString("N2") + ".",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "Unable to update prices. " + ex.Message;
            }
        }
    }
}