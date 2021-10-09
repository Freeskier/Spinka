using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class New_Tables_For_Timeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 794, DateTimeKind.Local).AddTicks(8159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 468, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.AddColumn<int>(
                name: "MajorEventId",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 798, DateTimeKind.Local).AddTicks(4876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 471, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 786, DateTimeKind.Local).AddTicks(1325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 460, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 785, DateTimeKind.Local).AddTicks(8648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 459, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 779, DateTimeKind.Local).AddTicks(4831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 453, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 763, DateTimeKind.Local).AddTicks(5451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 437, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 744, DateTimeKind.Local).AddTicks(2165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 418, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Acr = table.Column<string>(maxLength: 12, nullable: false),
                    Color = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MajorEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    StartOn = table.Column<DateTime>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: false),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    UnitDepartmentId = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorEvent_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MajorEvent_UnitDepartments_UnitDepartmentId",
                        column: x => x.UnitDepartmentId,
                        principalTable: "UnitDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EduBlocks_MajorEventId",
                table: "EduBlocks",
                column: "MajorEventId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorEvent_EventTypeId",
                table: "MajorEvent",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorEvent_UnitDepartmentId",
                table: "MajorEvent",
                column: "UnitDepartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EduBlocks_MajorEvent_MajorEventId",
                table: "EduBlocks",
                column: "MajorEventId",
                principalTable: "MajorEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduBlocks_MajorEvent_MajorEventId",
                table: "EduBlocks");

            migrationBuilder.DropTable(
                name: "MajorEvent");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropIndex(
                name: "IX_EduBlocks_MajorEventId",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "MajorEventId",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 468, DateTimeKind.Local).AddTicks(3027),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 794, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 471, DateTimeKind.Local).AddTicks(8439),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 798, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 460, DateTimeKind.Local).AddTicks(2110),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 786, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 459, DateTimeKind.Local).AddTicks(9194),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 785, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 453, DateTimeKind.Local).AddTicks(7125),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 779, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 437, DateTimeKind.Local).AddTicks(7876),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 763, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 1, 9, 45, 28, 418, DateTimeKind.Local).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 8, 12, 28, 22, 744, DateTimeKind.Local).AddTicks(2165));
        }
    }
}
