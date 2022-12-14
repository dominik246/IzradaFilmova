using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Director
{
    public class DeleteDirectorAccountDTOValidator : AbstractValidator<DeleteDirectorAccountDTO>
    {
        public DeleteDirectorAccountDTOValidator()
        {
            RuleFor(p => p.DirectorId).NotEmpty();
        }
    }
}
