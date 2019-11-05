using System;
using HarrisPharmacy.App.Data;
using HarrisPharmacy.App.Data.Interfaces;
using HarrisPharmacy.App.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Entities.Forms;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class FormsTests
    {
        private IFormService _formService;
        public ApplicationDbContext Context { get; set; }

        /// <summary>
        /// Makes sure the db connection is working and returns the forms
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CheckFormsFromDbNotNull()
        {
            MakeInMemoryContext();
            Assert.NotNull(await _formService.GetFormsAsync());
            // Cleanup
            EnsureContextDeleted();
        }

        [Fact]
        public async Task CheckInsertFormAsync()
        {
            MakeInMemoryContext();

            Form form = new Form()
            {
                FormId = "1",
                Description = "Test Form",
                CreatorId = "1",
                Name = "Test",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            var success = await _formService.InsertFormAsync(form);
            Assert.True(_formService.FormExists(success.FormId));
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Make temporary context for testing
        /// </summary>
        private void MakeInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;
            Context = new ApplicationDbContext(options);
            _formService = new FormService(Context);
        }

        /// <summary>
        /// Delete context after test
        /// </summary>
        private void EnsureContextDeleted() => Context.Database.EnsureDeleted();
    }
}