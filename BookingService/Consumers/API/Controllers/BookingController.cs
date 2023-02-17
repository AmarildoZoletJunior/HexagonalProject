using Application.Booking.DTOs;
using Application.Booking.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }
        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto booking)
        {
            await _bookingManager.CreateBooking(booking);

        }
    }
}
