using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalMgt.Infrastructure.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hospitalManagment");

            migrationBuilder.CreateTable(
                name: "Hospitals",
                schema: "hospitalManagment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                schema: "hospitalManagment",
                columns: table => new
                {
                    HospitalId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => new { x.HospitalId, x.Id });
                    table.ForeignKey(
                        name: "FK_ContactInformation_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "hospitalManagment",
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranch",
                schema: "hospitalManagment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsMainBranch = table.Column<bool>(type: "boolean", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranch_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "hospitalManagment",
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalSubscription",
                schema: "hospitalManagment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Contract = table.Column<string>(type: "text", nullable: true),
                    SubscriptionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalSubscription_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "hospitalManagment",
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchAddress",
                schema: "hospitalManagment",
                columns: table => new
                {
                    BranchesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    SubCity = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    LocationDescription = table.Column<string>(type: "text", nullable: true),
                    Longtiued = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchAddress", x => x.BranchesId);
                    table.ForeignKey(
                        name: "FK_HospitalBranchAddress_HospitalBranch_BranchesId",
                        column: x => x.BranchesId,
                        principalSchema: "hospitalManagment",
                        principalTable: "HospitalBranch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranch_HospitalId",
                schema: "hospitalManagment",
                table: "HospitalBranch",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalSubscription_HospitalId",
                schema: "hospitalManagment",
                table: "HospitalSubscription",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation",
                schema: "hospitalManagment");

            migrationBuilder.DropTable(
                name: "HospitalBranchAddress",
                schema: "hospitalManagment");

            migrationBuilder.DropTable(
                name: "HospitalSubscription",
                schema: "hospitalManagment");

            migrationBuilder.DropTable(
                name: "HospitalBranch",
                schema: "hospitalManagment");

            migrationBuilder.DropTable(
                name: "Hospitals",
                schema: "hospitalManagment");
        }
    }
}
