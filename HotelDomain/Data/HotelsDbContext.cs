using HotelDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data
{
    public class HotelsDbContext : DbContext
    {
        public HotelsDbContext(DbContextOptions<HotelsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<RoomBooking> RoomBookings { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public DbSet<RoomType> RoomTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelsDbContext).Assembly);
        }
    }
}
