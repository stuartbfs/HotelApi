using HotelDomain.Data.Projections;
using HotelDomain.Model;

namespace HotelDomain.Data.Repository
{
    public interface IHotelsRepository
    {
        Task<PageResponse<HotelRoomAvailability>> GetRoomAvailability(
            DateTime checkIn,
            DateTime checkOut,
            int partySize,
            int page,
            int pageSize);
    }
}
