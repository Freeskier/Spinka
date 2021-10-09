using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Procedure_Fix_Bug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DayRepCalendarForGroupProcedures",
                table: "DayRepCalendarForGroupProcedures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DayRepCalendarForGroupProcedures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DayRepCalendarForGroupProcedures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 723, DateTimeKind.Local).AddTicks(3381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 970, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 715, DateTimeKind.Local).AddTicks(1503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 959, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 714, DateTimeKind.Local).AddTicks(9597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 958, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 707, DateTimeKind.Local).AddTicks(2625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 952, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 690, DateTimeKind.Local).AddTicks(3613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 932, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 660, DateTimeKind.Local).AddTicks(1549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 897, DateTimeKind.Local).AddTicks(8980));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 970, DateTimeKind.Local).AddTicks(108),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 723, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 959, DateTimeKind.Local).AddTicks(1855),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 715, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 958, DateTimeKind.Local).AddTicks(9296),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 714, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DayRepCalendarForGroupProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DayRepCalendarForGroupProcedures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 952, DateTimeKind.Local).AddTicks(6878),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 707, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 932, DateTimeKind.Local).AddTicks(2111),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 690, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 17, 13, 39, 35, 897, DateTimeKind.Local).AddTicks(8980),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 18, 10, 54, 27, 660, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayRepCalendarForGroupProcedures",
                table: "DayRepCalendarForGroupProcedures",
                column: "Id");
        }
    }
}
