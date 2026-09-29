using System;

namespace CRM.domain
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = "Cash";
        public string? Notes { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.Now;
        public string RecordedBy { get; set; } = "frontdesk";
    }
}