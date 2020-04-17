using System;
using System.Text;
using System.Web.Http;
using System.Security.Claims; 
using System.Collections.Generic;
using System.Web.Http.Description;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt; 

using LESSION_WEB_API_DEMO.Models;
using LESSION_WEB_API_DEMO.DataAccess;
using System.Linq;
using System.Data.Entity;

namespace LESSION_WEB_API_DEMO.Controllers
{
    /// <summary>
    /// My authentication controller using jwt
    /// </summary>
    public class JwtAuthenticationController : ApiController
    {
        private readonly ProductManagementDbContext dbContext;

        /// <summary>
        /// The constructor
        /// </summary>
        public JwtAuthenticationController()
        {
            dbContext = new ProductManagementDbContext();
        }

        /// <summary>
        ///  Get info from user then generate the jwt token
        /// </summary>
        /// <param name="authenticationInfo"></param>
        /// <returns>JwtToken</returns>
        [ResponseType(typeof(JwtToken))]
        public JwtToken PostAuthenticationInfo(AuthenticationInfo authenticationInfo)
        {
            // Connect to database get user info
            var foundUser = dbContext.Users
                                     .Where(u => u.UserName == authenticationInfo.UserName && u.PassWord == authenticationInfo.PassWord)
                                     .Include("Role")
                                     .FirstOrDefault();
            // Check exist
            if (foundUser != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Payload
                var permClaims = new List<Claim>
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim("vaild","1"),
                    //new Claim("userid", "1"),
                    new Claim(ClaimTypes.Name, foundUser.UserName),
                    new Claim(ClaimTypes.Role, foundUser.Role.Name)
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
