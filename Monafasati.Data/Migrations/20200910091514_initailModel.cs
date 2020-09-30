using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monafasati.Data.Migrations
{
    public partial class initailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engineers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engineers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monafsas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Advertiser = table.Column<string>(nullable: true),
                    LastDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    StatuId = table.Column<int>(nullable: false),
                    EngineerId = table.Column<int>(nullable: false),
                    Sadad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monafsas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monafsas_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monafsas_Status_StatuId",
                        column: x => x.StatuId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monafsas_EngineerId",
                table: "Monafsas",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monafsas_StatuId",
                table: "Monafsas",
                column: "StatuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monafsas");

            migrationBuilder.DropTable(
                name: "Engineers");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
