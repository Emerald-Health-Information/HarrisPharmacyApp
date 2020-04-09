/*

   Harrison1 COSC 471 2019

   File = BasicTests.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HarrisPharmacy.IntegrationTests
{
    /// <summary>
    /// Basic Tests for testing our application
    /// </summary>
    public class BasicTests
        : IClassFixture<WebApplicationFactory<App.Startup>>
    {/// <summary>
     /// Factory for bootstrapping an application in memory for functional end to end tests.
     /// </summary>
        private readonly WebApplicationFactory<App.Startup> _factory;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="factory"></param>
        public BasicTests(WebApplicationFactory<App.Startup> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Tests our endpoints and ensures it returns Success Code and Correct Content Type
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("/")]
        [InlineData("/FormBuilder")]
        [InlineData("/Forms")]
        [InlineData("/Patients")]
        [InlineData("/PatientInformation")]
        [InlineData("/Appointment")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}