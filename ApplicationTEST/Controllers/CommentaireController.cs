
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationTEST.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationTEST.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<Candidat> userManager;


        public CommentaireController(TodoContext context, UserManager<Candidat> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }



        /*[HttpDelete]
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
                    msg = "Comnentaire supprimée avec succée !"
                });
            }
            return NotFound();
        }*/

        private bool Commentaire(int id)
        {
            return _context.Commentaire.Any(e => e.id == id);
        }
    }
}
