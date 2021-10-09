using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class DayRepGroupPerson_IsDelegated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 723, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 715, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 714, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelegated",
                table: "DayRepGroupPersons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 707, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 690, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 575, DateTimeKind.Local).AddTicks(1869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 660, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.CreateTable(
                name: "DayRepCalendarForGroupProcedureText",
                columns: table => new
                {
                    PersonInGroupId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Day1 = table.Column<string>(nullable: true),
                    Day2 = table.Column<string>(nullable: true),
                    Day3 = table.Column<string>(nullable: true),
                    Day4 = table.Column<string>(nullable: true),
                    Day5 = table.Column<string>(nullable: true),
                    Day6 = table.Column<string>(nullable: true),
                    Day7 = table.Column<string>(nullable: true),
                    Day8 = table.Column<string>(nullable: true),
                    Day9 = table.Column<string>(nullable: true),
                    Day10 = table.Column<string>(nullable: true),
                    Day11 = table.Column<string>(nullable: true),
                    Day12 = table.Column<string>(nullable: true),
                    Day13 = table.Column<string>(nullable: true),
                    Day14 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRepCalendarForGroupProcedureText");

            migrationBuilder.DropColumn(
                name: "IsDelegated",
                table: "DayRepGroupPersons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 723, DateTimeKind.Local).AddTicks(3381),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 715, DateTimeKind.Local).AddTicks(1503),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 714, DateTimeKind.Local).AddTicks(9597),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 707, DateTimeKind.Local).AddTicks(2625),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 690, DateTimeKind.Local).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 660, DateTimeKind.Local).AddTicks(1549),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 575, DateTimeKind.Local).AddTicks(1869));
        }
    }
}
