using HarrisPharmacy.App.Data;
using HarrisPharmacy.App.Data.Entities.Patients;
using HarrisPharmacy.App.Data.Interfaces;
using HarrisPharmacy.App.Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HarrisPharmacy.App.Pages;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class PatientInformationUnitTests
    {
        private IAppointmentService _appointmentService;
        private PatientInformation _patientInformation;
        public ApplicationDbContext Context { get; set; }
        private PatientList pl;

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
            var success = await _appointmentService.DeleteAsync(pl.PatientListId);
            var delete = await _appointmentService.GetAppointmentAsync(success.PatientListId);
            //Assert.Null(delete);
            Assert.Null(await _appointmentService.GetAppointmentAsync(success.PatientListId));
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

            pl = new PatientList()
            {
                PatientListId = Guid.NewGuid().ToString(),
                UserId = "001",
                StartTime = "10:00",
                EndTime = "12:00",
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