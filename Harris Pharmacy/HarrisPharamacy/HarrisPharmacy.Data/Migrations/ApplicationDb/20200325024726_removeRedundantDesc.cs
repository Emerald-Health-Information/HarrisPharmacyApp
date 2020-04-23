/*

   Harrison1 COSC 471 2019

   File = 20200325024726_removeRedundantDesc

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
    public partial class removeRedundantDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormDescription",
                table: "FormSubmissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormDescription",
                table: "FormSubmissions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
