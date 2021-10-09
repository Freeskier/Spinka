using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Add_Edu_Block_History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 355, DateTimeKind.Local).AddTicks(1278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 615, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 358, DateTimeKind.Local).AddTicks(2896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 618, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(4639),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 334, DateTimeKind.Local).AddTicks(8612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 601, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 317, DateTimeKind.Local).AddTicks(5186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 586, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 299, DateTimeKind.Local).AddTicks(8556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 571, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.CreateTable(
                name: "EduBlockHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: false),
                    ModifyGuid = table.Column<Guid>(nullable: false),
                    InstructorPersonId = table.Column<int>(nullable: false),
                    AmmoManagerPersonId = table.Column<int>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdatePersonId = table.Column<int>(nullable: false),
                    CreatedByPersonId = table.Column<int>(nullable: false),
                    DriverPersonId1 = table.Column<int>(nullable: true),
                    DriverPersonId2 = table.Column<int>(nullable: true),
                    ShootingInstructorPersonId = table.Column<int>(nullable: true),
                    ExplosivesManagerPersonId = table.Column<int>(nullable: true),
                    SecurityPersonId = table.Column<int>(nullable: true),
                    Approved = table.Column<bool>(nullable: false, defaultValue: false),
                    ApprovedByPersonId = table.Column<int>(nullable: true),
                    ApprovedTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 362, DateTimeKind.Local).AddTicks(6044)),
                    TrainingFacility = table.Column<string>(nullable: true),
                    CancellingRemarks = table.Column<string>(nullable: true),
                    IsMedicalServiceRequired = table.Column<bool>(nullable: false, defaultValue: false),
                    AdditionalInformation = table.Column<string>(maxLength: 500, nullable: true),
                    EduBlockSubjectId = table.Column<int>(nullable: false),
                    MedicalServiceForEduBlockId = table.Column<int>(nullable: true),
                    MajorEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlockHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduBlockHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 615, DateTimeKind.Local).AddTicks(8403),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 355, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 618, DateTimeKind.Local).AddTicks(3544),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 358, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(1434),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 607, DateTimeKind.Local).AddTicks(49),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 343, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 601, DateTimeKind.Local).AddTicks(4774),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 334, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 586, DateTimeKind.Local).AddTicks(1534),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 317, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 26, 16, 3, 42, 571, DateTimeKind.Local).AddTicks(1859),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 27, 8, 50, 2, 299, DateTimeKind.Local).AddTicks(8556));
        }
    }
}
