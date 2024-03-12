using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrudEmpresas.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CrudEmpresas.Services;

public class JwtService
{
    public static string GerarTokenAgente(Agente agente, IConfiguration configuration)
    {
        var jwtKey = configuration["Jwt:Key"];
        var jwtIssuer = configuration["Jwt:Issuer"];
        var jwtAudience = configuration["Jwt:Audience"];
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, agente.Nome),
            new Claim("Nif", agente.Nif),
            new Claim("Senha", agente.Senha),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(180),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}