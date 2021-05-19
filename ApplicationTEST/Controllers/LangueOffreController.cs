using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
    public class LangueOffreController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public LangueOffreController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }


        [HttpPost]
        [Route("AddLangue/{id}")]
        public async Task<IActionResult> AddLangue(int id, [FromBody] Langue langue)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (offre != null)
            {
                langue.offre = offre;
                _context.Add(langue);
                _context.SaveChanges();
                return Ok(new
                {
                    langue
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteLangue/{id}")]
        public async Task<IActionResult> DeleteLangue(int id)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue != null)
            {
                _context.Remove(langue);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "langue supprimée avec succée !"
                });
            }
            return NotFound();
        }

        [HttpPut]
        [Route("PutLangue/{id}")]

        public async Task<ActionResult<Langue>> Putlangue(int id, Langue langue)
        {
            if (id != langue.id)
            {
                return BadRequest();
            }

            _context.Entry(langue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Langues.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Langues.FindAsync(id);


        }

        /*   private bool FormationExists(int id)
           {
               return _context.Formation.Any(e => e.id == id);
           }*/
    }
}
