using Application.Guests.Requests;
using Application.Room.DTOs;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomManager _roomManager;
        private readonly ILogger<GuestController> _logger;
        public RoomController(IRoomManager roomManager, ILogger<GuestController> logger)
        {
            _roomManager = roomManager;
            _logger = logger;
        }

        [HttpPost]

        public async Task<ActionResult<RoomResponse>> Post(RoomDto room)
        {
            var request = new CreateRoomRequest
            {
                Data = room
            };
            var res = await _roomManager.CreateRoom(request);
            Console.WriteLine(res.Data.Id);
            if (res.Success) return Ok(res.Data);

            return BadRequest(res.ListMessages);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetRoom(int id)
        {
            var request = await _roomManager.GetRoomById(id);
            if (request.Success) return Ok(request.Data);

            return BadRequest(request.Message);
        }

    }
}
