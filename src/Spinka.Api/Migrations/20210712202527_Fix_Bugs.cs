using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_Bugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 490, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 494, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 482, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 481, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 475, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 459, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 441, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.CreateTable(
                name: "DayRepNumbersForGroupInnerDashBoardProcedure",
                columns: table => new
                {
                    DayRepValueName = table.Column<string>(nullable: true),
                    DayRepValueFull = table.Column<string>(nullable: true),
                    DayRepValueLocation = table.Column<string>(nullable: true),
                    DayRepValueDescription = table.Column<string>(nullable: true),
                    MilitaryRankPl = table.Column<string>(nullable: true),
                    PersonName = table.Column<string>(nullable: true),
                    PersonOpNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRepNumbersForGroupInnerDashBoardProcedure");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 490, DateTimeKind.Local).AddTicks(9132),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 494, DateTimeKind.Local).AddTicks(4758),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 482, DateTimeKind.Local).AddTicks(884),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 481, DateTimeKind.Local).AddTicks(8111),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 475, DateTimeKind.Local).AddTicks(6201),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 459, DateTimeKind.Local).AddTicks(7123),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 10, 11, 53, 51, 441, DateTimeKind.Local).AddTicks(536),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733));
        }
    }
}
