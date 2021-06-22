using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ApplicationTEST.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public QuestionController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("getAllQuestions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            return await _context.Questions.ToListAsync();
   
        }

        [HttpPost]
        [Route("AddQuestion/{id}")]
        public async Task<IActionResult> AddQuestion(int id, [FromBody] Question question)
        {
            var noteq = new Note_Question();
            var examen = await _context.Examens.FindAsync(id);

            if (examen != null)
            {
                noteq.examen = examen;
                noteq.question = question;
                _context.Add(question);
                _context.Add(noteq);

                _context.SaveChanges();
                return Ok(new
                {
                    question
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteQuestion/{id}")]
        public async Task<IActionResult> DelQuestionnaire(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Remove(question);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "question supprimée avec succée !"
                });
            }
            return NotFound();
        }

        [HttpPut]
        [Route("PutQuestion/{id}")]

        public async Task<ActionResult<Question>> PutQuestion(int id, Question question)
        {
            if (id != question.id)
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
                if (await _context.Questions.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Questions.FindAsync(id);


        }

        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
