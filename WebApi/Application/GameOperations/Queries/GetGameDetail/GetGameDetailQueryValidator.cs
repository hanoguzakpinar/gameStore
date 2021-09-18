using FluentValidation;

namespace WebApi.Application.GameOperations.Queries.GetGameDetail
{
    public class GetGameDetailQueryValidator : AbstractValidator<GetGameDetailQuery>
    {
        public GetGameDetailQueryValidator()
        {
            RuleFor(x => x.gameID).GreaterThan(0);
        }
    }
}