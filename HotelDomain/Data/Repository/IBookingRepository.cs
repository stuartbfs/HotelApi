using HotelDomain.Data.Entities;

namespace HotelDomain.Data.Repository
{
    public interface IBookingRepository
    {
        Task<Booking> BookRoom(
            Guid hotelId,
            string firstName,
            string lastName,
            DateTime checkIn,
            DateTime checkOut,
            string roomType,
            int partySize);
    }
}
