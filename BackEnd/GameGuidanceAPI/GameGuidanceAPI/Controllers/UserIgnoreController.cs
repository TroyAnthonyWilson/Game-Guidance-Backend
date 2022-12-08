using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using static GameGuidanceAPI.Helpers.IgdbTokens;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserIgnoreController : ControllerBase
    {
        private readonly GameGuidanceDBContext _authContext;

        public UserIgnoreController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }

        [HttpPost("addignore")]
        public async Task<IActionResult> Post(int gameId)
        {
            var authHeader = Request.Headers["Authorization"];
            var tokenString = authHeader.ToString().Split(" ")[1];
            User user = _authContext.Users.Where(u => u.Token == tokenString).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }
            var client = new RestClient("https://api.igdb.com/v4/games");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/games")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/games", Method.Post);
            request.AddHeader("Client-ID", GetClientID());
            request.AddHeader("Authorization", GetBearer());
            request.AddHeader("Content-Type", "text/plain");
            var body = $"fields *;where id = {gameId};";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                List<JsonDeserializer> myDeserializedClass = JsonConvert.DeserializeObject<List<JsonDeserializer>>(response.Content);

                if (myDeserializedClass.Count != null)
                {
                    JsonDeserializer myGame = myDeserializedClass[0];

                    UserIgnore userIgnore = new()
                    {
                        UserId = user.Id,
                        GameId = myGame.id.Value,
                        Name = myGame.name,
                        Summary = myGame.summary,
                    };

                    if (await CheckUserAlreadyIgnoredAsync(userIgnore.UserId, userIgnore.GameId))
                        return Ok(new { message = "Ignore Already Exists!" });

                    await _authContext.UserIgnores.AddAsync(userIgnore);
                    await _authContext.SaveChangesAsync();

                    return Ok(new { Message = $"{myGame.name} added to ignore list." });
                }
            }
            return BadRequest();
        }

        //remove user ignore
        [HttpDelete("removeignore")]
        public async Task<IActionResult> Delete(int gameId)
        {
            var authHeader = Request.Headers["Authorization"];
            var tokenString = authHeader.ToString().Split(" ")[1];
            User user = _authContext.Users.Where(u => u.Token == tokenString).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }

            if (await CheckUserAlreadyIgnoredAsync(user.Id, gameId))
            {
                UserIgnore userIgnore = await _authContext.UserIgnores.Where(u => u.UserId == user.Id && u.GameId == gameId).FirstOrDefaultAsync();
                _authContext.UserIgnores.Remove(userIgnore);
                await _authContext.SaveChangesAsync();
                return Ok(new { Message = "Favorite Removed!" });
            }
            return BadRequest();
        }


        //get ignores
        [HttpGet("getignores")]
        public async Task<IActionResult> Get()
        {
            var authHeader = Request.Headers["Authorization"];
            var tokenString = authHeader.ToString().Split(" ")[1];
            User user = _authContext.Users.Where(u => u.Token == tokenString).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }

            List<UserIgnore> userIgnores = await _authContext.UserIgnores.Where(u => u.UserId == user.Id).ToListAsync();
            return Ok(userIgnores);
        }

        private async Task<bool> CheckUserAlreadyIgnoredAsync(int userId, int gameId)
          => await _authContext.UserIgnores.AnyAsync(x => x.UserId == userId && x.GameId == gameId);
    }
}
