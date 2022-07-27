using HotelDomain.Data.Projections;

namespace HotelDomain.Queries.FindBooking
{
    public class FindBookingResponse
    {
        public BookingDetails[] Details { get; set; }
    }
}
