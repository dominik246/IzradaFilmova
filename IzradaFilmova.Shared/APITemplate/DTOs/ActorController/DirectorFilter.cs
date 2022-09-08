using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.ActorController
{
    public class DirectorFilter
    {
        public Guid? DirectorId { get; set; }
        public Guid[]? GenreIds { get; set; }
        public DateTime? StartDateOfMovie { get; set; }
        public DateTime? EndDateOfMovie { get; set; }
    }
}
