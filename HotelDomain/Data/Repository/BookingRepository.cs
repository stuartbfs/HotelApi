using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelsDbContext _context;

        public BookingRepository(HotelsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Booking> CreateBooking(BookingGenerator bookingGenerator, Guid hotelId)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            var availableRoomsQuery = await _context.Rooms
                .Where(x => x.HotelId == hotelId)
                .Select(HotelRoomAvailability.Projection(bookingGenerator.CheckIn, bookingGenerator.CheckOut))
                .ToListAsync();

            var booking = bookingGenerator.GenerateBooking(availableRoomsQuery);
            if (booking is null) return null;
            
            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return booking;
        }
    }
}
