using AdaptersSQL.Guest;
using AdaptersSQL.Room;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdaptersSQL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Domain.Entities.Guest> Guests { get; set; }
        public DbSet<Domain.Entities.Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}