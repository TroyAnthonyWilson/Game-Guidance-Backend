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
        }

        // GET: api/Question

        [HttpGet("GetAllQuestions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            if(_context.Questions == null)
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



        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {

            if(_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);

            if(question == null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpGet("GetChoicesToQuestionId/{id}")]
public List<Choice> GetChoicesToQuestionId(int id)
{
    var question = _context.Questions.Find(id);


    return _context.Choices.Where(c => c.QuestionId == question.Id).ToList();
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
        public List<Choice> GetChoicesToQuestionId(int id)
        {
            var question = _context.Questions.Find(id);


            return _context.Choices.Where(c => c.QuestionId == question.Id).ToList();
        }


        // PUT: api/Question/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if(id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!QuestionExists(id))
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
            if(_context.Questions == null)
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
            if(_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if(question == null)
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
    }
}