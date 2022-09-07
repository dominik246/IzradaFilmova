using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Director
{
    public class GetDirectorAccountDTOValidator : AbstractValidator<GetDirectorAccountDTO>
    {
        public GetDirectorAccountDTOValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty();
        }
    }
}
