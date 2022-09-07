using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class CreateMovieDTOValidator : AbstractValidator<CreateMovieDTO>
    {
        public CreateMovieDTOValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.CastingStart).GreaterThan(p => DateTime.Now.Date).When(p => p.CastingStart.HasValue);
            RuleFor(p => p.CastingEnd).GreaterThan(p => DateTime.Now.Date).When(p => p.CastingEnd.HasValue)
                                      .GreaterThan(p => p.CastingStart).When(p => p.CastingStart.HasValue);
            RuleFor(p => p.Duration).GreaterThan(p => TimeSpan.Zero).When(p => p.Duration.HasValue);
            RuleFor(p => p.Budget).GreaterThan(0);
            RuleFor(p => p.Description).MaximumLength(5000);
            RuleForEach(p => p.Genres).SetValidator(new GenreDTOValidator()).When(p => p.Genres is not null);
        }
    }
}
