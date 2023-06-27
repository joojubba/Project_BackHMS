using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelGuests",
                columns: table => new
                {
                    HotelGuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelGuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGuestIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGuestEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelGuestPhone = table.Column<int>(type: "int", nullable: false),
                    HotelGuestAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirthHotelGuest = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelGuests", x => x.HotelGuestId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RoomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    HotelGuestId = table.Column<int>(type: "int", nullable: false),
                    RateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_HotelGuests_HotelGuestId",
                        column: x => x.HotelGuestId,
                        principalTable: "HotelGuests",
                        principalColumn: "HotelGuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rates_RateId",
                        column: x => x.RateId,
                        principalTable: "Rates",
                        principalColumn: "RateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomAvailable", "RoomCapacity", "RoomDescription", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, true, 2, "Twin Room 35 m²: two single beds", 1, "TWN" },
                    { 2, true, 2, "Twin Room 35 m²: two single beds", 2, "TWN" },
                    { 3, true, 2, "Twin Room 35 m²: two single beds", 3, "TWN" },
                    { 4, true, 2, "Twin Room 35 m²: two single beds", 4, "TWN" },
                    { 5, true, 2, "Twin Room 35 m²: two single beds", 5, "TWN" },
                    { 6, true, 2, "Twin Room 35 m²: two single beds", 6, "TWN" },
                    { 7, true, 2, "Twin Room 35 m²: two single beds", 7, "TWN" },
                    { 8, true, 2, "Twin Room 35 m²: two single beds", 8, "TWN" },
                    { 9, true, 2, "Twin Room 35 m²: two single beds", 9, "TWN" },
                    { 10, true, 2, "Twin Room 35 m²: two single beds", 10, "TWN" },
                    { 11, true, 2, "Twin Room 35 m²: two single beds", 11, "TWN" },
                    { 12, true, 2, "Twin Room 35 m²: two single beds", 12, "TWN" },
                    { 13, true, 2, "Twin Room 35 m²: two single beds", 13, "TWN" },
                    { 14, true, 2, "Twin Room 35 m²: two single beds", 14, "TWN" },
                    { 15, true, 2, "Twin Room 35 m²: two single beds", 15, "TWN" },
                    { 16, true, 2, "Twin Room 35 m²: two single beds", 16, "TWN" },
                    { 17, true, 2, "Twin Room 35 m²: two single beds", 17, "TWN" },
                    { 18, true, 2, "Twin Room 35 m²: two single beds", 18, "TWN" },
                    { 19, true, 2, "Double Room 35 m²: double size bed", 19, "DBL" },
                    { 20, true, 2, "Double Room 35 m²: double size bed", 20, "DBL" },
                    { 21, true, 2, "Double Room 35 m²: double size bed", 21, "DBL" },
                    { 22, true, 2, "Double Room 35 m²: double size bed", 22, "DBL" },
                    { 23, true, 2, "Double Room 35 m²: double size bed", 23, "DBL" },
                    { 24, true, 2, "Double Room 35 m²: double size bed", 24, "DBL" },
                    { 25, true, 2, "Double Room 35 m²: double size bed", 25, "DBL" },
                    { 26, true, 2, "Double Room 35 m²: double size bed", 26, "DBL" },
                    { 27, true, 2, "Double Room 35 m²: double size bed", 27, "DBL" },
                    { 28, true, 2, "Double Room 35 m²: double size bed", 28, "DBL" },
                    { 29, true, 2, "Double Room 35 m²: double size bed", 29, "DBL" },
                    { 30, true, 2, "Double Room 35 m²: double size bed", 30, "DBL" },
                    { 31, true, 2, "Double Room 35 m²: double size bed", 31, "DBL" },
                    { 32, true, 2, "Double Room 35 m²: double size bed", 32, "DBL" },
                    { 33, true, 2, "Double Room 35 m²: double size bed", 33, "DBL" },
                    { 34, true, 2, "Double Room 35 m²: double size bed", 34, "DBL" },
                    { 35, true, 2, "Double Room 35 m²: double size bed", 35, "DBL" },
                    { 36, true, 2, "Double Room 35 m²: double size bed", 36, "DBL" },
                    { 37, true, 2, "Double Room 35 m²: double size bed", 37, "DBL" },
                    { 38, true, 2, "Double Room 35 m²: double size bed", 38, "DBL" },
                    { 39, true, 2, "Double Room 35 m²: double size bed", 39, "DBL" },
                    { 40, true, 2, "Double Room 35 m²: double size bed", 40, "DBL" },
                    { 41, true, 2, "Double Room 35 m²: double size bed", 41, "DBL" },
                    { 42, true, 2, "Double Room 35 m²: double size bed", 42, "DBL" },
                    { 43, true, 2, "Double Room 35 m²: double size bed", 43, "DBL" },
                    { 44, true, 2, "Double Room 35 m²: double size bed", 44, "DBL" },
                    { 45, true, 2, "Double Room 35 m²: double size bed", 45, "DBL" },
                    { 46, true, 2, "Double Room 35 m²: double size bed", 46, "DBL" },
                    { 47, true, 2, "Double Room 35 m²: double size bed", 47, "DBL" },
                    { 48, true, 2, "Double Room 35 m²: double size bed", 48, "DBL" },
                    { 49, true, 2, "Double Room 35 m²: double size bed", 49, "DBL" },
                    { 50, true, 2, "Double Room 35 m²: double size bed", 50, "DBL" },
                    { 51, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 51, "DLX" },
                    { 52, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 52, "DLX" },
                    { 53, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 53, "DLX" },
                    { 54, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 54, "DLX" },
                    { 55, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 55, "DLX" },
                    { 56, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 56, "DLX" },
                    { 57, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 57, "DLX" },
                    { 58, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 58, "DLX" },
                    { 59, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 59, "DLX" },
                    { 60, true, 3, "Deluxe Room 70m²: queen size bed and seafront ", 60, "DLX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelGuestId",
                table: "Reservations",
                column: "HotelGuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RateId",
                table: "Reservations",
                column: "RateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HotelGuests");

            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
