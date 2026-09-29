using System;

namespace CRM.domain
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int? CustomerId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; } = "";
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}