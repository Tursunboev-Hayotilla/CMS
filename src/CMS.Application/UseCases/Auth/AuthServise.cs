using CMS.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.UseCases.Auth
{
    public class AuthServise : IAuthServise
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public AuthServise(IConfiguration configuration, UserManager<User> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWT:Expire"]);

            var role = await _userManager.GetRolesAsync(user);
            if (role == null || role.Count == 0)
            {
                throw new InvalidOperationException("User does not have a role assigned.");
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FirstName + " " + user.LastName),
                new Claim("Role", user.Role!), 
                new Claim("id", user.Id.ToString()),
            };

            // Create JWT token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWTSettings:ValidIssuer"],
                audience: _config["JWTSettings:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
