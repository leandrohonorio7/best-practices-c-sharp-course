using AutoMapper;
using Avanade.BestPractices.API.Models.Charge;
using Avanade.BestPractices.API.Models.Ride;
using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Services;
using Avanade.BestPractices.Infrestructure.Core.Entities.Exceptions;
using Avanade.BestPractices.Infrestructure.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.API.Controllers
{
    [ApiController]
    [Route("rides")]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;

        public RideController(IRideService rideService,
            IMapper mapper)
        {
            _rideService = rideService;
            _mapper = mapper;
        }

        [HttpPost("start")]
        [ProducesResponseType(typeof(RideModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Start([FromBody] StartRideRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ride = await _rideService.StartAsync(request.VehicleId, request.AccountId);

            var response = _mapper.Map<Ride, RideModel>(ride);
            return Ok(response);
        }

        [HttpPost("finish/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Finish([FromRoute] Guid id)
        {
            if (id.IsEmpty())
                return BadRequest();

            await _rideService.FinishAsync(id);
            return Ok();
        }
    }
}
