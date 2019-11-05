using HarrisPharmacy.App.Data;
using HarrisPharmacy.App.Data.Entities.Patients;
using HarrisPharmacy.App.Data.Interfaces;
using HarrisPharmacy.App.Data.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class AppointmentUnitTests
    {
        private readonly IAppointmentService _appointmentService;
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
    }
}
