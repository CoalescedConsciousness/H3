using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDFirst.Migrations
{
    /// <inheritdoc />
    public partial class _111111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Radiation",
                table: "WeatherModel");

            migrationBuilder.RenameColumn(
                name: "WindSpeedThreeMinute",
                table: "WeatherModel",
                newName: "WindMean");

            migrationBuilder.RenameColumn(
                name: "WindSpeedTenMinute",
                table: "WeatherModel",
                newName: "WindMax3");

            migrationBuilder.RenameColumn(
                name: "WindSpeedDirection",
                table: "WeatherModel",
                newName: "WindMax10");

            migrationBuilder.RenameColumn(
                name: "Sunshine",
                table: "WeatherModel",
                newName: "WindDir");

            //migrationBuilder.AddColumn<bool>(
            //    name: "UsingTimer",
            //    table: "IngestModel",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsingTimer",
                table: "IngestModel");

            migrationBuilder.RenameColumn(
                name: "WindMean",
                table: "WeatherModel",
                newName: "WindSpeedThreeMinute");

            migrationBuilder.RenameColumn(
                name: "WindMax3",
                table: "WeatherModel",
                newName: "WindSpeedTenMinute");

            migrationBuilder.RenameColumn(
                name: "WindMax10",
                table: "WeatherModel",
                newName: "WindSpeedDirection");

            migrationBuilder.RenameColumn(
                name: "WindDir",
                table: "WeatherModel",
                newName: "Sunshine");

            migrationBuilder.AddColumn<string>(
                name: "Radiation",
                table: "WeatherModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
