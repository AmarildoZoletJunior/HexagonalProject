using Application.Booking.DTOs;
using Application.Booking.Ports;
using Application.Booking.Request;
using Application.Guests.Requests;
using Application.Payments.Request;
using Application.Payments.Response;
using Domain.Entities;
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
            var request = new CreateBookingRequest
            {
                Data = booking
            };
            var response = await _bookingManager.CreateBooking(request);
            if (response.Success) { return response.Data; };

            return BadRequest(response.ListMessages);
        }

        [HttpPost]
        [Route("{BookingId}/Pay")]

        public async Task<ActionResult<PaymentResponse>> Pay(PaymentRequestDto dto, int bookingId) {

            dto.BookingId = bookingId;
            var response = _bookingManager.PayForBooking(dto);

            if (response.Success) return Ok(response.Data);

            return BadRequest(response.ListMessages);
        }
    }
}
