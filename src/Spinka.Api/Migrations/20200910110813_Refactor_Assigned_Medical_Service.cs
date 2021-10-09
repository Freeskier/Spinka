using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Refactor_Assigned_Medical_Service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorPersonId",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.DropColumn(
                name: "ParamedicPersonId",
                table: "MedicalServiceForEduBlocks");

            migrationBuilder.DropColumn(
                name: "IsMedicalServiceRequired",
                table: "EduBlockSubjects");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 305, DateTimeKind.Local).AddTicks(6820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 406, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicalServiceRequired",
                table: "EduBlocks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 298, DateTimeKind.Local).AddTicks(1712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 297, DateTimeKind.Local).AddTicks(8502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 293, DateTimeKind.Local).AddTicks(3548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 393, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 279, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 380, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 262, DateTimeKind.Local).AddTicks(9362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 365, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.CreateTable(
                name: "AssignedPersonToMedicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonId = table.Column<int>(nullable: false),
                    MedicalServiceForEduBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPersonToMedicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedPersonToMedicalServices_MedicalServiceForEduBlocks_MedicalServiceForEduBlockId",
                        column: x => x.MedicalServiceForEduBlockId,
                        principalTable: "MedicalServiceForEduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPersonToMedicalServices_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPersonToMedicalServices_MedicalServiceForEduBlockId",
                table: "AssignedPersonToMedicalServices",
                column: "MedicalServiceForEduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPersonToMedicalServices_PersonId",
                table: "AssignedPersonToMedicalServices",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedPersonToMedicalServices");

            migrationBuilder.DropColumn(
                name: "IsMedicalServiceRequired",
                table: "EduBlocks");

            migrationBuilder.AddColumn<int>(
                name: "DoctorPersonId",
                table: "MedicalServiceForEduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParamedicPersonId",
                table: "MedicalServiceForEduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicalServiceRequired",
                table: "EduBlockSubjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 406, DateTimeKind.Local).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 305, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 298, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(2324),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 297, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 393, DateTimeKind.Local).AddTicks(7113),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 293, DateTimeKind.Local).AddTicks(3548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 380, DateTimeKind.Local).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 279, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 365, DateTimeKind.Local).AddTicks(7723),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 10, 13, 8, 13, 262, DateTimeKind.Local).AddTicks(9362));
        }
    }
}
