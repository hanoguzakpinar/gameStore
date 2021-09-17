using FluentValidation;

namespace WebApi.Application.PublisherOperations.Queries.GetPublisherDetail
{
    public class GetPublisherDetailQueryValidator : AbstractValidator<GetPublisherDetailQuery>
    {
        public GetPublisherDetailQueryValidator()
        {
            RuleFor(x => x.pubID).GreaterThan(0);
        }
    }
}