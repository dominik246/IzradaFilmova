using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    [Table("Movies")]
    public class MovieEntity : BaseEntity
    {
        [StringLength(32)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Budget { get; set; }
        public DateTime CastingStart { get; set; }
        public DateTime CastingEnd { get; set; }

        public Guid DirectorId { get; set; }
        public DirectorEntity? Director { get; set; }

        public IEnumerable<MovieGenreRelationEntity>? MovieGenreRelations { get; set; }
        public IEnumerable<ActorMovieRelationEntity>? ActorMovieRelations { get; set; }
    }
}
