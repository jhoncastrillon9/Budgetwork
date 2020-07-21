using Microsoft.EntityFrameworkCore.Migrations;

namespace Badgetwork.Infrastructure.Migrations
{
    public partial class AddField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                schema: "Badgets",
                table: "Badget",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                schema: "Badgets",
                table: "Badget");
        }
    }
}
