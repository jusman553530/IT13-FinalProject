using System;

namespace CRM.domain
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Tier { get; set; } = "";
        public decimal Rate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}