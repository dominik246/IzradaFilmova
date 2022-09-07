using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
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
