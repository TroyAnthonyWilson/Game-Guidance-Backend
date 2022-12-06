using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly GameGuidanceDBContext _context;

        public QuestionController(GameGuidanceDBContext context)
        {
            _context = context;
            AddQuestionsToDb();
            AddChoicesToDb();
        }

        [HttpGet("GetAllQuestions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Question
        [HttpGet("GetAllChoices")]
        public async Task<ActionResult<IEnumerable<Choice>>> GetAllChoices()
        {
            if (_context.Choices == null)
            {
                return NotFound();
            }
            return await _context.Choices.ToListAsync();
        }


        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            return await _context.Questions.ToListAsync();
        }


        // PUT: api/Question/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Question
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'GameGuidanceDBContext.Questions'  is null.");
            }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // POST: api/AddChoicesToQuestion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddChoicesToQuestion")]
        public void AddChoicesToQuestion(int questionId, List<string> choicesList)
        {
            Question q = _context.Questions.FirstOrDefault(q => q.Id == questionId);

            // add choices to database
            choicesList.ForEach(choiceOption =>
            {
                Choice newChoice = new Choice();
                newChoice.QuestionId = q.Id;
                newChoice.ChoiceName = choiceOption;
                _context.Choices.Add(newChoice);
                _context.SaveChanges();
            });
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        private void AddQuestionsToDb()
        {
            if (_context.Questions.Count() == 0)
            {
                _context.Questions.Add(new Question { QuestionName = "What systems would you like to play on?" });
                _context.Questions.Add(new Question { QuestionName = "Do you want Single or Multiplayer?" });
                _context.Questions.Add(new Question { QuestionName = "What is your age range?" });
                _context.Questions.Add(new Question { QuestionName = "What Genre of game are you interested in?" });
                _context.Questions.Add(new Question { QuestionName = "What perspective would you prefer in your next game?" });
                _context.Questions.Add(new Question { QuestionName = "Which of these themes appeals to you the most?" });
                _context.Questions.Add(new Question { QuestionName = "What is the minimum rating?" });
                _context.SaveChanges();
            }
        }

        private void AddChoicesToDb()
        {
            if (_context.Choices.Count() == 0)
            {
                int questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == "What systems would you like to play on?").Id;
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 2", QuestionId = questionId , ApiChoiceId = 8});
                _context.Choices.Add(new Choice { ChoiceName = "PC (Microsoft Windows)", QuestionId = questionId , ApiChoiceId = 6});
                _context.Choices.Add(new Choice { ChoiceName = "Dreamcast", QuestionId = questionId , ApiChoiceId = 23});
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo Switch", QuestionId = questionId , ApiChoiceId = 130});
                _context.Choices.Add(new Choice { ChoiceName = "Xbox", QuestionId = questionId , ApiChoiceId = 11});
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy Advance", QuestionId = questionId , ApiChoiceId = 24});
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo 64", QuestionId = questionId , ApiChoiceId = 4});
                _context.Choices.Add(new Choice { ChoiceName = "Wii U'", QuestionId = questionId , ApiChoiceId = 41});
                _context.Choices.Add(new Choice { ChoiceName = "Web browser", QuestionId = questionId , ApiChoiceId = 82});
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo Entertainment System", QuestionId = questionId , ApiChoiceId = 18});
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo 3DS", QuestionId = questionId , ApiChoiceId = 37});
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy Color", QuestionId = questionId , ApiChoiceId = 22});
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation Portable", QuestionId = questionId , ApiChoiceId = 38});
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 3", QuestionId = questionId , ApiChoiceId = 9 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo DS", QuestionId = questionId , ApiChoiceId = 20 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 4", QuestionId = questionId , ApiChoiceId = 48 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo GameCube", QuestionId = questionId , ApiChoiceId = 21 });
                _context.Choices.Add(new Choice { ChoiceName = "Super Nintendo Entertainment System", QuestionId = questionId , ApiChoiceId = 19 });
                _context.Choices.Add(new Choice { ChoiceName = "New Nintendo 3DS", QuestionId = questionId , ApiChoiceId = 137 });
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy", QuestionId = questionId , ApiChoiceId = 33 });
                _context.Choices.Add(new Choice { ChoiceName = "Wii", QuestionId = questionId , ApiChoiceId = 5 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 5", QuestionId = questionId , ApiChoiceId = 167 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox Series X|S", QuestionId = questionId , ApiChoiceId = 169 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox 360", QuestionId = questionId , ApiChoiceId = 12 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox One", QuestionId = questionId, ApiChoiceId = 49 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation", QuestionId = questionId, ApiChoiceId = 7 });              
                _context.SaveChanges();
            }
        }
    }
}