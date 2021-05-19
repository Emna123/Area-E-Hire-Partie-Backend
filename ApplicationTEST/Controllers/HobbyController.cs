using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public HobbyController(UserManager<Candidat> userManager, TodoContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("getAllHobbies/{id}")]
        public async Task<IActionResult> GetHobbies(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {


                var hobbies = _context.Hobbies.Where(h => h.candidat == user);
                return Ok(new
                {
                    hobbies
                });
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddHobby/{id}")]
        public async Task<IActionResult> AddHobby(string id, [FromBody] Hobby hobby)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                hobby.candidat = user;
                _context.Add(hobby);
                _context.SaveChanges();
                return Ok(new
                {
                    hobby = hobby
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteHobby/{id}")]
        public async Task<IActionResult> DelCompetence(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby != null)
            {
                _context.Remove(hobby);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "Hobby supprimé avec succée !"
                });
            }
            return NotFound();
        }
    }
}
