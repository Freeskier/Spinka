using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_Table_Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduBlocks_MajorEvent_MajorEventId",
                table: "EduBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorEvent_EventType_EventTypeId",
                table: "MajorEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorEvent_UnitDepartments_UnitDepartmentId",
                table: "MajorEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MajorEvent",
                table: "MajorEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventType",
                table: "EventType");

            migrationBuilder.RenameTable(
                name: "MajorEvent",
                newName: "MajorEvents");

            migrationBuilder.RenameTable(
                name: "EventType",
                newName: "EventTypes");

            migrationBuilder.RenameIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvents",
                newName: "IX_MajorEvents_UnitDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MajorEvent_EventTypeId",
                table: "MajorEvents",
                newName: "IX_MajorEvents_EventTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 140, DateTimeKind.Local).AddTicks(813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 159, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 156, DateTimeKind.Local).AddTicks(7657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 175, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 98, DateTimeKind.Local).AddTicks(9488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 118, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 97, DateTimeKind.Local).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 117, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 69, DateTimeKind.Local).AddTicks(3984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 88, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 996, DateTimeKind.Local).AddTicks(8900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 996, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 904, DateTimeKind.Local).AddTicks(5859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 907, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MajorEvents",
                table: "MajorEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EduBlocks_MajorEvents_MajorEventId",
                table: "EduBlocks",
                column: "MajorEventId",
                principalTable: "MajorEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorEvents_EventTypes_EventTypeId",
                table: "MajorEvents",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorEvents_UnitDepartments_UnitDepartmentId",
                table: "MajorEvents",
                column: "UnitDepartmentId",
                principalTable: "UnitDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduBlocks_MajorEvents_MajorEventId",
                table: "EduBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorEvents_EventTypes_EventTypeId",
                table: "MajorEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_MajorEvents_UnitDepartments_UnitDepartmentId",
                table: "MajorEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MajorEvents",
                table: "MajorEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventTypes",
                table: "EventTypes");

            migrationBuilder.RenameTable(
                name: "MajorEvents",
                newName: "MajorEvent");

            migrationBuilder.RenameTable(
                name: "EventTypes",
                newName: "EventType");

            migrationBuilder.RenameIndex(
                name: "IX_MajorEvents_UnitDepartmentId",
                table: "MajorEvent",
                newName: "IX_MajorEvent_UnitDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MajorEvents_EventTypeId",
                table: "MajorEvent",
                newName: "IX_MajorEvent_EventTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 159, DateTimeKind.Local).AddTicks(4526),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 140, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 175, DateTimeKind.Local).AddTicks(8884),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 156, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 118, DateTimeKind.Local).AddTicks(6208),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 98, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 117, DateTimeKind.Local).AddTicks(3680),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 97, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 20, 88, DateTimeKind.Local).AddTicks(1829),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 69, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 996, DateTimeKind.Local).AddTicks(6844),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 996, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 47, 19, 907, DateTimeKind.Local).AddTicks(1133),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 904, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MajorEvent",
                table: "MajorEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventType",
                table: "EventType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EduBlocks_MajorEvent_MajorEventId",
                table: "EduBlocks",
                column: "MajorEventId",
                principalTable: "MajorEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorEvent_EventType_EventTypeId",
                table: "MajorEvent",
                column: "EventTypeId",
                principalTable: "EventType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MajorEvent_UnitDepartments_UnitDepartmentId",
                table: "MajorEvent",
                column: "UnitDepartmentId",
                principalTable: "UnitDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
