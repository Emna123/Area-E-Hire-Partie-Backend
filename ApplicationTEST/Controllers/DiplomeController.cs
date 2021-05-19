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
    public class DiplomeController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public DiplomeController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }


        [HttpPost]
        [Route("AddDiplome/{id}")]
        public async Task<IActionResult> AddDiplome(int id, [FromBody] Diplome diplome)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (offre != null)
            {
                diplome.offre = offre;
                _context.Add(diplome);
                _context.SaveChanges();
                return Ok(new
                {
                    diplome = diplome
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteDiplome/{id}")]
        public async Task<IActionResult> DelDiplome(int id)
        {
            var diplome = await _context.Diplome.FindAsync(id);
            if (diplome != null)
            {
                _context.Remove(diplome);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "diplome supprimée avec succée !"
                });
            }
            return NotFound();
        }

        [HttpPut]
        [Route("PutDiplome/{id}")]

        public async Task<ActionResult<Diplome>> PutDiplome(int id, Diplome diplome)
        {
            if (id != diplome.id)
            {
                return BadRequest();
            }

            _context.Entry(diplome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Diplome.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Diplome.FindAsync(id);


        }

        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
