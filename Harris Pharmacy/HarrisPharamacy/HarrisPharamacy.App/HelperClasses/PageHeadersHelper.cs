using System;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HarrisPharmacy.App.HelperClasses
{
    public static class PageHeaderHelper
    {
        public static string GetPageHeader(string value)
        {
            value = value.Remove(0, value.LastIndexOf("/", StringComparison.Ordinal));
            switch (value)
            {
                case "/":
                    return "Appointments";

                case "/appointment":
                    return "Create Appointment";

                case "/formBuilder":
                    return "Edit Form Builder";

                case "/FormFields":
                    return "Edit Form Fields";

                default:
                    return "Home";
            }
        }
    }
}