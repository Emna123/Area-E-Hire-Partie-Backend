using ApplicationTEST.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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
        private readonly UserManager<User> userManager;

        public CandidatureController(UserManager<User> userManager, TodoContext context)
        {
            _context = context;
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("getAllCandidatures")]
        public async Task<ActionResult<IEnumerable<Candidature>>> GetOffres()
        {
            return await _context.Candidatures.ToListAsync();
     
        }
        [HttpPost]
        [Route("AddCandidature/{id}/{idoffre}")]
        public async Task<IActionResult> AddCandidature(string id,int idoffre, [FromBody] Candidature candidature)
        {
            Candidat user = (Candidat)await userManager.FindByIdAsync(id);
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
            Candidat user = (Candidat)await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var candidatures = user.candidatures;
               //     .Include(x => x.offre).Where(e => e.candidat == user);
                                                /*.ThenInclude(x => x.Diplome)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.Competence)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.Langue)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.Candidature).
                                                 ; ;*/
                return Ok(new
                {
                    candidatures = candidatures
                });
            }
            return NotFound();

            /*.Include(x => x.offre)
                                                .ThenInclude(x => x.diplomes)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.competences)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.langues)
                                                .Include(x => x.offre)
                                                .ThenInclude(x => x.candidatures).
                                                 Where(e => e.candidat == user);*/

        }

        [HttpPost]
        [Route("SendAccept/{id}/{type}/{metier}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> SendAccept(int id,string type,string metier)
        {



         



            var candidature = await _context.Candidature.FindAsync(id);

            var result_Examen = new Result_Examen();

              result_Examen.date_expiration = DateTime.Now.AddDays(2);
                result_Examen.candidat = candidature.candidat;
               result_Examen.examen = candidature.offre.Examen;
                _context.Add(result_Examen);
                candidature.etat = "présélectionné";

            _context.Entry(candidature).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
           var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", candidature.email));
            if (type == "Emploi") { 
            message.Subject = "Nouvelle candidature pour l'emploi : " +metier;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", "https://i.ibb.co/YfJg21W/i1.png") + string.Format("<p style='margin-left: 200px;font-size: 15px;color:black'>Bonjour,<br/>{0}</p>", "<p style='margin-left: 200px;color:black;width:550px'>Suite à votre postulation dans le site Area E-Hire sur l'offre " + "d'emploi"+" "+ metier+ ". Nous invite de passer un examen d'évolution en ligne.Lien... !<p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>L' équipe Area E-Hire</p></p>") };
            }
            else
            {
                message.Subject = "Nouvelle candidature pour le stage : " + metier;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' " +
                    "style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>"
                    , "https://i.ibb.co/YfJg21W/i1.png") + 
                       string.Format("<p style='margin-left: 200px;font-size: 15px;color:black'>Bonjour,<br/>{0}</p>", 
                       "<p style='margin-left: 200px;color:black;width:550px'>" +
                       "Suite à votre postulation dans le site Area E-Hire sur l'offre "
                    + "de stage" + " " + metier + "." +
                    " Nous invite de passer un examen d'évolution en ligne. " +
                    "Lien de l'Examen:" +
                    "<p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>" +
                    "L' équipe Area E-Hire</p></p>") };
            }


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("areaehirer.recrutement@gmail.com", "areaehire123");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok(new
            {
                candidatures = candidature
            });
        }
        [HttpPost]
        [Route("SendRefuse/{id}/{type}/{metier}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> SendRefuse(int id, string type, string metier)
        {
            var candidature = await _context.Candidature.FindAsync(id);
            candidature.etat = "rejeté";

            _context.Entry(candidature).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", candidature.email));
          
                message.Subject = "Nouvelle candidature pour l'emploi : " + metier;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", "https://i.ibb.co/YfJg21W/i1.png") + string.Format("<p style='margin-left: 200px;font-size: 15px;color:black'>Cher, Chère,"+ candidature.nom.ToUpper() + candidature.prenom+" ,<br/>{0}</p>", "<p style='margin-left: 200px;color:black;width:500px'>Nous voulons tout d’abord vous remercier pour votre intérêt dans notre entreprise, et en particulier pour la fonction de "+ metier + ".<br/>Votre profil présente certainement des forces, mais pour la fonction susmentionnée il manque encore la maîtrise et l’expérience de certains aspects importants.Pour cette raison nous ne souhaitons pas poursuivre avec votre candidature.Toutefois, nous vous conseillons de mettre votre profil régulièrement à jour, pour que nous puissions encore vous contacter pour d’autres postes vacants.Nous vous souhaitons encore de belles opportunités professionnelles.<p style='color:#110240;margin-left: 200px;'>Sincères Salutations,<br/>L' équipe Area E-Hire</p></p>") };
         


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("areaehirer.recrutement@gmail.com", "areaehire123");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok(new
            {
                candidatures = candidature
            });
        }
        [HttpPost]
        [Route("SendEmail/{email}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> SendEmail(string email , Mess ms)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = ms.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' " +
                "style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>",
                "https://i.ibb.co/YfJg21W/i1.png") +
                string.Format("<p style='margin-left: 200px;font-size: 15px;color:black';width:500px>{0}</p>", "" +
                " <p style='margin-left: 200px;font-size: 15px;color:black;width:500px'> " +
                "Bonjour,<br/><p style='margin-left: 200px;font-size: 15px;color:black;width:500px'>" + ms.Content+"" +
                "</p></p><p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>L' équipe Area E-Hire</p>") };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("areaehirer.recrutement@gmail.com", "areaehire123");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok(new
            {
                res = "message envoyé"
            });
        }
       /* [HttpDelete]
        [Route("DeleteCandidature/{id}")]
        public async Task<IActionResult> DelCompetence(long id)
        {
            var candidature = await _context.Candidature.FindAsync(id);
        }*/
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

                    msg = "Candidature supprimé avec succée !"
                });
            }
            return NotFound();
        }
    }
     
          
}

