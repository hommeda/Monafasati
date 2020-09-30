using Microsoft.EntityFrameworkCore.Migrations;

namespace Monafasati.Data.Migrations
{
    public partial class addNotesToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Items");
        }
    }
}
