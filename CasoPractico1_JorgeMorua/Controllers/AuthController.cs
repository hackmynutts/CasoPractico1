using CasoPractico1_JorgeMorua.Identity;
using CasoPractico1_JorgeMorua.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CasoPractico1_JorgeMorua.Controllers
{
    public class AuthController : ApiController
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AuthController()
        {
        }

        public AuthController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        public async Task<IHttpActionResult> Post([FromBody] AuthModel modelAuth)
        {
            var result = await SignInManager.PasswordSignInAsync(modelAuth.correo, modelAuth.clave, false, shouldLockout: false);

            if (result != SignInStatus.Success)
            {
                return Unauthorized();
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qSgD8V1pA+k7V5u6Sop9uwRtpNmseqlOeS0iNY6i01E="));

            var claims = new[]
           {
                new Claim(ClaimTypes.Role, "Administrador"),
                new Claim(ClaimTypes.Name, modelAuth.correo),
                new Claim(JwtRegisteredClaimNames.Sub, modelAuth.correo)
            };

            // Crear el token JWT
            var token = new JwtSecurityToken(
                issuer: "tu_issuer",
                audience: "tu_audiencia",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // El token expira en 1 hora
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Generar el token como cadena
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Json(new { token = tokenString });
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
