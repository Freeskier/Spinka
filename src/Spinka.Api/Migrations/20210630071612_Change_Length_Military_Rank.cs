using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Change_Length_Military_Rank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AcrRankPl",
                table: "MilitaryRanks",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcrRankEn",
                table: "MilitaryRanks",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 453, DateTimeKind.Local).AddTicks(3837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 922, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 457, DateTimeKind.Local).AddTicks(595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 925, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 445, DateTimeKind.Local).AddTicks(1439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 444, DateTimeKind.Local).AddTicks(8359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 438, DateTimeKind.Local).AddTicks(4579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 907, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 421, DateTimeKind.Local).AddTicks(5712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 891, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 402, DateTimeKind.Local).AddTicks(7269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 872, DateTimeKind.Local).AddTicks(4449));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AcrRankPl",
                table: "MilitaryRanks",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcrRankEn",
                table: "MilitaryRanks",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 922, DateTimeKind.Local).AddTicks(3856),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 453, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 925, DateTimeKind.Local).AddTicks(9771),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 457, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(3426),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 445, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(705),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 444, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 907, DateTimeKind.Local).AddTicks(7912),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 438, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 891, DateTimeKind.Local).AddTicks(3692),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 421, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 872, DateTimeKind.Local).AddTicks(4449),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 30, 9, 16, 12, 402, DateTimeKind.Local).AddTicks(7269));
        }
    }
}
