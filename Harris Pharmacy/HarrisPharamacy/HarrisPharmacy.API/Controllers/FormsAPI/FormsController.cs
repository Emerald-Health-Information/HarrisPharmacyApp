#region copyright

/*

Harrison1 COSC 470 2019

File = FormService.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Dakota Logan	2020-01-20			Initial

*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers.FormsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            this._formService = formService;
        }
    }
}   