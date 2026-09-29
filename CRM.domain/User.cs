using System;

namespace CRM.domain
{
    public class User
    {
        public int UserId { get; set; }
        public int? TenantId { get; set; }         // null = Master Super Admin
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string PasswordSalt { get; set; } = "";
        public string Role { get; set; } = "Staff";
        public string? FullName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool MustChangePassword { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }
    }
}