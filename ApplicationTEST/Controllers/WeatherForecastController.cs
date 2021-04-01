using ApplicationTEST.Models;
using EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace aria_e_hire.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IEmailSender _emailSender;

        public WeatherForecastController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet("{email}")]
        public int Get(String email)
        {
            var url = "http://localhost:3000/session/resetpassword";


            var rng = new Random();
            var code = rng.Next(10000, 99999); //Génère un entier compris entre 0 et 9
            var logo = "https://i.ibb.co/YfJg21W/i1.png";


            var message = new Message(new string[] { email }, code + " est votre code de récupération de compte Responsable RH", logo + "", "Nous avons reçu une demande de réinitialisation de votre mot de passe .<br/> Entrez le code de réinitialisation du mot de passe suivant : ", code + "", url);
            _emailSender.SendEmail(message);

            return (code);
        }
    }
}
