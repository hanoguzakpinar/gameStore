using FluentValidation;

namespace WebApi.Application.PublisherOperations.Commands.UpdatePublisher
{
    public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Country).MinimumLength(3).NotEmpty();
            RuleFor(x => x.pubID).GreaterThan(0);
        }
    }
}