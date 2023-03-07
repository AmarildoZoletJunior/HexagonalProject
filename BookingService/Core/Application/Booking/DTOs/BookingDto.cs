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
        public BookingDto()
        {
            PlacedAt = DateTime.UtcNow;
        }
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private Status Status { get; set; }


        public static Domain.Entities.Booking MapToEntity(BookingDto booking)
        {
            return new Domain.Entities.Booking
            {
                Id = booking.Id,
                End = booking.End,
                GuestId = booking.GuestId,
                RoomId = booking.RoomId ,
                Start = booking.Start
            };
        }

        public static BookingDto MapToDto(Domain.Entities.Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                End = booking.End,
                GuestId = booking.GuestId,
                RoomId = booking.RoomId,
                Start = booking.Start,
                 PlacedAt = booking.PlacedAt,
                 Status = booking.CurrentStatus
            };
        }
    }
}
