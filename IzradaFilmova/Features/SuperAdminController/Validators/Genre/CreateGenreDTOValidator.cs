using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

namespace IzradaFilmova.Features.SuperAdminController.Validators.Genre
{
    public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
    {
        public CreateGenreDTOValidator()
        {
            RuleFor(p => p.GenreName).NotEmpty();
        }
    }
}
