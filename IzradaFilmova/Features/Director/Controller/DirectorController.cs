using IzradaFilmova.Shared.APITemplate.DTOs.DirectorController;
using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzradaFilmova.Features.Director.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DirectorController : ControllerBase, IDirectorController
    {
        public Task<IActionResult> CreateMovie(CreateMovieDTO newMovie, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DirectorAcceptSalaryRequest(AcceptSalaryRequestDTO acceptSalaryRequest, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> FetchAllMovies(MovieFilter? movieFilter, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetMovie(GetMovieDTO movieDto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> InviteActor(InviteActorDTO inviteActor, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> StartOfFilming(StartFilmingDTO startFilming, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> StopOfFilming(StopFilmingDTO stopFilming, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
