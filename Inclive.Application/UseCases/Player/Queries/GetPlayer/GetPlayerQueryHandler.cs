using System.Threading;
using System.Threading.Tasks;
using Inclive.Application.Repositories;
using MediatR;

namespace Inclive.Application.UseCases.Player.Queries.GetPlayer
{
    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, GetPlayerQueryResult>
    {
        private readonly IPlayerReadOnlyRepository _playerReadOnlyRepository;

        public GetPlayerQueryHandler(IPlayerReadOnlyRepository playerReadOnlyRepository)
        {
            _playerReadOnlyRepository = playerReadOnlyRepository;
        }

        public async Task<GetPlayerQueryResult> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            var player =
                await _playerReadOnlyRepository.GetPlayerByEmailAndPassword(request.Email, request.Password);

            return new GetPlayerQueryResult {Player = player};
        }
    }
}