using FluentValidation;
using System;

namespace WebApi.Application.GameOperations.Commands.UpdateGame
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(x => x.gameID).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
            RuleFor(x => x.Model.GenreID).GreaterThan(0);
            RuleFor(x => x.Model.Price).GreaterThan(0);
            RuleFor(x => x.Model.ReleaseDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.PublisherID).GreaterThan(0);
            RuleFor(command => command.Model.DeveloperID).GreaterThan(0);
        }
    }
}