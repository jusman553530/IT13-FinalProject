using CRM.domain;
using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class InquiryCard : UserControl
    {
        public int InquiryId { get; private set; }
        public bool IsSelected { get; private set; }

        public event EventHandler? CardClicked;

        public InquiryCard()
        {
            InitializeComponent();
            WireClickRecursive(this);
        }

        public void Bind(Inquiry inquiry)
        {
            InquiryId = inquiry.InquiryId;

            lblGuest.Text = inquiry.GuestName ?? "(no name)";
            lblSubject.Text = Truncate(inquiry.Subject, 32);
            lblTimeAgo.Text = TimeAgo(inquiry.CreatedAt);
            lblPriority.Text = inquiry.Priority.ToUpperInvariant();

            switch (inquiry.Priority)
            {
                case "High":
                    lblPriority.ForeColor = Color.IndianRed;
                    pnlStripe.BackColor = Color.IndianRed;
                    break;
                case "Low":
                    lblPriority.ForeColor = Color.Gray;
                    pnlStripe.BackColor = Color.LightGray;
                    break;
                default:
                    lblPriority.ForeColor = Color.DarkOrange;
                    pnlStripe.BackColor = Color.DarkOrange;
                    break;
            }

            lblStatus.Text = inquiry.Status.ToUpperInvariant();

            switch (inquiry.Status)
            {
                case "New":
                    lblStatus.BackColor = Color.SteelBlue;
                    break;
                case "In Progress":
                    lblStatus.BackColor = Color.DarkOrange;
                    break;
                case "Answered":
                    lblStatus.BackColor = Color.SeaGreen;
                    break;
                case "Closed":
                    lblStatus.BackColor = Color.Gray;
                    break;
                case "Cancelled":
                    lblStatus.BackColor = Color.IndianRed;
                    break;
                default:
                    lblStatus.BackColor = Color.SteelBlue;
                    break;
            }
        }

        public void SetSelected(bool selected)
        {
            IsSelected = selected;
            BackColor = selected ? Theme.Tint : Color.White;
            Invalidate();
        }

        private void WireClickRecursive(Control parent)
        {
            parent.Click += (s, e) => CardClicked?.Invoke(this, EventArgs.Empty);
            parent.Cursor = Cursors.Hand;

            foreach (Control child in parent.Controls)
            {
                WireClickRecursive(child);
            }
        }

        private static string Truncate(string text, int max)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= max ? text : text.Substring(0, max - 1) + "…";
        }

        private static string TimeAgo(DateTime when)
        {
            var span = DateTime.Now - when;

            if (span.TotalSeconds < 60)
                return "now";

            if (span.TotalMinutes < 60)
                return (int)span.TotalMinutes + "m ago";

            if (span.TotalHours < 24)
                return (int)span.TotalHours + "h ago";

            if (span.TotalDays < 7)
                return (int)span.TotalDays + "d ago";

            return when.ToString("MMM dd");
        }
    }
}