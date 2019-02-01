using MediatR;

namespace Inclive.Application.UseCases.Player.Queries.GetPlayerCharacters
{
    public class GetPlayerCharactersQuery : IRequest<GetPlayerCharactersQueryResult>
    {
        public int PlayerId { get; set; }
    }
}