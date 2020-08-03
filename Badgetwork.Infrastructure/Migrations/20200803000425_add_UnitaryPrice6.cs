using Microsoft.EntityFrameworkCore.Migrations;

namespace Badgetwork.Infrastructure.Migrations
{
    public partial class add_UnitaryPrice6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Aup");

            migrationBuilder.CreateTable(
                name: "UnitaryPrice",
                schema: "Aup",
                columns: table => new
                {
                    UnitaryPriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chapter = table.Column<string>(maxLength: 500, nullable: true),
                    Item = table.Column<string>(maxLength: 500, nullable: true),
                    Measure = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitaryPrice", x => x.UnitaryPriceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitaryPrice",
                schema: "Aup");
        }
    }
}
