using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor
{
    public class FetchActorAccountDTO
    {
        public Guid? ActorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public decimal? StartSalaryRange { get; set; }
        public decimal? EndSalaryRange { get; set; }
    }
}
