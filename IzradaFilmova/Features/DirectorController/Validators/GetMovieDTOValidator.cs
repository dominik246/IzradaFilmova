using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.DirectorController.Validators
{
    public class GetMovieDTOValidator : AbstractValidator<GetMovieDTO>
    {
        public GetMovieDTOValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
        }
    }
}
