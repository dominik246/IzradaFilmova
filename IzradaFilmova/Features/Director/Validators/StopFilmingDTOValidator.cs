using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class StopFilmingDTOValidator : AbstractValidator<StopFilmingDTO>
    {
        public StopFilmingDTOValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
            RuleFor(p => p.MovieFinishFilming).GreaterThan(p => DateTime.Now.Date);
        }
    }
}
