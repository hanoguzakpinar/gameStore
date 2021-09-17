using FluentValidation;

namespace WebApi.Application.DeveloperOperations.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand>
    {
        public CreateDeveloperCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Country).MinimumLength(3).NotEmpty();
        }
    }
}