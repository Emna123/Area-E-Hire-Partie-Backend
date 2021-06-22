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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedinController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<User> userManager;

        public LinkedinController(UserManager<User> userManager, TodoContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("getLinkedin/{id}")]
        public async Task<IActionResult> GetLinkedin(string id)
        {
            Candidat user = (Candidat) await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var linkedin = user.linkedin;
                //var linkedin = _context.Linkedins.Where(c => c.candidat == user).FirstOrDefault();
                return Ok(new
                {
                    linkedin
                });
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddLinkedin/{id}")]
        public async Task<IActionResult> AddLinkedin(string id, [FromBody] Linkedin lin)
        {
            Candidat user = (Candidat) await userManager.FindByIdAsync(id);
            if (user != null)
            {
                Linkedin x = _context.Linkedins.Where(c => c.candidat == user).FirstOrDefault();
                if (x != null)
                {
                    //_context.Remove(x);
                    //lin.candidat = user;
                    x.linkedin = lin.linkedin;
                    _context.Entry(x).State = EntityState.Modified;

                    //  lin.id_candidat = user.Id;
                    //  _context.Add(lin);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        lin = x
                    });
                }
                else
                {
                    lin.candidat = user;
                   // lin.id_candidat = user.Id;
                    _context.Add(lin);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        lin = lin
                    });
                }            
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteLinkenin/{id}")]
        public async Task<IActionResult> DelLinkedin(int id)
        {
            var lin = await _context.Linkedins.FindAsync(id);
            if (lin != null)
            {
                _context.Remove(lin);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "linkedin supprimée avec succée !"
                });
            }
            return NotFound();
        }

        //Update Linkedin 
        [HttpPut]
        [Route("UpdateLinkedin/{id}")]
        public async Task<IActionResult> UpdateLinkedin(int id, Linkedin lin)
        {
            var linkedin = await _context.Linkedins.FindAsync(id);
            if (linkedin != null)
            {
                linkedin.candidat = linkedin.candidat;
                linkedin.linkedin = lin.linkedin;
                _context.Entry(linkedin).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatelinked = linkedin
                });
            }
            return NotFound();
        }
    }
}
