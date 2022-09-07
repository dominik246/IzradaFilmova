using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    [Table("Directors")]
    public class DirectorEntity : BaseEntity
    {
        [StringLength(32)]
        public string FirstName { get; set; } = default!;
        [StringLength(32)]
        public string LastName { get; set; } = default!;

        public IEnumerable<MovieEntity>? Movies { get; set; }
    }
}
