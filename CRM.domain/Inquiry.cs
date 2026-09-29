using System;

namespace CRM.domain
{
    public class Inquiry
    {
        public int InquiryId { get; set; }
        public int? CustomerId { get; set; }
        public string? GuestName { get; set; }
        public string? GuestContact { get; set; }
        public string Subject { get; set; } = "";
        public string Message { get; set; } = "";
        public string Status { get; set; } = "New";
        public string Priority { get; set; } = "Normal";
        public string Source { get; set; } = "Walk-In";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "frontdesk";
        public string? ResponseMessage { get; set; }
        public DateTime? ClosedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
    }
}