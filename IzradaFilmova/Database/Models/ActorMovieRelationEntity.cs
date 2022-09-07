using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    public enum MovieApplicationType
    {
        ActorInvited,
        ActorRequestedInvitation,
        ActorSecuredRole
    }

    public enum SalaryType
    {
        Approved,
        Requested,
        Denied
    }

    [Table("ActorMovieRelations")]
    public class ActorMovieRelationEntity : BaseEntity
    {
        public Guid ActorId { get; set; }
        public ActorEntity? Actor { get; set; }

        public Guid MovieId { get; set; }
        public MovieEntity? Movie { get; set; }

        public decimal CurrentSalary { get; set; }
        public decimal RequestedSalary { get; set; }
        public SalaryType SalaryType { get; set; }

        public MovieApplicationType ApplicationType { get; set; }
    }
}
