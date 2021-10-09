using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_All_Bugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 922, DateTimeKind.Local).AddTicks(3856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.AddColumn<int>(
                name: "SecurityPersonId",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 925, DateTimeKind.Local).AddTicks(9771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 630, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(3426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 907, DateTimeKind.Local).AddTicks(7912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 891, DateTimeKind.Local).AddTicks(3692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 872, DateTimeKind.Local).AddTicks(4449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 348, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons",
                column: "MilitaryRankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SecurityPersonId",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 922, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 630, DateTimeKind.Local).AddTicks(6199),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 925, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 914, DateTimeKind.Local).AddTicks(705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 907, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 891, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 348, DateTimeKind.Local).AddTicks(3826),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 6, 29, 18, 31, 10, 872, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons",
                column: "MilitaryRankId",
                unique: true,
                filter: "[MilitaryRankId] IS NOT NULL");
        }
    }
}
