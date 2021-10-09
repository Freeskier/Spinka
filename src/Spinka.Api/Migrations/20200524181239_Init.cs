using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmmoTransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Acronym = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoTransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmmoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayRepAcronyms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 15, nullable: false),
                    Color = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRepAcronyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Acronym = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    FullRankPl = table.Column<string>(maxLength: 25, nullable: true),
                    FullRankEn = table.Column<string>(maxLength: 35, nullable: true),
                    Nato = table.Column<string>(maxLength: 4, nullable: true),
                    Grading = table.Column<int>(nullable: false),
                    AcrRankPl = table.Column<string>(maxLength: 12, nullable: true),
                    AcrRankEn = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RegisterNumber = table.Column<string>(maxLength: 7, nullable: false),
                    VehicleType = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(maxLength: 35, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ammos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LogIndex = table.Column<string>(maxLength: 13, nullable: false),
                    IsDangerous = table.Column<bool>(nullable: false, defaultValue: false),
                    MeasureUnitId = table.Column<int>(nullable: false),
                    AmmoTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ammos_AmmoTypes_AmmoTypeId",
                        column: x => x.AmmoTypeId,
                        principalTable: "AmmoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ammos_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(maxLength: 11, nullable: false),
                    Login = table.Column<string>(maxLength: 20, nullable: true),
                    OpNo = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    MilitaryRankId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_MilitaryRanks_MilitaryRankId",
                        column: x => x.MilitaryRankId,
                        principalTable: "MilitaryRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EduBlockSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Subject = table.Column<string>(maxLength: 250, nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    IsMedicalServiceRequired = table.Column<bool>(nullable: false, defaultValue: false),
                    TrainingAreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlockSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduBlockSubjects_TrainingAreas_TrainingAreaId",
                        column: x => x.TrainingAreaId,
                        principalTable: "TrainingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGroupsInDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TrainingGroupId = table.Column<int>(nullable: false),
                    UnitDepartmentsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGroupsInDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGroupsInDepartments_TrainingGroups_TrainingGroupId",
                        column: x => x.TrainingGroupId,
                        principalTable: "TrainingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingGroupsInDepartments_UnitDepartments_UnitDepartmentsId",
                        column: x => x.UnitDepartmentsId,
                        principalTable: "UnitDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAmmoLimitsForDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Quantity = table.Column<int>(nullable: false),
                    ActualizationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 910, DateTimeKind.Local).AddTicks(1029)),
                    UnitDepartmentsId = table.Column<int>(nullable: true),
                    AmmoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAmmoLimitsForDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentAmmoLimitsForDepartments_Ammos_AmmoId",
                        column: x => x.AmmoId,
                        principalTable: "Ammos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentAmmoLimitsForDepartments_UnitDepartments_UnitDepartmentsId",
                        column: x => x.UnitDepartmentsId,
                        principalTable: "UnitDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayReps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Day = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 914, DateTimeKind.Local).AddTicks(7048)),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    DayRepAcronymId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayReps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayReps_DayRepAcronyms_DayRepAcronymId",
                        column: x => x.DayRepAcronymId,
                        principalTable: "DayRepAcronyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayReps_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAuthorizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    AuthorizationTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAuthorizations_AuthorizationsTypes_AuthorizationTypeId",
                        column: x => x.AuthorizationTypeId,
                        principalTable: "AuthorizationsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAuthorizations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGroupsPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    PersonId = table.Column<int>(nullable: false),
                    TrainingGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGroupsPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGroupsPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingGroupsPersons_TrainingGroups_TrainingGroupId",
                        column: x => x.TrainingGroupId,
                        principalTable: "TrainingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EduBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: false),
                    InstructorPersonId = table.Column<int>(nullable: false),
                    AmmoManagerPersonId = table.Column<int>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdatePersonId = table.Column<int>(nullable: false),
                    CreatedByPersonId = table.Column<int>(nullable: false),
                    DriverPersonId1 = table.Column<int>(nullable: true),
                    DriverPersonId2 = table.Column<int>(nullable: true),
                    ShootingInstructorPersonId = table.Column<int>(nullable: true),
                    ExplosivesManagerPersonId = table.Column<int>(nullable: true),
                    SecurityPersonId1 = table.Column<int>(nullable: true),
                    SecurityPersonId2 = table.Column<int>(nullable: true),
                    SecurityPersonId3 = table.Column<int>(nullable: true),
                    SecurityPersonId4 = table.Column<int>(nullable: true),
                    Approved = table.Column<bool>(nullable: false, defaultValue: false),
                    ApprovedByPersonId = table.Column<int>(nullable: true),
                    ApprovedTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 917, DateTimeKind.Local).AddTicks(8827)),
                    EduBlockSubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EduBlocks_EduBlockSubjects_EduBlockSubjectId",
                        column: x => x.EduBlockSubjectId,
                        principalTable: "EduBlockSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmmoTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Quantity = table.Column<int>(nullable: false),
                    AmmoAdminId = table.Column<int>(nullable: false),
                    TransactionDateTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 888, DateTimeKind.Local).AddTicks(5555)),
                    Remarks = table.Column<string>(maxLength: 250, nullable: true),
                    AmmoTransactionTypeId = table.Column<int>(nullable: true),
                    CurrentAmmoLimitsForDepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmmoTransactions_AmmoTransactionTypes_AmmoTransactionTypeId",
                        column: x => x.AmmoTransactionTypeId,
                        principalTable: "AmmoTransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmmoTransactions_CurrentAmmoLimitsForDepartments_CurrentAmmoLimitsForDepartmentId",
                        column: x => x.CurrentAmmoLimitsForDepartmentId,
                        principalTable: "CurrentAmmoLimitsForDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignedAmmos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    AmmoId = table.Column<int>(nullable: false),
                    EduBlockId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedAmmos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedAmmos_Ammos_AmmoId",
                        column: x => x.AmmoId,
                        principalTable: "Ammos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedAmmos_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTrainingFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: false),
                    ApprovedByPersonId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 250, nullable: true),
                    ApprovedTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 24, 20, 12, 38, 900, DateTimeKind.Local).AddTicks(7340)),
                    EduBlockId = table.Column<int>(nullable: false),
                    TrainingFacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTrainingFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedTrainingFacilities_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedTrainingFacilities_TrainingFacilities_TrainingFacilityId",
                        column: x => x.TrainingFacilityId,
                        principalTable: "TrainingFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTrainingGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TrainingGroupId = table.Column<int>(nullable: false),
                    EduBlockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTrainingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedTrainingGroups_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedTrainingGroups_TrainingGroups_TrainingGroupId",
                        column: x => x.TrainingGroupId,
                        principalTable: "TrainingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    EduBlockId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedVehicles_EduBlocks_EduBlockId",
                        column: x => x.EduBlockId,
                        principalTable: "EduBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ammos_AmmoTypeId",
                table: "Ammos",
                column: "AmmoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ammos_MeasureUnitId",
                table: "Ammos",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoTransactions_AmmoTransactionTypeId",
                table: "AmmoTransactions",
                column: "AmmoTransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoTransactions_CurrentAmmoLimitsForDepartmentId",
                table: "AmmoTransactions",
                column: "CurrentAmmoLimitsForDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAmmos_AmmoId",
                table: "AssignedAmmos",
                column: "AmmoId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAmmos_EduBlockId",
                table: "AssignedAmmos",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTrainingFacilities_EduBlockId",
                table: "AssignedTrainingFacilities",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTrainingFacilities_TrainingFacilityId",
                table: "AssignedTrainingFacilities",
                column: "TrainingFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTrainingGroups_EduBlockId",
                table: "AssignedTrainingGroups",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTrainingGroups_TrainingGroupId",
                table: "AssignedTrainingGroups",
                column: "TrainingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedVehicles_EduBlockId",
                table: "AssignedVehicles",
                column: "EduBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedVehicles_VehicleId",
                table: "AssignedVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAmmoLimitsForDepartments_AmmoId",
                table: "CurrentAmmoLimitsForDepartments",
                column: "AmmoId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAmmoLimitsForDepartments_UnitDepartmentsId",
                table: "CurrentAmmoLimitsForDepartments",
                column: "UnitDepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_DayReps_DayRepAcronymId",
                table: "DayReps",
                column: "DayRepAcronymId");

            migrationBuilder.CreateIndex(
                name: "IX_DayReps_PersonId",
                table: "DayReps",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EduBlocks_EduBlockSubjectId",
                table: "EduBlocks",
                column: "EduBlockSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EduBlockSubjects_TrainingAreaId",
                table: "EduBlockSubjects",
                column: "TrainingAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuthorizations_AuthorizationTypeId",
                table: "PersonAuthorizations",
                column: "AuthorizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAuthorizations_PersonId",
                table: "PersonAuthorizations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MilitaryRankId",
                table: "Persons",
                column: "MilitaryRankId",
                unique: false,
                filter: "[MilitaryRankId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGroupsInDepartments_TrainingGroupId",
                table: "TrainingGroupsInDepartments",
                column: "TrainingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGroupsInDepartments_UnitDepartmentsId",
                table: "TrainingGroupsInDepartments",
                column: "UnitDepartmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGroupsPersons_PersonId",
                table: "TrainingGroupsPersons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGroupsPersons_TrainingGroupId",
                table: "TrainingGroupsPersons",
                column: "TrainingGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmmoTransactions");

            migrationBuilder.DropTable(
                name: "AssignedAmmos");

            migrationBuilder.DropTable(
                name: "AssignedTrainingFacilities");

            migrationBuilder.DropTable(
                name: "AssignedTrainingGroups");

            migrationBuilder.DropTable(
                name: "AssignedVehicles");

            migrationBuilder.DropTable(
                name: "DayReps");

            migrationBuilder.DropTable(
                name: "PersonAuthorizations");

            migrationBuilder.DropTable(
                name: "TrainingGroupsInDepartments");

            migrationBuilder.DropTable(
                name: "TrainingGroupsPersons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AmmoTransactionTypes");

            migrationBuilder.DropTable(
                name: "CurrentAmmoLimitsForDepartments");

            migrationBuilder.DropTable(
                name: "TrainingFacilities");

            migrationBuilder.DropTable(
                name: "EduBlocks");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "DayRepAcronyms");

            migrationBuilder.DropTable(
                name: "AuthorizationsTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "TrainingGroups");

            migrationBuilder.DropTable(
                name: "Ammos");

            migrationBuilder.DropTable(
                name: "UnitDepartments");

            migrationBuilder.DropTable(
                name: "EduBlockSubjects");

            migrationBuilder.DropTable(
                name: "MilitaryRanks");

            migrationBuilder.DropTable(
                name: "AmmoTypes");

            migrationBuilder.DropTable(
                name: "MeasureUnits");

            migrationBuilder.DropTable(
                name: "TrainingAreas");
        }
    }
}
