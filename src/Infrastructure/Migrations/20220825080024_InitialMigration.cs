using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotteryDraw.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrawHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    SecondNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    ThirdNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    FourthNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    FifthNumber = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawHistory");
        }
    }
}
