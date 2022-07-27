using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;
using HotelDomain.Exceptions;
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

        public async Task<bool> HotelExists(Guid hotelId)
        {
            return await _context.Hotels.AnyAsync(x => x.HotelId == hotelId);
        }

        public async Task<List<BookingDetails>> GetBooking(int bookingNumber)
        {
            return await _context.RoomBookings
                .Where(x => x.Booking.BookingNumber == bookingNumber)
                .Select(BookingDetails.Projection)
                .ToListAsync();
        }

        public async Task<Booking> BookRoom(
            Guid hotelId, 
            string firstName, 
            string lastName, 
            DateTime checkIn, 
            DateTime checkOut,
            string roomType,
            int partySize)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            var room = await _context.Rooms
                .Where(x => x.HotelId == hotelId)
                .Where(x => x.RoomType.Name == roomType)
                .Select(HotelRoomAvailability.Projection(checkIn, checkOut))
                .FirstOrDefaultAsync(x => !x.HasBooking);

            if (room is null)
            {
                throw new BadRequestException("No rooms available");
            }

            var booking = new Booking
            {
                BookingDate = DateTime.UtcNow,
                FirstName = firstName,
                LastName = lastName,
                Rooms = new List<RoomBooking>
                {
                    new RoomBooking
                    {
                        RoomId = room.RoomId,
                        CheckIn = checkIn,
                        CheckOut = checkOut,
                        PartySize = partySize
                    }
                }
            };

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            await tx.CommitAsync();

            return booking;
        }
    }
}
