using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_New_Prop_In_Day_Reps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 468, DateTimeKind.Local).AddTicks(165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 650, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "DayReps",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(2079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 641, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "DayReps",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 455, DateTimeKind.Local).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 636, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 445, DateTimeKind.Local).AddTicks(834),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 622, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 432, DateTimeKind.Local).AddTicks(9897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 605, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.AddForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "DayReps");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "DayReps");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 650, DateTimeKind.Local).AddTicks(8126),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 468, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "DayReps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 641, DateTimeKind.Local).AddTicks(7340),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 460, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 636, DateTimeKind.Local).AddTicks(9575),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 455, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 622, DateTimeKind.Local).AddTicks(9432),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 445, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 605, DateTimeKind.Local).AddTicks(2436),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 2, 13, 46, 1, 432, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.AddForeignKey(
                name: "FK_DayReps_Persons_PersonId",
                table: "DayReps",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
