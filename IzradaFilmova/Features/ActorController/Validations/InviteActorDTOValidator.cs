using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.ActorController.Validations
{
    public class InviteActorDTOValidator : AbstractValidator<InviteActorDTO>
    {
        public InviteActorDTOValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
            RuleFor(p => p.ActorId).NotEmpty();
        }
    }
}
