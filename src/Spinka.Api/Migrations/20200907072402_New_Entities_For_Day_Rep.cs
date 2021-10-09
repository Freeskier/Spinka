using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class New_Entities_For_Day_Rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 406, DateTimeKind.Local).AddTicks(1068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 755, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 748, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(2324),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 747, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 393, DateTimeKind.Local).AddTicks(7113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 743, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 380, DateTimeKind.Local).AddTicks(290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 732, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 365, DateTimeKind.Local).AddTicks(7723),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 720, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.CreateTable(
                name: "AvailabilityRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvailabilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Type = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedAvailabilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    AvailabilityRoleId = table.Column<int>(nullable: true),
                    DayRepId = table.Column<int>(nullable: false),
                    AvailabilityTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedAvailabilityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedAvailabilityTypes_AvailabilityTypes_AvailabilityTypeId",
                        column: x => x.AvailabilityTypeId,
                        principalTable: "AvailabilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedAvailabilityTypes_DayReps_DayRepId",
                        column: x => x.DayRepId,
                        principalTable: "DayReps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAvailabilityTypes_AvailabilityTypeId",
                table: "AssignedAvailabilityTypes",
                column: "AvailabilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAvailabilityTypes_DayRepId",
                table: "AssignedAvailabilityTypes",
                column: "DayRepId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedAvailabilityTypes");

            migrationBuilder.DropTable(
                name: "AvailabilityRoles");

            migrationBuilder.DropTable(
                name: "AvailabilityTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 755, DateTimeKind.Local).AddTicks(8316),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 406, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 748, DateTimeKind.Local).AddTicks(795),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 747, DateTimeKind.Local).AddTicks(8111),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 398, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 743, DateTimeKind.Local).AddTicks(4650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 393, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 732, DateTimeKind.Local).AddTicks(3710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 380, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 4, 11, 43, 48, 720, DateTimeKind.Local).AddTicks(830),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 7, 9, 24, 2, 365, DateTimeKind.Local).AddTicks(7723));
        }
    }
}
