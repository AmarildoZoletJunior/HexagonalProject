using Application.Booking.DTOs;
using Application.Booking.Ports;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository bookRepository;

        public BookingManager(IBookingRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        } 

        public Task<BookingDto> CreateBooking(BookingDto booking)
        {
           
        }

        public Task<BookingDto> GetBooking(int id)
        {
            throw new NotImplementedException();
        }
    }
}
