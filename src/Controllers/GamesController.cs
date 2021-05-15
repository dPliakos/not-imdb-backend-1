using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.Controllers
{
  [Authorize(Roles = "admin, user")]
  [ApiController]
  [Route("[controller]")]
  public class GamesController : ControllerBase
  {
    private readonly ILogger<GamesController> _logger;
    private readonly ApplicationDbContext _context;


    public GamesController(
      ILogger<GamesController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> list()
    {

      var polls = await this._context.Questions
        .Where(q => q.additionalType == Question.GAME)
        .Include("answers")
        .ToArrayAsync();

      return polls;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> show(int id)
    {
      Question poll = await this._context.Questions
        .Where(q => q.Id == id && q.additionalType == Question.GAME)
        .Include("answers")
        .FirstOrDefaultAsync();

      if (poll is null)
      {
        return NotFound();
      }

      return poll;
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult<Question>> create(Question question)
    {

      question.additionalType = Question.GAME;
      if (question.datePublished.Equals(new DateTime()))
      {
        question.datePublished = DateTime.UtcNow;
      }

      string message = null;
      if (question.optionSet is null)
      {
        message = "Option set can not be empty";
      }
      else if (question.dateCreated > question.endDate)
      {
        message = "End date can not be earlier than start date";
      }
      else if (question.datePublished > question.endDate)
      {
        message = "Published date can not be earlier than start date";
      }

      if (!(message is null))
      {
        object error = new
        {
          message = message
        };
        return BadRequest(error);
      }

      this._context.Questions.Add(question);
      await this._context.SaveChangesAsync();
      return question;
    }

    [Authorize(Roles = "admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Question>> update(int id, QuestionUpdateDto q)
    {
      if (id != q.Id)
      {
        return BadRequest();
      }

      Question localQ = await this._context.Questions.Where(q => q.Id == id && q.additionalType == Question.GAME).FirstOrDefaultAsync();
      if (localQ is null)
      {
        return NotFound();
      }

      var question = new Question()
      {
        Id = localQ.Id,
        title = q.title is null ? localQ.title : q.title,
        startDate = q.startDate.Equals(new DateTime()) ? localQ.startDate : q.datePublished,
        endDate = q.endDate.Equals(new DateTime()) ? localQ.endDate : q.datePublished,
        datePublished = q.datePublished.Equals(new DateTime()) ? localQ.datePublished : q.datePublished,
        description = q.description is null ? localQ.description : q.description,
        correctAnswer = q.correctAnswer <= 0 ? localQ.correctAnswer : q.correctAnswer,
        additionalType = localQ.additionalType,
        alternateName = localQ.alternateName,
        optionSet = localQ.optionSet,
        dateModified = DateTime.UtcNow,
        dateCreated = localQ.dateCreated,
        answers = localQ.answers is null ? new List<VoteAction>() : localQ.answers
      };

      this._context.Entry(localQ).State = EntityState.Detached;
      this._context.Entry(question).State = EntityState.Modified;

      await this._context.SaveChangesAsync();
      Question updated = await this._context.Questions
        .Where(q => q.Id == id && q.additionalType == Question.GAME)
        .Include("answers")
        .FirstOrDefaultAsync();

      return updated;
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Question>> delete(int id)
    {

      // Find the user in the database
      var question = await _context.Questions.Where(q => q.Id == id && q.additionalType == Question.GAME).FirstOrDefaultAsync();
      if (question == null)
      {
        return NotFound();
      }

      this._context.Entry(question).State = EntityState.Deleted;
      await this._context.SaveChangesAsync();
      return question;
    }
  }
}
