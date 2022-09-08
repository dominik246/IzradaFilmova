using IzradaFilmova.Database.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Repository
{
    public interface IActorRepository
    {
        Task<ActorMovieRelationEntity> CreateActorMovieRelationForActorSelfInvitation(Guid actorId, InviteActorDTO inviteActor, CancellationToken token);
        Task<IEnumerable<MovieEntity>> FindMoviesByDirector(DirectorFilter directorFilter, CancellationToken token);
        Task<IEnumerable<MovieEntity>> FindMoviesByGenre(GenreFilter genreFilter, CancellationToken token);
        Task<IEnumerable<MovieEntity>> FindMoviesWithSpecifiedActor(Guid actorId, ActorFilter actorFilter, CancellationToken token);
        Task<ActorEntity> GetActorByUserId(string userId, CancellationToken token);
        Task<Guid> GetActorIdFromUserId(string userId, CancellationToken token);
        Task<ActorEntity> UpdateActorByUserId(string userId, UpdateActorProfileDTO updateActorProfile, CancellationToken token);
        Task<bool> UpdateActorSalaryByUserId(string userId, ChangeSalaryRequestDTO changeSalary, CancellationToken token);
    }
}
