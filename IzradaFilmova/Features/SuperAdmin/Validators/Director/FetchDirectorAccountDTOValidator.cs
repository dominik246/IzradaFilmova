using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Director
{
    public class FetchDirectorAccountDTOValidator : AbstractValidator<FetchDirectorAccountDTO>
    {
        public FetchDirectorAccountDTOValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().When(p => p.FirstName is not null);
            RuleFor(p => p.LastName).NotEmpty().When(p => p.LastName is not null);
            RuleFor(p => p.DirectorId).NotEmpty().When(p => p.DirectorId.HasValue);
        }
    }
}
