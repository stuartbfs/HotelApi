using HotelDomain.Data.Projections;
using HotelDomain.Model;
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

        public async Task<PageResponse<HotelRoomAvailability>> GetRoomAvailability(
            DateTime checkIn, 
            DateTime checkOut,
            int partySize,
            int page,
            int pageSize)
        {
            // Need the hotel that don't have a booking on the dates
            // Then need to also check the available rooms can accomodate
            // the party size.
            var hotelsQuery = _context.Rooms
                .Select(HotelRoomAvailability.Projection(checkIn, checkOut))
                .Where(x => !x.HasBooking)
                .GroupBy(x => x.HotelId)
                .Select(x => new
                {
                    HotelId = x.Key,
                    AvailablePartySize = x.Sum(t => t.RoomCapacity)
                })
                .Where(x => x.AvailablePartySize > partySize)
                .Select(x => x.HotelId)
                .Distinct();

            var hotelsCount = await hotelsQuery.CountAsync();

            if (hotelsCount == 0) return new PageResponse<HotelRoomAvailability>(page, pageSize, 0);
            
            var hotelIds = await hotelsQuery.Skip((page - 1) * pageSize)
                                                     .Take(pageSize)
                                                     .ToListAsync();

            // This should only happen if we are looking for an invalid page.
            if (!hotelIds.Any())
            {
                return new PageResponse<HotelRoomAvailability>(page, pageSize, hotelsCount);
            }

            return new PageResponse<HotelRoomAvailability>(page, pageSize, hotelsCount)
            {
                Items = await _context.Rooms
                    .Select(HotelRoomAvailability.Projection(checkIn, checkOut))
                    .Where(x => hotelIds.Contains(x.HotelId))
                    .Where(x => !x.HasBooking)
                    .ToListAsync()
            };
        }
    }
}
