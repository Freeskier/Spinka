using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_Relation_MajorEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 159, DateTimeKind.Local).AddTicks(4526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 175, DateTimeKind.Local).AddTicks(8884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 118, DateTimeKind.Local).AddTicks(6208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 117, DateTimeKind.Local).AddTicks(3680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 88, DateTimeKind.Local).AddTicks(1829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 996, DateTimeKind.Local).AddTicks(6844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 907, DateTimeKind.Local).AddTicks(1133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.CreateIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvent",
                column: "UnitDepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 159, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 175, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 118, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 117, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 88, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 996, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 907, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.CreateIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvent",
                column: "UnitDepartmentId",
                unique: true);
        }
    }
}
