using Microsoft.EntityFrameworkCore.Migrations;

namespace Monafasati.Data.Migrations
{
    public partial class addPdfField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Monafsas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Monafsas");
        }
    }
}
