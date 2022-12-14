using FluentValidation;

using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Validations
{
    public class DirectorFilterValidator : AbstractValidator<DirectorFilter>
    {
        public DirectorFilterValidator()
        {
            RuleFor(p => p.DirectorId).NotEmpty();
            RuleFor(p => p.StartDateOfMovie).LessThan(p => p.EndDateOfMovie).When(p => p.StartDateOfMovie.HasValue && p.EndDateOfMovie.HasValue);
        }
    }
}
