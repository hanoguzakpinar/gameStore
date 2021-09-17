using FluentValidation;

namespace WebApi.Application.DeveloperOperations.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommandValidator : AbstractValidator<UpdateDeveloperCommand>
    {
        public UpdateDeveloperCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Country).MinimumLength(3).NotEmpty();
            RuleFor(x => x.devID).GreaterThan(0);
        }
    }
}