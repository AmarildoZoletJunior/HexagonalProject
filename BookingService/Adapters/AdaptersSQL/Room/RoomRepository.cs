using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _dataContext;
        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> Create(Domain.Entities.Room room)
        {
            Console.Write("Este é o id que chegou" + room.Id);
            _dataContext.Rooms.Add(room);
            await _dataContext.SaveChangesAsync();
            Console.Write("Este é o id que saiu" + room.Id);
            return room.Id;
        }

        public async Task<Domain.Entities.Room> GetRoom(int id)
        {
            return await _dataContext.Rooms.Include(x => x.Bookings).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
