using Microsoft.EntityFrameworkCore.Migrations;

namespace Badgetwork.Infrastructure.Migrations
{
    public partial class Adddecimalrequires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                schema: "Badgets",
                table: "BadgetItem",
                type: "decimal (18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "Badgets",
                table: "BadgetItem",
                type: "decimal (18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Subtotal",
                schema: "Badgets",
                table: "BadgetItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "Badgets",
                table: "BadgetItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,4)");
        }
    }
}
