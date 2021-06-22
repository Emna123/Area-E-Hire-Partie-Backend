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
    public class OffreController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;

        public OffreController(TodoContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,User")]

        //get all Offres
        [HttpGet]
        [Route("getAllOffres")]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffres()
        {
            try
            {
                return await _context.Offres.ToListAsync();
                /*.Include(x => x.diplomes).
                                            Include(x => x.langues).
                                            Include(x => x.competences).
                                            Include(x => x.candidatures).
                                            //   Where(x=> Convert.ToDateTime(x.date_expiration) > Convert.ToDateTime(DateTime.Now.ToString())).
                                            ToListAsync();*/
            }
            catch
            {
                return BadRequest();
            }


        }

        // GET api/<OffreController>/5
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("getOffre/{id}")]

        public async Task<ActionResult<Offre>> GetOffre(int id)
        {
            var offre = await _context.Offre.FindAsync(id);

            if (offre == null)
            {
                return null;
            }

            return offre;
          
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("getOffreById/{id}")]

        public async Task<ActionResult<Offre>> GetOffreById(int id)
        {
            var offre = await _context.Offre.FindAsync(id);

            if (offre == null)
            {
                return null;
            }

            return offre;

        }

        [Authorize(Roles = "Admin")]
        [Authorize]
        // POST api/<OffreController>
        [HttpPost]
        [Route("PostOffre")]

        public async Task<ActionResult<Offre>> PostOffre(Offre offre)
        {
            if (await _context.Offre.FindAsync(offre.id) == null)
            {
                offre.archiver = false;
                _context.Offre.Add(offre);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                     offre
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        // PUT api/<OffreController>/5
        [HttpPut]
        [Route("PutOffre/{id}")]

        public async Task<ActionResult<Offre>> PutOffre(int id, Offre offre)
        {
            if (id != offre.id)
            {
                return BadRequest();
            }
            _context.Entry(offre).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Offre.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Offre.FindAsync(id);
        }

        /* [HttpDelete]
         [Route("DeleteExamenOffre/{id}")]

         public async Task<ActionResult<Offre>> DeleteExamenOffre(int id)
         {
             var offre= await _context.Offre.FindAsync(id);


             if (offre != null)
             {
                 //offre.Examen= null;
                 _context.Remove(offre.Examen);

                 await _context.SaveChangesAsync();

                 return Ok(new
                 {
                     msg = "Examen supprimée avec succée !"
                 });
             }
             return NotFound();

             ;
         }
        */

        [Authorize(Roles = "Admin")]
        // DELETE api/<OffreController>/5
        [HttpDelete]
        [Route("DeleteOffre/{id}")]
        public async Task<IActionResult> DeleteOffre(int id)
        {

            var comp = await _context.Offre.FindAsync(id);


            if (comp != null)
            {
                foreach (var d in comp.Diplome)
                {
                    _context.Remove(d);

                }
                foreach (var d in comp.Langue)
                {
                    _context.Remove(d);

                }
                foreach (var d in comp.Competence)
                {
                    _context.Remove(d);

                }
                foreach (var d in comp.Candidature)
                {
                    _context.Remove(d);

                }
                foreach (var d in comp.Questionnaire)
                {
                    _context.Remove(d);

                }
                _context.Remove(comp);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "offre supprimée avec succée !"
                });
            }
            return NotFound();
        }
     
    }
}
