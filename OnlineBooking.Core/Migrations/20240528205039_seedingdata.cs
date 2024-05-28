using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "0af8167d-78c1-4dc1-b986-b6bce04afa94", "user1@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "3a994356-776b-4d11-84b8-87db3daa47ab", false, "user1@example.com" },
                    { "user2", 0, "bf930ddd-b2ab-43e5-83e6-52745b5d9ffc", "user2@example.com", false, "Jane", "Doe", false, null, null, null, null, null, false, "b6fafc0e-99a7-492c-8a16-72d63ff1c791", false, "user2@example.com" }
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
                    { 1L, 1L, "user1", new DateTime(2024, 5, 19, 0, 50, 38, 517, DateTimeKind.Local).AddTicks(3686), new DateTime(2024, 5, 24, 0, 50, 38, 517, DateTimeKind.Local).AddTicks(3698), 500.0 },
                    { 2L, 2L, "user2", new DateTime(2024, 5, 26, 0, 50, 38, 517, DateTimeKind.Local).AddTicks(3700), new DateTime(2024, 5, 28, 0, 50, 38, 517, DateTimeKind.Local).AddTicks(3701), 300.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
