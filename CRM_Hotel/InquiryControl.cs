using CRM.domain;
using CRM.infrastructure;
using CRM.winforms.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class InquiryControl : UserControl
    {
        private string _activeFilter = "All";
        private int? _selectedId = null;

        private readonly Dictionary<int, InquiryCard> _cardById = new();

        public InquiryControl()
        {
            InitializeComponent();
            WireEvents();
            ShowTab("All");
            LoadQueue();
        }

        public void ReloadData()
        {
            LoadQueue();
        }

        private void WireEvents()
        {
            btnTabAll.Click += (s, e) => ShowTab("All");
            btnTabNew.Click += (s, e) => ShowTab("New");
            btnTabInProgress.Click += (s, e) => ShowTab("In Progress");
            btnTabAnswered.Click += (s, e) => ShowTab("Answered");
            btnTabClosed.Click += (s, e) => ShowTab("Closed");

            btnNew.Click += BtnNew_Click;
            btnRefresh.Click += (s, e) => LoadQueue();
            btnSaveResponse.Click += BtnSaveResponse_Click;
            btnAdvance.Click += BtnAdvance_Click;
            btnCancel.Click += BtnCancelInquiry_Click;
        }

        // =========================================================
        // TABS
        // =========================================================
        private void ShowTab(string filter)
        {
            _activeFilter = filter;

            RoundedButton[] tabs =
            {
                btnTabAll, btnTabNew, btnTabInProgress, btnTabAnswered, btnTabClosed
            };

            string[] names = { "All", "New", "In Progress", "Answered", "Closed" };

            for (int i = 0; i < tabs.Length; i++)
            {
                bool active = names[i] == filter;

                tabs[i].NormalColor = active ? Theme.Primary : Theme.Field;
                tabs[i].HoverColor = active ? Theme.PrimaryHover : Theme.Tint;
                tabs[i].ForeColor = active ? Color.White : Theme.TextDark;
            }

            LoadQueue();
        }

        // =========================================================
        // QUEUE
        // =========================================================
        private void LoadQueue()
        {
            try
            {
                List<Inquiry> items;

                using (var db = new HotelDbContext())
                {
                    var query = db.Inquiries.AsQueryable();

                    if (_activeFilter != "All")
                        query = query.Where(i => i.Status == _activeFilter);

                    items = query
                        .OrderByDescending(i => i.CreatedAt)
                        .ToList();

                    int openCount = db.Inquiries.Count(i =>
                        i.Status == "New" || i.Status == "In Progress");

                    int totalCount = db.Inquiries.Count();

                    lblCounter.Text = openCount + " open · " + totalCount + " total";
                }

                RenderCards(items);
                RestoreSelection(items);
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load inquiries.", ex);
            }
        }

        private void RenderCards(List<Inquiry> items)
        {
            flpCards.SuspendLayout();
            flpCards.Controls.Clear();
            _cardById.Clear();

            foreach (var inquiry in items)
            {
                var card = new InquiryCard();
                card.Width = Math.Max(280, flpCards.ClientSize.Width - 25);
                card.Bind(inquiry);
                card.CardClicked += Card_CardClicked;

                _cardById[inquiry.InquiryId] = card;
                flpCards.Controls.Add(card);
            }

            flpCards.ResumeLayout();

            if (items.Count == 0)
            {
                ShowEmptyState(_activeFilter == "All"
                    ? "No inquiries yet. Click + New to log one."
                    : "No inquiries with status '" + _activeFilter + "'.");
            }
        }

        private void RestoreSelection(List<Inquiry> items)
        {
            if (_selectedId == null)
            {
                ShowEmptyState("Select an inquiry to view it here");
                return;
            }

            var match = items.FirstOrDefault(i => i.InquiryId == _selectedId.Value);

            if (match == null)
            {
                _selectedId = null;
                ShowEmptyState("Select an inquiry to view it here");
                return;
            }

            DisplayDetail(match);

            foreach (var kv in _cardById)
                kv.Value.SetSelected(kv.Key == _selectedId.Value);
        }

        // =========================================================
        // CARD CLICK
        // =========================================================
        private void Card_CardClicked(object? sender, EventArgs e)
        {
            if (sender is not InquiryCard card) return;

            _selectedId = card.InquiryId;

            foreach (var kv in _cardById)
                kv.Value.SetSelected(kv.Key == card.InquiryId);

            try
            {
                using (var db = new HotelDbContext())
                {
                    var inquiry = db.Inquiries
                        .FirstOrDefault(i => i.InquiryId == card.InquiryId);

                    if (inquiry != null)
                        DisplayDetail(inquiry);
                }
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to load inquiry detail.", ex);
            }
        }

        // =========================================================
        // DETAIL
        // =========================================================
        private void DisplayDetail(Inquiry inquiry)
        {
            lblEmptyState.Visible = false;
            pnlDetailInner.Visible = true;

            lblDetailSubject.Text = inquiry.Subject;
            lblDetailMeta.Text =
                (inquiry.GuestName ?? "(no name)") +
                "  ·  " + (inquiry.GuestContact ?? "no contact") +
                "  ·  " + inquiry.Source +
                "  ·  " + inquiry.CreatedAt.ToString("MMM dd, yyyy HH:mm");

            lblDetailPriority.Text = inquiry.Priority.ToUpperInvariant();

            switch (inquiry.Priority)
            {
                case "High":
                    lblDetailPriority.BackColor = Color.IndianRed;
                    break;
                case "Low":
                    lblDetailPriority.BackColor = Color.Gray;
                    break;
                default:
                    lblDetailPriority.BackColor = Color.DarkOrange;
                    break;
            }

            lblDetailStatus.Text = inquiry.Status.ToUpperInvariant();

            switch (inquiry.Status)
            {
                case "New":
                    lblDetailStatus.BackColor = Color.SteelBlue;
                    break;
                case "In Progress":
                    lblDetailStatus.BackColor = Color.DarkOrange;
                    break;
                case "Answered":
                    lblDetailStatus.BackColor = Color.SeaGreen;
                    break;
                case "Closed":
                    lblDetailStatus.BackColor = Color.Gray;
                    break;
                case "Cancelled":
                    lblDetailStatus.BackColor = Color.IndianRed;
                    break;
            }

            txtDetailMessage.Text = inquiry.Message;
            txtDetailResponse.Text = inquiry.ResponseMessage ?? "";

            bool editable =
                inquiry.Status == "New" ||
                inquiry.Status == "In Progress" ||
                inquiry.Status == "Answered";

            txtDetailResponse.ReadOnly = !editable;
            btnSaveResponse.Enabled = editable;
            btnAdvance.Enabled = editable;
            btnCancel.Enabled = editable;

            lblResponseHint.Text = editable
                ? "Saving a response marks the inquiry as Answered."
                : "This inquiry is " + inquiry.Status.ToLowerInvariant() + " and can no longer be edited.";
        }

        private void ShowEmptyState(string message)
        {
            lblEmptyState.Text = message;
            lblEmptyState.Visible = true;
            pnlDetailInner.Visible = false;
        }

        // =========================================================
        // ACTIONS
        // =========================================================
        private void BtnNew_Click(object? sender, EventArgs e)
        {
            using (var dlg = new NewInquiryForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    SetStatus("Inquiry logged.");
                    LoadQueue();
                }
            }
        }

        private void BtnSaveResponse_Click(object? sender, EventArgs e)
        {
            if (_selectedId == null)
            {
                Warn("Please select an inquiry first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDetailResponse.Text))
            {
                Warn("Please type a response before saving.");
                return;
            }

            try
            {
                using (var db = new HotelDbContext())
                {
                    var inquiry = db.Inquiries
                        .FirstOrDefault(i => i.InquiryId == _selectedId.Value);

                    if (inquiry == null) { Warn("Inquiry not found."); return; }

                    inquiry.ResponseMessage = txtDetailResponse.Text.Trim();
                    inquiry.Status = "Answered";
                    db.SaveChanges();
                }

                SetStatus("Response saved for inquiry #" + _selectedId);
                LoadQueue();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to save response.", ex);
            }
        }

        private void BtnAdvance_Click(object? sender, EventArgs e)
        {
            if (_selectedId == null) { Warn("Please select an inquiry first."); return; }

            try
            {
                using (var db = new HotelDbContext())
                {
                    var inquiry = db.Inquiries
                        .FirstOrDefault(i => i.InquiryId == _selectedId.Value);

                    if (inquiry == null) { Warn("Inquiry not found."); return; }

                    string next;
                    switch (inquiry.Status)
                    {
                        case "New": next = "In Progress"; break;
                        case "In Progress": next = "Answered"; break;
                        case "Answered": next = "Closed"; inquiry.ClosedAt = DateTime.Now; break;
                        case "Closed":
                        case "Cancelled":
                            Warn("Already " + inquiry.Status.ToLowerInvariant() + ".");
                            return;
                        default: next = "In Progress"; break;
                    }

                    inquiry.Status = next;
                    db.SaveChanges();
                    SetStatus("Moved to " + next + ".");
                }

                LoadQueue();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to advance inquiry.", ex);
            }
        }

        private void BtnCancelInquiry_Click(object? sender, EventArgs e)
        {
            if (_selectedId == null) { Warn("Please select an inquiry first."); return; }

            var confirm = MessageBox.Show(
                "Cancel this inquiry? The record will remain as Cancelled.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new HotelDbContext())
                {
                    var inquiry = db.Inquiries
                        .FirstOrDefault(i => i.InquiryId == _selectedId.Value);

                    if (inquiry == null) { Warn("Inquiry not found."); return; }

                    inquiry.Status = "Cancelled";
                    inquiry.CancelledAt = DateTime.Now;
                    db.SaveChanges();
                }

                SetStatus("Inquiry cancelled.");
                LoadQueue();
            }
            catch (Exception ex)
            {
                ShowDbError("Unable to cancel inquiry.", ex);
            }
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
                "Inquiries",
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
    }
}