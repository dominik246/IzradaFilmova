using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Actor
{
    public class DeleteActorAccountDTOValidator : AbstractValidator<DeleteActorAccountDTO>
    {
        public DeleteActorAccountDTOValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty();
        }
    }
}
