using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;

namespace HotelDomain.Data.Repository
{
    public interface IHotelRepository
    {
        Task<bool> IsRoomBooked(Guid roomId, DateTime checkIn, DateTime checkOut);

        Task<List<HotelRoomAvailability>> GetRoomAvailability(Guid hotelId, DateTime checkIn, DateTime checkOut);
    }
}
