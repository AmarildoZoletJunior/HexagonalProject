using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IBookingRepository
    {
        Task<Domain.Entities.Booking> GetBooking(int id);
        Task<int> Create(Booking booking);
    }
}
