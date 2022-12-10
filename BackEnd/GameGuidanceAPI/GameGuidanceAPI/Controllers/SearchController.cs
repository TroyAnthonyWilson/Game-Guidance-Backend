using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using static GameGuidanceAPI.Helpers.IgdbTokens;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> Get(string search)
        {

            var client = new RestClient(GetBaseUrl());
            RestClientOptions options = new RestClientOptions(GetBaseUrl())
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest(GetBaseUrl(), Method.Post);
            request.AddHeader("Client-ID", GetClientID());
            request.AddHeader("Authorization", GetBearer());
            request.AddHeader("Content-Type", "text/plain");
            var body = $"fields *;search \"{search}\";limit 50;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            return Ok(response.Content);
        }
    }
}
