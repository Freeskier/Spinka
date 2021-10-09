using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class New_Field_Edu_Block_Additional_Info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 468, DateTimeKind.Local).AddTicks(3027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 453, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "EduBlocks",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 471, DateTimeKind.Local).AddTicks(8439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 457, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 460, DateTimeKind.Local).AddTicks(2110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 445, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 459, DateTimeKind.Local).AddTicks(9194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 444, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 453, DateTimeKind.Local).AddTicks(7125),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 438, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 437, DateTimeKind.Local).AddTicks(7876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 421, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 418, DateTimeKind.Local).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 402, DateTimeKind.Local).AddTicks(7269));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 453, DateTimeKind.Local).AddTicks(3837),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 468, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 457, DateTimeKind.Local).AddTicks(595),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 471, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 445, DateTimeKind.Local).AddTicks(1439),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 460, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 444, DateTimeKind.Local).AddTicks(8359),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 459, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 438, DateTimeKind.Local).AddTicks(4579),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 453, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 421, DateTimeKind.Local).AddTicks(5712),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 437, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 402, DateTimeKind.Local).AddTicks(7269),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 418, DateTimeKind.Local).AddTicks(7837));
        }
    }
}
