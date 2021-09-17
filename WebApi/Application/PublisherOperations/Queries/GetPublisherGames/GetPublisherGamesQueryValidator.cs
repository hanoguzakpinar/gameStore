using FluentValidation;

namespace WebApi.Application.PublisherOperations.Queries.GetPublisherGamesQuery
{
    public class GetPublisherGamesQueryValidator : AbstractValidator<GetPublisherGamesQuery>
    {
        public GetPublisherGamesQueryValidator()
        {
            RuleFor(x => x.pubID).GreaterThan(0);
        }
    }
}