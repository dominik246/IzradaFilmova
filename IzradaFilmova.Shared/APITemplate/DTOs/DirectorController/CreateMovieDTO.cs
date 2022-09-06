using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.DirectorController
{
    public class CreateMovieDTO
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public decimal Budget { get; set; }
        public DateTime? CastingStart { get; set; }
        public DateTime? CastingEnd { get; set; }
        public GenreDTO[]? Genres { get; set; }
    }
}
