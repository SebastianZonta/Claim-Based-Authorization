using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProbandoAutorizacion.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProbandoAutorizacion.Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;

        public LoginService(IConfiguration config)
        {
            _config = config;
        }
        public User? Authenticate(UserLogin user)
        {
            return UserConstants.users.FirstOrDefault(e => e.Username.ToLower() == user.Username.ToLower() &&
                                         e.Password.ToLower() == user.Password.ToLower());
        }
        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.EmailAdress),
                new Claim(ClaimTypes.GivenName,user.GivenName),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                notBefore: null,
                DateTime.Now.AddMinutes(15),
                credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
