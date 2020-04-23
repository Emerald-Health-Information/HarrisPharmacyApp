/*

   Harrison1 COSC 471 2019

   File = 20200324180555_formSubmissions

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrisPharmacy.App.Migrations.ApplicationDb
{
    public partial class formSubmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormSubmissions",
                columns: table => new
                {
                    FormSubmissionId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    FormName = table.Column<string>(nullable: true),
                    FormDescription = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmissions", x => x.FormSubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "FormFieldSubmissions",
                columns: table => new
                {
                    FormFieldSubmissionId = table.Column<string>(nullable: false),
                    FormFieldName = table.Column<string>(nullable: true),
                    FormFieldValue = table.Column<string>(nullable: true),
                    FormInputType = table.Column<int>(nullable: false),
                    FormSubmissionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFieldSubmissions", x => x.FormFieldSubmissionId);
                    table.ForeignKey(
                        name: "FK_FormFieldSubmissions_FormSubmissions_FormSubmissionId",
                        column: x => x.FormSubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "FormSubmissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldSubmissions_FormSubmissionId",
                table: "FormFieldSubmissions",
                column: "FormSubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFieldSubmissions");

            migrationBuilder.DropTable(
                name: "FormSubmissions");
        }
    }
}
