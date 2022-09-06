using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.DirectorController.Validators
{
    public class GenreDTOValidator : AbstractValidator<GenreDTO>
    {
        public GenreDTOValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
