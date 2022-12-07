using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using GameGuidanceAPI.Models;
using RestSharp;
using GameGuidanceAPI.Helpers;
using GameGuidanceAPI.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GameGuidanceAPI.Controllers;
using Microsoft.EntityFrameworkCore.ChangeTracking;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly GameGuidanceDBContext _authContext;
        private string clientId = Helpers.IgdbTokens.GetClientID();
        private string bearer = Helpers.IgdbTokens.GetBearer();



        public HomeController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;

        }

        // POST api/<HomeController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/games")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/games", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Cookie", "__cf_bm=tArho0gINIfLmN3bLfKD9VmJJXO_zA0icrIpJZwzsdE-1669564263-0-AeA4CPYMcXk+VQzXR0z36LHOrx7xkYr8hr49f/zZZ6EaAcL7B2S7ufy5ixCu/2kMQOqyzps9Vmqx9Y+kWCWKPL0=");
            var body = @"fields *;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response.Content;
        }

    }  
}
