using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HotelManagementSystem
{
    public class Context : DbContext
    {
        public DbSet<HotelGuest> HotelGuests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL15.SQLEXPRESS\\MSSQL\\DATA\\ProjectHMS.mdf;Database=ProjectHMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                 .Property(p => p.PaymentAmount)
                 .HasPrecision(18, 2);

            modelBuilder.Entity<Rate>()
                .Property(ra => ra.RatePrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Reservation>()
                .Property(re => re.ReservationAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserId = 1,
                    Username = "admin",  
                    Password = "456",
                    Role = "manager"
                });
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserId = 2,
                    Username = "user",
                    Password = "123",
                    Role = "employee"
                });


            for (int i = 1; i <= 18; i++)
            {
                modelBuilder.Entity<Room>().HasData(new Room
                {
                    RoomId = i,
                    RoomNumber = i,
                    RoomCapacity = 2,
                    RoomType = "TWN",
                    RoomAvailable = true,
                    RoomDescription = "Twin Room 35 m²: two single beds"
                });
            }
            for (int i = 19; i <= 50; i++)
            {
                modelBuilder.Entity<Room>()
                    .HasData(new Room
                {
                    RoomId = i,
                    RoomNumber = i,
                    RoomCapacity = 2,
                    RoomType = "DBL",
                    RoomAvailable = true,
                    RoomDescription = "Double Room 35 m²: double size bed"
                });
            }
            for (int i = 51; i <= 60; i++)
            {
                modelBuilder.Entity<Room>()
                    .HasData(new Room
                {
                    RoomId = i,
                    RoomNumber = i,
                    RoomCapacity = 3,
                    RoomType = "DLX",
                    RoomAvailable = true,
                    RoomDescription = "Deluxe Room 70m²: queen size bed and seafront "
                });
            }


            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 1,
                    RateCode = "BAR",
                    RatePrice = 250.00m,
                    RateDescription = "Rack Rate"
                });
            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 2,
                    RateCode = "NET",
                    RatePrice = 100.00m,
                    RateDescription = "Non-commissioned"
                });
            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 3,
                    RateCode = "CORP",
                    RatePrice = 160.50m,
                    RateDescription = "Companies Rate"
                });
            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 4,
                    RateCode = "LONG",
                    RatePrice = 198.50m,
                    RateDescription = "Long Stay Rate - 15 days"
                });
            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 5,
                    RateCode = "MON",
                    RatePrice = 185.50m,
                    RateDescription = "Monthly Rate"
                });
            modelBuilder.Entity<Rate>()
                .HasData(new Rate
                {
                    RateId = 6,
                    RateCode = "GRP",
                    RatePrice = 180.00m,
                    RateDescription = "Group Rate"
                });
        }
    }
}
