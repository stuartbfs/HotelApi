using HotelDomain.Data.Projections;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data.Repository
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly HotelsDbContext _context;

        public HotelsRepository(HotelsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<HotelRoomAvailability>> GetRoomAvailability(DateTime checkIn, DateTime checkOut)
        {
            return await _context.Rooms
                .Select(HotelRoomAvailability.Projection(checkIn, checkOut))
                .Where(x => !x.HasBooking)
                .ToListAsync();
        }
    }
}
