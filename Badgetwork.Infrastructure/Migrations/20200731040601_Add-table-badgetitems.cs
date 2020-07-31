using Microsoft.EntityFrameworkCore.Migrations;

namespace Badgetwork.Infrastructure.Migrations
{
    public partial class Addtablebadgetitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Badgets",
                table: "Badget",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BadgetName",
                schema: "Badgets",
                table: "Badget",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                schema: "Badgets",
                table: "Badget",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "Badgets",
                table: "Badget",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeDocument",
                schema: "Badgets",
                table: "Badget",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BadgetItem",
                schema: "Badgets",
                columns: table => new
                {
                    BadgetItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgetId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgetItem", x => x.BadgetItemId);
                    table.ForeignKey(
                        name: "FK_BadgetItem_Badget_BadgetId",
                        column: x => x.BadgetId,
                        principalSchema: "Badgets",
                        principalTable: "Badget",
                        principalColumn: "BadgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BadgetItem_BadgetId",
                schema: "Badgets",
                table: "BadgetItem",
                column: "BadgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadgetItem",
                schema: "Badgets");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.DropColumn(
                name: "BadgetName",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                schema: "Badgets",
                table: "Badget");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Badgets",
                table: "Badget",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
