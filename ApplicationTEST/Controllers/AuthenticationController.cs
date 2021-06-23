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
        private readonly UserManager<User> userManager;
        private readonly UserManager<User> userManagerRH;

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly TodoContext _context;


        public AuthenticationController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration, TodoContext context, UserManager<User> userManagerRH)
        {
            this.userManager = userManager;
            this.userManagerRH = userManagerRH;
            this.roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Candidat model)
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
            var result = await userManager.CreateAsync(candidat, model.password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured !", status = "Error 500 !!" });
            }
            bool x = await roleManager.RoleExistsAsync("User");
            x = await roleManager.RoleExistsAsync("User");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "User";
                await roleManager.CreateAsync(role);
            }

            var result1 = await userManager.AddToRoleAsync(candidat, "User");

            var message = new MimeMessage();
            var token = await userManager.GenerateEmailConfirmationTokenAsync(candidat);
            token = HttpUtility.UrlEncode(token);
            message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
            message.To.Add(new MailboxAddress("", model.Email));
            message.Subject = "Confirmation Compte Area E-Hire";
            var chaine = "Bonjour " + model.nom.ToUpper() + " " + model.prenom +
                "! \n Veuillez Confirmer votre compte en cliquant sur ce lien \n " +
                "http://localhost:3000/Inscription/Confirmation-compte?id=" + model.UserName +
                "&token="+token;
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
            return Ok(new Response { message = "User succefully added !", status = "success 200 " });
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
                var token = GenerateToken(authClaims);
                var reftoken = GenerateRefreshToken();
                var refreshtoken = new RefreshToken
                {
                    refresh_token = reftoken,
                    access_token = token,
                    candidat = (Candidat) user
                };
                _context.Add(refreshtoken);
                _context.SaveChanges();
              /*  var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var email = "";
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(5),
                    claims : authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );*/
                return Ok(new
                {
                    token = token,
                    refreshtoken = reftoken,
                    user = user
                });
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost]
        [Route("Inscription/ConfimMail")]
        public async Task<IActionResult> ConfirmInscription([FromBody] Candidat candidat)
        {
            var user = await userManager.FindByNameAsync(candidat.UserName);
            Console.Write(user.Email);
            if (user != null)
            {
                if (user.EmailConfirmed == true)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Email dejà confirmé  !", status = "401" });
                }
                var result = await userManager.ConfirmEmailAsync(user, candidat.nom);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        reponse = "email a été confirmé avec succès ! "
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Email not confirmed !", status = "500" });
                }   
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { message = "User Not found !" });
        }

        [HttpPost]
        [Route("RegisterRH")]
        public async Task<IActionResult> RegisterRH([FromBody] Responsable_RH model)
        {
            var userExist = await userManagerRH.FindByEmailAsync(model.Email);
            var userbyusername = await userManagerRH.FindByNameAsync(model.UserName);
            Console.Write("VARIABLE A AFFFICHER !!!!!!!");
            Responsable_RH responsable_RH = new Responsable_RH
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                mdp = model.mdp,
            };

            var result = await userManagerRH.CreateAsync(responsable_RH, model.mdp);
            bool x = await roleManager.RoleExistsAsync("Admin");

            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
            }
            var result1 = await userManager.AddToRoleAsync(responsable_RH, "Admin");

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured !", status = "Error 500 !!" });
            }
            return Ok(new Response { message = "User succefully added !", status = "success 200 " });
        }

        [HttpPost]
        [Route("LoginRH")]
        public async Task<IActionResult> LoginRH([FromBody] Responsable_RH model)
        {
            var userRH = await userManagerRH.FindByEmailAsync(model.Email);
            if (userRH != null && await userManagerRH.CheckPasswordAsync(userRH, model.mdp))
            {
                var userRoles = await userManagerRH.GetRolesAsync(userRH);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userRH.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var email = "";
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(10),
                    claims : authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userRH = userRH
                });
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost]
        [Route("UpdateRH")]
        public async Task<IActionResult> UpdateRH([FromBody] Responsable_RH model)
        {
            Responsable_RH responsable_RH = (Responsable_RH) await userManagerRH.FindByEmailAsync(model.Email);
            responsable_RH.mdp = model.mdp;
            responsable_RH.code = model.code;
            var token = await userManagerRH.GeneratePasswordResetTokenAsync(responsable_RH);
            await userManagerRH.ResetPasswordAsync(responsable_RH, token, model.mdp);
            var result = await userManagerRH.UpdateAsync(responsable_RH);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { message = "Error has been occured !", status = "Error 500 !!" });
            }
            return Ok(new Response { message = "User succefully added !", status = "success 200 " });
        }

        //reset password user
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> checkEmailCandidat([FromBody] Response res)
        {
            var email = res.extrafield;
            Console.WriteLine("this a message from reset password : " + email);
           // Candidat candidat = (Candidat) await userManager.FindByEmailAsync(email);
            Candidat candidat = (Candidat)await userManager.FindByEmailAsync(email);
            //var candidat = await userManager.FindByEmailAsync(email);
            if (candidat != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(candidat);
                token = HttpUtility.UrlEncode(token);
                Console.WriteLine("this a message from reset password : " + token);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("area-e-hire  ", "areaehirer.recrutement@gmail.com"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = " Rénitialiser votre mot de passe ";
                var chaine = " Bonjour " + candidat.nom.ToUpper() + " " + candidat.prenom +
                    "! \n \n Pour changer votre mot de passe, veuillez cliquer sur le lien ci-dessous : \n http://localhost:3000/change-password?user_id="
                      + candidat.Email + "&token=" + token + "\n Ce lien expirera au bout d'une heure ! \n \n Merci pour votre confiance,\n L'équipe Area E-Hire";
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


        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenvalidationparams = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidateLifetime = false,
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
                expires: DateTime.Now.AddMinutes(5),
                claims : claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
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
        
        public IActionResult Refresh1(string token,string refreshToken)
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
        [Route("refresh")]
        public async Task<IActionResult> RefreshAsync( [FromBody] RefreshToken reft)
        {
            var principal = GetPrincipalFromExpiredToken(reft.access_token);
            var email = principal.Identity.Name;
            Candidat user = (Candidat) await userManager.FindByEmailAsync(email);
            //retrieve the refresh token from a data store
            var savedRefreshToken =  user.RefreshTokens.Where(
            x=>x.refresh_token == reft.refresh_token && 
            x.access_token == reft.access_token).FirstOrDefault();
            if (savedRefreshToken != null) {
                if (savedRefreshToken.refresh_token != reft.refresh_token){
                    throw new SecurityTokenException("Invalid refresh token");
                }
                var newJwtToken = GenerateToken(principal.Claims);
                var newRefreshToken = GenerateRefreshToken();
                savedRefreshToken.refresh_token = newRefreshToken;
                savedRefreshToken.access_token = newJwtToken;
                _context.SaveChanges();
                //DeleteRefreshToken(username, refreshToken);
                //SaveRefreshToken(username, newRefreshToken);
                return new ObjectResult(new
                {
                    token = newJwtToken,
                    refreshToken = newRefreshToken
                });
            }
            else
            {
                return Ok(new
                {
                    msg="refresh token not found for this user !!!!"
                });
            }   
        }

        [HttpPost]
        [Route("logout/{id}")]
        public async Task<IActionResult> logout([FromBody] RefreshToken reft , string id)
        {
            Candidat user = (Candidat) await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var savedRefreshToken = user.RefreshTokens.Where(x => x.refresh_token == reft.refresh_token &&
                x.access_token == reft.access_token).FirstOrDefault();
                Console.WriteLine(savedRefreshToken == null);
                Console.WriteLine(reft.access_token);
                Console.WriteLine(reft.refresh_token);
                if (savedRefreshToken != null)
                {
                    _context.Remove(savedRefreshToken);
                    _context.SaveChanges();
                    return Ok(new { msg = "success !" });
                }
                else
                {
                    return StatusCode(404);
                }
            }
            else
            {
                return StatusCode(403);
            }
        }

    }
}
