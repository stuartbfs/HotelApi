using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;
using HotelDomain.Model;

namespace HotelDomain.Data.Repository
{
    public interface IHotelsRepository
    {
        Task<PageResponse<HotelDetails>> FindHotels(string name, int page, int pageSize);

        Task<PageResponse<HotelRoomAvailability>> GetRoomAvailability(
            DateTime checkIn,
            DateTime checkOut,
            int partySize,
            int page,
            int pageSize);
    }
}
