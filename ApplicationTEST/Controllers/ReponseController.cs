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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReponseController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public ReponseController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }


        [HttpPost]
        [Route("AddReponse/{id}")]
        public async Task<IActionResult> AddQuestionnaire(int id, [FromBody] Reponse reponse)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {

                reponse.question = question;
                _context.Add(reponse);
                _context.SaveChanges();
                return Ok(new
                {
                    reponse
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteReponse/{id}")]
        public async Task<IActionResult> DelReponse(int id)
        {
            var reponse = await _context.Reponses.FindAsync(id);
            if (reponse != null)
            {
                _context.Remove(reponse);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "Reponse supprimée avec succée !"
                });
            }
            return NotFound();
        }

        [HttpPut]
        [Route("PutReponse/{id}")]

        public async Task<ActionResult<Reponse>> PutReponse(int id, Reponse reponse)
        {
            if (id != reponse.id)
            {
                return BadRequest();
            }

            _context.Entry(reponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Reponses.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Reponses.FindAsync(id);


        }

        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
