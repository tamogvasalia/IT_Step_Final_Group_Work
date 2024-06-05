﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBooking.Core.Migrations
{
    /// <inheritdoc />
    public partial class userPropertyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalBudget",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBudget",
                table: "AspNetUsers");
        }
    }
}
