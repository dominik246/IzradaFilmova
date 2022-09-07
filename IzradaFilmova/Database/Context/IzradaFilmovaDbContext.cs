using IzradaFilmova.Database.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Database.Context
{
    public class IzradaFilmovaDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        public IzradaFilmovaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual ActorEntity Actors { get; set; } = default!;
        public virtual DirectorEntity Directors { get; set; } = default!;
        public virtual GenreEntity Genres { get; set; } = default!;
        public virtual MovieEntity Movies { get; set; } = default!;

        public virtual ActorMovieRelationEntity ActorMovieRelations { get; set; } = default!;
        public virtual MovieGenreRelationEntity MovieGenreRelations { get; set; } = default!;

        protected override void OnModelCreating([NotNull]ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActorEntity>()
                   .HasMany(p => p.ActorMovieRelations)
                   .WithOne(p => p.Actor);
            builder.Entity<MovieEntity>()
                   .HasMany(p => p.ActorMovieRelations)
                   .WithOne(p => p.Movie);

            builder.Entity<DirectorEntity>()
                   .HasMany(p => p.Movies)
                   .WithOne(p => p.Director);

            builder.Entity<GenreEntity>()
                   .HasMany(p => p.MovieGenreRelations)
                   .WithOne(p => p.Genre);
            builder.Entity<MovieEntity>()
                   .HasMany(p => p.MovieGenreRelations)
                   .WithOne(p => p.Movie);

            builder.Entity<ActorEntity>()
                   .HasOne(p => p.User)
                   .WithOne()
                   .HasForeignKey<ActorEntity>(p => p.UserId);
            builder.Entity<DirectorEntity>()
                   .HasOne(p => p.User)
                   .WithOne()
                   .HasForeignKey<DirectorEntity>(p => p.UserId);

            builder.Entity<ActorMovieRelationEntity>()
                   .Property(p => p.RequestedSalary)
                   .HasPrecision(16);
            builder.Entity<ActorMovieRelationEntity>()
                   .Property(p => p.CurrentSalary)
                   .HasPrecision(16);
            builder.Entity<MovieEntity>()
                   .Property(p => p.Budget)
                   .HasPrecision(16);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["SqlServer:ConnectionString"]);
        }
    }
}
