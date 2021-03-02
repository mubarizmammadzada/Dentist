using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentist.Migrations
{
    public partial class CreatePriceAndPriceDetailsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceDetaillName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    PriceDetailCost = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceDetails_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceDetails_PriceId",
                table: "PriceDetails",
                column: "PriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceDetails");

            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}
