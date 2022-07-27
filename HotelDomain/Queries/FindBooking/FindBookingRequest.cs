using MediatR;

namespace HotelDomain.Queries.FindBooking
{
    public class FindBookingRequest : IRequest<FindBookingResponse>
    {
        public FindBookingRequest(string bookingRef)
        {
            BookingRef = bookingRef;
        }

        public string BookingRef { get; }
    }
}
