using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;
using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzradaFilmova.Features.SuperAdmin.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SuperAdminController : ControllerBase, ISuperAdminController
    {
        public Task<IActionResult> CreateActorAccount(NewActorAccountDTO newActorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateDirectorAccount(NewDirectorAccountDTO newDirectorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateGenre(CreateGenreDTO createGenre, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteActorAccount(DeleteActorAccountDTO deleteActorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDirectorAccount(DeleteDirectorAccountDTO deleteDirectorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteGenres(DeleteGenreDTO deleteGenre, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> FetchActorAccounts(FetchActorAccountDTO fetchActorAccounts, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> FetchDirectorAccounts(FetchDirectorAccountDTO fetchDirectorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> FetchGenres(FetchGenreDTO fetchGenres, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetActorAccount(GetActorAccountDTO getActorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetDirectorAccount(GetDirectorAccountDTO getDirectorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateActorAccount(UpdateActorAccountDTO updateActorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateDirectorAccount(UpdateDirectorAccountDTO updateDirectorAccount, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateGenre(UpdateGenreDTO updateGenre, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
