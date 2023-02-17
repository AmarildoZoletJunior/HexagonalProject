using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IRoomRepository
    {
        Task<Domain.Entities.Room> GetRoom(int id);
        Task<int> Create(Room room);
    }
}
