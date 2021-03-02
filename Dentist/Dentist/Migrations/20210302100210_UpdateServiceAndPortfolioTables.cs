using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentist.Migrations
{
    public partial class UpdateServiceAndPortfolioTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_TreatmentId",
                table: "Portfolios",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Treatments_TreatmentId",
                table: "Portfolios",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Treatments_TreatmentId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_TreatmentId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Portfolios");

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }
    }
}
