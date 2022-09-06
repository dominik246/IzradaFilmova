using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.DTOs.ActorController
{
    public class ActorFilter
    {
        public bool ShowWhereActorIsInvited { get; set; }
        public bool ShowWhereActorRequestedInvitation { get; set; }
        public bool ShowWhereActorSecuredRole { get; set; }
    }
}
