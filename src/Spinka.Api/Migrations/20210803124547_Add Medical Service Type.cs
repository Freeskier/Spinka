using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class AddMedicalServiceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicalServiceType",
                table: "MedicalServiceForEduBlocks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 727, DateTimeKind.Local).AddTicks(6259),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 539, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 739, DateTimeKind.Local).AddTicks(3632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 545, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 731, DateTimeKind.Local).AddTicks(9388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 541, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 713, DateTimeKind.Local).AddTicks(3309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 713, DateTimeKind.Local).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 703, DateTimeKind.Local).AddTicks(2663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 530, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 678, DateTimeKind.Local).AddTicks(1980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 519, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 659, DateTimeKind.Local).AddTicks(3327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 507, DateTimeKind.Local).AddTicks(9530));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalServiceType",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 539, DateTimeKind.Local).AddTicks(8185),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 727, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlockHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 545, DateTimeKind.Local).AddTicks(6176),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 739, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 541, DateTimeKind.Local).AddTicks(6305),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 731, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(4446),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 713, DateTimeKind.Local).AddTicks(3309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 534, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 713, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 530, DateTimeKind.Local).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 703, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 519, DateTimeKind.Local).AddTicks(9587),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 678, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 9, 36, 7, 507, DateTimeKind.Local).AddTicks(9530),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 3, 14, 45, 46, 659, DateTimeKind.Local).AddTicks(3327));
        }
    }
}
