using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Actor;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Director;
using IzradaFilmova.Shared.APITemplate.DTOs.SuperAdminController.Genre;
using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzradaFilmova.Features.SuperAdminController.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SuperAdminController : ControllerBase, ISuperAdminController
    {
    }
}
