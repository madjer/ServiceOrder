using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly iAuthRepository _repo;

		public IConfiguration _config { get; }

		public AuthController(iAuthRepository repo, IConfiguration config)
		{
			_repo = repo;
			_config = config;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
		{
			userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
			if (await _repo.UserExist(userForRegisterDto.Username))
				return BadRequest("Username already exists");

			var userToCreate = new User
			{
				Username = userForRegisterDto.Username
			};
			var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
			return StatusCode(201);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
		{
			var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
			if (userFromRepo == null)
				return Unauthorized();

			var claims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
				new Claim(ClaimTypes.Name, userFromRepo.Username),
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8
				.GetBytes(_config.GetSection("AppSettings:Token").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = creds
			};
			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return Ok(new
			{
				token = tokenHandler.WriteToken(token)
			});
		}
	}
}