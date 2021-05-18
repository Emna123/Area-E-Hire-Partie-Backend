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

        //get all Offres
        [HttpGet]
        [Route("getAllOffres")]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffres()
        {
            return await  _context.Offres.Include(x=>x.diplomes).
                                         Include(x=>x.langues).
                                         Include(x => x.competences).
                                         Include(x=>x.candidatures).
                                      //   Where(x=> Convert.ToDateTime(x.date_expiration) > Convert.ToDateTime(DateTime.Now.ToString())).
                                         ToListAsync();
        }

        // GET api/<OffreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<OffreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OffreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OffreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
