﻿/*

Harrison1 COSC 471 2019

File = 20191121012620_Appointments.cs

Author = Grayson King

Date = 2020 - 01 - 10

License = MIT

            Modification History

Version     Author Date           Desc
v 1.0		Grayson King     2020-01-10			Created

*/
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrisPharmacy.App.Migrations.ApplicationDb
{
    public partial class Appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    AppointmentState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
