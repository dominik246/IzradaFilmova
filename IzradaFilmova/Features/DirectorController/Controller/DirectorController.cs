using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzradaFilmova.Features.DirectorController.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DirectorController : ControllerBase, IDirectorController
    {
    }
}
