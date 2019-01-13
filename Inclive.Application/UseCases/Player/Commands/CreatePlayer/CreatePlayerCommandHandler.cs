using System.Threading;
using System.Threading.Tasks;
using Inclive.Application.Repositories;
using MediatR;
using Inclive.Domain.Entities;

namespace Inclive.Application.UseCases.Player.Commands.CreatePlayer
{
    public class CreatePlayerCommandHandler : AsyncRequestHandler<CreatePlayerCommand>
    {
        private readonly IPlayerReadOnlyRepository _playerReadOnlyRepository;
        private readonly IPlayerWriteOnlyRepository _playerWriteOnlyRepository;

        public CreatePlayerCommandHandler(IPlayerReadOnlyRepository playerReadOnlyRepository,
            IPlayerWriteOnlyRepository playerWriteOnlyRepository)
        {
            _playerReadOnlyRepository = playerReadOnlyRepository;
            _playerWriteOnlyRepository = playerWriteOnlyRepository;
        }

        protected override async Task Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var alreadyExists = await _playerReadOnlyRepository.PlayerWithEmailExist(request.Email);

            if (alreadyExists)
                throw new PlayerWithSuchEmailAlreadyExistsException(request.Email);

            var player = new Domain.Entities.Player()
            {
                Email = request.Email,
                Password = request.Password
            };

            await _playerWriteOnlyRepository.CreatePlayer(player);
        }
    }
}