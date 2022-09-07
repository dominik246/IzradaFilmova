using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class StartFilmingDTOValidator : AbstractValidator<StartFilmingDTO>
    {
        public StartFilmingDTOValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
            RuleFor(p => p.MovieStart).GreaterThan(p => DateTime.Now.Date);
        }
    }
}
