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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using EmailService;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
        private readonly SignInManager<Candidat> _signInManager;


        public AuthenticationController(UserManager<Candidat> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration, TodoContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;

            _configuration = configuration;
        }
       
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
                prenom = model.prenom,
                password = model.password,
            };
            var result = await userManager.CreateAsync(candidat,model.password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured !", status = "Error 500 !!" });
            }
            var emailtoken = await userManager.GenerateEmailConfirmationTokenAsync(candidat);
           // emailtoken.wait();
           // var confirmationLink = Url.Action(null, "Account", new { emailtoken, email = candidat.Email }, Request.Scheme);
          //  var msg= new Message(new string[] { candidat.Email }, "Confirmation email link", confirmationLink, null);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", model.Email));
            message.Subject = "Confirmation Compte Area E-Hire";
            Console.WriteLine(emailtoken);
            var chaine = "Bonjour "+model.nom.ToUpper() + " " + model.prenom +"! \n Veuillez Confirmer votre compte" +
                  " en cliquant sur ce lien :  \n http://localhost:3000/Inscription/Confirmation-compte?id="
                  +candidat.Id+
                  "&token="+emailtoken+""
                  ;
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

        public  string GetToken(Candidat user)
        {
           // var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
            /*foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }*/
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(5),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenvalidationparams = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]))
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenvalidationparams, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(5),
               // claims = claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var newJwtToken = GenerateToken(principal.Claims);
            var newRefreshToken = GenerateRefreshToken();
            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
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
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                /*foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }*/
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires = DateTime.Now.AddHours(5),
                    refreshToken = GenerateRefreshToken(),
                    user = user
                }) ;
            }
            else
            {
                return Unauthorized();
            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


        [HttpPost]
        [Route("Inscription/ConfimMail")]
        public async Task<IActionResult> ConfirmInscription ([FromBody] Candidat candidat)
        {
            var user = await userManager.FindByIdAsync(candidat.UserName);
          //  Console.Write(user.Email);
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

        //reset password user
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> checkEmailCandidat([FromBody] Response res)
        {
            try
            {
                var email = res.extrafield;
                Candidat candidat = await userManager.FindByEmailAsync(email);
                if(candidat != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(candidat);
                    token = HttpUtility.UrlEncode(token);
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
                    message.To.Add(new MailboxAddress("", email));
                    message.Subject = " Changer votre mot de passe ";
                    var chaine = " Bonjour " + candidat.nom.ToUpper() + " " + candidat.prenom +
                        "! \n \n Pour changer votre mot de passe, veuillez utiliser le lien ci-dessous : \n http://localhost:3000/change-password?user_id="
                          + candidat.Email+"&token="+token+ "\n Ce lien expirera dans une heure ! \n \n Merci pour votre confiance,\n L'équipe Area E-Hire";
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
                    return Ok(new Response { message = "email succefully sent for recover !", status = "success 200 " });
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //change password 
        [HttpPost]
        [Route("ChangerUserPassword/{iduser}")]
        public async Task<IActionResult> changePassword([FromBody] Response res,string iduser)
        {
            try
            {
                Console.WriteLine(res.message);
                var candidat = await userManager.FindByEmailAsync(iduser);
                if (candidat != null && res.message!=null)
                {
                    Console.WriteLine(res.extrafield);
                 //   String hashedNewPassword = userManager.PasswordHasher.HashPassword(candidat,res.extrafield);
                   // UserStore
                    var result =  await userManager.ResetPasswordAsync(candidat, res.message, res.extrafield);
                    Console.WriteLine("result!!!!!!!!"+result);
                    if (result.Succeeded)
                    {
                        return Ok(new
                        {
                            msg = "Password changed succefully !"
                        }); ;
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured while changing the password!",status="500" });
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

    }

   
}
