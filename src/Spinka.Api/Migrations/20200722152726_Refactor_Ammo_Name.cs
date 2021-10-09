using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Refactor_Ammo_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ammos_AmmoTypes_AmmoTypeId",
                table: "Ammos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ammos_MeasureUnits_MeasureUnitId",
                table: "Ammos");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedAmmos_Ammos_AmmoId",
                table: "AssignedAmmos");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedAmmos_EduBlocks_EduBlockId",
                table: "AssignedAmmos");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAmmoLimitsForDepartments_Ammos_AmmoId",
                table: "CurrentAmmoLimitsForDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedAmmos",
                table: "AssignedAmmos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ammos",
                table: "Ammos");

            migrationBuilder.RenameTable(
                name: "AssignedAmmos",
                newName: "AssignedAmmo");

            migrationBuilder.RenameTable(
                name: "Ammos",
                newName: "Ammo");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedAmmos_EduBlockId",
                table: "AssignedAmmo",
                newName: "IX_AssignedAmmo_EduBlockId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedAmmos_AmmoId",
                table: "AssignedAmmo",
                newName: "IX_AssignedAmmo_AmmoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ammos_MeasureUnitId",
                table: "Ammo",
                newName: "IX_Ammo_MeasureUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ammos_AmmoTypeId",
                table: "Ammo",
                newName: "IX_Ammo_AmmoTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 874, DateTimeKind.Local).AddTicks(7007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 42, 5, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 866, DateTimeKind.Local).AddTicks(5744),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 997, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 862, DateTimeKind.Local).AddTicks(2321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 993, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 850, DateTimeKind.Local).AddTicks(9395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 982, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 838, DateTimeKind.Local).AddTicks(5959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 970, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedAmmo",
                table: "AssignedAmmo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ammo",
                table: "Ammo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ammo_AmmoTypes_AmmoTypeId",
                table: "Ammo",
                column: "AmmoTypeId",
                principalTable: "AmmoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ammo_MeasureUnits_MeasureUnitId",
                table: "Ammo",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedAmmo_Ammo_AmmoId",
                table: "AssignedAmmo",
                column: "AmmoId",
                principalTable: "Ammo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedAmmo_EduBlocks_EduBlockId",
                table: "AssignedAmmo",
                column: "EduBlockId",
                principalTable: "EduBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAmmoLimitsForDepartments_Ammo_AmmoId",
                table: "CurrentAmmoLimitsForDepartments",
                column: "AmmoId",
                principalTable: "Ammo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ammo_AmmoTypes_AmmoTypeId",
                table: "Ammo");

            migrationBuilder.DropForeignKey(
                name: "FK_Ammo_MeasureUnits_MeasureUnitId",
                table: "Ammo");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedAmmo_Ammo_AmmoId",
                table: "AssignedAmmo");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedAmmo_EduBlocks_EduBlockId",
                table: "AssignedAmmo");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAmmoLimitsForDepartments_Ammo_AmmoId",
                table: "CurrentAmmoLimitsForDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedAmmo",
                table: "AssignedAmmo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ammo",
                table: "Ammo");

            migrationBuilder.RenameTable(
                name: "AssignedAmmo",
                newName: "AssignedAmmos");

            migrationBuilder.RenameTable(
                name: "Ammo",
                newName: "Ammos");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedAmmo_EduBlockId",
                table: "AssignedAmmos",
                newName: "IX_AssignedAmmos_EduBlockId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedAmmo_AmmoId",
                table: "AssignedAmmos",
                newName: "IX_AssignedAmmos_AmmoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ammo_MeasureUnitId",
                table: "Ammos",
                newName: "IX_Ammos_MeasureUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Ammo_AmmoTypeId",
                table: "Ammos",
                newName: "IX_Ammos_AmmoTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 42, 5, DateTimeKind.Local).AddTicks(1124),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 874, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 997, DateTimeKind.Local).AddTicks(2773),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 866, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 993, DateTimeKind.Local).AddTicks(1369),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 862, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 982, DateTimeKind.Local).AddTicks(3950),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 850, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 970, DateTimeKind.Local).AddTicks(4195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 17, 27, 25, 838, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedAmmos",
                table: "AssignedAmmos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ammos",
                table: "Ammos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ammos_AmmoTypes_AmmoTypeId",
                table: "Ammos",
                column: "AmmoTypeId",
                principalTable: "AmmoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ammos_MeasureUnits_MeasureUnitId",
                table: "Ammos",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedAmmos_Ammos_AmmoId",
                table: "AssignedAmmos",
                column: "AmmoId",
                principalTable: "Ammos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedAmmos_EduBlocks_EduBlockId",
                table: "AssignedAmmos",
                column: "EduBlockId",
                principalTable: "EduBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAmmoLimitsForDepartments_Ammos_AmmoId",
                table: "CurrentAmmoLimitsForDepartments",
                column: "AmmoId",
                principalTable: "Ammos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
