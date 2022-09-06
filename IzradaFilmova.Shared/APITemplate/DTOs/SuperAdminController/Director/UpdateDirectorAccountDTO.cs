using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director
{
    public class UpdateDirectorAccountDTO
    {
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
