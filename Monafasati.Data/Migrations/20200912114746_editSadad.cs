using Microsoft.EntityFrameworkCore.Migrations;

namespace Monafasati.Data.Migrations
{
    public partial class editSadad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Sadad",
                table: "Monafsas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sadad",
                table: "Monafsas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
