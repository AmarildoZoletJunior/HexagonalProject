using Application.Booking.DTOs;
using Application.Booking.Request;
using Application.Booking.Response;
using Application.Payments.Request;
using Application.Payments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(CreateBookingRequest booking);
        Task<BookingDto> GetBooking(int id);
        Task<PaymentResponse> PayForBooking(PaymentRequestDto dto);
    }
}
