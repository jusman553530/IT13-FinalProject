using System;

namespace CRM.domain
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Tier { get; set; } = "Micro";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}