using HotelDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data
{
    public class HotelsDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomBooking> RoomBookings { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelsDbContext).Assembly);
        }
    }
}
