using ApplicationTEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MimeKit;
using MailKit.Net.Smtp;

namespace ApplicationTEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Candidat> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly TodoContext _context;


        public AuthenticationController(UserManager<Candidat> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration, TodoContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;

            _configuration = configuration;
        }
       /* public Sendmail()
        {
            

        }*/
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register ([FromBody] Candidat model)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);
            var userbyusername = await userManager.FindByNameAsync(model.UserName);
            Console.Write("VARIABLE A AFFFICHER !!!!!!!");

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Cette adresse mail est déjà utilisée", status = "Error 500 !!" });
            }
            if (userbyusername != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Nom d'utilisateur déjà utilisé!", status = "Error 500 !!" });

            }

            Candidat candidat = new Candidat
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                nom = model.nom,
                prenom=model.prenom,
                password= model.password
            };
            var result = await userManager.CreateAsync(candidat,model.password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured !", status = "Error 500 !!" });
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", model.Email));
            message.Subject = "Confirmation Compte Area E-Hire";
            var chaine = "Bonjour "+model.nom.ToUpper() + " " + model.prenom +"! \n Veuillez Confirmer votre compte en cliquant sur ce lien \n http://localhost:3000/Inscription/Confirmation-compte?id="+model.UserName+"";
            message.Body = new TextPart("plain")
            {
                Text = chaine.ToString()

            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("areaehirer.recrutement@gmail.com", "areaehire123");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok( new Response { message = "User succefully added !", status = "success 200 " });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Candidat model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.password))
            {
                if (user != null && user.EmailConfirmed != true)
                {
                    return Ok(new
                    {
                        status = "500"
                    });
                }
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var email = "";
                var token = new JwtSecurityToken(
                    issuer:  _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                 //   claims = authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user = user
                }) ;
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("Inscription/ConfimMail")]
        public async Task<IActionResult> ConfirmInscription ([FromBody] Candidat candidat)
        {
            var user = await userManager.FindByNameAsync(candidat.UserName);
            Console.Write(user.Email);
            if (user != null)
            {
                user.EmailConfirmed= true;
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    reponse = "email a été confirmé "
                });
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { message = "Error has been occured !" });
        }

    }

   
}
