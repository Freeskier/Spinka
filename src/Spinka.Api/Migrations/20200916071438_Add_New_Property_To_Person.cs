using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_New_Property_To_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "Persons",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 643, DateTimeKind.Local).AddTicks(6449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 305, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 635, DateTimeKind.Local).AddTicks(2552),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 298, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 634, DateTimeKind.Local).AddTicks(9463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 297, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 630, DateTimeKind.Local).AddTicks(2955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 293, DateTimeKind.Local).AddTicks(3548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 615, DateTimeKind.Local).AddTicks(370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 279, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 594, DateTimeKind.Local).AddTicks(3296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 262, DateTimeKind.Local).AddTicks(9362));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Father",
                table: "Persons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 305, DateTimeKind.Local).AddTicks(6820),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 643, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 298, DateTimeKind.Local).AddTicks(1712),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 635, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 297, DateTimeKind.Local).AddTicks(8502),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 634, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 293, DateTimeKind.Local).AddTicks(3548),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 630, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 279, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 615, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 262, DateTimeKind.Local).AddTicks(9362),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 594, DateTimeKind.Local).AddTicks(3296));
        }
    }
}
