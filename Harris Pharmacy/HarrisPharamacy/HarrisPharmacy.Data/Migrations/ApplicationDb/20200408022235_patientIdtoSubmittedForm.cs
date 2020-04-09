using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrisPharmacy.App.Migrations.ApplicationDb
{
    public partial class patientIdtoSubmittedForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "FormSubmissions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "FormSubmissions");
        }
    }
}
