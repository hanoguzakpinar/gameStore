using FluentValidation;

namespace WebApi.Application.PublisherOperations.Commands.DeletePublisher
{
    public class DeletePublisherCommandValidator : AbstractValidator<DeletePublisherCommand>
    {
        public DeletePublisherCommandValidator()
        {
            RuleFor(x => x.pubID).GreaterThan(0);
        }
    }
}