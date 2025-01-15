using FinansalTakipWebApiCore.TokenJobs;
using Microsoft.AspNetCore.Mvc;

namespace FinansalTakipWebApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController:ControllerBase
    {
        private readonly TokenService _tokenService;

        public LoginController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Örnek kullanıcı kontrolü
            if (request.Username == "admin" && request.Password == "12345")
            {
                var token = _tokenService.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Kullanıcı adı veya şifre yanlış.");
        }
    }
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
