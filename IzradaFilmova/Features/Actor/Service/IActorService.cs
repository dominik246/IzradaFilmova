using IzradaFilmova.Database.Models;
using IzradaFilmova.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Service
{
    public interface IActorService
    {
        Task<ServiceResult> ActorChangeSalaryRequest(string userId, ChangeSalaryRequestDTO changeSalary, CancellationToken token);
        Task<ServiceResult> ActorSelfInvite(string userId, InviteActorDTO inviteActor, CancellationToken token);
        Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesByDirector(DirectorFilter directorFilter, CancellationToken token);
        Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesByGenre(GenreFilter genreFilter, CancellationToken token);
        Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesWhereActorIsReferenced(string userId, ActorFilter actorFilter, CancellationToken token);
        Task<ServiceResult<ActorEntity>> GetActorProfile(string userId, CancellationToken token);
        Task<ServiceResult<ActorEntity>> UpdateActorProfile(string userId, UpdateActorProfileDTO updateActorProfile, CancellationToken token);
    }
}
