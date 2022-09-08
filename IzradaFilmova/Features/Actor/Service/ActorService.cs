using IzradaFilmova.Database.Models;
using IzradaFilmova.Features.Actor.Repository;
using IzradaFilmova.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Features.Actor.Service
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly ILogger<ActorService> _logger;
        public ActorService(IActorRepository actorRepository, ILogger<ActorService> logger)
        {
            _actorRepository = actorRepository;
            _logger = logger;
        }
        public async Task<ServiceResult> ActorChangeSalaryRequest(string userId, [NotNull] ChangeSalaryRequestDTO changeSalary, CancellationToken token)
        {
            var updateResult = await _actorRepository.UpdateActorSalaryByUserId(userId, changeSalary, token);
            return updateResult ? ServiceResult.SuccessfulResult : ServiceResult.FailedResult;
        }

        public async Task<ServiceResult> ActorSelfInvite(string userId, [NotNull] InviteActorDTO inviteActor, CancellationToken token)
        {
            var actorId = await _actorRepository.GetActorIdFromUserId(userId, token);
            var actorMovieRelation = await _actorRepository.CreateActorMovieRelationForActorSelfInvitation(actorId, inviteActor, token);
            return actorMovieRelation is not null ? ServiceResult.SuccessfulResult : ServiceResult.FailedResult;
        }

        public async Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesByDirector(DirectorFilter directorFilter, CancellationToken token)
        {
            var movies = await _actorRepository.FindMoviesByDirector(directorFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesByGenre(GenreFilter genreFilter, CancellationToken token)
        {
            var movies = await _actorRepository.FindMoviesByGenre(genreFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<IEnumerable<MovieEntity>>> FetchMoviesWhereActorIsReferenced(string userId, ActorFilter actorFilter, CancellationToken token)
        {
            var actorId = await _actorRepository.GetActorIdFromUserId(userId, token);
            var movies = await _actorRepository.FindMoviesWithSpecifiedActor(actorId, actorFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<ActorEntity>> GetActorProfile(string userId, CancellationToken token)
        {
            var actor = await _actorRepository.GetActorByUserId(userId, token);
            return new(actor);
        }

        public async Task<ServiceResult<ActorEntity>> UpdateActorProfile(string userId, UpdateActorProfileDTO updateActorProfile, CancellationToken token)
        {
            var updatedResult = await _actorRepository.UpdateActorByUserId(userId, updateActorProfile, token);
            return new(updatedResult);
        }
    }
}
