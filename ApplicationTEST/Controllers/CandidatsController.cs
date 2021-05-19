using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApplicationTEST.Controllers

{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatsController : ControllerBase
    {
        private readonly TodoContext _context;

        public CandidatsController(TodoContext context)
        {
            _context = context;

        }

        // GET: api/Candidats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetCandidats()
        {
            Console.WriteLine(HttpContext.User.ToString());
            return await _context.Candidats.ToListAsync();
        }

        // GET: api/Candidats/5
        [HttpGet("{id}")]
        public  async Task<Candidat> GetCandidat(string id)
        {
            var candidat =  await _context.Candidats.FindAsync(id);

            if (candidat == null)
            {
                return null;
            }

            return candidat;
        }

        // PUT: api/Candidats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidat(string id, Candidat candidat)
        {
            if (id != candidat.Id)
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

            return NoContent();
        }

        // POST: api/Candidats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Candidat>> PostCandidat(Candidat candidat)
        {
            _context.Candidats.Add(candidat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidat", new { id = candidat.Id }, candidat);
        }

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
        [HttpPost]
        [Route("AddLanguage/{id}")]
        public async Task<IActionResult> AddLangue( string id, [FromBody] Langue langue)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                langue.candidat = user;
                _context.Add(langue);
                _context.SaveChanges();
                return Ok(new
                {
                    langue=langue
                });
            }
            return NotFound();

        }

        [HttpGet]
        [Route("getLanguages/{id}")]
        public async Task<IActionResult> GetLangues(string id)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                var languages =  _context.Langues.Where(l => l.candidat == user);
                        
                
                return Ok(new
                {
                   languages
                });
            }
            return NotFound();

        }

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

        [HttpGet]
        [Route("getExperiences/{id}")]
        public async Task<IActionResult> GetExps(string id)
        {
            var user = await GetCandidat(id);
            if (user != null)
            {
                var exps = _context.Experience_prof.Where(e => e.candidat == user);
                return Ok(new
                {
                    exps
                });
            }
            return NotFound();
        }
        //get Commentaire


        [HttpGet]
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
        //delete experience

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


                });
            }
            return NotFound();
        }
    }
  

}
