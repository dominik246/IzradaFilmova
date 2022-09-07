using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Validations
{
    public class UpdateActorProfileDTOValidator : AbstractValidator<UpdateActorProfileDTO>
    {
        public UpdateActorProfileDTOValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.ExpectedSalaries).NotNull();
        }
    }
}
