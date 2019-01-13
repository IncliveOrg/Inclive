using MediatR;

namespace Inclive.Application.UseCases.Player.Commands.CreatePlayer
{
    public class CreatePlayerCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}