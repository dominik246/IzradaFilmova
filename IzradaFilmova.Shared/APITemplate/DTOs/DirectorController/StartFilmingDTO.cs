using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.DirectorController
{
    public class StartFilmingDTO
    {
        public Guid MovieId { get; set; }
        public DateTime MovieStart { get; set; }
    }
}
