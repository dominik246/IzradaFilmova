using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Genre
{
    public class DeleteGenreDTOValidator : AbstractValidator<DeleteGenreDTO>
    {
        public DeleteGenreDTOValidator()
        {
            RuleFor(p => p.GenreId).NotEmpty();
        }
    }
}
