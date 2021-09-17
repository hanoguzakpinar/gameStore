using FluentValidation;

namespace WebApi.Application.DeveloperOperations.Queries.GetDeveloperGamesQuery
{
    public class GetDeveloperGamesQueryValidator : AbstractValidator<GetDeveloperGamesQuery>
    {
        public GetDeveloperGamesQueryValidator()
        {
            RuleFor(x => x.devID).GreaterThan(0);
        }
    }
}