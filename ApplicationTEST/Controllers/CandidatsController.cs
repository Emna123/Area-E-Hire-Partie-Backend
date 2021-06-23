using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using MailKit.Net.Smtp;


namespace ApplicationTEST.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;

        public CandidatsController(UserManager<Candidat> userManager, TodoContext context)
        {
            _context = context;
            this.userManager = userManager;
        }
        [Authorize(Roles = "Admin")]

        // GET: api/Candidats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetCandidats()
        {
            Console.WriteLine(HttpContext.User.ToString());
            return await _context.Candidats.ToListAsync();
        }
        [Authorize(Roles = "Admin,User")]

        // GET: api/Candidats/5
        [HttpGet("{id}")]
        public async Task<Candidat> GetCandidat(string id)
        {
            var candidat = _context.Candidats.Include(c => c.candidatures).ThenInclude(c => c.offre)
                                              .Where(c => c.Id == id).FirstOrDefault();
            //  return Ok(new { candidat });
            return candidat;

        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("ArchiverCandidat/{id}")]
        public async Task<IActionResult> ArchiverCandidat(string id, Candidat candidat)

        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.archiver = true;
              
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    user = user
                });
            }
            return NotFound();

        }
        // PUT: api/Candidats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidat(string id, Candidat candidat)
        {

            Candidat user = (Candidat) await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.nom = candidat.nom;
                user.prenom = candidat.prenom;
                user.adresse = candidat.adresse;
                user.date_naissance = candidat.date_naissance;
                user.PhoneNumber = candidat.PhoneNumber;
                user.etat_matrimonial = candidat.etat_matrimonial;
                user.genre = candidat.genre;
                user.metier = candidat.metier;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    user
                });
            }
            return BadRequest();
            /* if (id != candidat.Id)
             {
                 return BadRequest();
             }

             _context.Entry(candidat).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!CandidatExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return Ok(new {
                 candidat
             });*/
        }

        // POST: api/Candidats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "User")]
        [HttpPost]

        public async Task<ActionResult<Candidat>> PostCandidat(Candidat candidat)
        {
            _context.Candidats.Add(candidat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidat", new { id = candidat.Id }, candidat);
        }
        [Authorize(Roles = "Admin")]

        // DELETE: api/Candidats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Candidat>> DeleteCandidat(long id)
        {
            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }

            _context.Candidats.Remove(candidat);
            await _context.SaveChangesAsync();

            return candidat;
        }

        private bool CandidatExists(string id)
        {
            return _context.Candidats.Any(e => e.Id == id);
        }
        [Authorize(Roles = "User")]

        [HttpPost]
        [Route("AddLanguage/{id}")]
        public async Task<IActionResult> AddLangue(string id, [FromBody] Langue langue)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                langue.candidat = user;
                _context.Add(langue);
                _context.SaveChanges();
                return Ok(new
                {
                    langue = langue
                });
            }
            return NotFound();

        }
        [Authorize(Roles = "User")]

        [HttpGet]
        [Route("getLanguages/{id}")]
        public async Task<IActionResult> GetLangues(string id)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                var languages = user.Langue;


                return Ok(new
                {
                    languages
                });
            }
            return NotFound();

        }
        [Authorize(Roles = "User")]

        [HttpDelete]
        [Route("DeleteLanguage/{id}")]
        public async Task<IActionResult> DelLangue(int id)
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

        //get experiences
        [Authorize(Roles = "User")]

        [HttpGet]
        [Route("getExperiences/{id}")]
        public async Task<IActionResult> GetExps(string id)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                var exps = user.Experience_prof;
                return Ok(new
                {
                    exps
                });
            }
            return NotFound();
        }

        [Authorize(Roles = "User")]

        //Update Langue 
        [HttpPut]
        [Route("UpdateLanguage/{id}")]
        public async Task<IActionResult> UpdateLangue(int id, Langue lang)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue != null)
            {
                langue.candidat = langue.candidat;
                langue.langue = lang.langue;
                langue.niveau = lang.niveau;
                langue.value = lang.value;
                _context.Entry(langue).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    languemodifier = langue

                });
            }
            return NotFound();
        }

        //get Commentaire


        /*[HttpGet]
        [Route("getCommentaire/{id}")]
        public async Task<IActionResult> GetCommentaire(string id)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {

                var cmt = _context.Commentaire.Where(e => e.candidat == user);
                return Ok(new
                {
                    cmt

                });
            }
            return NotFound();
        }
        */
        //get experiences


        //delete experience
        [Authorize(Roles = "User")]

        [HttpDelete]
        [Route("DeleteExperience/{id}")]
        public async Task<IActionResult> DelExp(int id)
        {
            var exp = await _context.Experience_prof.FindAsync(id);
            if (exp != null)
            {
                _context.Remove(exp);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "expérience supprimée avec succée !"
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "User")]

        [HttpPost]
        [Route("AddExperience/{id}")]
        public async Task<IActionResult> AddExp(string id, [FromBody] Experience_prof exp)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                exp.candidat = user;
                _context.Add(exp);
                _context.SaveChanges();
                return Ok(new
                {
                    exp = exp
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        [Route("AddCommentaire/{id}")]
        public async Task<IActionResult> AddCommentaire(string id, [FromBody] Commentaire commentaire)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                commentaire.candidat = user;
                _context.Add(commentaire);
                _context.SaveChanges();
                return Ok(new
                {
                    commentaire
                });
            }
            return NotFound();

        }
        [Authorize(Roles = "Admin")]

        [HttpDelete]
        [Route("DeleteCommentaire/{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            var commentaire = await _context.Commentaire.FindAsync(id);
            if (commentaire != null)
            {
                _context.Remove(commentaire);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "commentiare supprimé!"
                });
            }
            return NotFound();
        }

        [Authorize(Roles = "User")]

        //Update Experience 
        [HttpPut]
        [Route("UpdateExperience/{id}")]
        public async Task<IActionResult> UpdateExp(int id, Experience_prof exp)
        {
            var experience = await _context.Experience_prof.FindAsync(id);
            if (experience != null)
            {
                experience.candidat = experience.candidat;
                experience.employeur = exp.employeur;
                experience.poste_occupe = exp.poste_occupe;
                experience.lieu_Exp = exp.lieu_Exp;
                experience.typeEmploi = exp.typeEmploi;
                experience.date_debut = exp.date_debut;
                experience.date_fin = exp.date_fin;
                experience.description = exp.description;
                _context.Entry(experience).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatedexp = experience

                });
            }
            return NotFound();
        }
       
    }

   


}
