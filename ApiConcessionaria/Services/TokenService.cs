using ApiConcessionaria.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiConcessionaria.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken(string key, string issuer, string audience, UserModel user)
        {
            try
            {
                Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())

                };
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                string stringToken = tokenHandler.WriteToken(token);

                return stringToken;
            }
            catch (Exception ex)
            {
                return "ERRO: " + ex.Message;
            }
        }
    }
}
