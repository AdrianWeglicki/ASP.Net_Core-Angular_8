using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingSite.API.Data;
using DatingSite.API.Dtos;
using DatingSite.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            this._authRepository = authRepository;
            this._config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await _authRepository.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Użytkownik o tej nazwie istnieje!");
            }
            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
             var userFromRepo = await _authRepository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
             
             if(userFromRepo == null)
             {
                 return Unauthorized();
             }

            //create Token
            var claims = new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return Ok(new {token = tokenHandler.WriteToken(token)});
        }
    }
}
