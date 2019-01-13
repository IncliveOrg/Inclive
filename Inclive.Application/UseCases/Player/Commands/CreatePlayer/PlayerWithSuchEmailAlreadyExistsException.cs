using Inclive.Application.Exceptions;

namespace Inclive.Application.UseCases.Player.Commands.CreatePlayer
{
    public class PlayerWithSuchEmailAlreadyExistsException : ApplicationException
    {
        internal PlayerWithSuchEmailAlreadyExistsException(string email) : base(
            $"Player with email {email} already exists.")
        {
        }
    }
}