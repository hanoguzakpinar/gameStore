using FluentValidation;

namespace WebApi.Application.PublisherOperations.Commands.CreatePublisher
{
    public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Country).MinimumLength(3).NotEmpty();
        }
    }
}