using ApplicationTEST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTEST.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<User> userManager;


        public HobbyController(UserManager<User> userManager, TodoContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("getAllHobbies/{id}")]
        public async Task<IActionResult> GetHobbies(string id)
        {
            Candidat user = (Candidat)await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var hobbies = user.Hobby ;
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
            Candidat user = (Candidat) await userManager.FindByIdAsync(id);
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

        //Update Hobby 
        [HttpPut]
        [Route("UpdateHobby/{id}")]
        public async Task<IActionResult> UpdateCompt(int id, Hobby loisir)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby != null)
            {
                hobby.candidat = hobby.candidat;
                hobby.hobby = loisir.hobby;
                _context.Entry(hobby).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatedhobby = hobby
                });
            }
            return NotFound();
        }
    }
}
