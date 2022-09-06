using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre
{
    public class FetchGenreDTO
    {
        public Guid? GenreId { get; set; }
        public string? GenreName { get; set; }
    }
}
