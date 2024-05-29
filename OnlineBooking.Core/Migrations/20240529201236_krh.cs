using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class krh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56cd6be5-6586-4803-9178-68897da38de9", "6af8cff5-df65-4401-9549-1c41fb423780" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bca5745d-41e7-44a7-927f-0095d893a19b", "0cf664fa-f945-4edf-b00c-85dad50635a1" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1793), new DateTime(2024, 5, 25, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 27, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1825), new DateTime(2024, 5, 29, 0, 12, 34, 295, DateTimeKind.Local).AddTicks(1826) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "165bce9a-3110-4803-a14b-8c2037ccb88b", "5e86f5fd-6ad0-4080-b426-c0ac364a462d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c821e809-5693-40b0-9535-b2f1a740eb8f", "f22e0740-17f5-43eb-ac9d-d597bfe9b1ef" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 19, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8548), new DateTime(2024, 5, 24, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8568) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 26, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8571), new DateTime(2024, 5, 28, 2, 1, 46, 149, DateTimeKind.Local).AddTicks(8572) });
        }
    }
}
