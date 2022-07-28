using HotelDomain.Data.Projections;

namespace HotelDomain.Queries.FindBooking
{
    public class FindBookingResponse
    {
        public FindBookingResponse(IEnumerable<BookingDetails> details)
        {
            Details = details.ToArray();
        }

        public BookingDetails[] Details { get; }
    }
}
