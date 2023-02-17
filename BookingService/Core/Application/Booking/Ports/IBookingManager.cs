﻿using Application.Booking.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingDto> CreateBooking(BookingDto booking);
        Task<BookingDto> GetBooking(int id);
    }
}
