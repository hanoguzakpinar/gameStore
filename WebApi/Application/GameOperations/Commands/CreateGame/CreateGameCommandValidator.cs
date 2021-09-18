using System;
using FluentValidation;

namespace WebApi.Application.GameOperations.Commands.CreateGame
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.PublisherID).GreaterThan(0);
            RuleFor(x => x.Model.DeveloperID).GreaterThan(0);
            RuleFor(x => x.Model.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}