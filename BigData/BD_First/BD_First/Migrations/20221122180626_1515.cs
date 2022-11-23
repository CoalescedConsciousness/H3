using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDFirst.Migrations
{
    /// <inheritdoc />
    public partial class _1515 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longtitude",
                table: "WeatherModel",
                newName: "Longitude");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "WeatherModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "WeatherModel");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "WeatherModel",
                newName: "Longtitude");
        }
    }
}
