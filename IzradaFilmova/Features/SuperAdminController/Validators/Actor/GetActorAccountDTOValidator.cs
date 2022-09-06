using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;

namespace IzradaFilmova.Features.SuperAdminController.Validators.Actor
{
    public class GetActorAccountDTOValidator : AbstractValidator<GetActorAccountDTO>
    {
        public GetActorAccountDTOValidator()
        {
            RuleFor(p => p.ActorId).NotEmpty();
        }
    }
}
