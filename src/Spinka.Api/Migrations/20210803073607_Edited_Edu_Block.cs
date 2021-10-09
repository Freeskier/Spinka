using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Edited_Edu_Block : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 539, DateTimeKind.Local).AddTicks(8185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 277, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.AddColumn<string>(
                name: "CancellReason",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "EduBlocks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 545, DateTimeKind.Local).AddTicks(6176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 284, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 541, DateTimeKind.Local).AddTicks(6305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 279, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(4446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 530, DateTimeKind.Local).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 264, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 519, DateTimeKind.Local).AddTicks(9587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 250, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 507, DateTimeKind.Local).AddTicks(9530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 235, DateTimeKind.Local).AddTicks(5275));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellReason",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 277, DateTimeKind.Local).AddTicks(2258),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 539, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 284, DateTimeKind.Local).AddTicks(2204),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 545, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 279, DateTimeKind.Local).AddTicks(8503),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 541, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(6438),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(4852),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 264, DateTimeKind.Local).AddTicks(2773),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 530, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 250, DateTimeKind.Local).AddTicks(308),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 519, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 235, DateTimeKind.Local).AddTicks(5275),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 507, DateTimeKind.Local).AddTicks(9530));
        }
    }
}
