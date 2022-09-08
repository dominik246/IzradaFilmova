using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.ActorController
{
    public class InviteActorDTO
    {
        public Guid MovieId { get; set; }
        public decimal RequestedSalary { get; set; }
    }
}
