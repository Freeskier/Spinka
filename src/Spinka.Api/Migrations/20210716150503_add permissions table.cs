using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spinka.Api.Migrations
{
    public partial class addpermissionstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 181, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 190, DateTimeKind.Local).AddTicks(2069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(3720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(1691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 159, DateTimeKind.Local).AddTicks(8433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 142, DateTimeKind.Local).AddTicks(4068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 122, DateTimeKind.Local).AddTicks(5113),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationsTypePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    AuthorizationsTypeId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationsTypePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizationsTypePermissions_AuthorizationsTypes_AuthorizationsTypeId",
                        column: x => x.AuthorizationsTypeId,
                        principalTable: "AuthorizationsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorizationsTypePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationsTypePermissions_AuthorizationsTypeId",
                table: "AuthorizationsTypePermissions",
                column: "AuthorizationsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationsTypePermissions_PermissionId",
                table: "AuthorizationsTypePermissions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizationsTypePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "EduBlocks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 799, DateTimeKind.Local).AddTicks(2917),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 181, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimeModified",
                table: "EduBlockControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 815, DateTimeKind.Local).AddTicks(2310),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 190, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 757, DateTimeKind.Local).AddTicks(3514),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DayReps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 756, DateTimeKind.Local).AddTicks(1188),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 169, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualizationDate",
                table: "CurrentAmmoLimitsForDepartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 726, DateTimeKind.Local).AddTicks(1400),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 159, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedTime",
                table: "AssignedTrainingFacilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 654, DateTimeKind.Local).AddTicks(3405),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 142, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDateTime",
                table: "AmmoTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 12, 22, 25, 25, 570, DateTimeKind.Local).AddTicks(7733),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 7, 16, 17, 5, 3, 122, DateTimeKind.Local).AddTicks(5113));
        }
    }
}
