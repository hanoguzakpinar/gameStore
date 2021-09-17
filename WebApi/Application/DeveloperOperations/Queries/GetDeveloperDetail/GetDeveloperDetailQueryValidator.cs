using FluentValidation;

namespace WebApi.Application.DeveloperOperations.Queries.GetDeveloperDetail
{
    public class GetDeveloperDetailQueryValidator : AbstractValidator<GetDeveloperDetailQuery>
    {
        public GetDeveloperDetailQueryValidator()
        {
            RuleFor(x => x.devID).GreaterThan(0);
        }
    }
}