using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrisPharmacy.App.Migrations.ApplicationDb
{
    public partial class patientList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Patient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MentalStatus",
                table: "Patient",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientList",
                columns: table => new
                {
                    PatientListId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientList", x => x.PatientListId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientList");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "MentalStatus",
                table: "Patient");
        }
    }
}
