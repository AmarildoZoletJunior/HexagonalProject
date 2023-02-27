using Application;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Application.Guests.Validators;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            if (res.Success) return Ok(res.Data);
  

            return BadRequest(res);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetGuest([Required]int id)
        {
            var guest = await _ports.GetGuest(id);
            if (guest.Success) return Ok(guest.Data);

            return BadRequest(guest.Message);
        }
    }
}
