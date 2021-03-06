﻿/*

Harrison1 COSC 471 2019

File = HomeController

Author = Taylor Adam

Date = 2020-03-20	

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam	2020-03-20			Created

*/
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController : Controller
{
    public async Task<ChatConfig> Index()
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

        var config = new ChatConfig()
        {
            Token = token,
            UserId = Guid.NewGuid().ToString()
        };

        return config;
    }
}

public class DirectLineToken
{
    public string conversationId { get; set; }
    public string token { get; set; }
    public int expires_in { get; set; }
}

public class ChatConfig
{
    public string Token { get; set; }
    public string UserId { get; set; }
}