using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models;
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
    public class GameModeController : ControllerBase
    {

        private readonly GameGuidanceDBContext _authContext;
        private string clientId = Helpers.IgdbTokens.getClientID();
        private string bearer = Helpers.IgdbTokens.getBearer();

        public GameModeController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }

        // POST api/<GameModeController>
        [HttpPost("GameModes")]
        public string PostGameModes([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/game_modes");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/game_modes")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/game_modes", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response.Content;
        }

        [HttpPost("AddGameModes")]
        public async Task<IActionResult> AddGameModes([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/game_modes");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/game_modes")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/game_modes", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields *; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            List<GameModeJsonDeserializer> DeserializedGameModes = JsonConvert.DeserializeObject<List<GameModeJsonDeserializer>>(response.Content);
            foreach (GameModeJsonDeserializer g in DeserializedGameModes)
            {
                GameMode gm = new() {ApiId = g.Id, Name = g.Name};
                await _authContext.GameModes.AddAsync(gm);
                await _authContext.SaveChangesAsync();
            }
            return Ok(response.Content);
        }

        [HttpGet("GetGameModes")]
        public async Task<ActionResult<GameMode>> GetGameModes()
        {
            return Ok(await _authContext.GameModes.ToListAsync());
        }
    }
}
