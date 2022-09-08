using AutoMapper;

using FluentValidation;
using FluentValidation.AspNetCore;

using IzradaFilmova.Features.Actor.Service;
using IzradaFilmova.Functions;
using IzradaFilmova.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;
using IzradaFilmova.Shared.APITemplate.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace IzradaFilmova.Features.Actor.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Actor")]
    public class ActorController : ControllerBase, IActorController
    {
        private readonly ILogger<ActorController> _logger;
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeSalaryRequestDTO> _changeSalaryRequestDTOValidator;
        private readonly IValidator<InviteActorDTO> _inviteActorDTOValidator;
        private readonly IValidator<DirectorFilter> _directorFilterValidator;
        private readonly IValidator<GenreFilter> _genreFilterValidator;
        private readonly IValidator<ActorFilter> _actorFilterValidator;
        private readonly IValidator<UpdateActorProfileDTO> _updateActorProfileDTOValidator;

        public ActorController(ILogger<ActorController> logger, 
            IActorService actorService,
            IMapper mapper,
            IValidator<ChangeSalaryRequestDTO> changeSalaryRequestDTOValidator,
            IValidator<InviteActorDTO> inviteActorDTOValidator,
            IValidator<DirectorFilter> directorFilterValidator,
            IValidator<GenreFilter> genreFilterValidator,
            IValidator<ActorFilter> actorFilterValidator,
            IValidator<UpdateActorProfileDTO> updateActorProfileDTOValidator)
        {
            _logger = logger;
            _actorService = actorService;
            _mapper = mapper;
            _changeSalaryRequestDTOValidator = changeSalaryRequestDTOValidator;
            _inviteActorDTOValidator = inviteActorDTOValidator;
            _directorFilterValidator = directorFilterValidator;
            _genreFilterValidator = genreFilterValidator;
            _actorFilterValidator = actorFilterValidator;
            _updateActorProfileDTOValidator = updateActorProfileDTOValidator;
        }

        [HttpPost]
        public async Task<IActionResult> ActorChangeSalaryRequest(ChangeSalaryRequestDTO changeSalary, CancellationToken token)
        {
            var validatorResult = await _changeSalaryRequestDTOValidator.ValidateAsync(changeSalary, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(ChangeSalaryRequestDTO));
                return BadRequest(ModelState);
            }

            var userId = HttpContext.FindUserId();
            if (userId is null)
            {
                ModelState.AddErrorToModelStateIfPropertyIsNull(nameof(userId));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.ActorChangeSalaryRequest(userId, changeSalary, token);
            if (requestResult.IsSuccessful)
            {
                return NoContent();
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> ActorSelfInvite(InviteActorDTO inviteActor, CancellationToken token)
        {
            var validatorResult = await _inviteActorDTOValidator.ValidateAsync(inviteActor, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(InviteActorDTO));
                return BadRequest(ModelState);
            }

            var userId = HttpContext.FindUserId();
            if (userId is null)
            {
                ModelState.AddErrorToModelStateIfPropertyIsNull(nameof(userId));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.ActorSelfInvite(userId, inviteActor, token);
            if (requestResult.IsSuccessful)
            {
                return NoContent();
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> FetchMoviesByDirector(DirectorFilter directorFilter, CancellationToken token)
        {
            var validatorResult = await _directorFilterValidator.ValidateAsync(directorFilter, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(DirectorFilter));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.FetchMoviesByDirector(directorFilter, token);
            if (requestResult.IsSuccessful)
            {
                return Ok(_mapper.Map<IEnumerable<MovieDTO>>(requestResult.ReturnValue));
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> FetchMoviesByGenre(GenreFilter genreFilter, CancellationToken token)
        {
            var validatorResult = await _genreFilterValidator.ValidateAsync(genreFilter, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(GenreFilter));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.FetchMoviesByGenre(genreFilter, token);
            if (requestResult.IsSuccessful)
            {
                return Ok(_mapper.Map<IEnumerable<MovieDTO>>(requestResult.ReturnValue));
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> FetchMoviesWhereActorIsReferenced(ActorFilter actorFilter, CancellationToken token)
        {
            var validatorResult = await _actorFilterValidator.ValidateAsync(actorFilter, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(ActorFilter));
                return BadRequest(ModelState);
            }

            var userId = HttpContext.FindUserId();
            if (userId is null)
            {
                ModelState.AddErrorToModelStateIfPropertyIsNull(nameof(userId));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.FetchMoviesWhereActorIsReferenced(userId, actorFilter, token);
            if (requestResult.IsSuccessful)
            {
                return Ok(_mapper.Map<IEnumerable<MovieDTO>>(requestResult.ReturnValue));
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(CancellationToken token)
        {
            var userId = HttpContext.FindUserId();
            if (userId is null)
            {
                ModelState.AddErrorToModelStateIfPropertyIsNull(nameof(userId));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.GetActorProfile(userId, token);
            if (requestResult.IsSuccessful)
            {
                return Ok(_mapper.Map<ActorDTO>(requestResult.ReturnValue));
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateActorProfileDTO updateActorProfile, CancellationToken token)
        {
            var validatorResult = await _updateActorProfileDTOValidator.ValidateAsync(updateActorProfile, token);
            if (validatorResult.IsValid is false)
            {
                validatorResult.AddToModelState(ModelState, nameof(UpdateActorProfileDTO));
                return BadRequest(ModelState);
            }

            var userId = HttpContext.FindUserId();
            if (userId is null)
            {
                ModelState.AddErrorToModelStateIfPropertyIsNull(nameof(userId));
                return BadRequest(ModelState);
            }

            var requestResult = await _actorService.UpdateActorProfile(userId, updateActorProfile, token);
            if (requestResult.IsSuccessful)
            {
                return Ok(_mapper.Map<ActorDTO>(requestResult.ReturnValue));
            }

            requestResult.AddFailedReasonToModelState(ModelState);
            return BadRequest(ModelState);
        }
    }
}
