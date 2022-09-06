using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.DirectorController
{
    public class InviteActorDTO
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
    }
}
