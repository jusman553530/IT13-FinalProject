using CRM.domain;
using CRM.infrastructure;
using CRM.winforms;
using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM_Hotel
{
    public partial class Form1 : Form
    {
        private RoomManagementControl? roomManagementControl;
        private ReservationManagementControl? reservationManagementControl;
        private CheckInOutControl? checkInOutControl;
        private FeedbackControl? feedbackControl;
        private InquiryControl? inquiryControl;

        public Form1()
        {
            InitializeComponent();

            // Show who's logged in
            this.Text = "Hotel CRM — " + CurrentUser.FullName +
                        " (" + CurrentUser.Role + ")";

            ApplyRoleVisibility();

            ConfigureTheme();

            LoadCustomers();
            ShowCustomers();
        }

        // =========================================================
        // ROLE-BASED SIDEBAR VISIBILITY
        // (Add rules here as you build admin pages)
        // =========================================================
        private void ApplyRoleVisibility()
        {
            // Everyone logged in can see the staff pages.
            btnCustomers.Visible = true;
            btnReservations.Visible = true;
            btnRooms.Visible = true;
            btnCheckInOut.Visible = true;
            btnFeedback.Visible = true;
            btnInquiries.Visible = true;

            // Example rules to enable later:
            //
            // if (!CurrentUser.IsAdmin)
            // {
            //     btnManageUsers.Visible = false;
            // }
        }

        private void ConfigureTheme()
        {
            BackColor = Theme.Background;

            pnlSidebar.BackColor = Theme.Sidebar;
            pnlHeader.BackColor = Theme.Primary;

            lblTitle.ForeColor = Color.White;
            lblSubtitle.ForeColor = Theme.Tint;

            pnlContent.BackColor = Theme.Background;

            pnlSearch.BackColor = Theme.Field;
            pnlSearch.BorderColor = Theme.Border;
            pnlSearch.BorderThickness = 1;
            pnlSearch.CornerRadius = 12;

            txtSearch.BackColor = Theme.Field;
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.BorderStyle = BorderStyle.None;

            lblSearch.ForeColor = Theme.TextDark;
            lblRecords.ForeColor = Theme.TextDark;

            btnRegister.NormalColor = Theme.Primary;
            btnRegister.HoverColor = Theme.PrimaryHover;
            btnRegister.CornerRadius = 10;

            btnUpdate.NormalColor = Theme.Accent;
            btnUpdate.HoverColor = Theme.PrimaryHover;
            btnUpdate.CornerRadius = 10;

            btnArchive.NormalColor = Theme.Danger;
            btnArchive.HoverColor = Color.FromArgb(160, 40, 40);
            btnArchive.CornerRadius = 10;

            pnlTable.BackColor = Theme.Card;
            pnlTable.BorderColor = Theme.Border;
            pnlTable.BorderThickness = 1;
            pnlTable.CornerRadius = 14;

            dgvCustomers.BackgroundColor = Theme.Card;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.GridColor = Theme.Border;
            dgvCustomers.EnableHeadersVisualStyles = false;

            dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = Theme.Primary;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.Primary;
            dgvCustomers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvCustomers.DefaultCellStyle.BackColor = Theme.Card;
            dgvCustomers.DefaultCellStyle.ForeColor = Theme.TextDark;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Theme.Tint;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Theme.Primary;
            dgvCustomers.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvCustomers.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            dgvCustomers.ColumnHeadersHeight = 44;
            dgvCustomers.RowTemplate.Height = 40;

            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        // =========================================================
        // CUSTOMER DISPLAY
        // =========================================================
        private void LoadCustomers()
        {
            try
            {
                using (HotelDbContext db = new HotelDbContext())
                {
                    var customers = db.Customers
                        .Where(c => !c.IsArchived)
                        .Select(c => new
                        {
                            c.CustomerId,
                            c.FirstName,
                            c.MiddleName,
                            c.LastName,
                            c.ContactNumber,
                            c.Email,
                            c.Address
                        })
                        .ToList();

                    dgvCustomers.DataSource = customers;
                    SetColumnWidths();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load customers.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetColumnWidths()
        {
            if (dgvCustomers.Columns.Count == 0) return;

            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetHeader("CustomerId", "ID");
            SetHeader("FirstName", "First Name");
            SetHeader("MiddleName", "Middle Name");
            SetHeader("LastName", "Last Name");
            SetHeader("ContactNumber", "Contact Number");
            SetHeader("Email", "Email");
            SetHeader("Address", "Address");

            SetFillWeight("CustomerId", 45);
            SetFillWeight("FirstName", 90);
            SetFillWeight("MiddleName", 90);
            SetFillWeight("LastName", 90);
            SetFillWeight("ContactNumber", 110);
            SetFillWeight("Email", 150);
            SetFillWeight("Address", 170);
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dgvCustomers.Columns.Contains(columnName))
                dgvCustomers.Columns[columnName].HeaderText = headerText;
        }

        private void SetFillWeight(string columnName, float weight)
        {
            if (dgvCustomers.Columns.Contains(columnName))
                dgvCustomers.Columns[columnName].FillWeight = weight;
        }

        // =========================================================
        // SEARCH
        // =========================================================
        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            try
            {
                using (HotelDbContext db = new HotelDbContext())
                {
                    var customers = db.Customers
                        .Where(c => !c.IsArchived)
                        .Where(c =>
                            c.FirstName.Contains(searchText) ||
                            c.LastName.Contains(searchText) ||
                            (c.MiddleName != null && c.MiddleName.Contains(searchText)) ||
                            c.ContactNumber.Contains(searchText) ||
                            (c.Email != null && c.Email.Contains(searchText)) ||
                            (c.Address != null && c.Address.Contains(searchText)))
                        .Select(c => new
                        {
                            c.CustomerId,
                            c.FirstName,
                            c.MiddleName,
                            c.LastName,
                            c.ContactNumber,
                            c.Email,
                            c.Address
                        })
                        .ToList();

                    dgvCustomers.DataSource = customers;
                    SetColumnWidths();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to search customers.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // REGISTER
        // =========================================================
        private void btnRegister_Click(object? sender, EventArgs e)
        {
            using (CustomerForm customerForm = new CustomerForm())
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                    LoadCustomers();
            }
        }

        // =========================================================
        // ARCHIVE
        // =========================================================
        private void btnArchive_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.",
                    "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object? idValue = dgvCustomers.CurrentRow.Cells["CustomerId"].Value;
            if (idValue == null)
            {
                MessageBox.Show("Unable to identify the selected customer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = Convert.ToInt32(idValue);

            var result = MessageBox.Show(
                "Are you sure you want to archive this customer?\n\n" +
                "The customer will not be permanently deleted.",
                "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (HotelDbContext db = new HotelDbContext())
                {
                    Customer? customer = db.Customers
                        .FirstOrDefault(c => c.CustomerId == customerId);

                    if (customer == null)
                    {
                        MessageBox.Show("Customer was not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    customer.IsArchived = true;
                    db.SaveChanges();
                }

                MessageBox.Show("Customer archived successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to archive customer.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // UPDATE
        // =========================================================
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.",
                    "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Update functionality will be added next.",
                "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================
        // NAV - CUSTOMERS
        // =========================================================
        private void btnCustomers_Click(object? sender, EventArgs e)
        {
            ShowCustomers();
        }

        private void ShowCustomers()
        {
            pnlContent.Controls.Clear();

            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Controls.Add(lblRecords);
            pnlContent.Controls.Add(lblSearch);
            pnlContent.Controls.Add(pnlSearch);
            pnlContent.Controls.Add(btnRegister);
            pnlContent.Controls.Add(btnUpdate);
            pnlContent.Controls.Add(btnArchive);
            pnlContent.Controls.Add(pnlTable);

            pnlHeader.BringToFront();
            lblRecords.BringToFront();
            lblSearch.BringToFront();
            pnlSearch.BringToFront();
            btnRegister.BringToFront();
            btnUpdate.BringToFront();
            btnArchive.BringToFront();
            pnlTable.BringToFront();

            HighlightSidebar(btnCustomers);
        }

        // =========================================================
        // NAV - RESERVATIONS
        // =========================================================
        private void btnReservations_Click(object? sender, EventArgs e)
        {
            ShowReservationManagement();
        }

        private void ShowReservationManagement()
        {
            if (reservationManagementControl == null)
                reservationManagementControl = new ReservationManagementControl();

            reservationManagementControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(reservationManagementControl);
            reservationManagementControl.BringToFront();

            HighlightSidebar(btnReservations);
        }

        // =========================================================
        // NAV - ROOMS
        // =========================================================
        private void btnRooms_Click(object? sender, EventArgs e)
        {
            ShowRoomManagement();
        }

        private void ShowRoomManagement()
        {
            if (roomManagementControl == null)
                roomManagementControl = new RoomManagementControl();

            roomManagementControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(roomManagementControl);
            roomManagementControl.BringToFront();

            HighlightSidebar(btnRooms);
        }

        // =========================================================
        // NAV - CHECK IN / OUT
        // =========================================================
        private void btnCheckInOut_Click(object? sender, EventArgs e)
        {
            ShowCheckInOut();
        }

        private void ShowCheckInOut()
        {
            if (checkInOutControl == null)
                checkInOutControl = new CheckInOutControl();
            else
                checkInOutControl.ReloadData();

            checkInOutControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(checkInOutControl);
            checkInOutControl.BringToFront();

            HighlightSidebar(btnCheckInOut);
        }

        // =========================================================
        // NAV - FEEDBACK
        // =========================================================
        private void btnFeedback_Click(object? sender, EventArgs e)
        {
            ShowFeedback();
        }

        private void ShowFeedback()
        {
            if (feedbackControl == null)
                feedbackControl = new FeedbackControl();
            else
                feedbackControl.ReloadData();

            feedbackControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(feedbackControl);
            feedbackControl.BringToFront();

            HighlightSidebar(btnFeedback);
        }

        // =========================================================
        // NAV - INQUIRIES
        // =========================================================
        private void btnInquiries_Click(object? sender, EventArgs e)
        {
            ShowInquiries();
        }

        private void ShowInquiries()
        {
            if (inquiryControl == null)
                inquiryControl = new InquiryControl();
            else
                inquiryControl.ReloadData();

            inquiryControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(inquiryControl);
            inquiryControl.BringToFront();

            HighlightSidebar(btnInquiries);
        }

        // =========================================================
        // SIDEBAR HIGHLIGHT
        // =========================================================
        private void HighlightSidebar(RoundedButton active)
        {
            RoundedButton[] buttons =
            {
                btnCustomers,
                btnReservations,
                btnRooms,
                btnCheckInOut,
                btnFeedback,
                btnInquiries
            };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;

                if (btn == active)
                {
                    btn.NormalColor = Theme.Primary;
                    btn.HoverColor = Theme.PrimaryHover;
                }
                else
                {
                    btn.NormalColor = Theme.Sidebar;
                    btn.HoverColor = Theme.SidebarHover;
                }
            }
        }
    }
}