using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDFirst.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngestModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Station = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunshine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Radiation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindSpeedThreeMinute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindSpeedTenMinute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindSpeedDirection = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngestModel");

            migrationBuilder.DropTable(
                name: "WeatherModel");
        }
    }
}
