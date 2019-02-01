using System.Threading.Tasks;
using Inclive.Application.UseCases.Player.Queries.GetPlayerCharacters;
using Microsoft.AspNetCore.Mvc;

namespace Inclive.Backend.Controllers
{
    public class PlayerController : BaseController
    {
        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var playerId = int.Parse(User.Identity.Name);

            var queryResult = await Mediator.Send(new GetPlayerCharactersQuery {PlayerId = playerId});

            return Ok(queryResult.Characters);
        }
    }
}