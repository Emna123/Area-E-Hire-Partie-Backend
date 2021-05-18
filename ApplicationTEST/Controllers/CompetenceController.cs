﻿using ApplicationTEST.Models;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public CompetenceController(UserManager<Candidat> userManager, TodoContext context)
        {
            this.userManager = userManager;
            _context = context;
            //candidats = _candidats;
        }
     
        // GET api/<CompetenceController>
      
        [HttpGet]
        [Route("getAllCompetences/{id}")]
        public async Task<IActionResult> GetCompetences(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var comps = _context.Competences.Where(c => c.candidat == user);
                return Ok(new
                {
                    comps
                });
            }
            return NotFound();
        }

        [HttpPost]
        [Route("AddCompetence/{id}")]
        public async Task<IActionResult> AddLangue(string id, [FromBody] Competence comp)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                comp.candidat = user;
                _context.Add(comp);
                _context.SaveChanges();
                return Ok(new
                {
                    comp = comp
                });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCompetence/{id}")]
        public async Task<IActionResult> DelCompetence(int id)
        {
            var comp = await _context.Competences.FindAsync(id);
            if (comp != null)
            {
                _context.Remove(comp);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "competence supprimée avec succée !"
                });
            }
            return NotFound();
        }

        //Update Compétence 
        [HttpPut]
        [Route("UpdateCompetence/{id}")]
        public async Task<IActionResult> UpdateCompt(int id, Competence comp)
        {
            var competence = await _context.Competences.FindAsync(id);
            if (competence != null)
            {
                competence.candidat = competence.candidat;
                competence.titre = comp.titre;
                competence.niveau = comp.niveau;
                _context.Entry(competence).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    updatedcomp = competence
                });
            }
            return NotFound();
        }

    }
}