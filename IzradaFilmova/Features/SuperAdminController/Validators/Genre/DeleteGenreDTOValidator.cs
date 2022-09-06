using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

namespace IzradaFilmova.Features.SuperAdminController.Validators.Genre
{
    public class DeleteGenreDTOValidator : AbstractValidator<DeleteGenreDTO>
    {
        public DeleteGenreDTOValidator()
        {
            RuleFor(p => p.GenreId).NotEmpty();
        }
    }
}
