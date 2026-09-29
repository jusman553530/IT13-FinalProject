using CRM.domain;
using Microsoft.EntityFrameworkCore;

namespace CRM.infrastructure
{
    public class HotelDbContext : DbContext
    {
        // =========================================================
        // SHARED TABLES (always in dbo)
        // =========================================================
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        // =========================================================
        // TENANT-SCOPED TABLES (mapped to the active tenant's schema)
        // =========================================================
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }

        // ---------------------------------------------------------
        // The schema that business tables will be mapped to.
        // If the user has no tenant slug (e.g. not logged in yet),
        // fall back to "dbo" so the app doesn't crash on startup.
        // ---------------------------------------------------------
        private readonly string _schema;

        public HotelDbContext()
        {
            _schema = string.IsNullOrEmpty(CurrentUser.TenantSlug)
                ? "dbo"
                : CurrentUser.TenantSlug;
        }

        protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=CRM_Hotel;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // =========================================================
            // SHARED TABLES — always dbo
            // =========================================================
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenants", "dbo");
                entity.HasKey(e => e.TenantId);
                entity.Property(e => e.TenantId).HasColumnName("TenantId").ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Slug).HasColumnName("Slug").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Tier).HasColumnName("Tier").HasMaxLength(20).IsRequired();
                entity.Property(e => e.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "dbo");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserId").ValueGeneratedOnAdd();
                entity.Property(e => e.TenantId).HasColumnName("TenantId");
                entity.Property(e => e.Username).HasColumnName("Username").HasMaxLength(50).IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(200).IsRequired();
                entity.Property(e => e.PasswordSalt).HasColumnName("PasswordSalt").HasMaxLength(200).IsRequired();
                entity.Property(e => e.Role).HasColumnName("Role").HasMaxLength(20).IsRequired();
                entity.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(150);
                entity.Property(e => e.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
                entity.Property(e => e.MustChangePassword).HasColumnName("MustChangePassword").IsRequired().HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.LastLoginAt).HasColumnName("LastLoginAt").HasColumnType("datetime2");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discounts", "dbo");
                entity.HasKey(e => e.DiscountId);
                entity.Property(e => e.DiscountId).HasColumnName("DiscountId").ValueGeneratedOnAdd();
                entity.Property(e => e.Tier).HasColumnName("Tier").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Rate).HasColumnName("Rate").HasColumnType("decimal(6,4)").IsRequired();
                entity.Property(e => e.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
                entity.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2").IsRequired();
            });

            // =========================================================
            // BUSINESS TABLES — mapped to the active tenant's schema
            // =========================================================
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers", _schema);
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId").ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
                entity.Property(e => e.MiddleName).HasColumnName("MiddleName").HasMaxLength(100);
                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
                entity.Property(e => e.ContactNumber).HasColumnName("ContactNumber").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(150);
                entity.Property(e => e.Address).HasColumnName("Address").HasMaxLength(250);
                entity.Property(e => e.IsArchived).HasColumnName("IsArchived").IsRequired().HasDefaultValue(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Rooms", _schema);
                entity.HasKey(e => e.RoomId);
                entity.Property(e => e.RoomId).HasColumnName("RoomId").ValueGeneratedOnAdd();
                entity.Property(e => e.RoomNumber).HasColumnName("RoomNumber").HasMaxLength(20).IsRequired();
                entity.Property(e => e.RoomType).HasColumnName("RoomType").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Price).HasColumnName("Price").HasColumnType("decimal(10,2)").IsRequired();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservations", _schema);
                entity.HasKey(e => e.ReservationId);
                entity.Property(e => e.ReservationId).HasColumnName("ReservationId").ValueGeneratedOnAdd();
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId").IsRequired();
                entity.Property(e => e.RoomId).HasColumnName("RoomId").IsRequired();
                entity.Property(e => e.CheckInDate).HasColumnName("CheckInDate").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.CheckOutDate).HasColumnName("CheckOutDate").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.NumberOfGuests).HasColumnName("NumberOfGuests").IsRequired();
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(30).IsRequired();
                entity.Property(e => e.SpecialRequests).HasColumnName("SpecialRequests").HasMaxLength(500);
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.ActualCheckInTime).HasColumnName("ActualCheckInTime").HasColumnType("datetime2");
                entity.Property(e => e.ActualCheckOutTime).HasColumnName("ActualCheckOutTime").HasColumnType("datetime2");
                entity.Property(e => e.TotalAmount).HasColumnName("TotalAmount").HasColumnType("decimal(10,2)").IsRequired().HasDefaultValue(0m);
                entity.Property(e => e.DownPayment).HasColumnName("DownPayment").HasColumnType("decimal(10,2)").IsRequired().HasDefaultValue(0m);
                entity.Property(e => e.PaymentStatus).HasColumnName("PaymentStatus").HasMaxLength(20).IsRequired().HasDefaultValue("Unpaid");
                entity.Property(e => e.PaidAt).HasColumnName("PaidAt").HasColumnType("datetime2");
                entity.Property(e => e.DiscountAmount).HasColumnName("DiscountAmount").HasColumnType("decimal(10,2)").IsRequired().HasDefaultValue(0m);
                entity.Property(e => e.FinalAmount).HasColumnName("FinalAmount").HasColumnType("decimal(10,2)").IsRequired().HasDefaultValue(0m);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments", _schema);
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.PaymentId).HasColumnName("PaymentId").ValueGeneratedOnAdd();
                entity.Property(e => e.ReservationId).HasColumnName("ReservationId").IsRequired();
                entity.Property(e => e.Amount).HasColumnName("Amount").HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(e => e.Method).HasColumnName("Method").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Notes).HasColumnName("Notes").HasMaxLength(500);
                entity.Property(e => e.PaidAt).HasColumnName("PaidAt").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.RecordedBy).HasColumnName("RecordedBy").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedbacks", _schema);
                entity.HasKey(e => e.FeedbackId);
                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackId").ValueGeneratedOnAdd();
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
                entity.Property(e => e.Rating).HasColumnName("Rating").IsRequired();
                entity.Property(e => e.Comments).HasColumnName("Comments").HasMaxLength(1000).IsRequired();
                entity.Property(e => e.SubmittedAt).HasColumnName("SubmittedAt").HasColumnType("datetime2").IsRequired();
            });

            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.ToTable("Inquiries", _schema);
                entity.HasKey(e => e.InquiryId);
                entity.Property(e => e.InquiryId).HasColumnName("InquiryId").ValueGeneratedOnAdd();
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
                entity.Property(e => e.GuestName).HasColumnName("GuestName").HasMaxLength(200);
                entity.Property(e => e.GuestContact).HasColumnName("GuestContact").HasMaxLength(150);
                entity.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(200).IsRequired();
                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(2000).IsRequired();
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Priority).HasColumnName("Priority").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Source).HasColumnName("Source").HasMaxLength(30).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(100).IsRequired();
                entity.Property(e => e.ResponseMessage).HasColumnName("ResponseMessage").HasMaxLength(2000);
                entity.Property(e => e.ClosedAt).HasColumnName("ClosedAt").HasColumnType("datetime2");
                entity.Property(e => e.CancelledAt).HasColumnName("CancelledAt").HasColumnType("datetime2");
            });
        }

        public static void EnsureDatabaseCreated()
        {
            using (var db = new HotelDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}