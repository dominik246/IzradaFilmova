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
            var actorMovieRelation = await _actorRepository.GetActorMovieRelation(userId, changeSalary.MovieId, token);
            if (actorMovieRelation is null)
            {
                return new ServiceResult<ActorEntity>(default);
            }

            actorMovieRelation.SalaryType = SalaryType.Requested;
            actorMovieRelation.RequestedSalary = changeSalary.SalaryRequested;

            var updateResult = await _actorRepository.UpdateActorSalary(actorMovieRelation, token);
            return updateResult is not null ? ServiceResult.SuccessfulResult : ServiceResult.FailedResult;
        }

        public async Task<ServiceResult> ActorSelfInvite(string userId, [NotNull] InviteActorDTO inviteActor, CancellationToken token)
        {
            var actorId = await _actorRepository.GetActorIdFromUserId(userId, token);
            if (actorId is null)
            {
                return new ServiceResult(new[] { $"{nameof(actorId)} is null. Therefore {nameof(userId)} is invalid." });
            }

            var newActorMovieRelation = new ActorMovieRelationEntity
            {
                ActorId = actorId.Value,
                ApplicationType = MovieApplicationType.ActorRequestedInvitation,
                MovieId = inviteActor.MovieId,
                RequestedSalary = inviteActor.RequestedSalary,
                SalaryType = SalaryType.Requested
            };

            var actorMovieRelation = await _actorRepository.CreateActorMovieRelation(newActorMovieRelation, token);
            return actorMovieRelation is not null ? ServiceResult.SuccessfulResult : ServiceResult.FailedResult;
        }

        public async Task<ServiceResult<IList<MovieEntity>>> FetchMoviesByDirector(DirectorFilter directorFilter, CancellationToken token)
        {
            var movies = await _actorRepository.FindMoviesByDirector(directorFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<IList<MovieEntity>>> FetchMoviesByGenre(GenreFilter genreFilter, CancellationToken token)
        {
            var movies = await _actorRepository.FindMoviesByGenre(genreFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<IList<MovieEntity>>> FetchMoviesWhereActorIsReferenced(string userId, ActorFilter actorFilter, CancellationToken token)
        {
            var actorId = await _actorRepository.GetActorIdFromUserId(userId, token);
            if (actorId is null)
            {
                return new(default, new[] { $"{nameof(actorId)} is null. Therefore {nameof(userId)} is invalid." });
            }

            var movies = await _actorRepository.FindMoviesWithSpecifiedActor(actorId.Value, actorFilter, token);
            return new(movies);
        }

        public async Task<ServiceResult<ActorEntity>> GetActorProfile(string userId, CancellationToken token)
        {
            var actor = await _actorRepository.GetActorByUserId(userId, token);
            return new(actor);
        }

        public async Task<ServiceResult<ActorEntity>> UpdateActorProfile(string userId, [NotNull] ActorEntity updateActorProfile, CancellationToken token)
        {
            var actor = await _actorRepository.GetActorByUserId(userId, token);
            if (actor is null)
            {
                return new ServiceResult<ActorEntity>(default);
            }

            updateActorProfile.Id = actor.Id;
            updateActorProfile.UserId = actor.UserId;

            var updatedResult = await _actorRepository.UpdateActor(updateActorProfile, token);
            return new(updatedResult);
        }
    }
}
