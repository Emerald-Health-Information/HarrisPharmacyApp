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
    /// <summary>
    /// A class for unit testing things to do with forms
    /// </summary>
    public class FormsUnitTests
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

        /// <summary>
        /// Make sure Insert Form is working
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task CheckInsertFormAsync()
        {
            MakeInMemoryContext();

            Form form = CreateNewTestingForm();
            var success = await _formService.InsertFormAsync(form);
            Assert.True(_formService.FormExists(success.FormId));
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Make sure Delete Form is working
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task CheckDeleteFormAsync()
        {
            MakeInMemoryContext();

            Form form = CreateNewTestingForm();
            var success = await _formService.InsertFormAsync(form);
            await _formService.DeleteFormAsync(success.FormId);
            Assert.False(_formService.FormExists(success.FormId));
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Make sure update form is workings
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CheckUpdateFormAsync()
        {
            MakeInMemoryContext();

            Form form = CreateNewTestingForm();
            var success = await _formService.InsertFormAsync(form);
            form.Name = "New Name";

            var updatedForm = await _formService.UpdateFormAsync(form);
            Assert.Equal("New Name", updatedForm.Name);
            // Cleanup
            EnsureContextDeleted();
        }

        /// <summary>
        /// Create a form for testing purposes
        /// </summary>
        /// <returns>the created form</returns>
        private static Form CreateNewTestingForm()
        {
            return new Form()
            {
                FormId = "1",
                Description = "Test Form",
                CreatorId = "1",
                Name = "Test",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
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