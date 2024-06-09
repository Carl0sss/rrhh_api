using Microsoft.AspNetCore.Mvc;
using rrhh_api.Dto;
using rrhh_api.Services;
using System.IdentityModel.Tokens.Jwt;

namespace rrhh_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var authResult = await _authService.AuthResponse(login);
            
            if (authResult == null) { 
                return Unauthorized();
            }

            return Ok(authResult);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenExpiradoSupuestamente = tokenHandler.ReadJwtToken(token.Token);

            if (tokenExpiradoSupuestamente.ValidTo > DateTime.UtcNow)
                return BadRequest(new AuthResponse { result = false, message = "Token no ha expirado" });

            string idUsuario = tokenExpiradoSupuestamente.Claims.First(x =>
                x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();


            var autorizacionResponse = await _authService.RefreshTokenResponse(token, idUsuario);

            if (autorizacionResponse.result)
                return Ok(autorizacionResponse);
            else
                return BadRequest(autorizacionResponse);
        }

    }
}
