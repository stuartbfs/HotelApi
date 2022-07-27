using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;

namespace HotelDomain.Data.Repository
{
    public interface IBookingRepository
    {
        Task<bool> HotelExists(Guid hotelId);

        Task<List<BookingDetails>> GetBooking(int bookingNumber);

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
