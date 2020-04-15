using System;
using System.Text;
using System.Threading.Tasks;
using LESSION_WEB_API_DEMO.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(LESSION_WEB_API_DEMO.StartUp))]

namespace LESSION_WEB_API_DEMO
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions 
            { 
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters 
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtInfo.ValidIssuer,
                    ValidAudience = JwtInfo.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecretKey))
                }
            });
        }
    }
}
