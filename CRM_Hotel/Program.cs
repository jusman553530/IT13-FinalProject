using CRM.infrastructure;
using CRM.winforms;

namespace CRM_Hotel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    bool canConnect = db.Database.CanConnect();
                    int userCount = db.Users.Count();
                    int tenantCount = db.Tenants.Count();

                    MessageBox.Show(
                        "Can connect: " + canConnect + "\n" +
                        "Users in DB: " + userCount + "\n" +
                        "Tenants in DB: " + tenantCount,
                        "DB Connection Test",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "DB connection FAILED:\n\n" + ex.Message,
                    "DB Connection Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // ... rest of Main unchanged
        }
    }
}