using Application.Guests.DTOs;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public decimal Value { get; set; }
        public int Currency { get; set; }


        public static Domain.Entities.Room MapToEntity(RoomDto room)
        {
            return new Domain.Entities.Room
            {
                Id = room.Id,
                Name = room.Name,
                Level = room.Level,
                InMaintenance = room.InMaintenance,
                PriceRoom = new Price
                {
                    Currency = (AcceptedCurrencies)room.Currency,
                    Value = room.Value,
                }
            };
        }

        public static RoomDto MapToDto(Domain.Entities.Room room)
        {
            return new RoomDto
            {
                 Id=room.Id,
                Name = room.Name,
                Level = room.Level,
                InMaintenance = room.InMaintenance,
                Currency = (int)room.PriceRoom.Currency,
                Value = room.PriceRoom.Value
            };
        }




    }
}
