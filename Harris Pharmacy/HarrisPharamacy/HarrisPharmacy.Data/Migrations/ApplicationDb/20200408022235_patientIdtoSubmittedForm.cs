/*

   Harrison1 COSC 471 2019

   File = 20200408022235_patientIdtoSubmittedForm

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
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
