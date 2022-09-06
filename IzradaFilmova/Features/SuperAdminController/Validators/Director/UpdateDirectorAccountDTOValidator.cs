using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;

namespace IzradaFilmova.Features.SuperAdminController.Validators.Director
{
    public class UpdateDirectorAccountDTOValidator : AbstractValidator<UpdateDirectorAccountDTO>
    {
        public UpdateDirectorAccountDTOValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
        }
    }
}
