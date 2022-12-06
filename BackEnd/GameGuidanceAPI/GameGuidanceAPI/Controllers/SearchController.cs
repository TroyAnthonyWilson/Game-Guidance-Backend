using GameGuidanceAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly GameGuidanceDBContext _authContext;
        private readonly string clientId = Helpers.IgdbTokens.GetClientID();
        private readonly string bearer = Helpers.IgdbTokens.GetBearer();


        [HttpGet("search")]
        public async Task<IActionResult> Get(string search)
        {

            var client = new RestClient("https://api.igdb.com/v4/games");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/games")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/games", Method.Post);
            request.AddHeader("Client-ID", clientId);
            request.AddHeader("Authorization", bearer);
            request.AddHeader("Content-Type", "text/plain");
            var body = $"fields *;search \"{search}\";limit 50;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            return Ok(response.Content);
        }
    }
}
