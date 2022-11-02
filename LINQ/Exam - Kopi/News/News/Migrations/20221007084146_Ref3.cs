using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations
{
    public partial class Ref3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_Guid_GuidId",
                table: "NewsItems");

            migrationBuilder.DropTable(
                name: "Guid");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_GuidId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "GuidId",
                table: "NewsItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuidId",
                table: "NewsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guid",
                columns: table => new
                {
                    GuidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPermaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guid", x => x.GuidId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_GuidId",
                table: "NewsItems",
                column: "GuidId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_Guid_GuidId",
                table: "NewsItems",
                column: "GuidId",
                principalTable: "Guid",
                principalColumn: "GuidId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
