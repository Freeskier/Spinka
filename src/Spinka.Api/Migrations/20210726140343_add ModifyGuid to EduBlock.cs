using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class addModifyGuidtoEduBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 615, DateTimeKind.Local).AddTicks(8403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 575, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifyGuid",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 618, DateTimeKind.Local).AddTicks(3544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 579, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(1434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(49),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 601, DateTimeKind.Local).AddTicks(4774),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 560, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 586, DateTimeKind.Local).AddTicks(1534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 541, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 571, DateTimeKind.Local).AddTicks(1859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 521, DateTimeKind.Local).AddTicks(8495));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyGuid",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 575, DateTimeKind.Local).AddTicks(7726),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 615, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 579, DateTimeKind.Local).AddTicks(4434),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 618, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(7106),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(4498),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 560, DateTimeKind.Local).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 601, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 541, DateTimeKind.Local).AddTicks(4191),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 586, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 521, DateTimeKind.Local).AddTicks(8495),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 571, DateTimeKind.Local).AddTicks(1859));
        }
    }
}
