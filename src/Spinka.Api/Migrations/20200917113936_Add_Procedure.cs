using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 970, DateTimeKind.Local).AddTicks(108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 961, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 959, DateTimeKind.Local).AddTicks(1855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 958, DateTimeKind.Local).AddTicks(9296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 952, DateTimeKind.Local).AddTicks(6878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 949, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 932, DateTimeKind.Local).AddTicks(2111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 935, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 897, DateTimeKind.Local).AddTicks(8980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 917, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.CreateTable(
                name: "DayRepCalendarForGroupProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonInGroupId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Day1 = table.Column<int>(nullable: true),
                    Day2 = table.Column<int>(nullable: true),
                    Day3 = table.Column<int>(nullable: true),
                    Day4 = table.Column<int>(nullable: true),
                    Day5 = table.Column<int>(nullable: true),
                    Day6 = table.Column<int>(nullable: true),
                    Day7 = table.Column<int>(nullable: true),
                    Day8 = table.Column<int>(nullable: true),
                    Day9 = table.Column<int>(nullable: true),
                    Day10 = table.Column<int>(nullable: true),
                    Day11 = table.Column<int>(nullable: true),
                    Day12 = table.Column<int>(nullable: true),
                    Day13 = table.Column<int>(nullable: true),
                    Day14 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRepCalendarForGroupProcedures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRepCalendarForGroupProcedures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 961, DateTimeKind.Local).AddTicks(2282),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 970, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(7033),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 959, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 958, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 949, DateTimeKind.Local).AddTicks(303),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 952, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 935, DateTimeKind.Local).AddTicks(8498),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 932, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 917, DateTimeKind.Local).AddTicks(616),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 897, DateTimeKind.Local).AddTicks(8980));
        }
    }
}
