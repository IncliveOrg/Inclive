using System.Threading;
using System.Threading.Tasks;
using Inclive.Application.Repositories;
using MediatR;

namespace Inclive.Application.UseCases.Player.Queries.GetPlayerCharacters
{
    public class GetPlayerCharactersQueryHandler : IRequestHandler<GetPlayerCharactersQuery, GetPlayerCharactersQueryResult>
    {
        private readonly IPlayerReadOnlyRepository _playerReadOnlyRepository;

        public GetPlayerCharactersQueryHandler(IPlayerReadOnlyRepository playerReadOnlyRepository)
        {
            _playerReadOnlyRepository = playerReadOnlyRepository;
        }

        public async Task<GetPlayerCharactersQueryResult> Handle(GetPlayerCharactersQuery request, CancellationToken cancellationToken)
        {
            var characters =
                await _playerReadOnlyRepository.GetPlayerCharacters(request.PlayerId);
            return new GetPlayerCharactersQueryResult {Characters = characters};
        }
    }
}