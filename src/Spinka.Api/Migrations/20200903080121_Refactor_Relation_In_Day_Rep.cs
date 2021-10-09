using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Refactor_Relation_In_Day_Rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps");

            migrationBuilder.DropIndex(
                name: "IX_DayReps_PersonId",
                table: "DayReps");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DayReps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 117, DateTimeKind.Local).AddTicks(4406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 468, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(7724),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(4044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.AddColumn<int>(
                name: "DayRepGroupPersonId",
                table: "DayReps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 100, DateTimeKind.Local).AddTicks(9444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 455, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 79, DateTimeKind.Local).AddTicks(7584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 445, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 61, DateTimeKind.Local).AddTicks(2193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 432, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.CreateIndex(
                name: "IX_DayReps_DayRepGroupPersonId",
                table: "DayReps",
                column: "DayRepGroupPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayReps_DayRepGroupPersons_DayRepGroupPersonId",
                table: "DayReps",
                column: "DayRepGroupPersonId",
                principalTable: "DayRepGroupPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayReps_DayRepGroupPersons_DayRepGroupPersonId",
                table: "DayReps");

            migrationBuilder.DropIndex(
                name: "IX_DayReps_DayRepGroupPersonId",
                table: "DayReps");

            migrationBuilder.DropColumn(
                name: "DayRepGroupPersonId",
                table: "DayReps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 468, DateTimeKind.Local).AddTicks(165),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 117, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(4724),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(2079),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 106, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "DayReps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 455, DateTimeKind.Local).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 100, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 445, DateTimeKind.Local).AddTicks(834),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 79, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 432, DateTimeKind.Local).AddTicks(9897),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 3, 10, 1, 21, 61, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.CreateIndex(
                name: "IX_DayReps_PersonId",
                table: "DayReps",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
