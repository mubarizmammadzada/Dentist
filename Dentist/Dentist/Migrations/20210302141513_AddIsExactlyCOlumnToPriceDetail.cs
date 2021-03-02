using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentist.Migrations
{
    public partial class AddIsExactlyCOlumnToPriceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "İsExactly",
                table: "PriceDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "İsExactly",
                table: "PriceDetails");
        }
    }
}
