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
    public class QuestionnaireController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public QuestionnaireController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }


        [HttpPost]
        [Route("AddQuestionnaire/{id}")]
        public async Task<IActionResult> AddQuestionnaire(int id, [FromBody] Questionnaire questionnaire)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (offre != null)
            {
                questionnaire.offre = offre;
                _context.Add(questionnaire);
                _context.SaveChanges();
                return Ok(new
                {
                   questionnaire
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteQuestionnaire/{id}")]
        public async Task<IActionResult> DelQuestionnaire(int id)
        {
            var questionnaire = await _context.Questionnaire.FindAsync(id);
            if (questionnaire != null)
            {
                _context.Remove(questionnaire);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "questionnaire supprimée avec succée !"
                });
            }
            return NotFound();
        }

        [HttpPut]
        [Route("PutQuestionnaire/{id}")]

        public async Task<ActionResult<Questionnaire>> PutQuestionnaire(int id, Questionnaire questionnaire)
        {
            if (id != questionnaire.id)
            {
                return BadRequest();
            }

            _context.Entry(questionnaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Questionnaire.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Questionnaire.FindAsync(id);


        }

        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
