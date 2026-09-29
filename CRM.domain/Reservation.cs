using System;

namespace CRM.domain
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = "Pending";
        public string? SpecialRequests { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ActualCheckInTime { get; set; }
        public DateTime? ActualCheckOutTime { get; set; }

        // Payments
        public decimal TotalAmount { get; set; } = 0m;
        public decimal DownPayment { get; set; } = 0m;
        public string PaymentStatus { get; set; } = "Unpaid";
        public DateTime? PaidAt { get; set; }

        // Discount (tier-based)
        public decimal DiscountAmount { get; set; } = 0m;
        public decimal FinalAmount { get; set; } = 0m;
    }
}