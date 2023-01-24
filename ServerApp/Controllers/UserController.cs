using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using serverapp.DTOs;
using serverapp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace serverapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public readonly IConfiguration _configuration;
        public UserController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userdto)
        {
            User user = _mapper.Map<User>(userdto);
            var result = await _userManager.CreateAsync(user,userdto.Password);
            if (result.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userdto)
        {
            var user = await _userManager.FindByNameAsync(userdto.UserName);
            if(user is null)
            {
                return BadRequest(new { message = "username is not correct" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, userdto.Password, false);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    token=GenerateJwtToken(user)
                });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key =Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Issuer="ytanyel",
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
