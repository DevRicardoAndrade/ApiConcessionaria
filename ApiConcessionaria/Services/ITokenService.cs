using ApiConcessionaria.Model;

namespace ApiConcessionaria.Services
{
    public interface ITokenService
    {
        string GetToken(string key, string issuer, string audience, UserModel user);  
    }
}
