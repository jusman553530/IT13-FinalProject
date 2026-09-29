using System;

namespace CRM.domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = "";
        public string ContactNumber { get; set; } = "";
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsArchived { get; set; } = false;
    }
}