using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Change_Length_Name_Authorization_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 650, DateTimeKind.Local).AddTicks(8126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 756, DateTimeKind.Local).AddTicks(6004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 641, DateTimeKind.Local).AddTicks(7340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 739, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 636, DateTimeKind.Local).AddTicks(9575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 730, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthorizationsTypes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 622, DateTimeKind.Local).AddTicks(9432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 707, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 605, DateTimeKind.Local).AddTicks(2436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 682, DateTimeKind.Local).AddTicks(6215));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 756, DateTimeKind.Local).AddTicks(6004),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 650, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 739, DateTimeKind.Local).AddTicks(5300),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 641, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 730, DateTimeKind.Local).AddTicks(2173),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 636, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthorizationsTypes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 707, DateTimeKind.Local).AddTicks(6544),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 622, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 20, 27, 50, 682, DateTimeKind.Local).AddTicks(6215),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 1, 10, 58, 10, 605, DateTimeKind.Local).AddTicks(2436));
        }
    }
}
