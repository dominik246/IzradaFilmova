using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Director
{
    public class NewDirectorAccountDTOValidator : AbstractValidator<NewDirectorAccountDTO>
    {
        public NewDirectorAccountDTOValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
        }
    }
}
