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
    public class CompetenceController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public CompetenceController(UserManager<Candidat> userManager, TodoContext context)
        {
            this.userManager = userManager;
            _context = context;
            //candidats = _candidats;
        }

        // GET api/<CompetenceController>
        [Authorize(Roles = "Admin,User")]

        [HttpGet]
        [Route("getAllCompetences/{id}")]
        public async Task<IActionResult> GetCompetences(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var comps = user.Competence;
                return Ok(new
                {
                    comps
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "User")]

        [HttpPost]
        [Route("AddCompetence/{id}")]
        public async Task<IActionResult> AddCompetence(string id, [FromBody] Competence comp)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                comp.candidat = user;
                _context.Add(comp);
                _context.SaveChanges();
                return Ok(new
                {
                    comp = comp
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "User")]

        [HttpDelete]
        [Route("DeleteCompetence/{id}")]
        public async Task<IActionResult> DelCompetence(int id)
        {
            var comp = await _context.Competences.FindAsync(id);
            if (comp != null)
            {
                _context.Remove(comp);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "competence supprimée avec succée !"
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        [Route("AddOffreCompetence/{id}")]
        public async Task<IActionResult> AddOffreCompetance(int id, [FromBody] Competence competence)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (offre != null)
            {
                competence.offre = offre;
                _context.Add(competence);
                _context.SaveChanges();
                return Ok(new
                {
                    competence
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        [Route("DeleteOffreCompetence/{id}")]
        public async Task<IActionResult> DeleteLangue(int id)
        {
            var competence = await _context.Competence.FindAsync(id);
            if (competence != null)
            {
                _context.Remove(competence);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "competence supprimée avec succée !"
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "User")]

        //Update Compétence 
        [HttpPut]
        [Route("UpdateCompetence/{id}")]
        public async Task<IActionResult> UpdateCompt(int id, Competence comp)
        {
            var competence = await _context.Competences.FindAsync(id);
            if (competence != null)
            {
                competence.candidat = competence.candidat;
                competence.titre = comp.titre;
                competence.niveau = comp.niveau;
                competence.value = comp.value;
                _context.Entry(competence).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatedcomp = competence
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        [Route("PutOffreCompetence/{id}")]
        public async Task<ActionResult<Competence>> Putlangue(int id, Competence competence)
        {
            if (id != competence.id)
            {
                return BadRequest();
            }

            _context.Entry(competence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Competence.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Competence.FindAsync(id);


        }


    }
}
