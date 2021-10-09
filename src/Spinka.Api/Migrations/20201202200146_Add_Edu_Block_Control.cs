using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Edu_Block_Control : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 602, DateTimeKind.Local).AddTicks(2619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 562, DateTimeKind.Local).AddTicks(9170),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 561, DateTimeKind.Local).AddTicks(5802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DayRepAcronyms",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 528, DateTimeKind.Local).AddTicks(5060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 455, DateTimeKind.Local).AddTicks(4752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 348, DateTimeKind.Local).AddTicks(3826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 575, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.CreateTable(
                name: "EduBlockControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    EduBlockId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Attended = table.Column<bool>(nullable: false, defaultValue: true),
                    AbsenceReason = table.Column<string>(maxLength: 100, nullable: true),
                    AdminLogin = table.Column<string>(nullable: false),
                    LastTimeModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 630, DateTimeKind.Local).AddTicks(6199)),
                    Remarks = table.Column<string>(maxLength: 250, nullable: true),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlockControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduBlockControls_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EduBlockControls_Persons_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EduBlockControls_EduBlockId",
                table: "EduBlockControls",
                column: "EduBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduBlockControls");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 631, DateTimeKind.Local).AddTicks(6547),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 602, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 562, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 620, DateTimeKind.Local).AddTicks(5036),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 561, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DayRepAcronyms",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 612, DateTimeKind.Local).AddTicks(799),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 528, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 597, DateTimeKind.Local).AddTicks(387),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 455, DateTimeKind.Local).AddTicks(4752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 11, 19, 12, 22, 16, 575, DateTimeKind.Local).AddTicks(1869),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 2, 21, 1, 44, 348, DateTimeKind.Local).AddTicks(3826));
        }
    }
}
