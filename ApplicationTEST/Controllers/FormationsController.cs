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
    public class FormationsController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public FormationsController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("getAllFormations/{id}")]
        public async Task<IActionResult> GetFormations(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var formations = user.Formation;
                return Ok(new
                {
                    formations
                });
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddFormation/{id}")]
        public async Task<IActionResult> AddFormation(string id, [FromBody] Formation formation)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                formation.candidat = user;
                _context.Add(formation);
                _context.SaveChanges();
                return Ok(new
                {
                    formation = formation
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteFormation/{id}")]
        public async Task<IActionResult> DelFormation(int id)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation != null)
            {
                _context.Remove(formation);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "formation supprimée avec succée !"
                });
            }
            return NotFound();
        }


        //Update Formation 
        [HttpPut]
        [Route("UpdateFormation/{id}")]
        public async Task<IActionResult> UpdateFormation(int id, Formation form)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation != null)
            {
              /*  _context.Remove(formation);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "formation supprimée avec succée !"*/
                formation.candidat = formation.candidat;
                formation.universite = form.universite;
                formation.diplome = form.diplome;
                formation.annee_debut = form.annee_debut;
                formation.annee_fin = form.annee_fin;
                formation.description = form.description;
                _context.Entry(formation).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatedformation = formation
                });
            }
            return NotFound();
        }

     /*   private bool FormationExists(int id)
        {
            return _context.Formation.Any(e => e.id == id);
        }*/
        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
