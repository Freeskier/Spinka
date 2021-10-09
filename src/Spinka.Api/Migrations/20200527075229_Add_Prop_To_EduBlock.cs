using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Prop_To_EduBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EduBlockSubjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 214, DateTimeKind.Local).AddTicks(2513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 917, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.AddColumn<string>(
                name: "CancellingRemarks",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainingFacility",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 211, DateTimeKind.Local).AddTicks(6129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 914, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 207, DateTimeKind.Local).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 910, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 198, DateTimeKind.Local).AddTicks(8756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 900, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 186, DateTimeKind.Local).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 888, DateTimeKind.Local).AddTicks(5555));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellingRemarks",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "TrainingFacility",
                table: "EduBlocks");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EduBlockSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 917, DateTimeKind.Local).AddTicks(8827),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 214, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 914, DateTimeKind.Local).AddTicks(7048),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 211, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 910, DateTimeKind.Local).AddTicks(1029),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 207, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 900, DateTimeKind.Local).AddTicks(7340),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 198, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 888, DateTimeKind.Local).AddTicks(5555),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 186, DateTimeKind.Local).AddTicks(5685));
        }
    }
}
