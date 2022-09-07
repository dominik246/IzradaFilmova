using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Validations
{
    public class ChangeSalaryRequestValidator : AbstractValidator<ChangeSalaryRequestDTO>
    {
        public ChangeSalaryRequestValidator()
        {
            RuleFor(p => p.MovieId).NotEmpty();
            RuleFor(p => p.SalaryRequested).GreaterThan(0);
        }
    }
}
