using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Inclive.Application.UseCases.Player.Commands.CreatePlayer;
using Inclive.Application.UseCases.Player.Queries.GetPlayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Inclive.Backend.Controllers
{
    public class AuthController : BaseController
    {
        private string GenerateTokenForPlayer(int playerId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.AppSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, playerId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]IDictionary<string, string> data)
        {
            if (!data.ContainsKey("email") || data["email"].Length == 0)
                return BadRequest(new {message = "Email is missing."});

            if (!data.ContainsKey("password") || data["password"].Length == 0)
                return BadRequest(new {message = "Password is missing."});

            var email = data["email"];
            var password = data["password"];

            var queryResult = await Mediator.Send(new GetPlayerQuery {Email = email, Password = password});
            var player = queryResult.Player;

            if (player == null)
                return BadRequest(new {message = "Player with such credentials does not exist."});

            var tokenString = GenerateTokenForPlayer(player.Id);

            return Ok(new
            {
                Id = player.Id,
                Email = player.Email,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] IDictionary<string, string> data)
        {
            if (!data.ContainsKey("email"))
                return BadRequest(new { message = "Email is missing." });

            if (!data.ContainsKey("password"))
                return BadRequest(new { message = "Password is missing." });

            var email = data["email"];
            var password = data["password"];

            try
            {
                await Mediator.Send(new CreatePlayerCommand {Email = email, Password = password});

                var queryResult = await Mediator.Send(new GetPlayerQuery { Email = email, Password = password });
                var player = queryResult.Player;

                var tokenString = GenerateTokenForPlayer(player.Id);

                return Ok(new
                {
                    Id = player.Id,
                    Email = player.Email,
                    Token = tokenString
                });
            }
            catch (PlayerWithSuchEmailAlreadyExistsException)
            {
                return BadRequest(new {message = "Player with such email already exists."});
            }
        }
    }
}