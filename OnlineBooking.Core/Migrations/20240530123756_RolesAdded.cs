using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "676d3177-345c-4836-bf00-367058c25049", "5210dcae-e754-4237-997b-36252715e235" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4b1bee3-e31b-4b3e-9e5a-3906da6edda1", "06c0921f-2ca2-4602-bd07-35783fe80fe7" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 20, 16, 37, 54, 641, DateTimeKind.Local).AddTicks(5578), new DateTime(2024, 5, 25, 16, 37, 54, 641, DateTimeKind.Local).AddTicks(5599) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 27, 16, 37, 54, 641, DateTimeKind.Local).AddTicks(5601), new DateTime(2024, 5, 29, 16, 37, 54, 641, DateTimeKind.Local).AddTicks(5602) });
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
