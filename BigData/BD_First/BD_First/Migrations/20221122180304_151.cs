using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDFirst.Migrations
{
    /// <inheritdoc />
    public partial class _151 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Station",
                table: "WeatherModel");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "WeatherModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longtitude",
                table: "WeatherModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "WeatherModel");

            migrationBuilder.DropColumn(
                name: "Longtitude",
                table: "WeatherModel");

            migrationBuilder.AddColumn<string>(
                name: "Station",
                table: "WeatherModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
