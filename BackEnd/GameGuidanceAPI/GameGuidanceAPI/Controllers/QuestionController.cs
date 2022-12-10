using GameGuidanceAPI.Context;
using GameGuidanceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("GetChoicesToQuestionId/{id}")]
        [Authorize]
        public List<Choice> GetChoicesToQuestionId(int id)
        {
            var question = _context.Questions.Find(id);
            return _context.Choices.Where(c => c.QuestionId == question.Id).ToList();
        }


        private string question1 = "What systems would you like to play on?";
        private string question2 = "What kind of gameplay would you like?";
        private string question3 = "What Genre of game are you interested in?";
        private string question4 = "What perspective would you prefer in your next game?";
        private string question5 = "Which of these themes appeals to you the most?";
        private string question6 = "What would you like the average reviewed rating to be?";

        private void AddQuestionsToDb()
        {



            if (_context.Questions.Count() == 0)
            {
                _context.Questions.Add(new Question { QuestionName = question1 });
                _context.Questions.Add(new Question { QuestionName = question2 });
                _context.Questions.Add(new Question { QuestionName = question3 });
                _context.Questions.Add(new Question { QuestionName = question4 });
                _context.Questions.Add(new Question { QuestionName = question5 });
                _context.Questions.Add(new Question { QuestionName = question6 });
                _context.SaveChanges();
            }
        }

        private void AddChoicesToDb()
        {
            if (_context.Choices.Count() == 0)
            {

                //question 1
                int questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question1).Id;

                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 2", QuestionId = questionId, ApiChoiceId = 8 });
                _context.Choices.Add(new Choice { ChoiceName = "PC (Microsoft Windows)", QuestionId = questionId, ApiChoiceId = 6 });
                _context.Choices.Add(new Choice { ChoiceName = "Dreamcast", QuestionId = questionId, ApiChoiceId = 23 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo Switch", QuestionId = questionId, ApiChoiceId = 130 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox", QuestionId = questionId, ApiChoiceId = 11 });
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy Advance", QuestionId = questionId, ApiChoiceId = 24 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo 64", QuestionId = questionId, ApiChoiceId = 4 });
                _context.Choices.Add(new Choice { ChoiceName = "Wii U'", QuestionId = questionId, ApiChoiceId = 41 });
                _context.Choices.Add(new Choice { ChoiceName = "Web browser", QuestionId = questionId, ApiChoiceId = 82 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo Entertainment System", QuestionId = questionId, ApiChoiceId = 18 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo 3DS", QuestionId = questionId, ApiChoiceId = 37 });
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy Color", QuestionId = questionId, ApiChoiceId = 22 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation Portable", QuestionId = questionId, ApiChoiceId = 38 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 3", QuestionId = questionId, ApiChoiceId = 9 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo DS", QuestionId = questionId, ApiChoiceId = 20 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 4", QuestionId = questionId, ApiChoiceId = 48 });
                _context.Choices.Add(new Choice { ChoiceName = "Nintendo GameCube", QuestionId = questionId, ApiChoiceId = 21 });
                _context.Choices.Add(new Choice { ChoiceName = "Super Nintendo Entertainment System", QuestionId = questionId, ApiChoiceId = 19 });
                _context.Choices.Add(new Choice { ChoiceName = "New Nintendo 3DS", QuestionId = questionId, ApiChoiceId = 137 });
                _context.Choices.Add(new Choice { ChoiceName = "Game Boy", QuestionId = questionId, ApiChoiceId = 33 });
                _context.Choices.Add(new Choice { ChoiceName = "Wii", QuestionId = questionId, ApiChoiceId = 5 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation 5", QuestionId = questionId, ApiChoiceId = 167 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox Series X|S", QuestionId = questionId, ApiChoiceId = 169 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox 360", QuestionId = questionId, ApiChoiceId = 12 });
                _context.Choices.Add(new Choice { ChoiceName = "Xbox One", QuestionId = questionId, ApiChoiceId = 49 });
                _context.Choices.Add(new Choice { ChoiceName = "PlayStation", QuestionId = questionId, ApiChoiceId = 7 });


                //question 2

                questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question2).Id;

                _context.Choices.Add(new Choice { ChoiceName = "Single player", QuestionId = questionId, ApiChoiceId = 1 });
                _context.Choices.Add(new Choice { ChoiceName = "Multiplayer", QuestionId = questionId, ApiChoiceId = 2 });
                _context.Choices.Add(new Choice { ChoiceName = "Co-operative", QuestionId = questionId, ApiChoiceId = 3 });
                _context.Choices.Add(new Choice { ChoiceName = "Split screen", QuestionId = questionId, ApiChoiceId = 4 });
                _context.Choices.Add(new Choice { ChoiceName = "Massively Multiplayer Online (MMO)", QuestionId = questionId, ApiChoiceId = 5 });
                _context.Choices.Add(new Choice { ChoiceName = "Battle Royale", QuestionId = questionId, ApiChoiceId = 6 });



                //question 3
                questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question3).Id;

                _context.Choices.Add(new Choice { ChoiceName = "Point-and-click", QuestionId = questionId, ApiChoiceId = 2 });
                _context.Choices.Add(new Choice { ChoiceName = "Fighting", QuestionId = questionId, ApiChoiceId = 4 });
                _context.Choices.Add(new Choice { ChoiceName = "Shooter", QuestionId = questionId, ApiChoiceId = 5 });
                _context.Choices.Add(new Choice { ChoiceName = "Music", QuestionId = questionId, ApiChoiceId = 7 });
                _context.Choices.Add(new Choice { ChoiceName = "Platform", QuestionId = questionId, ApiChoiceId = 8 });
                _context.Choices.Add(new Choice { ChoiceName = "Puzzle", QuestionId = questionId, ApiChoiceId = 9 });
                _context.Choices.Add(new Choice { ChoiceName = "Racing", QuestionId = questionId, ApiChoiceId = 10 });
                _context.Choices.Add(new Choice { ChoiceName = "Real Time Strategy (RTS)", QuestionId = questionId, ApiChoiceId = 11 });
                _context.Choices.Add(new Choice { ChoiceName = "Role-playing (RPG)", QuestionId = questionId, ApiChoiceId = 12 });
                _context.Choices.Add(new Choice { ChoiceName = "Simulator", QuestionId = questionId, ApiChoiceId = 13 });
                _context.Choices.Add(new Choice { ChoiceName = "Sport", QuestionId = questionId, ApiChoiceId = 14 });
                _context.Choices.Add(new Choice { ChoiceName = "Strategy", QuestionId = questionId, ApiChoiceId = 15 });
                _context.Choices.Add(new Choice { ChoiceName = "Turn-based strategy (TBS)", QuestionId = questionId, ApiChoiceId = 16 });
                _context.Choices.Add(new Choice { ChoiceName = "Tactical", QuestionId = questionId, ApiChoiceId = 24 });
                _context.Choices.Add(new Choice { ChoiceName = "Hack and slash/Beat em up", QuestionId = questionId, ApiChoiceId = 25 });
                _context.Choices.Add(new Choice { ChoiceName = "Quiz/Trivia", QuestionId = questionId, ApiChoiceId = 26 });
                _context.Choices.Add(new Choice { ChoiceName = "Pinball", QuestionId = questionId, ApiChoiceId = 30 });
                _context.Choices.Add(new Choice { ChoiceName = "Adventure", QuestionId = questionId, ApiChoiceId = 31 });
                _context.Choices.Add(new Choice { ChoiceName = "Indie", QuestionId = questionId, ApiChoiceId = 32 });
                _context.Choices.Add(new Choice { ChoiceName = "Arcade", QuestionId = questionId, ApiChoiceId = 33 });
                _context.Choices.Add(new Choice { ChoiceName = "Visual Novel", QuestionId = questionId, ApiChoiceId = 34 });
                _context.Choices.Add(new Choice { ChoiceName = "Card & Board Game", QuestionId = questionId, ApiChoiceId = 35 });
                _context.Choices.Add(new Choice { ChoiceName = "MOBA", QuestionId = questionId, ApiChoiceId = 36 });


                //question 4
                questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question4).Id;

                _context.Choices.Add(new Choice { ChoiceName = "First person", QuestionId = questionId, ApiChoiceId = 1 });
                _context.Choices.Add(new Choice { ChoiceName = "Third person", QuestionId = questionId, ApiChoiceId = 2 });
                _context.Choices.Add(new Choice { ChoiceName = "Bird view / Isometric", QuestionId = questionId, ApiChoiceId = 3 });
                _context.Choices.Add(new Choice { ChoiceName = "Side view", QuestionId = questionId, ApiChoiceId = 4 });
                _context.Choices.Add(new Choice { ChoiceName = "Text", QuestionId = questionId, ApiChoiceId = 5 });
                _context.Choices.Add(new Choice { ChoiceName = "Auditory", QuestionId = questionId, ApiChoiceId = 6 });
                _context.Choices.Add(new Choice { ChoiceName = "Virtual Reality", QuestionId = questionId, ApiChoiceId = 7 });


                //question 5
                questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question5).Id;

                _context.Choices.Add(new Choice { ChoiceName = "Thriller", QuestionId = questionId, ApiChoiceId = 20 });
                _context.Choices.Add(new Choice { ChoiceName = "Science fiction", QuestionId = questionId, ApiChoiceId = 18 });
                _context.Choices.Add(new Choice { ChoiceName = "Action", QuestionId = questionId, ApiChoiceId = 1 });
                _context.Choices.Add(new Choice { ChoiceName = "Horror", QuestionId = questionId, ApiChoiceId = 19 });
                _context.Choices.Add(new Choice { ChoiceName = "Survival", QuestionId = questionId, ApiChoiceId = 21 });
                _context.Choices.Add(new Choice { ChoiceName = "Fantasy", QuestionId = questionId, ApiChoiceId = 17 });
                _context.Choices.Add(new Choice { ChoiceName = "Historical", QuestionId = questionId, ApiChoiceId = 22 });
                _context.Choices.Add(new Choice { ChoiceName = "Stealth", QuestionId = questionId, ApiChoiceId = 23 });
                _context.Choices.Add(new Choice { ChoiceName = "Comedy", QuestionId = questionId, ApiChoiceId = 27 });
                _context.Choices.Add(new Choice { ChoiceName = "Business", QuestionId = questionId, ApiChoiceId = 28 });
                _context.Choices.Add(new Choice { ChoiceName = "Drama", QuestionId = questionId, ApiChoiceId = 31 });
                _context.Choices.Add(new Choice { ChoiceName = "Non-fiction", QuestionId = questionId, ApiChoiceId = 32 });
                _context.Choices.Add(new Choice { ChoiceName = "Kids", QuestionId = questionId, ApiChoiceId = 35 });
                _context.Choices.Add(new Choice { ChoiceName = "Sandbox", QuestionId = questionId, ApiChoiceId = 33 });
                _context.Choices.Add(new Choice { ChoiceName = "Open world", QuestionId = questionId, ApiChoiceId = 38 });
                _context.Choices.Add(new Choice { ChoiceName = "Warfare", QuestionId = questionId, ApiChoiceId = 39 });
                _context.Choices.Add(new Choice { ChoiceName = "4X (explore, expand, exploit, and exterminate)", QuestionId = questionId, ApiChoiceId = 41 });
                _context.Choices.Add(new Choice { ChoiceName = "Educational", QuestionId = questionId, ApiChoiceId = 34 });
                _context.Choices.Add(new Choice { ChoiceName = "Mystery", QuestionId = questionId, ApiChoiceId = 43 });
                _context.Choices.Add(new Choice { ChoiceName = "Party", QuestionId = questionId, ApiChoiceId = 40 });


                //question 6
                questionId = _context.Questions.FirstOrDefault(q => q.QuestionName == question6).Id;

                _context.Choices.Add(new Choice { ChoiceName = ">=50", QuestionId = questionId, ApiChoiceId = 0 });
                _context.Choices.Add(new Choice { ChoiceName = ">=60", QuestionId = questionId, ApiChoiceId = 0 });
                _context.Choices.Add(new Choice { ChoiceName = ">=70", QuestionId = questionId, ApiChoiceId = 0 });
                _context.Choices.Add(new Choice { ChoiceName = ">=80", QuestionId = questionId, ApiChoiceId = 0 });
                _context.Choices.Add(new Choice { ChoiceName = ">=90", QuestionId = questionId, ApiChoiceId = 0 });



                _context.SaveChanges();
            }
        }

        //// GET: api/Question
        //[HttpGet("GetAllChoices")]
        //public async Task<ActionResult<IEnumerable<Choice>>> GetAllChoices()
        //{
        //    if (_context.Choices == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Choices.ToListAsync();
        //}


        //// GET: api/Question
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        //{
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Questions.ToListAsync();
        //}


        //// PUT: api/Question/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuestion(int id, Question question)
        //{
        //    if (id != question.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(question).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Question
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Question>> PostQuestion(Question question)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return Problem("Entity set 'GameGuidanceDBContext.Questions'  is null.");
        //    }
        //    _context.Questions.Add(question);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        //}

        //// POST: api/AddChoicesToQuestion
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("AddChoicesToQuestion")]
        //public void AddChoicesToQuestion(int questionId, List<string> choicesList)
        //{
        //    Question q = _context.Questions.FirstOrDefault(q => q.Id == questionId);

        //    // add choices to database
        //    choicesList.ForEach(choiceOption =>
        //    {
        //        Choice newChoice = new Choice();
        //        newChoice.QuestionId = q.Id;
        //        newChoice.ChoiceName = choiceOption;
        //        _context.Choices.Add(newChoice);
        //        _context.SaveChanges();
        //    });
        //}




        //// DELETE: api/Question/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuestion(int id)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }
        //    var question = await _context.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Questions.Remove(question);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QuestionExists(int id)
        //{
        //    return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}