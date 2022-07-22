using HotelDomain.Data.Entities;
using HotelDomain.Model;

namespace HotelDomain.Data.Repository
{
    public interface IBookingRepository
    {
        Task<Booking> CreateBooking(BookingGenerator bookingGenerator, Guid hotelId);
    }
}