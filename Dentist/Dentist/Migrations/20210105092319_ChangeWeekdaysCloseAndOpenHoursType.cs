using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dentist.Migrations
{
    public partial class ChangeWeekdaysCloseAndOpenHoursType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SundayCloseHour",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "SundayOpenHour",
                table: "Bios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WeekdayCloseHour",
                table: "Bios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WeekDaysOpenHour",
                table: "Bios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WeekdayCloseHour",
                table: "Bios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WeekDaysOpenHour",
                table: "Bios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SundayCloseHour",
                table: "Bios",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SundayOpenHour",
                table: "Bios",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
