using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Additional_Personnel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 143, DateTimeKind.Local).AddTicks(4043),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 140, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 161, DateTimeKind.Local).AddTicks(3926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 156, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 101, DateTimeKind.Local).AddTicks(3727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 98, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 100, DateTimeKind.Local).AddTicks(1623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 97, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 70, DateTimeKind.Local).AddTicks(9738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 69, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 41, 997, DateTimeKind.Local).AddTicks(6279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 996, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 15, 45, 41, 907, DateTimeKind.Local).AddTicks(3900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 904, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.CreateTable(
                name: "AdditionalPersonnel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonId = table.Column<int>(nullable: false),
                    EduBlockId = table.Column<int>(nullable: false),
                    IsLivePlayer = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalPersonnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalPersonnel_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalPersonnel_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPersonnel_EduBlockId",
                table: "AdditionalPersonnel",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPersonnel_PersonId",
                table: "AdditionalPersonnel",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalPersonnel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 140, DateTimeKind.Local).AddTicks(813),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 143, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 156, DateTimeKind.Local).AddTicks(7657),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 161, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 98, DateTimeKind.Local).AddTicks(9488),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 101, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 97, DateTimeKind.Local).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 100, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 23, 69, DateTimeKind.Local).AddTicks(3984),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 42, 70, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 996, DateTimeKind.Local).AddTicks(8900),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 41, 997, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 19, 7, 56, 22, 904, DateTimeKind.Local).AddTicks(5859),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 19, 15, 45, 41, 907, DateTimeKind.Local).AddTicks(3900));
        }
    }
}
