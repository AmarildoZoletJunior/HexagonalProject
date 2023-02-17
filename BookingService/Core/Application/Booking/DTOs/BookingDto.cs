using Application.Guests.DTOs;
using Application.Room.DTOs;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }

        public RoomDto Room { get; set; }
        public GuestDto Guest { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private Status Status { get; set; }

    }
}
