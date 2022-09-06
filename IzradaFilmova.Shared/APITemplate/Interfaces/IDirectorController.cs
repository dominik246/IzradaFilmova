using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.Interfaces
{
    public interface IDirectorController
    {
        public Task<IActionResult> FetchAllMovies(MovieFilter? movieFilter, CancellationToken token);
        public Task<IActionResult> GetMovie(GetMovieDTO movieDto, CancellationToken token);
        public Task<IActionResult> InviteActor(InviteActorDTO inviteActor, CancellationToken token);
        public Task<IActionResult> DirectorAcceptSalaryRequest(AcceptSalaryRequestDTO acceptSalaryRequest, CancellationToken token);
        public Task<IActionResult> CreateMovie(CreateMovieDTO newMovie, CancellationToken token);
        public Task<IActionResult> StartOfFilming(StartFilmingDTO startFilming, CancellationToken token);
        public Task<IActionResult> StopOfFilming(StopFilmingDTO stopFilming, CancellationToken token);
    }
}
