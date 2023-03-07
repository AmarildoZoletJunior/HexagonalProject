using Application.Booking.DTOs;
using Application.Booking.Ports;
using Application.Booking.Request;
using Application.Guests.Requests;
using Application.Payment.DTOs;
using Application.Payment.PaymentResponse;
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
            if (response.Success) return Ok(response.Data);

            return BadRequest(response);
        }

        [HttpPost]
        [Route("{bookingId}/Pay")]
        public async Task<ActionResult<ResponsePayment>> Pay(
            PaymentRequestDto paymentRequest, int bookingId
            )
        {
            paymentRequest.BookingId = bookingId;
            var response = await _bookingManager.PayForBooking(paymentRequest);
            if(response.Success) { return Ok(response.Data); };

            return BadRequest(response);
        }
    }
}
