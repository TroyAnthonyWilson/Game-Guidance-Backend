using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models.IGDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GameGuidanceDBContext _authContext;
        private string clientId = Helpers.IgdbTokens.getClientID();
        private string bearer = Helpers.IgdbTokens.getBearer();

        public GenreController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }

        // POST api/<GenreController>
        [HttpPost("Genres")]
        public string PostGenres([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/genres");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/genres")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/genres", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response.Content;
        }

        [HttpPost("AddGenres")]
        public async Task<IActionResult> AddGenres([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/genres");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/genres")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/genres", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields *; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            List<GenreJsonDeserializer> DeserializedGenres = JsonConvert.DeserializeObject<List<GenreJsonDeserializer>>(response.Content);
            foreach (GenreJsonDeserializer g in DeserializedGenres)
            {
                Genre gr = new() {ApiId = g.Id, Name = g.Name };
                await _authContext.Genres.AddAsync(gr);
                await _authContext.SaveChangesAsync();
            }
            return Ok(response.Content);
        }

        [HttpGet("GetGenres")]
        public async Task<ActionResult<Genre>> GetGenres()
        {
            return Ok(await _authContext.Genres.ToListAsync());
        }
    }
}
