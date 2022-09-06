using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.DirectorController.Validators
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
