using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Refactor_Relation_Between_EduBlock_MedicalService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceForEduBlocks_AmbulanceVehicleId",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.DropColumn(
                name: "EduBlockId",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 42, 5, DateTimeKind.Local).AddTicks(1124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 832, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 997, DateTimeKind.Local).AddTicks(2773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 827, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 993, DateTimeKind.Local).AddTicks(1369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 823, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 982, DateTimeKind.Local).AddTicks(3950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 812, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 970, DateTimeKind.Local).AddTicks(4195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 800, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons",
                column: "MilitaryRankId",
                unique: false,
                filter: "[MilitaryRankId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceForEduBlocks_AmbulanceVehicleId",
                table: "MedicalServiceForEduBlocks",
                column: "AmbulanceVehicleId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_EduBlocks_MedicalServiceForEduBlockId",
                table: "EduBlocks",
                column: "MedicalServiceForEduBlockId",
                unique: false,
                filter: "[MedicalServiceForEduBlockId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EduBlocks_MedicalServiceForEduBlocks_MedicalServiceForEduBlockId",
                table: "EduBlocks",
                column: "MedicalServiceForEduBlockId",
                principalTable: "MedicalServiceForEduBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduBlocks_MedicalServiceForEduBlocks_MedicalServiceForEduBlockId",
                table: "EduBlocks");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_MedicalServiceForEduBlocks_AmbulanceVehicleId",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.DropIndex(
                name: "IX_EduBlocks_MedicalServiceForEduBlockId",
                table: "EduBlocks");

            migrationBuilder.AddColumn<int>(
                name: "EduBlockId",
                table: "MedicalServiceForEduBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 832, DateTimeKind.Local).AddTicks(7777),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 42, 5, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 827, DateTimeKind.Local).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 997, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 823, DateTimeKind.Local).AddTicks(4644),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 993, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 812, DateTimeKind.Local).AddTicks(4626),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 982, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 800, DateTimeKind.Local).AddTicks(2270),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 22, 10, 56, 41, 970, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceForEduBlocks_AmbulanceVehicleId",
                table: "MedicalServiceForEduBlocks",
                column: "AmbulanceVehicleId");
        }
    }
}
