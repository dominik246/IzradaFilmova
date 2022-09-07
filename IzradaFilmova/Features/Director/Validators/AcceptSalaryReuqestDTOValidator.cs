using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

namespace IzradaFilmova.Features.Director.Validators
{
    public class AcceptSalaryReuqestDTOValidator : AbstractValidator<AcceptSalaryRequestDTO>
    {
        public AcceptSalaryReuqestDTOValidator()
        {
            RuleFor(p => p.ActorId).NotEmpty();
            RuleFor(p => p.MovieId).NotEmpty();
        }
    }
}
