using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

namespace IzradaFilmova.Features.SuperAdminController.Validators.Genre
{
    public class FetchGenreDTOValidator : AbstractValidator<FetchGenreDTO>
    {
        public FetchGenreDTOValidator()
        {
            RuleFor(p => p.GenreId).NotEmpty().When(p => p.GenreId.HasValue);
            RuleFor(p => p.GenreName).NotEmpty().When(p => p.GenreName is not null);
        }
    }
}
