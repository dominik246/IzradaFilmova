using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.DirectorController
{
    public class MovieFilter
    {
        public Guid[]? GenreIds { get; set; }

        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }

        public DateTime? StartDateOfMovie { get; set; }
        public DateTime? EndDateOfMovie { get; set; }
    }
}
