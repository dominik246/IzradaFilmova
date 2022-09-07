using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class GetMovieDTOValidator : AbstractValidator<GetMovieDTO>
    {
        public GetMovieDTOValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
        }
    }
}
