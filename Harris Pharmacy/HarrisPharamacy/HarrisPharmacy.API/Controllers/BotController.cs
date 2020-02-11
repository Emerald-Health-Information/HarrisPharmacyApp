using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HarrisPharmacy.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers
{
    public class BotController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var secret = "h_HVarww4aY.0QYBDvzG21lZGN4-czsO9w7XPLkgW9cTWAC_VvsULl0";
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                $" https://directline.botframework.com/v3/directline/tokens/generate");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", secret);

            var userId = $"dl_{Guid.NewGuid()}";
            request.Content = new StringContent(
                JsonConvert.SerializeObject(
                    new { User = new { Id = userId } }),
                Encoding.UTF8,
                "application/json");

            var response = await client.SendAsync(request);
            string token = String.Empty;

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<DirectLineToken>(body).token;
            }
            var config = new ConfigModel();
            config.UserId = Guid.NewGuid().ToString();
            config.Token = token;
            return View("../Views/BotView", config);
        }
    }

    public class DirectLineToken
    {
        public string conversationId { get; set; }
        public string token { get; set; }
        public int expires_in { get; set; }
    }
}