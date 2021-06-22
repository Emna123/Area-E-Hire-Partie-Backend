
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Note_QuestionController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;

        public Note_QuestionController(TodoContext context)
        {
            _context = context;
        }



        [Authorize(Roles = "Admin")]
        // POST api/<Note_QuestionController>
        [HttpPost]
        [Route("PostNote_Question/{idqs}/{idex}")]

        public async Task<ActionResult<Note_Question>> PostNote_Question(int idex,int idqs,Note_Question note_Question)
        {
            var ex = await _context.Examens.FindAsync(idex);
            var qs = await _context.Questions.FindAsync(idqs);
            if (await _context.Note_Questions.FindAsync(note_Question.id) == null)
            {
                note_Question.examen = ex;
                note_Question.question = qs;
                _context.Note_Questions.Add(note_Question);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    note_Question
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteNote_Question/{id}")]
        public async Task<IActionResult> DeleteNote_Question(int id)
        {
            var note_Question = await _context.Note_Questions.FindAsync(id);
            if (note_Question != null)
            {
                _context.Remove(note_Question);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "note_Question supprimée avec succée !"
                });
            }
            return NotFound();
        }

    }
}
