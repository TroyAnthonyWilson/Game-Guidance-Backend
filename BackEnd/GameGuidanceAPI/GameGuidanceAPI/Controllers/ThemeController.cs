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
    public class ThemeController : ControllerBase
    {
        private readonly GameGuidanceDBContext _authContext;
        private string clientId = Helpers.IgdbTokens.GetClientID();
        private string bearer = Helpers.IgdbTokens.GetBearer();

        public ThemeController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }

        // POST api/<ThemeController>
        [HttpPost("Themes")]
        public string PostThemes([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/themes");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/themes")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/themes", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response.Content;
        }

        [HttpPost("AddThemes")]
        public async Task<IActionResult> AddThemes([FromBody] string value)
        {
            var client = new RestClient("https://api.igdb.com/v4/themes");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/themes")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/themes", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields *; limit 500; ";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            List<ThemeJsonDeserializer> DeserializedThemes = JsonConvert.DeserializeObject<List<ThemeJsonDeserializer>>(response.Content);
            foreach (ThemeJsonDeserializer g in DeserializedThemes)
            {
                Theme gr = new() {ApiId = g.Id, Name = g.Name };
                await _authContext.Themes.AddAsync(gr);
                await _authContext.SaveChangesAsync();
            }
            return Ok(response.Content);
        }

        [HttpGet("GetThemes")]
        public async Task<ActionResult<Theme>> GetThemes()
        {
            return Ok(await _authContext.Themes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            var theme = await _authContext.Themes.FindAsync(id);
            if (theme == null)
            {
                return NotFound();
            }

            _authContext.Themes.Remove(theme);
            await _authContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
