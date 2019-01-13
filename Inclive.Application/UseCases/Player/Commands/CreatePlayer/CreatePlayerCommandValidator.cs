using FluentValidation;

namespace Inclive.Application.UseCases.Player.Commands.CreatePlayer
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            //TODO: add appropriate messages when validation fails
            RuleFor(x => x.Email).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(60);
        }
    }
}