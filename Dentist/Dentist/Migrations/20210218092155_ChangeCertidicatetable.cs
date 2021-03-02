using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentist.Migrations
{
    public partial class ChangeCertidicatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Certificates");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
