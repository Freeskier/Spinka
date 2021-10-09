using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Relation_Between_Group_For_Day_Reps_And_Departments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitDepartmentsId",
                table: "GroupForDayReps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 755, DateTimeKind.Local).AddTicks(8316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 117, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 748, DateTimeKind.Local).AddTicks(795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 747, DateTimeKind.Local).AddTicks(8111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 743, DateTimeKind.Local).AddTicks(4650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 100, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 732, DateTimeKind.Local).AddTicks(3710),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 79, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 720, DateTimeKind.Local).AddTicks(830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 61, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.CreateIndex(
                name: "IX_GroupForDayReps_UnitDepartmentsId",
                table: "GroupForDayReps",
                column: "UnitDepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupForDayReps_UnitDepartments_UnitDepartmentsId",
                table: "GroupForDayReps",
                column: "UnitDepartmentsId",
                principalTable: "UnitDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupForDayReps_UnitDepartments_UnitDepartmentsId",
                table: "GroupForDayReps");

            migrationBuilder.DropIndex(
                name: "IX_GroupForDayReps_UnitDepartmentsId",
                table: "GroupForDayReps");

            migrationBuilder.DropColumn(
                name: "UnitDepartmentsId",
                table: "GroupForDayReps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 117, DateTimeKind.Local).AddTicks(4406),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 755, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(7724),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 748, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(4044),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 747, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 100, DateTimeKind.Local).AddTicks(9444),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 743, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 79, DateTimeKind.Local).AddTicks(7584),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 732, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 61, DateTimeKind.Local).AddTicks(2193),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 720, DateTimeKind.Local).AddTicks(830));
        }
    }
}
