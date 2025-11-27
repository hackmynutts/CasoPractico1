using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;

[assembly: OwinStartupAttribute(typeof(CasoPractico1_JorgeMorua.Identity.Startup))]
namespace CasoPractico1_JorgeMorua.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = "tu_issuer";//el emisor del token, puede ser el dominio del app
            var audience = "tu_audience";//el público del token, puede ser el dominio del app (quien esta autorizado a consumir el token)
            var secretKey = "qSgD8V1pA+k7V5u6Sop9uwRtpNmseqlOeS0iNY6i01E="; // La clave secreta para firmar los JWT

            // El middleware de JWT
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Evitar problemas con la expiración del token
                }
            });

            ConfigureAuth(app);
        }
    }
}
