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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<User> userManager;

        public ExamenController(TodoContext context)
        {
            _context = context;
        }

        //get all Offres
        [HttpGet]
        [Route("getAllExamens")]
        public async Task<ActionResult<IEnumerable<Examen>>> GetExamens()
        {
            return await _context.Examens.ToListAsync();
            
        }

        [Authorize]
        [HttpGet]
        [Route("getExamen/{id}")]

        public async Task<ActionResult<Examen>> GetExamen(int id)
        {
            var examen = await _context.Examens.FindAsync(id);

            if (examen == null)
            {
                return null;
            }

            return examen;

        }
 
        [HttpPost]
        [Route("PostExamen/{id}")]

        public async Task<ActionResult<Examen>> PostExamen(int id,Examen examen)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (await _context.Examens.FindAsync(examen.id) == null)
            {
                examen.offre = offre;
                _context.Entry(offre).State = EntityState.Modified;
                _context.Examens.Add(examen);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    examen
                });
            }
            return NotFound();
        }
  
        [HttpPut]
        [Route("PutExamen/{id}")]

        public async Task<ActionResult<Examen>> PutExamen(int id, Examen examen)
        {
            if (id != examen.id)
            {
                return BadRequest();
            }
            _context.Entry(examen).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Examens.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Examens.FindAsync(id);
        }
        [HttpDelete]
        [Route("DeleteExamen/{id}")]
        public async Task<IActionResult> DeleteExamen(int id)
        {

            var examen = await _context.Examens.FindAsync(id);


            if (examen != null)
            {
                _context.Remove(examen);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "examen supprimée avec succée !"
                });
            }
            return NotFound();
        }

    }
}
