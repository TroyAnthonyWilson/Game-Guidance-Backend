using GameGuidanceAPI.Context;
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

        private readonly GameGuidanceDBContext _authContext;

        public AnswerController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }

        [HttpPost("FinalPost")]
        [Authorize]
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
                bodybuild.Add($" player_perspectives=({answer.PlayerPerspective}) ");

            if (answer.Genre != null)
                bodybuild.Add($" genres=({answer.Genre}) ");

            if (answer.Theme != null)
                bodybuild.Add($" themes=({answer.Theme}) ");

            string fields = string.Join(" & ", bodybuild);
            string body = $"fields *; limit 20; where {fields} & category=(0,8,9,11); & status=0 ";

            request.AddHeader("Client-ID", GetClientID());
            request.AddHeader("Authorization", GetBearer());
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return Ok(response.Content);
        }



        //[HttpPost]
        //public async Task<ActionResult<Answer>> PostAnswer([FromBody] Answer answerObj)
        //{
        //    var newAnswer = new Answer
        //    {
        //        Platform = answerObj.Platform,
        //        GameMode = answerObj.GameMode,
        //        PlayerPerspective = answerObj.PlayerPerspective,
        //        Genre = answerObj.Genre,
        //        Theme = answerObj.Theme,
        //    };
        //    _authContext.Answers.Add(newAnswer);
        //    await _authContext.SaveChangesAsync();
        //    return newAnswer;
        //}

        // POST api/<HomeController>

        //[HttpPost("ChangeAnswer")]
        //public async Task<ActionResult<Answer>> ChangeAnswer(Answer answer)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");

        //    {
        //        var existingAnswer = _authContext.Answers.FirstOrDefault();

        //        if (existingAnswer != null)
        //        {
        //            existingAnswer.Platform = answer.Platform;
        //            existingAnswer.GameMode = answer.GameMode;
        //            existingAnswer.PlayerPerspective = answer.PlayerPerspective;
        //            existingAnswer.Genre = answer.Genre;
        //            existingAnswer.Theme = answer.Theme;
        //            _authContext.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }

        //    return Ok();
        //}

        //// DELETE: api/Question/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnswer(int id)
        //{
        //    if (_authContext.Answers == null)
        //    {
        //        return NotFound();
        //    }
        //    var answer = await _authContext.Answers.FindAsync(id);
        //    if (answer == null)
        //    {
        //        return NotFound();
        //    }

        //    _authContext.Answers.Remove(answer);
        //    await _authContext.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpGet("GetAnswers")]
        //public async Task<ActionResult<Answer>> GetAnswers()
        //{
        //    return Ok(await _authContext.Answers.ToListAsync());
        //}
    }
}
