using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProbandoAutorizacion.Models;
using ProbandoAutorizacion.Services;

namespace ProbandoAutorizacion.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginService _service;

        public LoginController(IConfiguration config,
            ILoginService service)
        {
            _config = config;
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin user)
        {
            
            var userFound = _service.Authenticate(user);
            if (userFound is not null)
            {
                var token = _service.Generate(userFound);
                return Ok(token);
            }
            return NotFound("user not found");
        }
    }
}
