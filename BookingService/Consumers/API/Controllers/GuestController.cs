using Application;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Application.Guests.Validators;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _ports;

        public GuestController(ILogger<GuestController> logger, IGuestManager ports)
        {
            _logger = logger;
            _ports = ports;
        }

        [HttpPost]

        public async Task<ActionResult<GuestDto>> Post(GuestDto guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };
            var res = await _ports.CreateGuest(request);
            if (res.Success) return Created("", res.Data);

            if(res.ErrorCode == ErrorCodes.COULDNOT_STORE_DATA)
            {
                _logger.LogError("A response retornou um erro desconhecido");
                return BadRequest(res);
            }
            return BadRequest(500);
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var Guests = await _ports.GetGuests();
            return Ok(Guests);
        }
    }
}
