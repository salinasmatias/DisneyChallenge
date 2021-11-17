using DisneyWorld.Application.Services;
using DisneyWorld.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DisneyWorld.Presentation.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(UserDtoForCreation user)
        {
            try
            {
                var usuarioEntity = _service.RegisterUser(user);

                if (usuarioEntity != null)
                {
                    
                    return new JsonResult(user) { StatusCode = 201 };
                }

                return new JsonResult(Conflict()) { StatusCode = 409 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserLogin(UserLoginDto loginUser)
        {
            try
            {
                var usuario = _service.LoginUser(loginUser);

                if (usuario != null)
                {
                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim("UserId", usuario.UserId.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Email, usuario.Email));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(1),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    var token = tokenHandler.WriteToken(createdToken);
                    
                    LoginResponseDto response = new LoginResponseDto
                    {
                        Status = "Success",
                        Token = token
                    };

                    return new JsonResult(response) { StatusCode = 201 };
                }

                LoginResponseDto errorResponse = new LoginResponseDto
                {
                    Status = "Error",
                    Token = "The token could not be generated"
                };

                return new JsonResult(errorResponse) { StatusCode = 404 };
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
