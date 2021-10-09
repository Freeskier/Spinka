using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Fix_Security_Person_And_Add_New_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SecurityPersonId1",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "SecurityPersonId2",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "SecurityPersonId3",
                table: "EduBlocks");

            migrationBuilder.DropColumn(
                name: "SecurityPersonId4",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 832, DateTimeKind.Local).AddTicks(7777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 214, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.AddColumn<int>(
                name: "MedicalServiceForEduBlockId",
                table: "EduBlocks",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 827, DateTimeKind.Local).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 211, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 823, DateTimeKind.Local).AddTicks(4644),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 207, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 812, DateTimeKind.Local).AddTicks(4626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 198, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 800, DateTimeKind.Local).AddTicks(2270),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 186, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.CreateTable(
                name: "AuxPersonForEduBlocks",
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
                    table.PrimaryKey("PK_AuxPersonForEduBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuxPersonForEduBlocks_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuxPersonForEduBlocks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionForEduBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionForEduBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupForDayReps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupForDayReps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalServiceForEduBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ParamedicPersonId = table.Column<int>(nullable: false),
                    DoctorPersonId = table.Column<int>(nullable: false),
                    DriverPersonId = table.Column<int>(nullable: false),
                    AmbulanceVehicleId = table.Column<int>(nullable: false),
                    EduBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServiceForEduBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalServiceForEduBlocks_Vehicles_AmbulanceVehicleId",
                        column: x => x.AmbulanceVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAuthorisedForEduBlockFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    AuthorisationsTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAuthorisedForEduBlockFunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAuthorisedForEduBlockFunctions_AuthorizationsTypes_AuthorisationsTypeId",
                        column: x => x.AuthorisationsTypeId,
                        principalTable: "AuthorizationsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAuthorisedForEduBlockFunctions_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayRepGroupPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    GroupForDayRepId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRepGroupPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayRepGroupPersons_GroupForDayReps_GroupForDayRepId",
                        column: x => x.GroupForDayRepId,
                        principalTable: "GroupForDayReps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayRepGroupPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuxPersonForEduBlocks_EduBlockId",
                table: "AuxPersonForEduBlocks",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AuxPersonForEduBlocks_PersonId",
                table: "AuxPersonForEduBlocks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DayRepGroupPersons_GroupForDayRepId",
                table: "DayRepGroupPersons",
                column: "GroupForDayRepId");

            migrationBuilder.CreateIndex(
                name: "IX_DayRepGroupPersons_PersonId",
                table: "DayRepGroupPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServiceForEduBlocks_AmbulanceVehicleId",
                table: "MedicalServiceForEduBlocks",
                column: "AmbulanceVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuthorisedForEduBlockFunctions_AuthorisationsTypeId",
                table: "PersonAuthorisedForEduBlockFunctions",
                column: "AuthorisationsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuthorisedForEduBlockFunctions_PersonId",
                table: "PersonAuthorisedForEduBlockFunctions",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuxPersonForEduBlocks");

            migrationBuilder.DropTable(
                name: "DayRepGroupPersons");

            migrationBuilder.DropTable(
                name: "FunctionForEduBlocks");

            migrationBuilder.DropTable(
                name: "MedicalServiceForEduBlocks");

            migrationBuilder.DropTable(
                name: "PersonAuthorisedForEduBlockFunctions");

            migrationBuilder.DropTable(
                name: "GroupForDayReps");

            migrationBuilder.DropColumn(
                name: "MedicalServiceForEduBlockId",
                table: "EduBlocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 214, DateTimeKind.Local).AddTicks(2513),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 832, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.AddColumn<int>(
                name: "SecurityPersonId1",
                table: "EduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityPersonId2",
                table: "EduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityPersonId3",
                table: "EduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityPersonId4",
                table: "EduBlocks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 211, DateTimeKind.Local).AddTicks(6129),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 827, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 207, DateTimeKind.Local).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 823, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 198, DateTimeKind.Local).AddTicks(8756),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 812, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 27, 9, 52, 29, 186, DateTimeKind.Local).AddTicks(5685),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 19, 21, 7, 16, 800, DateTimeKind.Local).AddTicks(2270));
        }
    }
}
