/*

   Harrison1 COSC 471 2019

   File = IPatientInfoService.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using System;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Patients;

namespace HarrisPharmacy.Data.Interfaces
{
    /// <summary>
    /// The interface for the service class for appointments that allows the front end to interact with the database
    /// </summary>
    public interface IPatientInfoService
    {
        Task<Patient> GetPatientInformationAsync(String patientListID);
    }
}