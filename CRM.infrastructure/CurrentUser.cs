namespace CRM.infrastructure
{
    public static class CurrentUser
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; } = "";
        public static string FullName { get; private set; } = "";
        public static string Role { get; private set; } = "";
        public static int? TenantId { get; private set; }
        public static string TenantSlug { get; private set; } = "";   // tenant_a / tenant_b / tenant_c
        public static string TenantName { get; private set; } = "";
        public static bool IsLoggedIn { get; private set; }

        public static bool IsAdmin => Role == "Admin";
        public static bool IsManager => Role == "Manager" || IsAdmin;
        public static bool IsStaff => IsLoggedIn;

        // True when the account has no tenant assigned (Master Super Admin)
        public static bool IsMasterAdmin => IsAdmin && TenantId == null;

        public static void Set(
            int userId,
            string username,
            string fullName,
            string role,
            int? tenantId = null,
            string tenantSlug = "",
            string tenantName = "")
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            Role = role;
            TenantId = tenantId;
            TenantSlug = tenantSlug;
            TenantName = tenantName;
            IsLoggedIn = true;
        }

        // Called when a master admin picks a tenant
        public static void SetTenant(string slug, string name, int? tenantId)
        {
            TenantSlug = slug;
            TenantName = name;
            TenantId = tenantId;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = "";
            FullName = "";
            Role = "";
            TenantId = null;
            TenantSlug = "";
            TenantName = "";
            IsLoggedIn = false;
        }
    }
}