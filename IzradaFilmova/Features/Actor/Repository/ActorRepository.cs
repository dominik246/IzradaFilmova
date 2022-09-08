using IzradaFilmova.Database.Context;
using IzradaFilmova.Database.Models;
using IzradaFilmova.Functions;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

using Microsoft.EntityFrameworkCore;

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace IzradaFilmova.Features.Actor.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly IzradaFilmovaDbContext _db;
        private readonly ILogger<ActorRepository> _logger;
        public ActorRepository(IzradaFilmovaDbContext db, ILogger<ActorRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<ActorMovieRelationEntity?> CreateActorMovieRelation(ActorMovieRelationEntity actorMovieRelation, CancellationToken token)
        {
            var result = await _db.UseTransactionAsync(() =>
            {
                return _db.ActorMovieRelations.Add(actorMovieRelation);
            }, token);

            return result.Item1;
        }

        public async Task<IList<MovieEntity>> FindMoviesByDirector([NotNull] DirectorFilter directorFilter, CancellationToken token)
        {
            var query = _db.Directors.Include(p => p.Movies)!
                                     .ThenInclude(p => p.MovieGenreRelations)
                                     .Where(p => p.Id == directorFilter.DirectorId)
                                     .SelectMany(p => p.Movies!);

            if (directorFilter.StartDateOfMovie.HasValue)
            {
                query = query.Where(p => p.CastingStart == directorFilter.StartDateOfMovie.Value);
            }
            if (directorFilter.EndDateOfMovie.HasValue)
            {
                query = query.Where(p => p.CastingEnd == directorFilter.EndDateOfMovie.Value);
            }

            foreach (var genreId in directorFilter.GenreIds)
            {
                query = query.Where(p => p.MovieGenreRelations!.Any(sp => sp.GenreId == genreId));
            }

            return await query.ToListAsync(token);
        }

        public async Task<IList<MovieEntity?>> FindMoviesByGenre([NotNull] GenreFilter genreFilter, CancellationToken token)
        {
            var query = _db.MovieGenreRelations.Include(p => p.Movie)
                                               .Where(p => p.GenreId == genreFilter.GenreId);

            if (genreFilter.StartDateOfMovie.HasValue)
            {
                query = query.Where(p => p.Movie!.CastingStart == genreFilter.StartDateOfMovie.Value);
            }
            if (genreFilter.EndDateOfMovie.HasValue)
            {
                query = query.Where(p => p.Movie!.CastingEnd == genreFilter.EndDateOfMovie.Value);
            }

            return await query.Select(p => p.Movie).ToListAsync(token);
        }

        public async Task<IList<MovieEntity?>> FindMoviesWithSpecifiedActor(Guid actorId, [NotNull] ActorFilter actorFilter, CancellationToken token)
        {
            var movies = await _db.ActorMovieRelations.Where(p => p.ActorId == actorId)
                                                      .Where(p => (actorFilter.ShowWhereActorIsInvited && p.ApplicationType == MovieApplicationType.ActorInvited) ||
                                                                  (actorFilter.ShowWhereActorRequestedInvitation && p.ApplicationType == MovieApplicationType.ActorRequestedInvitation) ||
                                                                  (actorFilter.ShowWhereActorSecuredRole && p.ApplicationType == MovieApplicationType.ActorSecuredRole))
                                                      .Include(p => p.Movie)
                                                      .Select(p => p.Movie)
                                                      .ToListAsync(token);
            return movies;
        }

        public async Task<ActorEntity?> GetActorByUserId(string userId, CancellationToken token)
        {
            var actor = await _db.Actors.FirstOrDefaultAsync(p => p.UserId == userId, token);
            return actor;
        }

        public async Task<Guid?> GetActorIdFromUserId(string userId, CancellationToken token)
        {
            var actorId = await _db.Actors.Where(p => p.UserId == userId).Select(p => p.Id).FirstOrDefaultAsync(token);
            return actorId;
        }

        public async Task<ActorMovieRelationEntity?> GetActorMovieRelation(string userId, Guid movieId, CancellationToken token)
        {
            var result = await _db.ActorMovieRelations.Include(p => p.Actor)
                                                      .Where(p => p.Actor!.UserId == userId)
                                                      .Where(p => p.MovieId == movieId)
                                                      .FirstOrDefaultAsync(token);
            return result;
        }

        public async Task<ActorEntity?> UpdateActor([NotNull] ActorEntity updateActorProfile, CancellationToken token)
        {
            var result = await _db.UseTransactionAsync(() =>
            {
                return _db.Actors.Update(updateActorProfile);
            }, token);

            return result.Item1;
        }

        public async Task<ActorMovieRelationEntity?> UpdateActorSalary(ActorMovieRelationEntity actorMovieRelation, CancellationToken token)
        {
            var result = await _db.UseTransactionAsync(() =>
            {
                return _db.ActorMovieRelations.Update(actorMovieRelation);
            }, token);

            return result.Item1;
        }
    }
}
