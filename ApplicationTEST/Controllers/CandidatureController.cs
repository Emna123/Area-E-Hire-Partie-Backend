using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApplicationTEST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatureController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;

        public CandidatureController(UserManager<Candidat> userManager, TodoContext context)
        {
            _context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("AddCandidature/{id}/{idoffre}")]
        public async Task<IActionResult> AddCandidature(string id,int idoffre, [FromBody] Candidature candidature)
        {
            var user = await userManager.FindByIdAsync(id);
            var offre = await _context.Offres.FindAsync(idoffre);
            Console.WriteLine("Offre ", offre);
            if (user != null && offre != null)
            {
                candidature.candidat = user;
                candidature.date_candidature = DateTime.Now.ToString();
                candidature.etat = "en attente";
                candidature.offre = offre;
                _context.Add(candidature);
                _context.SaveChanges();
                return Ok(new
                {
                    candidature = candidature
                });
            }
            return NotFound();

        }

        [HttpGet]
        [Route("getAllCandidatures/{id}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> getAllCandidatures(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var candidatures = _context.Candidatures.Include(x => x.offre)
                                                    .ThenInclude(x => x.diplomes)
                                                    .Include(x => x.offre)
                                                    .ThenInclude(x => x.competences)
                                                    .Include(x => x.offre)
                                                    .ThenInclude(x => x.langues)
                                                    .Include(x => x.offre)
                                                    .ThenInclude(x => x.candidatures).
                   Where(e => e.candidat == user);
            return Ok(new
            {
                candidatures = candidatures
            });
        }

        [HttpDelete]
        [Route("deleteCandidature/{id}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> deleteCandidature(int id)
        {
            // var user = await userManager.FindByIdAsync(id);
            var candidature = await _context.Candidatures.FindAsync(id);

            if (candidature != null)
            {
                _context.Remove(candidature);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "candidatures supprimée avec succés ! "
                });
            }
            else
            {
                return NotFound();
            }
          
        }
    }
}
