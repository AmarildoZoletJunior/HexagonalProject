using Domain.Enums;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _dataContext;
        public BookingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> Create(Domain.Entities.Booking booking)
        {
            _dataContext.Bookings.Add(booking);
            _dataContext.SaveChanges();
            return booking.Id;
        }

        public async Task<Domain.Entities.Booking> GetBooking(int id)
        {
            return await _dataContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
