using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Badgetwork.Infrastructure.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Badgets");

            migrationBuilder.CreateTable(
                name: "Badget",
                schema: "Badgets",
                columns: table => new
                {
                    BadgetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badget", x => x.BadgetId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badget",
                schema: "Badgets");
        }
    }
}
