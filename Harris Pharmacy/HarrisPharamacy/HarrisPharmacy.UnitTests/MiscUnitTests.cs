using System;
using System.Collections.Generic;
using System.Text;
using HarrisPharmacy.App.HelperClasses;
using Xunit;

namespace HarrisPharmacy.UnitTests
{
    public class MiscUnitTests
    {
        /// <summary>
        /// Testing the Page header helper class
        /// </summary>
        [Fact]
        public void PageHeaderReturnsProperHeaders()
        {
            List<string> urisToTestList = new List<string>
            {
                "https://localhost:44356/",
                "https://localhost:44356/AppointmentInformation/62c0adf9-9099-4b7a-9982-da2228f44ed7",
                "https://localhost:44356/ManageForms",
                "https://localhost:44356/ManageFormFields",
                "https://localhost:44356/CreateAppointment",
            };

            List<string> expectedResultsList = new List<string>
            {
                "Appointments",
                "Appointment Information",
                "Manage Forms",
                "Manage Form Fields",
                "Create Appointment",
            };
            for (int i = 0; i < urisToTestList.Count; i++)
            {
                Assert.Equal(expectedResultsList[i], PageHeaderHelper.GetPageHeader(urisToTestList[i]));
            }
        }
    }
}