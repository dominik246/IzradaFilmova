using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.ActorController
{
    public class ChangeSalaryRequestDTO
    {
        public Guid MovieId { get; set; }
        public decimal SalaryRequested { get; set; }
    }
}
