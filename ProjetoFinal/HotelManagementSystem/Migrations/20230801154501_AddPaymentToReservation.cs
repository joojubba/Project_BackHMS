using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_PaymentId",
                table: "Reservations",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_PaymentId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservations");
        }
    }
}
