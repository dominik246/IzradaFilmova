using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Validations
{
    public class GenreFilterValidator : AbstractValidator<GenreFilter>
    {
        public GenreFilterValidator()
        {
            RuleFor(p => p.GenreId).NotEmpty();
            RuleFor(p => p.StartDateOfMovie).LessThan(p => p.EndDateOfMovie).When(p => p.EndDateOfMovie.HasValue && p.StartDateOfMovie.HasValue);
        }
    }
}
