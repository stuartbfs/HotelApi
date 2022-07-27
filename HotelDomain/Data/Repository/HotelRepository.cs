using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelsDbContext _context;

        public HotelRepository(HotelsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> IsRoomBooked(Guid roomId, DateTime checkIn, DateTime checkOut)
        {
            var roomBooking = new RoomBooking { CheckIn = checkIn, CheckOut = checkOut };

            return await _context.RoomBookings.Where(x => x.Room.RoomId == roomId)
                .Where(BookingTimes.ClashExpr<RoomBooking, RoomBooking>(roomBooking))
                .AnyAsync();
        }

        public async Task<List<HotelRoomAvailability>> GetRoomAvailability(Guid hotelId, DateTime checkIn, DateTime checkOut)
        {
            return await _context.Rooms.Where(x => x.HotelId == hotelId)
                .Select(HotelRoomAvailability.Projection(checkIn, checkOut))
                .ToListAsync();
        }
    }
}
