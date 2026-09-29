using System;
using System.Linq;

namespace CRM.infrastructure
{
    public static class UserSeeder
    {
        private const string DefaultPassword = "admin123";

        public static void SeedIfNeeded()
        {
            using (var db = new HotelDbContext())
            {
                var pending = db.Users
                    .Where(u => u.PasswordHash == "PENDING" ||
                                u.PasswordSalt == "PENDING")
                    .ToList();

                if (pending.Count == 0)
                    return;

                foreach (var user in pending)
                {
                    var (hash, salt) = PasswordHasher.Hash(DefaultPassword);
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;

                    Console.WriteLine(
                        "[UserSeeder] Seeded password for user: " + user.Username);
                }

                db.SaveChanges();
            }
        }
    }
}