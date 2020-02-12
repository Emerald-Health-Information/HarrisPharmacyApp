using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Entities.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HarrisPharmacy.IntegrationTests
{
    /// <summary>
    /// Integration Tests relating to forms
    /// </summary>
    public class FormsIntegrationTests
    {
        /// <summary>
        /// The application Db Context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormsIntegrationTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(
                    $"Server=172.105.6.43;Database=HarrisProject_Testing;User Id=spike;Password=Spiketeam1;MultipleActiveResultSets=true")
                .UseInternalServiceProvider(serviceProvider);

            _context = new ApplicationDbContext(builder.Options);
            _context.Database.Migrate();
        }

        /// <summary>
        /// Creates a form and make sure it exists, then deletes it
        /// </summary>
        [Fact]
        public void CreateFormAccessFormDeleteForm()
        {
            var forms = _context.Forms;

            //Add the form before querying
            forms.Add(CreateNewTestingForm());
            _context.SaveChanges();

            //Verify the results
            Assert.Equal(1, forms.Count());
            var form = forms.First();
            Assert.Equal("Test Form", form.Description);
            Assert.Equal("Test", form.Name);
            Assert.Equal("1", form.CreatorId);
            forms.Remove(form);
            _context.SaveChanges();
            Assert.Equal(0, forms.Count());
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
    }
}