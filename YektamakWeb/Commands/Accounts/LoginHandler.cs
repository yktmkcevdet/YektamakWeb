using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models;
using NPOI.SS.Formula.Functions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorApp1.Features.Commands.Account.Login
{
    public class LoginHandler
    {
        private IConfiguration _configuration;
        public LoginHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(Kullanici user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var Issuer = jwtSettings.GetValue<string>("Issuer");
            var Audience = jwtSettings.GetValue<string>("Audience");
            var ExpirationMinutes = jwtSettings.GetValue<int>("ExpirationMinutes");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,user.ad),
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim("Role", user.rolId.ToString()),
            };
            var token = new JwtSecurityToken(Issuer, Audience, claims, expires: DateTime.Now.AddMinutes(ExpirationMinutes), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
