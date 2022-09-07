using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;

namespace IzradaFilmova.Features.SuperAdmin.Validators.Actor
{
    public class FetchActorAccountDTOValidator : AbstractValidator<FetchActorAccountDTO>
    {
        public FetchActorAccountDTOValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().When(p => p.FirstName is not null);
            RuleFor(p => p.LastName).NotEmpty().When(p => p.LastName is not null);
            RuleFor(p => p.Address).NotEmpty().When(p => p.Address is not null);
            RuleFor(p => p.ActorId).NotEmpty().When(p => p.ActorId.HasValue);
            RuleFor(p => p.EndSalaryRange).LessThan(p => p.StartSalaryRange).When(p => p.StartSalaryRange.HasValue && p.EndSalaryRange.HasValue);
        }
    }
}
