using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.Interfaces
{
    public interface IActorController
    {
        public Task<IActionResult> GetProfile(CancellationToken token);
        public Task<IActionResult> UpdateProfile(UpdateActorProfileDTO updateActorProfile, CancellationToken token);

        public Task<IActionResult> ActorSelfInvite(InviteActorDTO inviteActor, CancellationToken token);
        public Task<IActionResult> ActorChangeSalaryRequest(ChangeSalaryRequestDTO changeSalary, CancellationToken token);

        public Task<IActionResult> FetchMoviesWhereActorIsReferenced(ActorFilter actorFilter, CancellationToken token);
        public Task<IActionResult> FetchMoviesByDirector(DirectorFilter directorFilter, CancellationToken token);
        public Task<IActionResult> FetchMoviesByGenre(GenreFilter genreFilter, CancellationToken token);
    }
}
