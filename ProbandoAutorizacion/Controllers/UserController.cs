using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProbandoAutorizacion.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Public()
        {
            return Ok("holis");
        }
    }
}
