using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using GameGuidanceAPI.Models;
using RestSharp;
using GameGuidanceAPI.Helpers;
using GameGuidanceAPI.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Sockets;
using GameGuidanceAPI.Models.IGDB;


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
        public async Task<string> FinalPost([FromBody] Answer answer)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            RestClientOptions options = new RestClientOptions("https://api.igdb.com/v4/games")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var request = new RestRequest("https://api.igdb.com/v4/games", Method.Post);
            request.AddHeader("Client-ID", "n9kcwb4ynvskjy7bd147jk94tdt6yw");
            request.AddHeader("Authorization", "Bearer 1w3wtuaj6g10l2zttajubqwveonvtf");
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Cookie", "__cf_bm=tArho0gINIfLmN3bLfKD9VmJJXO_zA0icrIpJZwzsdE-1669564263-0-AeA4CPYMcXk+VQzXR0z36LHOrx7xkYr8hr49f/zZZ6EaAcL7B2S7ufy5ixCu/2kMQOqyzps9Vmqx9Y+kWCWKPL0=");
            var body = $"fields name; limit 1; where game_modes=({answer.GameMode}); where genres=({answer.Genre}) & " +
                $"player_perspectives=({answer.PlayerPerspective}) & themes=({answer.Theme}) & category=(0,8,9,11); & status=0 & " +
                $"where platforms=({answer.Platform});";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(body);
            return response.Content;
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
