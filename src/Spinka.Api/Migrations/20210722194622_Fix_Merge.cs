using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_Merge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 575, DateTimeKind.Local).AddTicks(7726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 181, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "EduBlockControls",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 579, DateTimeKind.Local).AddTicks(4434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 190, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.AlterColumn<string>(
                name: "AdminLogin",
                table: "EduBlockControls",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReason",
                table: "EduBlockControls",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(7106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(4498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 560, DateTimeKind.Local).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 159, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 541, DateTimeKind.Local).AddTicks(4191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 142, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 521, DateTimeKind.Local).AddTicks(8495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 122, DateTimeKind.Local).AddTicks(5113));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 181, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 575, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "EduBlockControls",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 190, DateTimeKind.Local).AddTicks(2069),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 579, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.AlterColumn<string>(
                name: "AdminLogin",
                table: "EduBlockControls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReason",
                table: "EduBlockControls",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(3720),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(7106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(1691),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 566, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 159, DateTimeKind.Local).AddTicks(8433),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 560, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 142, DateTimeKind.Local).AddTicks(4068),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 541, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 122, DateTimeKind.Local).AddTicks(5113),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 22, 21, 46, 22, 521, DateTimeKind.Local).AddTicks(8495));
        }
    }
}
