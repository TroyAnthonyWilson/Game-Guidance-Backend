using GameGuidanceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using static GameGuidanceAPI.Helpers.IgdbTokens;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {

        public AnswerController() { }

        [HttpPost("FinalPost"), Authorize]
        public async Task<IActionResult> FinalPost([FromBody] Answer answer)
        {
            var client = new RestClient(GetBaseUrl());
            RestClientOptions options = new RestClientOptions(GetBaseUrl())
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest(GetBaseUrl(), Method.Post);

            List<string> bodybuild = new();

            if (answer.Platform != null)
                bodybuild.Add($" platforms = ({answer.Platform}) ");

            if (answer.GameMode != null)
                bodybuild.Add($" game_modes = ({answer.GameMode}) ");

            if (answer.PlayerPerspective != null)
                bodybuild.Add($" player_perspectives = ({answer.PlayerPerspective}) ");

            if (answer.Genre != null)
                bodybuild.Add($" genres = ({answer.Genre}) ");

            if (answer.Theme != null)
                bodybuild.Add($" themes = ({answer.Theme}) ");

            if (answer.Rating != null)
                bodybuild.Add($" rating >= {answer.Rating}");

            string fields = string.Join(" & ", bodybuild);
            string body = $"fields *; limit 20; where {fields} & category=(0,8,9,11); sort rating desc;";

            request.AddHeader("Client-ID", GetClientID());
            request.AddHeader("Authorization", GetBearer());
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Ok(response.Content);
        }
    }
}
