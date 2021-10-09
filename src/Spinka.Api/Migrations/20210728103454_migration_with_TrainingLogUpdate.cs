using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class migration_with_TrainingLogUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingAreas",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "TrainingAcronym",
                table: "TrainingAreas",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCountedIn",
                table: "EduBlockSubjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfRequirement",
                table: "EduBlockSubjects",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 277, DateTimeKind.Local).AddTicks(2258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 355, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 284, DateTimeKind.Local).AddTicks(2204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 362, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 279, DateTimeKind.Local).AddTicks(8503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 358, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.AlterColumn<bool>(
                name: "Attended",
                table: "EduBlockControls",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(6438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(4852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 264, DateTimeKind.Local).AddTicks(2773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 334, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 250, DateTimeKind.Local).AddTicks(308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 317, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 235, DateTimeKind.Local).AddTicks(5275),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 299, DateTimeKind.Local).AddTicks(8556));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingAcronym",
                table: "TrainingAreas");

            migrationBuilder.DropColumn(
                name: "IsCountedIn",
                table: "EduBlockSubjects");

            migrationBuilder.DropColumn(
                name: "TypeOfRequirement",
                table: "EduBlockSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingAreas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 355, DateTimeKind.Local).AddTicks(1278),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 277, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 362, DateTimeKind.Local).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 284, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 358, DateTimeKind.Local).AddTicks(2896),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 279, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.AlterColumn<bool>(
                name: "Attended",
                table: "EduBlockControls",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(4639),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 269, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 334, DateTimeKind.Local).AddTicks(8612),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 264, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 317, DateTimeKind.Local).AddTicks(5186),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 250, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 299, DateTimeKind.Local).AddTicks(8556),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 34, 54, 235, DateTimeKind.Local).AddTicks(5275));
        }
    }
}
