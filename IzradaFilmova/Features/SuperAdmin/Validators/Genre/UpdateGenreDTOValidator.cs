using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Genre
{
    public class UpdateGenreDTOValidator : AbstractValidator<UpdateGenreDTO>
    {
        public UpdateGenreDTOValidator()
        {
            RuleFor(p => p.GenreId).NotEmpty();
            RuleFor(p => p.GenreName).NotEmpty();
        }
    }
}
