using IzradaFilmova.Database.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor.Repository
{
    public interface IActorRepository
    {
        Task<ActorMovieRelationEntity?> CreateActorMovieRelation(ActorMovieRelationEntity actorMovieRelation, CancellationToken token);
        Task<IList<MovieEntity>> FindMoviesByDirector(DirectorFilter directorFilter, CancellationToken token);
        Task<IList<MovieEntity?>> FindMoviesByGenre(GenreFilter genreFilter, CancellationToken token);
        Task<IList<MovieEntity?>> FindMoviesWithSpecifiedActor(Guid actorId, ActorFilter actorFilter, CancellationToken token);
        Task<ActorEntity?> GetActorByUserId(string userId, CancellationToken token);
        Task<Guid?> GetActorIdFromUserId(string userId, CancellationToken token);
        Task<ActorEntity?> UpdateActor(ActorEntity updateActorProfile, CancellationToken token);
        Task<ActorMovieRelationEntity?> UpdateActorSalary(ActorMovieRelationEntity actorMovieRelation, CancellationToken token);
        Task<ActorMovieRelationEntity?> GetActorMovieRelation(string userId, Guid movieId, CancellationToken token);
    }
}
