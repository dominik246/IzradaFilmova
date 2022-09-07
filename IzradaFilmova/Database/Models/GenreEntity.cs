using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    [Table("Genres")]
    public class GenreEntity : BaseEntity
    {
        [StringLength(32)]
        public string GenreName { get; set; } = default!;

        public IEnumerable<MovieGenreRelationEntity>? MovieGenreRelations { get; set; }
    }
}
