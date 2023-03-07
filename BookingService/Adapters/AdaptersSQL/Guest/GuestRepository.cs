using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Guest
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataContext _dataContext;
        public GuestRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Create(Domain.Entities.Guest guest)
        {
            _dataContext.Guests.Add(guest);
            await _dataContext.SaveChangesAsync();
            return guest.Id;
        }

        public async Task<Domain.Entities.Guest> GetGuest(int id)
        {
            return await _dataContext.Guests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
