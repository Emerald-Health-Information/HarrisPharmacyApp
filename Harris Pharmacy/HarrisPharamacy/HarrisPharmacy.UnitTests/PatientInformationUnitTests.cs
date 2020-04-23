/*

   Harrison1 COSC 471 2019

   File = PatientInformationUnitTests.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Entities.Patients;
using HarrisPharmacy.Data.Entities.Appointments;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class PatientInformationUnitTests
    {
        private IAppointmentService _appointmentService;
        public ApplicationDbContext Context { get; set; }
        private Appointment pl;

        public PatientInformationUnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "temp")
                          .Options;
            var dbContext = new ApplicationDbContext(options);
            _appointmentService = new AppointmentService(dbContext);
        }

        /// <summary>
        /// Deletes appointment form DB and checks to see if is deleted
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FinishAppointment()
        {
            MakeInMemoryContext();
            var success = await _appointmentService.DeleteAsync(pl.AppointmentId);
            var delete = await _appointmentService.GetAppointmentAsync(success.AppointmentId);
            //Assert.Null(delete);
            Assert.Null(await _appointmentService.GetAppointmentAsync(success.AppointmentId));
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Make temperary context for testing
        /// </summary>
        private async void MakeInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;
            Context = new ApplicationDbContext(options);
            _appointmentService = new AppointmentService(Context);

            pl = new Appointment()
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
        }

        /// <summary>
        /// Delete context after testing.
        /// </summary>
        private void EnsureContextDeleted() => Context.Database.EnsureDeleted();
    }
}