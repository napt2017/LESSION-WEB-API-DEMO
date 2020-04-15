using LESSION_WEB_API_DEMO.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace LESSION_WEB_API_DEMO.Controllers
{
    public class JwtAuthenticationController : ApiController
    {
        [ResponseType(typeof(JwtToken))]
        public JwtToken PostAuthenticationInfo(AuthenticationInfo authenticationInfo)
        {
            // Connect to database get user info
            // Check exist
            if (authenticationInfo.UserName =="user" && authenticationInfo.PassWord == "user")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Payload
                var permClaims = new List<Claim>
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("vaild","1"),
                    new Claim("userid", "1"),
                    new Claim(ClaimTypes.Name, "Demo Student"),
                    new Claim(ClaimTypes.Role, "user")
                };

                // Create token
                var securityToken = new JwtSecurityToken
                (
                    JwtInfo.ValidIssuer, 
                    JwtInfo.ValidAudience, 
                    permClaims, 
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials:credentials
                );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return new JwtToken
                {
                    TokenString = jwtToken
                };
            }
            return new JwtToken();
        }
    }
}
