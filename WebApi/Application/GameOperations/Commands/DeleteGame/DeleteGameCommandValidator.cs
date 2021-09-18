using FluentValidation;

namespace WebApi.Application.GameOperations.Commands.DeleteGame
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameCommandValidator()
        {
            RuleFor(x => x.gameID).GreaterThan(0);
        }
    }
}