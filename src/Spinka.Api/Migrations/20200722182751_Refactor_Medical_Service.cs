using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Refactor_Medical_Service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParamedicPersonId",
                table: "MedicalServiceForEduBlocks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorPersonId",
                table: "MedicalServiceForEduBlocks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 756, DateTimeKind.Local).AddTicks(6004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 874, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 739, DateTimeKind.Local).AddTicks(5300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 866, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 730, DateTimeKind.Local).AddTicks(2173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 862, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 707, DateTimeKind.Local).AddTicks(6544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 850, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 682, DateTimeKind.Local).AddTicks(6215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 838, DateTimeKind.Local).AddTicks(5959));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParamedicPersonId",
                table: "MedicalServiceForEduBlocks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorPersonId",
                table: "MedicalServiceForEduBlocks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 874, DateTimeKind.Local).AddTicks(7007),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 756, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 866, DateTimeKind.Local).AddTicks(5744),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 739, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 862, DateTimeKind.Local).AddTicks(2321),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 730, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 850, DateTimeKind.Local).AddTicks(9395),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 707, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 838, DateTimeKind.Local).AddTicks(5959),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 682, DateTimeKind.Local).AddTicks(6215));
        }
    }
}
