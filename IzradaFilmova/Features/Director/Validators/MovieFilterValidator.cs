using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class MovieFilterValidator : AbstractValidator<MovieFilter>
    {
        public MovieFilterValidator()
        {
            RuleFor(p => p.StartDateOfMovie).LessThan(p => p.EndDateOfMovie).When(p => p.StartDateOfMovie.HasValue && p.EndDateOfMovie.HasValue);

            RuleFor(p => p.MinBudget).LessThan(p => p.MaxBudget).When(p => p.MinBudget.HasValue && p.MaxBudget.HasValue)
                                     .GreaterThan(0).When(p => p.MinBudget.HasValue);
        }
    }
}
