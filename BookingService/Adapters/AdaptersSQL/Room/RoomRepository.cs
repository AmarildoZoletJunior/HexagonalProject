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
            _dataContext.Rooms.Add(room);
            await _dataContext.SaveChangesAsync();
            return room.Id;
        }

        public async Task<Domain.Entities.Room> Get(int id)
        {
            return await _dataContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
