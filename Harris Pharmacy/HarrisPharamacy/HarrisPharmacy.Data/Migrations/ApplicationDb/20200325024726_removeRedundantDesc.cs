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
