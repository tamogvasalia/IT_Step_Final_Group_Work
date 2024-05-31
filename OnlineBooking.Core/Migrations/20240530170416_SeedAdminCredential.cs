using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "856818fa-8a02-481e-9be7-bd342e474e22", "e3b96fd6-cf9c-4729-b73b-bf80fe94d2ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa3cb2dc-ee43-4eb9-a364-082c3d5a87d0", "d52cdbde-f77a-4cd9-95ff-7eeb4e7c0c54" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 4, 13, 696, DateTimeKind.Local).AddTicks(2348), new DateTime(2024, 5, 25, 21, 4, 13, 696, DateTimeKind.Local).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "checkInTime", "checkOutTime" },
                values: new object[] { new DateTime(2024, 5, 27, 21, 4, 13, 696, DateTimeKind.Local).AddTicks(2374), new DateTime(2024, 5, 29, 21, 4, 13, 696, DateTimeKind.Local).AddTicks(2375) });

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
