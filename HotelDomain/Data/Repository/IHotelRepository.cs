using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;

namespace HotelDomain.Data.Repository
{
    public interface IHotelRepository
    {
        Task<bool> IsRoomBooked(Guid roomId, DateTime checkIn, DateTime checkOut);

        Task<List<HotelRoomBookings>> GetRoomsStatus(Guid hotelId, DateTime checkIn, DateTime checkOut);
    }
}
