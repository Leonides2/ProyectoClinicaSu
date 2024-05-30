using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Login;

namespace ProyectoClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISvLogin _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ISvLogin loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRequest request)
        {
            if (request == null)
            {
                return NoContent();
            }

            var user_request = await _loginService.ReturnToken(request, _configuration.GetValue<string>("JWT:secret")!);

            if (user_request == null)
            {
                return Unauthorized();
            }

            return Ok(user_request);
        }
    }
}
