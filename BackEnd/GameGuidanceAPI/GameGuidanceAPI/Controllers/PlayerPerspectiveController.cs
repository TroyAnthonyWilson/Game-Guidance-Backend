//using GameGuidanceAPI.Context;
//using GameGuidanceAPI.Models.IGDB;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using RestSharp;

//namespace GameGuidanceAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PlayerPerspectiveController : ControllerBase
//    {
//        private readonly GameGuidanceDBContext _authContext;
//        private string clientId = Helpers.IgdbTokens.GetClientID();
//        private string bearer = Helpers.IgdbTokens.GetBearer();

//        public PlayerPerspectiveController(GameGuidanceDBContext gameGuidanceDBContext)
//        {
//            _authContext = gameGuidanceDBContext;
//        }

//        // POST api/<PlayerPerspectiveController>
//        [HttpPost("PlayerPerspectives")]
//        public string PostPlayerPerspectives([FromBody] string value)
//        {
//            var client = new RestClient("https://api.igdb.com/v4/player_perspectives");
//            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/player_perspectives")
//            {
//                ThrowOnAnyError = true,
//                MaxTimeout = -1
//            };
//            var request = new RestRequest("https://api.igdb.com/v4/player_perspectives", Method.Post);
//            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
//            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
//            request.AddHeader("Content-Type", "text/plain");
//            var body = @"fields name; limit 500; ";
//            request.AddParameter("text/plain", body, ParameterType.RequestBody);
//            RestResponse response = client.Execute(request);
//            return response.Content;
//        }

//        [HttpPost("AddPlayerPerspectives")]
//        public async Task<IActionResult> AddplayerPerspectives([FromBody] string value)
//        {
//            var client = new RestClient("https://api.igdb.com/v4/player_perspectives");
//            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/player_perspectives")
//            {
//                ThrowOnAnyError = true,
//                MaxTimeout = -1
//            };
//            var request = new RestRequest("https://api.igdb.com/v4/player_perspectives", Method.Post);
//            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
//            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
//            request.AddHeader("Content-Type", "text/plain");
//            var body = @"fields *; limit 500; ";
//            request.AddParameter("text/plain", body, ParameterType.RequestBody);
//            RestResponse response = client.Execute(request);
//            List<PlayerPerspectiveJsonDeserializer> DeserializedPlayerPerspectives = JsonConvert.DeserializeObject<List<PlayerPerspectiveJsonDeserializer>>(response.Content);
//            foreach (PlayerPerspectiveJsonDeserializer p in DeserializedPlayerPerspectives)
//            {
//                PlayerPerspective pl = new() {ApiId = p.Id, Name = p.Name };
//                await _authContext.PlayerPerspectives.AddAsync(pl);
//                await _authContext.SaveChangesAsync();
//            }
//            return Ok(response.Content);
//        }

//        [HttpGet("GetPlayerPerspectives")]
//        public async Task<ActionResult<PlayerPerspective>> GetPlayerPerspectives()
//        {
//            return Ok(await _authContext.PlayerPerspectives.ToListAsync());
//        }
//    }
//}
