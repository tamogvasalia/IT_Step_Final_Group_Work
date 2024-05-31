using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class AfterMergeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "165bce9a-3110-4803-a14b-8c2037ccb88b", "user1@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "5e86f5fd-6ad0-4080-b426-c0ac364a462d", false, "user1@example.com" },
                    { "user2", 0, "c821e809-5693-40b0-9535-b2f1a740eb8f", "user2@example.com", false, "Jane", "Doe", false, null, null, null, null, null, false, "f22e0740-17f5-43eb-ac9d-d597bfe9b1ef", false, "user2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1L, "42 Sunset Boulevard", "Los Angeles", "Hotel California", "hotelcalifornia.jpg" },
                    { 2L, "1 Republic Avenue", "Zubrowka", "The Grand Budapest Hotel", "grandbudapest.jpg" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1L, "Single" },
                    { 2L, "Double" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "Name", "PicturePath", "PricePerDay", "isAvailable", "maxGuests", "roomTypeId" },
                values: new object[,]
                {
                    { 1L, 1L, "Room 101", "room101.jpg", 100.0, true, 2, 1L },
                    { 2L, 1L, "Room 102", "room102.jpg", 150.0, true, 3, 2L }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "RoomId", "UserID", "checkInTime", "checkOutTime", "totalPrice" },
                values: new object[,]
                {
                    { 1L, 1L, "user1", new DateTime(2024, 5, 20, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1793), new DateTime(2024, 5, 25, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1821), 500.0 },
                    { 2L, 2L, "user2", new DateTime(2024, 5, 26, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8571), new DateTime(2024, 5, 28, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8572), 300.0 }
                });
        }
    }
}
