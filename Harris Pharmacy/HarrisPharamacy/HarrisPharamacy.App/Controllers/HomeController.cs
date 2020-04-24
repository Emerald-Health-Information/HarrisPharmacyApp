using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rsk.AspNetCore.Fido;
using Rsk.AspNetCore.Fido.Dtos;
using System.Security.Claims;
using HarrisPharmacy.App.Models;
using Microsoft.AspNetCore.Authentication;
using Rsk.AspNetCore.Fido.Models;
using System.Net.Http;
using System.Text;

namespace HarrisPharmacy.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IFidoAuthentication fido;

        public HomeController(IFidoAuthentication fido)
        {
            this.fido = fido ?? throw new ArgumentNullException(nameof(fido));
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View();

        [HttpGet]
        [Route("StartRegistration")]
        public IActionResult StartRegistration() => View();

        [HttpPost("register")]
        public async Task<Base64FidoRegistrationChallenge> Register(RegistrationModel model)
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
            FidoRegistrationChallenge challenge = await fido.InitiateRegistration(model.UserId, model.DeviceName);
            /*var opt = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonUtf8 = JsonSerializer.Serialize<Base64FidoRegistrationChallenge>(challenge.ToBase64Dto(), opt);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("/StartRegistration", UriKind.Relative);
            response.Content = new JsonContent(jsonUtf8, System.Text.Encoding.UTF8);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);*/
            return challenge.ToBase64Dto();
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

    public class JsonContent : StringContent
    {
        public JsonContent(string content) : this(content, Encoding.UTF8)
        {
        }

        public JsonContent(string content, Encoding encoding) : base(content, encoding, "application/json")
        {
        }
    }
}