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
            var offre = await _context.Offre.FindAsync(idoffre);
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
            var candidatures = _context.Candidature.
                Where(e => e.candidat == user);
            return Ok(new
            {
                candidatures = candidatures
            });
        }

        [HttpPost]
        [Route("SendAccept/{id}/{type}/{metier}")]
        public async Task<ActionResult<IEnumerable<Candidature>>> SendAccept(long id,string type,string metier)
        {
            var candidature = await _context.Candidature.FindAsync(id);
            candidature.etat = "en traitement";

            _context.Entry(candidature).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
           var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", candidature.email));
            if (type == "Emploi") { 
            message.Subject = "Nouvelle candidature pour l'emploi : " +metier;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", "https://i.ibb.co/YfJg21W/i1.png") + string.Format("<p style='margin-left: 200px;font-size: 15px;color:black'>Bonjour,<br/>{0}</p>", "<p style='margin-left: 200px;color:black;width:550px'>Suite à votre postulation dans le site Area E-Hire sur l'offre " + "d'emploi"+" "+ metier+ ". Nous invite de passer un examen d'évolution en ligne Soyez prêt, nous vous informerons des détails plus tard !<p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>L' équipe Area E-Hire</p></p>") };
            }
            else
            {
                message.Subject = "Nouvelle candidature pour le stage : " + metier;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", "https://i.ibb.co/YfJg21W/i1.png") + string.Format("<p style='margin-left: 200px;font-size: 15px;color:black'>Bonjour,<br/>{0}</p>", "<p style='margin-left: 200px;color:black;width:550px'>Suite à votre postulation dans le site Area E-Hire sur l'offre " + "de stage" + " " + metier + ". Nous invite de passer un examen d'évolution en ligne Soyez prêt, nous vous informerons des détails plus tard !<p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>L' équipe Area E-Hire</p></p>") };
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
        public async Task<ActionResult<IEnumerable<Candidature>>> SendRefuse(long id, string type, string metier)
        {
            var candidature = await _context.Candidature.FindAsync(id);
            candidature.etat = "réfuser";

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
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", "https://i.ibb.co/YfJg21W/i1.png") + string.Format("<p style='margin-left: 200px;font-size: 15px;color:black';width:500px>{0}</p>", " <p style='margin-left: 200px;font-size: 15px;color:black;width:500px'> Bonjour,<br/><p style='margin-left: 200px;font-size: 15px;color:black;width:500px'>" + ms.Content+"</p></p><p style='color:#110240;margin-left: 200px;'>Merci pour votre confiance,<br/>L' équipe Area E-Hire</p>") };
            


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
        [HttpDelete]
        [Route("DeleteCandidature/{id}")]
        public async Task<IActionResult> DelCompetence(long id)
        {
            var candidature = await _context.Candidature.FindAsync(id);
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
