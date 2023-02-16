using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IGuestRepository
    {
        Task<Domain.Entities.Guest> GetGuest(int id);
        Task<int> Create(Guest guest);

    }
}
