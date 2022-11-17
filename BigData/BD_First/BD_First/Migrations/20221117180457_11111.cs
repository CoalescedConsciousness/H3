using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDFirst.Migrations
{
    /// <inheritdoc />
    public partial class _11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UsingTimer",
                table: "IngestModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsingTimer",
                table: "IngestModel");
        }
    }
}
