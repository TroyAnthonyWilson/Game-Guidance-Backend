using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer([FromBody] Answer answerObj)
        {
            var newAnswer = new Answer
            {
                Platform = answerObj.Platform,
                GameMode = answerObj.GameMode,
                PlayerPerspective = answerObj.PlayerPerspective,
                Genre = answerObj.Genre,
                Theme = answerObj.Theme,
            };
            _authContext.Answers.Add(newAnswer);
            await _authContext.SaveChangesAsync();
            return newAnswer;
        }

        // POST api/<HomeController>
        [HttpPost("FinalPost")]
        public async Task<IActionResult> FinalPost([FromBody] Answer answer)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/games")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/games", Method.Post);

            List<string> bodybuild = new();
            
            if (answer.Platform != null)
            {
                bodybuild.Add($" platforms = ({answer.Platform}) ");
            }
            if (answer.GameMode != null)
            {
                bodybuild.Add($" game_modes = ({answer.GameMode}) ");
            }
            if (answer.PlayerPerspective != null)
            {
                bodybuild.Add($" player_perspectives=({answer.PlayerPerspective}) ");
            }
            if (answer.Genre != null)
            {
                bodybuild.Add($" genres=({answer.Genre}) ");
            }
            if (answer.Theme != null)
            {
                bodybuild.Add($" themes=({answer.Theme}) ");
            }

            string fields = string.Join(" & ", bodybuild);
            string body = $"fields *; limit 20; where {fields} & category=(0,8,9,11); & status=0 ";

            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            //request.AddHeader("Cookie", "__cf_bm=tArho0gINIfLmN3bLfKD9VmJJXO_zA0icrIpJZwzsdE-1669564263-0-AeA4CPYMcXk+VQzXR0z36LHOrx7xkYr8hr49f/zZZ6EaAcL7B2S7ufy5ixCu/2kMQOqyzps9Vmqx9Y+kWCWKPL0=");
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            //return body;
            //return answer;
            return Ok(response.Content);
        }



        [HttpPost("ChangeAnswer")]
        public async Task<ActionResult<Answer>> ChangeAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            {
                var existingAnswer = _authContext.Answers.FirstOrDefault();

                if (existingAnswer != null)
                {
                    existingAnswer.Platform = answer.Platform;
                    existingAnswer.GameMode = answer.GameMode;
                    existingAnswer.PlayerPerspective = answer.PlayerPerspective;
                    existingAnswer.Genre = answer.Genre;
                    existingAnswer.Theme = answer.Theme;
                    _authContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            if (_authContext.Answers == null)
            {
                return NotFound();
            }
            var answer = await _authContext.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _authContext.Answers.Remove(answer);
            await _authContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetAnswers")]
        public async Task<ActionResult<Answer>> GetAnswers()
        {
            return Ok(await _authContext.Answers.ToListAsync());
        }
    }
}
