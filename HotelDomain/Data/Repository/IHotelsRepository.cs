using HotelDomain.Data.Projections;

namespace HotelDomain.Data.Repository
{
    public interface IHotelsRepository
    {
        Task<List<HotelRoomAvailability>> GetRoomAvailability(DateTime checkIn, DateTime checkOut);
    }
}
