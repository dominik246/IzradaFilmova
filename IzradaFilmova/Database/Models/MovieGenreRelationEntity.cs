using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    [Table("MovieGenreRelations")]
    public class MovieGenreRelationEntity : BaseEntity
    {
        public Guid MovieId { get; set; }
        public MovieEntity? Movie { get; set; }

        public Guid GenreId { get; set; }
        public GenreEntity? Genre { get; set; }
    }
}
