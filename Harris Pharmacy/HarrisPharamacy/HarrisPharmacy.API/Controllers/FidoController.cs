﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Models;
using Microsoft.AspNetCore.Mvc;
using Rsk.AspNetCore.Fido;
using Rsk.AspNetCore.Fido.Dtos;
using Rsk.AspNetCore.Fido.Models;

namespace HarrisPharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FidoController : Controller
    {
        private readonly IFidoAuthentication fido;

        public FidoController(IFidoAuthentication fido)
        {
            this.fido = fido ?? throw new ArgumentNullException(nameof(fido));
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View();

        [HttpGet]
        [Route("StartRegistration")]
        public IActionResult StartRegistration() => View();

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            //  var challenge = await fido.InitiateRegistration(model.UserId, model.DeviceName);
            /*var dto = new FidoRegistrationChallengeDTO()
            {
                UserId = challenge.UserId,
                UserHandle = challenge.UserHandle,
                Challenge = challenge.Challenge,
                RelyingPartyId = challenge.RelyingPartyId,
                DeviceFriendlyName = challenge.DeviceFriendlyName,
                ExcludedKeyIds = challenge.ExcludedKeyIds ?? (IEnumerable<byte[]>)new List<byte[]>(),
            };*/

            var challenge = await fido.InitiateRegistration(model.UserId, model.DeviceName);

            return View(challenge.ToBase64Dto());
        }

        [HttpPost]
        public async Task<IActionResult> CompleteRegistration([FromBody] Base64FidoRegistrationResponse registrationResponse)
        {
            var result = await fido.CompleteRegistration(registrationResponse.ToFidoResponse());

            if (result.IsError) return BadRequest(result.ErrorDescription);
            return Ok();
        }
    }

    public class RegistrationModel
    {
        public string UserId { get; set; }
        public string DeviceName { get; set; }
    }
}