using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzradaFilmova.Shared.APITemplate.Interfaces
{
    public interface ISuperAdminController
    {
        public Task<IActionResult> CreateDirectorAccount(NewDirectorAccountDTO newDirectorAccount, CancellationToken token);
        public Task<IActionResult> UpdateDirectorAccount(UpdateDirectorAccountDTO updateDirectorAccount, CancellationToken token);
        public Task<IActionResult> GetDirectorAccount(GetDirectorAccountDTO getDirectorAccount, CancellationToken token);
        public Task<IActionResult> FetchDirectorAccounts(FetchDirectorAccountDTO fetchDirectorAccount, CancellationToken token);
        public Task<IActionResult> DeleteDirectorAccount(DeleteDirectorAccountDTO deleteDirectorAccount, CancellationToken token);

        public Task<IActionResult> CreateActorAccount(NewActorAccountDTO newActorAccount, CancellationToken token);
        public Task<IActionResult> UpdateActorAccount(UpdateActorAccountDTO updateActorAccount, CancellationToken token);
        public Task<IActionResult> GetActorAccount(GetActorAccountDTO getActorAccount, CancellationToken token);
        public Task<IActionResult> FetchActorAccounts(FetchActorAccountDTO fetchActorAccounts, CancellationToken token);
        public Task<IActionResult> DeleteActorAccount(DeleteActorAccountDTO deleteActorAccount, CancellationToken token);

        public Task<IActionResult> CreateGenre(CreateGenreDTO createGenre, CancellationToken token);
        public Task<IActionResult> UpdateGenre(UpdateGenreDTO updateGenre, CancellationToken token);
        public Task<IActionResult> FetchGenres(FetchGenreDTO fetchGenres, CancellationToken token);
        public Task<IActionResult> DeleteGenres(DeleteGenreDTO deleteGenre, CancellationToken token);
    }
}
