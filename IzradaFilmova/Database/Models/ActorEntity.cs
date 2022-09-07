﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzradaFilmova.Database.Models
{
    [Table("Actors")]
    public class ActorEntity : BaseEntity
    {
        [StringLength(32)]
        public string FirstName { get; set; } = default!;
        [StringLength(32)]
        public string LastName { get; set; } = default!;
        [StringLength(64)]
        public string Address { get; set; } = default!;

        public IEnumerable<ActorMovieRelationEntity>? ActorMovieRelations { get; set; }
    }
}
