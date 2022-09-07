using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Actor
{
    public class GetActorAccountDTOValidator : AbstractValidator<GetActorAccountDTO>
    {
        public GetActorAccountDTOValidator()
        {
            RuleFor(p => p.ActorId).NotEmpty();
        }
    }
}
