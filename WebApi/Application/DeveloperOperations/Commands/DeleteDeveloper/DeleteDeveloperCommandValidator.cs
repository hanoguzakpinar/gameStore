using FluentValidation;

namespace WebApi.Application.DeveloperOperations.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommandValidator : AbstractValidator<DeleteDeveloperCommand>
    {
        public DeleteDeveloperCommandValidator()
        {
            RuleFor(x => x.devID).GreaterThan(0);
        }
    }
}