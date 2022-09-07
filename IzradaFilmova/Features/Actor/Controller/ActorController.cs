using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;
using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzradaFilmova.Features.Actor.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActorController : ControllerBase, IActorController
    {
    }
}
