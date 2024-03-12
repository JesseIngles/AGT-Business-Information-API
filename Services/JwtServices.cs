using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrudEmpresas.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CrudEmpresas.Services;

public class JwtService
{
    /*private readonly SymmetricSecurityKey _key;
    public JwtService(SymmetricSecurityKey key)
    {
        _key = key;
    }
    public static string GerarTokenAgente(Agente agente)
    {
        // Pad the key to ensure it meets the required length
        //var paddedKey = jwtKey.PadRight(32, '0'); // Assuming 32 bytes (256 bits) is required

        //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(paddedKey));
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, agente.Nome),
            new Claim("Nif", agente.Nif),
            new Claim("Senha", agente.Senha),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        if (agente.IsAdmin == true)
        {
            claims[claims.Length - 1] = new Claim("IsAdmin", agente.IsAdmin.ToString());
        }
        var token = new JwtSecurityToken(
                issuer: "CRUDEmpresas",
                audience: "CRUDEmpresas",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(180),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }*/

}