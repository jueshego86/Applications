using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using WebApi.Servicios.Contrats;

namespace WebApi.Servicios
{
    public class TokenBuilder : ITokenBuilder
    {
        private IConfiguration config;

        public TokenBuilder(IConfiguration config)
        {
            this.config = config;
        }

        public object BuildToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Admin ? "Admin" : "User"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["LLAVE_SECRETA"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: credentials);

            var tokenObj = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            };

            return tokenObj;
        }
    }
}
