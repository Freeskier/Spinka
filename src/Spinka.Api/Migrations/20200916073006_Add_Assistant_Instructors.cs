using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Assistant_Instructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 961, DateTimeKind.Local).AddTicks(2282),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 643, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(7033),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 635, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(3786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 634, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 949, DateTimeKind.Local).AddTicks(303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 630, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 935, DateTimeKind.Local).AddTicks(8498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 615, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 917, DateTimeKind.Local).AddTicks(616),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 594, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.CreateTable(
                name: "AssignedAssistantInstructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    EduBlockId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedAssistantInstructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedAssistantInstructors_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedAssistantInstructors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAssistantInstructors_EduBlockId",
                table: "AssignedAssistantInstructors",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAssistantInstructors_PersonId",
                table: "AssignedAssistantInstructors",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedAssistantInstructors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 643, DateTimeKind.Local).AddTicks(6449),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 961, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 635, DateTimeKind.Local).AddTicks(2552),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 634, DateTimeKind.Local).AddTicks(9463),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 953, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 630, DateTimeKind.Local).AddTicks(2955),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 949, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 615, DateTimeKind.Local).AddTicks(370),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 935, DateTimeKind.Local).AddTicks(8498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 16, 9, 14, 38, 594, DateTimeKind.Local).AddTicks(3296),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 16, 9, 30, 5, 917, DateTimeKind.Local).AddTicks(616));
        }
    }
}
