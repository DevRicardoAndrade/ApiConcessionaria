using ApiConcessionaria.Model;
using ApiConcessionaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel userModel, ITokenService tokenService)
        {
            try
            {
                if(userModel == null)
                {
                    return BadRequest("Login Inválido");
                    
                }

                if (userModel.UserName == "Rick" && userModel.Password == "123")
                {
                    string tokenString = tokenService.GetToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Kwt:Audience"], userModel);
                    return Ok(new { token = tokenString });
                }
                else
                {
                    return BadRequest("Login Inválido");
                    }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
