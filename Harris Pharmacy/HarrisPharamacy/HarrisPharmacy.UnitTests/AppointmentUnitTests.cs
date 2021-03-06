﻿/*

   Harrison1 COSC 471 2019

   File = AppointmentUnitTests.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Entities.Appointments;
using HarrisPharmacy.Data.Entities.Patients;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class AppointmentUnitTests
    {
        private IAppointmentService _appointmentService;
        public ApplicationDbContext Context { get; set; }

        public AppointmentUnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "temp")
                          .Options;
            var dbContext = new ApplicationDbContext(options);
            _appointmentService = new AppointmentService(dbContext);
        }

        /// <summary>
        /// Queries database to check that there are appointments in the database.
        /// </summary>
        [Fact]
        public async void GetAllAppointmentsTest()
        {
            Assert.NotNull(await _appointmentService.GetPatientListAsync());
        }

        /// <summary>
        /// Creates a new appointment and checks that it exists in the database.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CheckInsertAppointmentAsync()
        {
            MakeInMemoryContext();
            Appointment pl = new Appointment()
            {
                AppointmentId = Guid.NewGuid().ToString(),
                UserId = "001",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                PatientId = "000001",
                Location = "Kelowna",
                Description = "Unit test",
            };
            var success = await _appointmentService.InsertAsync(pl);
            Assert.NotNull(_appointmentService.GetAppointmentAsync(pl.AppointmentId));
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Make temperary context for testing
        /// </summary>
        private void MakeInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;
            Context = new ApplicationDbContext(options);
            _appointmentService = new AppointmentService(Context);
        }

        /// <summary>
        /// Delete context after testing.
        /// </summary>
        private void EnsureContextDeleted() => Context.Database.EnsureDeleted();
    }
}