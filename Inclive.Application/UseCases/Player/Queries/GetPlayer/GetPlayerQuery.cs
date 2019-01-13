using MediatR;

namespace Inclive.Application.UseCases.Player.Queries.GetPlayer
{
    public class GetPlayerQuery : IRequest<GetPlayerQueryResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}