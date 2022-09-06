using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.DirectorController
{
    public class StopFilmingDTO
    {
        public Guid MovieId { get; set; }
        public DateTime MovieFinishFilming { get; set; }
    }
}
