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
        public async Task<ActionResult<Answer>> PostAnswer(int platform, int gameMode, int playerPerpective, int genre, int theme)
        {
            var newAnswer = new Answer
            {
                Platform = platform,
                GameMode = gameMode,
                PlayerPerspective = playerPerpective,
                Genre = genre,
                Theme = theme,
            };
            _authContext.Answers.Add(newAnswer);
            await _authContext.SaveChangesAsync();
            return newAnswer;
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
