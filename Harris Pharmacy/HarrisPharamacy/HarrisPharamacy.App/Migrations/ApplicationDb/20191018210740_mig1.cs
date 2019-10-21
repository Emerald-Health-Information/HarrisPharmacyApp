using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrisPharmacy.App.Migrations.ApplicationDb
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PatientList");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "PatientList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "PatientList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Patient",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "PatientList");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "PatientList");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Patient");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "PatientList",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
