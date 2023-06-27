﻿// <auto-generated />
using System;
using HotelManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230624193022_PredefinedUsers2")]
    partial class PredefinedUsers2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementSystem.DataModels.HotelGuest", b =>
                {
                    b.Property<int>("HotelGuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelGuestId"));

                    b.Property<DateTime>("DateBirthHotelGuest")
                        .HasColumnType("datetime2");

                    b.Property<string>("HotelGuestAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelGuestEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelGuestIdentification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelGuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelGuestPhone")
                        .HasColumnType("int");

                    b.HasKey("HotelGuestId");

                    b.ToTable("HotelGuests");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("PaymentAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RateId"));

                    b.Property<string>("RateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RateDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RatePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.HasIndex("RoomId");

                    b.ToTable("Rates");

                    b.HasData(
                        new
                        {
                            RateId = 1,
                            RateCode = "BAR",
                            RateDescription = "Rack Rate",
                            RatePrice = 250.00m
                        },
                        new
                        {
                            RateId = 2,
                            RateCode = "NET",
                            RateDescription = "Non-commissioned",
                            RatePrice = 100.00m
                        },
                        new
                        {
                            RateId = 3,
                            RateCode = "CORP",
                            RateDescription = "Companies Rate",
                            RatePrice = 160.50m
                        },
                        new
                        {
                            RateId = 4,
                            RateCode = "LONG",
                            RateDescription = "Long Stay Rate - 15 days",
                            RatePrice = 198.50m
                        },
                        new
                        {
                            RateId = 5,
                            RateCode = "MON",
                            RateDescription = "Monthly Rate",
                            RatePrice = 185.50m
                        },
                        new
                        {
                            RateId = 6,
                            RateCode = "GRP",
                            RateDescription = "Group Rate",
                            RatePrice = 180.00m
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelGuestId")
                        .HasColumnType("int");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<int>("NumberGuests")
                        .HasColumnType("int");

                    b.Property<int?>("RateId")
                        .HasColumnType("int");

                    b.Property<decimal>("ReservationAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationId");

                    b.HasIndex("HotelGuestId");

                    b.HasIndex("RateId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<bool>("RoomAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 1,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 2,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 2,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 3,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 3,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 4,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 4,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 5,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 5,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 6,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 6,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 7,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 7,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 8,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 8,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 9,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 9,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 10,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 10,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 11,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 11,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 12,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 12,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 13,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 13,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 14,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 14,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 15,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 15,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 16,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 16,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 17,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 17,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 18,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Twin Room 35 m²: two single beds",
                            RoomNumber = 18,
                            RoomType = "TWN",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 19,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 19,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 20,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 20,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 21,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 21,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 22,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 22,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 23,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 23,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 24,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 24,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 25,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 25,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 26,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 26,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 27,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 27,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 28,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 28,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 29,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 29,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 30,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 30,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 31,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 31,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 32,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 32,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 33,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 33,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 34,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 34,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 35,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 35,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 36,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 36,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 37,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 37,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 38,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 38,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 39,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 39,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 40,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 40,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 41,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 41,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 42,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 42,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 43,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 43,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 44,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 44,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 45,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 45,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 46,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 46,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 47,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 47,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 48,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 48,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 49,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 49,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 50,
                            RoomAvailable = true,
                            RoomCapacity = 2,
                            RoomDescription = "Double Room 35 m²: double size bed",
                            RoomNumber = 50,
                            RoomType = "DBL",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 51,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 51,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 52,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 52,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 53,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 53,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 54,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 54,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 55,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 55,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 56,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 56,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 57,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 57,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 58,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 58,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 59,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 59,
                            RoomType = "DLX",
                            Status = 0
                        },
                        new
                        {
                            RoomId = 60,
                            RoomAvailable = true,
                            RoomCapacity = 3,
                            RoomDescription = "Deluxe Room 70m²: queen size bed and seafront ",
                            RoomNumber = 60,
                            RoomType = "DLX",
                            Status = 0
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "456",
                            Role = "manager",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "123",
                            Role = "employee",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Rate", b =>
                {
                    b.HasOne("HotelManagementSystem.DataModels.Room", "Room")
                        .WithMany("Rates")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Reservation", b =>
                {
                    b.HasOne("HotelManagementSystem.DataModels.HotelGuest", "HotelGuest")
                        .WithMany("reservations")
                        .HasForeignKey("HotelGuestId");

                    b.HasOne("HotelManagementSystem.DataModels.Rate", "Rate")
                        .WithMany()
                        .HasForeignKey("RateId");

                    b.HasOne("HotelManagementSystem.DataModels.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("HotelGuest");

                    b.Navigation("Rate");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.HotelGuest", b =>
                {
                    b.Navigation("reservations");
                });

            modelBuilder.Entity("HotelManagementSystem.DataModels.Room", b =>
                {
                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}