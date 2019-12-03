using System;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HarrisPharmacy.App.HelperClasses
{
    public static class PageHeaderHelper
    {
        public static string GetPageHeader(string value)
        {
            value = value.Remove(0, value.IndexOf("//", StringComparison.Ordinal) + 2);
            value = value.Remove(0, value.IndexOf("/", StringComparison.Ordinal));

            if (value.Remove(value.LastIndexOf("/", StringComparison.Ordinal)).Contains("/"))
                value = value.Remove(value.LastIndexOf("/", StringComparison.Ordinal));
            switch (value)
            {
                case "/":
                    return "Appointments";

                case "/CreateAppointment":
                    return "Create Appointment";

                case "/ManageForms":
                    return "Manage Forms";

                case "/ManageFormFields":
                    return "Manage Form Fields";

                case "/AppointmentInformation":
                    return "Appointment Information";

                default:
                    return "";
            }
        }
    }
}