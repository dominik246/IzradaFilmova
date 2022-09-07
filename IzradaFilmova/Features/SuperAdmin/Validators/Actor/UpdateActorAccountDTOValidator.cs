using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Actor
{
    public class UpdateActorAccountDTOValidator : AbstractValidator<UpdateActorAccountDTO>
    {
        public UpdateActorAccountDTOValidator()
        {
            RuleFor(p => p.ActorId).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
        }
    }
}
