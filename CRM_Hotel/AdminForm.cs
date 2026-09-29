using CRM.infrastructure;
using CRM.winforms;
using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRM_Hotel
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            // Show logged-in admin
            this.Text = "Hotel CRM — Admin Console (" + CurrentUser.FullName + ")";

            WireEvents();

            // First page shown on login
            ShowDashboard();
        }

        private void WireEvents()
        {
            // Real page
            btnUserManagement.Click += (s, e) => ShowUserManagement();

            // Placeholders (until we build each one)
            btnDashboard.Click += (s, e) => ShowDashboard();
            btnTerms.Click += (s, e) => ShowPage(btnTerms, "Terms & Conditions");
            btnGuests.Click += (s, e) => ShowManageGuests();
            btnRevenue.Click += (s, e) => ShowRevenueReports();
            btnRetention.Click += (s, e) => ShowCustomerRetention();
            btnRooms.Click += (s, e) => ShowManageRooms();
            btnDiscounts.Click += (s, e) => ShowManageDiscounts();
            btnFeedbacks.Click += (s, e) => ShowPage(btnFeedbacks, "Manage Customer Feedbacks");
        }

        // =========================================================
        // USER MANAGEMENT (real)
        // =========================================================
        private void ShowUserManagement()
        {
            var page = new ManageUsersControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnUserManagement);
        }

        private void ShowManageRooms()
        {
            var page = new ManageRoomsControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnRooms);
        }

        private void ShowManageDiscounts()
        {
            var page = new ManageDiscountsControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnDiscounts);
        }

        private void ShowDashboard()
        {
            var page = new DashboardControl();

            // Wire KPI drill-downs to the corresponding pages
            page.NavigateToGuests += (s, e) => ShowManageGuests();
            page.NavigateToRevenue += (s, e) => ShowRevenueReports();
            page.NavigateToRetention += (s, e) => ShowCustomerRetention();
            page.NavigateToDiscounts += (s, e) => ShowManageDiscounts();

            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnDashboard);
        }

        private void ShowCustomerRetention()
        {
            var page = new CustomerRetentionControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnRetention);
        }

        private void ShowRevenueReports()
        {
            var page = new RevenueReportsControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnRevenue);
        }

        // =========================================================
        // PLACEHOLDER (still used by the other 7 pages)
        // =========================================================
        private void ShowPage(RoundedButton source, string pageTitle)
        {
            var page = new AdminPlaceholderControl(pageTitle);
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(source);
        }

        private void ShowManageGuests()
        {
            var page = new ManageGuestsControl();
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(page);
            page.BringToFront();

            HighlightSidebar(btnGuests);
        }

        private void HighlightSidebar(RoundedButton active)
        {
            RoundedButton[] buttons =
            {
                btnUserManagement,
                btnTerms,
                btnGuests,
                btnRevenue,
                btnRetention,
                btnRooms,
                btnDiscounts,
                btnFeedbacks
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