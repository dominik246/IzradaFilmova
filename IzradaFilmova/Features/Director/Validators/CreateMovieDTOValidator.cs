using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class CreateMovieDTOValidator : AbstractValidator<CreateMovieDTO>
    {
        public CreateMovieDTOValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.CastingStart).GreaterThan(p => DateTime.Now.Date);
            RuleFor(p => p.CastingEnd).GreaterThan(p => DateTime.Now.Date)
                                      .GreaterThan(p => p.CastingStart);
            RuleFor(p => p.Duration).GreaterThan(p => TimeSpan.Zero);
            RuleFor(p => p.Budget).GreaterThan(0);
            RuleFor(p => p.Description).MaximumLength(5000);
            RuleForEach(p => p.Genres).SetValidator(new GenreDTOValidator()).When(p => p.Genres is not null);
        }
    }
}
