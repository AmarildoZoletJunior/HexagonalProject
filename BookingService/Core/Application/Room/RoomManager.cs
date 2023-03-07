
using Application.Guests.DTOs;
using Application.Guests.Responses;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using Application.Room.Validators;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room
{
    public class RoomManager : IRoomManager
    {
        private IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomResponse> CreateRoom(CreateRoomRequest room)
        {
            var roomDto = room.Data;
            var validator = new RoomValidator();
            var resultado = validator.Validate(roomDto);

            if (!resultado.IsValid)
            {
                return new RoomResponse
                {
                    Message = "Ocorreu um erro de validação.",
                    Success = false,
                    ListErrors = resultado.Errors.Select(x => new { x.ErrorMessage, x.PropertyName })
                };
            }

            var roomMap = RoomDto.MapToEntity(room.Data);
            await roomMap.SaveAsync(_roomRepository);
            room.Data.Id = roomMap.Id;
           return new RoomResponse
            {
                Data = room.Data,
                Success = true
            };

        }

        public async Task<RoomResponse> GetRoomById(int id)
        {
            var getRoom = await _roomRepository.GetRoom(id);
            if (getRoom != null)
            {
                return new RoomResponse
                {
                    Data = RoomDto.MapToDto(getRoom),
                    Success = true
                };
            }
            return new RoomResponse
            {
                Success = false,
                Message = "Não foi possivel encontrar esta room"
            };
        }
    }
}
