using System.Collections.Generic;
using Inclive.Domain.Entities;

namespace Inclive.Application.UseCases.Player.Queries.GetPlayerCharacters
{
    public class GetPlayerCharactersQueryResult
    {
        public IEnumerable<Character> Characters { get; set; }
    }
}