using Application.Guests.Requests;
using Application.Guests.Responses;
using Application.Room.Requests;
using Application.Room.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Ports
{
    public interface IRoomManager
    {
        Task<RoomResponse> CreateRoom(CreateRoomRequest guest);
        public Task<RoomResponse> GetRoomById(int id);
    }
}
